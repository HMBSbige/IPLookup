using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        private delegate void UpdateDataGridView2_Delegate(D2data dd);

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
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
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

        private const int Timeout = 3000;

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
            try
            {
                Dns_Client.DnsServers = DnsServers;
            }
            catch (Exception ex)
            {
                HTTPStatus.Text = @"DNS 服务器错误: "+ex.Message;
                return new string[0];
            }
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

        private void HTTPStatusButton_Click(object sender, EventArgs e)
        {
            HTTPStatusButton.Enabled = false;
            Task t = new Task(() =>
            {
                var dd=TestHttpWithIp(hostnameTextBox.Text.Trim(), hostIPTextBox.Text.Trim(), Timeout);
                BeginInvoke(new UpdateDataGridView2_Delegate(UpdateDataGridView2),dd);
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

        private void ReadFromJsonButton_Click(object sender, EventArgs e)
        {
            ReadFromJsonButton.Enabled = false;
            var dia = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Title = @"请选择文件",
                Filter = @"|*.json"
            };
            dia.ShowDialog();
            var JSONfilename = dia.FileName;
            if (string.IsNullOrEmpty(JSONfilename))
            {
                ReadFromJsonButton.Enabled = true;
                return;
            }
            List<HostList> list = JsonReader.ReadList(JSONfilename);
            if (list == null)
            {
                HTTPStatus.Text = @"列表读取错误";
                ReadFromJsonButton.Enabled = true;
                return;
            }
            HTTPStatus.Text = @"列表读取成功";
            Parallel.ForEach(list, l =>
            {
                Task.Run(() =>
                {
                    var dd = TestHttpWithIp(l.host.Trim(), l.ip.Trim(), Timeout);
                    BeginInvoke(new UpdateDataGridView2_Delegate(UpdateDataGridView2), dd);
                });
            });
            ReadFromJsonButton.Enabled = true;
        }

        private void UpdateDataGridView2(D2data dd)
        {
            var Index = dataGridView2.Rows.Add();
            dataGridView2.Rows[Index].Cells[@"Hostname"].Value = dd.hostname;
            dataGridView2.Rows[Index].Cells[@"Host"].Value = dd.ip;
            if (dd.dalay < 2000)
            {
                dataGridView2.Rows[Index].Cells[@"Dalay"].Style.ForeColor = Color.Green;
            }
            else if (dd.dalay < 3000)
            {
                dataGridView2.Rows[Index].Cells[@"Dalay"].Style.ForeColor = Color.Coral;
            }
            else
            {
                dataGridView2.Rows[Index].Cells[@"Dalay"].Style.ForeColor = Color.Red;
            }
            dataGridView2.Rows[Index].Cells[@"Dalay"].Value = dd.dalay;
            dataGridView2.Rows[Index].Cells[@"Status"].Value = dd.status;
            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.Rows.Count - 1;
        }

        private struct D2data
        {
            public string hostname;
            public string ip;
            public int dalay;
            public string status;
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void 导出列表到JSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Title = @"请选择要保存的文件",
                Filter = @"|*.json"
            };
            sfd.ShowDialog(this);

            var Path = sfd.FileName;
            var num = dataGridView2.Rows.Count;
            var list=new List<HostList>();
            for (var i = 0; i < num; ++i)
            {
                var hl = new HostList
                {
                    host = dataGridView2.Rows[i].Cells[@"Hostname"].Value.ToString(),
                    ip = dataGridView2.Rows[i].Cells[@"Host"].Value.ToString()
                };
                list.Add(hl);
            }
            try
            {
                JsonReader.WriteList(Path, list);
                HTTPStatus.Text = @"导出成功";
            }
            catch
            {
                HTTPStatus.Text = @"导出失败";
            }
        }

        private static D2data TestHttpWithIp(string hostname,string ip, int timeout)
        {
            D2data dd = new D2data
            {
                hostname = hostname,
                ip=ip
            };
            var request = (HttpWebRequest)WebRequest.Create(@"http://" + hostname + @"/");
            try
            {
                request.Timeout = timeout;
               
                if (!string.IsNullOrEmpty(ip))
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
                dd.ip = remoteEP?.Address.ToString() ?? request.Address.Host;
                dd.dalay = (int) timeSpan.TotalMilliseconds;
                dd.status = Convert.ToInt32(response.StatusCode).ToString();
            }
            catch (WebException ex)
            {
                var res = (HttpWebResponse) ex.Response;
                var status = res == null ? ex.Message : Convert.ToInt32(res.StatusCode).ToString();
                dd.dalay = timeout;
                dd.status = status;
            }
            finally
            {
                request.Abort();
            }
            return dd;
        }

        #endregion
    }
}