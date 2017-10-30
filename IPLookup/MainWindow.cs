using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

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
        }

        private readonly IPIPdotNET db1 = new IPIPdotNET(),db2 = new IPIPdotNET();
        private readonly CZIP _czip = new CZIP();

        private void Lookup_button_Click(object sender, EventArgs e)
        {
            var cn_location = db1.GetLocation(IP_Textbox.Text);
            var en_location = db2.GetLocation(IP_Textbox.Text);
            var location = _czip.GetLocation(IP_Textbox.Text);
            Result_Textbox.Text= string.Join(",", cn_location) + Environment.NewLine + 
                                 string.Join(",", en_location) + Environment.NewLine +
                                 string.Join(",", location);
        }

        private void GetIP_button_Click(object sender, EventArgs e)
        {
            Result_Textbox.Text = GetLocalIP();
        }

        private string GetLocalIP()
        {
            string IP = @"0.0.0.0";
            WebRequest wr = WebRequest.Create("https://myip.ipip.net/");
            Stream s = wr.GetResponse().GetResponseStream();
            if (s != null)
            {
                StreamReader sr = new StreamReader(s, Encoding.UTF8);
                IP = sr.ReadToEnd();
                int start = IP.IndexOf(@"当前 IP：", StringComparison.Ordinal) + 6;
                int end = IP.IndexOf(@"  来自于：", start, StringComparison.Ordinal);
                IP = IP.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            return IP;
        }
    }
}