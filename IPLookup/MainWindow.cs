using System;
using System.Windows.Forms;

namespace IPLookup
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            db1.Load(@"D:\Downloads\17monipdb_cn.dat");
            db2.Load(@"D:\Downloads\17monipdb_en.dat");
            _czip.Load(@"D:\Downloads\QQWry.dat");
        }

        private readonly IPIPdotNET db1 = new IPIPdotNET(),db2 = new IPIPdotNET();
        private readonly CZIP _czip = new CZIP();

        private void Lookup_button_Click(object sender, EventArgs e)
        {
            var cn_location = db1.GetLocation(IP_Textbox.Text);
            var en_location = db2.GetLocation(IP_Textbox.Text);

            Result_Textbox.Text= string.Join(",", cn_location) + Environment.NewLine + string.Join(",", en_location);

            CZIP.location loc = _czip.GetLocation(IP_Textbox.Text);
            Result_Textbox.Text += Environment.NewLine + loc.country + @"," + loc.area;
        }
    }
}