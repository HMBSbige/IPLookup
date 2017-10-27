using System;
using System.Linq;
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
        }

        private readonly IPIPdotNET db1 = new IPIPdotNET(),db2 = new IPIPdotNET();

        private static void RemoveEmptyString(ref string[] raw)
        {
            raw = raw.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }
        private void Lookup_button_Click(object sender, EventArgs e)
        {
            var cn_location = db1.Find(IP_Textbox.Text);
            var en_location = db2.Find(IP_Textbox.Text);
            RemoveEmptyString(ref cn_location);
            RemoveEmptyString(ref en_location);

            Result_Textbox.Text= string.Join(",", cn_location) + Environment.NewLine + string.Join(",", en_location);            
        }
    }
}
