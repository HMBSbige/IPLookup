using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
            HttpLookup = TestHttpWithIp;
            //不缓存ServicePoint
            ServicePointManager.MaxServicePointIdleTime = 0;
        }

        #region ClipboardMonitor

        // Windows API Clipboard
        [DllImport(@"user32.dll")]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport(@"user32.dll")]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        private VoidMethod_Delegate AutoLookupIP;

        private void AutoLookup()
        {
            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                if (IPIPdotNET.IsIPv4(ref text))
                {
                    ip_Textbox.Text = text;

                    iplookup_button.Enabled = false;
                    Task t = new Task(() =>
                    {
                        BeginInvoke(new VoidMethod_Delegate(() =>
                        {
                            LookupIP(ip_Textbox.Text);
                        }));
                    });
                    t.Start();
                    t.ContinueWith(task =>
                    {
                        BeginInvoke(new VoidMethod_Delegate(() =>
                        {
                            iplookup_button.Enabled = true;
                        }));
                    });
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

        #endregion

        // 定义回调
        private delegate void VoidMethod_Delegate();
        private delegate void SSI_Delegate(string a,string b,int c);

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 停止监视剪贴板
            RemoveClipboardFormatListener(Handle);
        }

        #region IPlookup
        
        private readonly IPIPdotNET db1 = new IPIPdotNET(), db2 = new IPIPdotNET();
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
            iplookup_button.Enabled = false;
            Task t = new Task(() =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
                {
                    LookupIP(ip_Textbox.Text);
                }));
            });
            t.Start();
            t.ContinueWith(task =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
                {
                    iplookup_button.Enabled = true;
                }));
            });
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex < 0)
                return;
            dataGridView1.ClearSelection();
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            Table1RightMenu.Show(MousePosition.X, MousePosition.Y);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Clipboard.SetDataObject(dataGridView1.SelectedCells[0].Value);
            }
        }

        private void GetIP_button_Click(object sender, EventArgs e)
        {
            getIP_button.Enabled = false;
            Task t=new Task(() =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
                {
                    localIP_Textbox.Text = IPIPdotNET.GetLocalIP();
                }));
            });
            t.Start();
            t.ContinueWith(task =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
                {
                    getIP_button.Enabled = true;
                }));
            });
        }

        #endregion

        #region HTTPlookup

        private static string[] Nslookup(string hostname)
        {
            try
            {
                var IPAddrs = Dns.GetHostAddresses(hostname);
                return IPAddrs.Select(IPAddr => IPAddr.ToString()).ToArray();
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        private string[] Nslookup(string hostname, string[] DnsServers)
        {
            Dns_Client.DnsServers = DnsServers;
            Dns_Client.UseDnsCache = false;
            using (var dns = new Dns_Client())
            {
                var reponse = dns.Query(hostname, DNS_QType.A);

                if (reponse == null || !reponse.ConnectionOk)
                {
                    HTTPStatus.Text = @"DNS 服务器无响应";
                    return new[] { @"" };
                }

                HTTPStatus.Text = @"DNS 服务器响应: " + reponse.ResponseCode;

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
            nslookupButton.Enabled = false;
            Task t = new Task(() =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
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
                }));
            });
            t.Start();
            t.ContinueWith(task =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
                {
                    nslookupButton.Enabled = true;
                }));
            });
        }

        private readonly SSI_Delegate HttpLookup;

        private void HTTPStatusButton_Click(object sender, EventArgs e)
        {
            HTTPStatusButton.Enabled = false;
            Task t = new Task(() =>
            {
                BeginInvoke(HttpLookup,hostnameTextBox.Text.Trim(), hostIPTextBox.Text.Trim(), 3000);
                
            });
            t.Start();
            t.ContinueWith(task =>
            {
                BeginInvoke(new VoidMethod_Delegate(() =>
                {
                    HTTPStatusButton.Enabled = true;
                }));
            });
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex < 0)
                return;
            dataGridView2.ClearSelection();
            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            Table2RightMenu.Show(MousePosition.X, MousePosition.Y);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Clipboard.SetDataObject(dataGridView2.SelectedCells[0].Value);
            }
        }

        private void TestHttpWithIp(string hostname,string ip, int timeout)
        {
            var Index = dataGridView2.Rows.Add();
            dataGridView2.Rows[Index].Cells[@"Hostname"].Value = hostname;
            dataGridView2.Rows[Index].Cells[@"Host"].Value = ip;
            var request = (HttpWebRequest)WebRequest.Create(@"http://" + hostname + @"/");
            try
            {
                request.Timeout = timeout;
               
                if (!string.IsNullOrEmpty(hostIPTextBox.Text))
                {
                    request.Proxy = new WebProxy(ip);
                }

                //获取服务端 IP
                IPEndPoint remoteEP = null;
                request.ServicePoint.BindIPEndPointDelegate = delegate(ServicePoint servicePoint,IPEndPoint remoteEndPoint, int retryCount)
                {
                    remoteEP = remoteEndPoint;
                    return null;
                };

                var timer = new Stopwatch();
                timer.Start();

                var response = (HttpWebResponse) request.GetResponse();
                response.Close();

                timer.Stop();

                var timeSpan = timer.Elapsed;
                dataGridView2.Rows[Index].Cells[@"Host"].Value = remoteEP?.Address.ToString() ?? request.Address.Host;
                var dalay = (int) timeSpan.TotalMilliseconds;
                dataGridView2.Rows[Index].Cells[@"Dalay"].Style.ForeColor = dalay < 2000 ? Color.Green : Color.Coral;
                dataGridView2.Rows[Index].Cells[@"Dalay"].Value = dalay.ToString(CultureInfo.InvariantCulture) + @"ms";
                dataGridView2.Rows[Index].Cells[@"Status"].Value = Convert.ToInt32(response.StatusCode).ToString();
            }
            catch (WebException ex)
            {
                var res = (HttpWebResponse) ex.Response;
                var status = res == null ? ex.Message : Convert.ToInt32(res.StatusCode).ToString();
                dataGridView2.Rows[Index].Cells[@"Dalay"].Style.ForeColor = Color.Red;
                dataGridView2.Rows[Index].Cells[@"Dalay"].Value = timeout + @"ms";
                dataGridView2.Rows[Index].Cells[@"Status"].Value = status;
            }
            finally
            {
                request.Abort();
            }
        }

        #endregion
    }
}