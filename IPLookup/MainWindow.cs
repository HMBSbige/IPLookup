using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LumiSoft.Net.DNS;
using LumiSoft.Net.DNS.Client;

namespace IPLookup
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            db1.Load(@"17monipdb_cn.dat");
            db2.Load(@"17monipdb_en.dat");
            _czip.Load(@"QQWry.dat");
            // 监视剪贴板
            AddClipboardFormatListener(Handle);
            AutoLookupIP = AutoLookup;
        }
        // Windows API Clipboard
        [DllImport(@"user32.dll")]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport(@"user32.dll")]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        // 定义、声明回调
        private delegate void AutoLookupIP_dele();
        private AutoLookupIP_dele AutoLookupIP;

        private readonly IPIPdotNET db1 = new IPIPdotNET(),db2 = new IPIPdotNET();
        private readonly CZIP _czip = new CZIP();

        private void LookupIP(string strIP)
        {
            for (var i = 0; i < dataGridView1.RowCount; ++i)
            {
                if (dataGridView1.Rows[i].Cells[@"IP"].Value.ToString() == strIP)
                {
                    return;
                }
            }
            var cn_location = db1.GetLocation(strIP);
            var en_location = db2.GetLocation(strIP);
            var location = _czip.GetLocation(strIP);
            var Index = dataGridView1.Rows.Add();
            dataGridView1.Rows[Index].Cells[@"index"].Value = (Index + 1).ToString();
            dataGridView1.Rows[Index].Cells[@"IP"].Value = strIP;
            dataGridView1.Rows[Index].Cells[@"IPIPNETCN"].Value = string.Join(",", cn_location);
            dataGridView1.Rows[Index].Cells[@"IPIPNETEn"].Value = string.Join(",", en_location);
            dataGridView1.Rows[Index].Cells[@"CZDB"].Value = string.Join(",", location);
        }
        private void Lookup_button_Click(object sender, EventArgs e)
        {
            LookupIP(ip_Textbox.Text);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex < 0)
                return;
            dataGridView1.ClearSelection();
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            TableRightMenu.Show(MousePosition.X, MousePosition.Y);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Clipboard.SetDataObject(dataGridView1.SelectedCells[0].Value);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 停止监视剪贴板
            RemoveClipboardFormatListener(Handle);
        }

        private void GetIP_button_Click(object sender, EventArgs e)
        {
            localIP_Textbox.Text = IPIPdotNET.GetLocalIP();
        }

        private void AutoLookup()
        {
            if (Clipboard.ContainsText())
            {
                var t = Clipboard.GetText();
                if (IPIPdotNET.IsIPv4(ref t))
                {
                    ip_Textbox.Text = t;
                    LookupIP(ip_Textbox.Text);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AutoLookupIP = AutoLookup;
            }
            else
            {
                AutoLookupIP = null;
            }
        }
        
        private static string[] Nslookup(string hostname)
        {
            try
            {
                var IPAddrs = Dns.GetHostAddresses(hostname);
                return IPAddrs.Select(IPAddr => IPAddr.ToString()).ToArray();
            }
            catch (Exception e)
            {
                return new []{ e.Message };
            }
        }

        private string[] Nslookup(string hostname,string[] DnsServers)
        {
            Dns_Client.DnsServers = DnsServers;
            Dns_Client.UseDnsCache = false;
            using (var dns = new Dns_Client())
            {
                var reponse = dns.Query(hostname, DNS_QType.A);

                if (reponse == null || !reponse.ConnectionOk)
                {
                    HTTPStatus.Text = @"DNS 服务器无响应";
                    return new []{@""};
                }

                HTTPStatus.Text = @"服务器响应: " + reponse.ResponseCode;

                var iplist = new List<string>();
                var records = reponse.Answers;
                for (var i = 0; i < reponse.Answers.Length; i++)
                {
                    var record = records[i];
                    if (record.RecordType == DNS_QType.A)
                    {
                        var aRec = (DNS_rr_A)record;
                        
                        iplist.Add(aRec.IP.ToString());
                    }
                }
                return iplist.ToArray();
            }
        }

        private void nslookupButton_Click(object sender, EventArgs e)
        {
            string[] iplist;
            if (DNSServer.Text == @"系统DNS")
            {
                iplist = Nslookup(hostnameTextBox.Text);
                if (iplist.Length != 0)
                {
                    hostIPTextBox.Text = iplist[0];
                    HTTPStatus.Text = @"系统DNS解析成功";
                }
                else
                {
                    hostIPTextBox.Text = @"";
                    HTTPStatus.Text = @"系统DNS解析失败";
                }
            }
            else
            {
                iplist = Nslookup(hostnameTextBox.Text, new[] { DNSServer.Text });
                hostIPTextBox.Text = iplist.Length != 0 ? iplist[0] : @"";
            }
        }

        /// <summary>
        /// 当剪贴板内容改变时，如果内容为IPv4地址时自动查询
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x031D)
            {
                AutoLookupIP?.Invoke();
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }
    }
}