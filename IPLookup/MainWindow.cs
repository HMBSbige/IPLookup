using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Result_Textbox.Text = aliyun_domain.Test().ToString();
        }

        private void GetIP_button_Click(object sender, EventArgs e)
        {
            localIP_Textbox.Text = IPIPdotNET.GetLocalIP();
        }
    }
}