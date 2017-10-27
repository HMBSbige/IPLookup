using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLookup
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void RemoveEmptyString(ref string[] raw)
        {
            raw = raw.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IPIPdotNET.EnableFileWatch = true;
            IPIPdotNET.Load(@"D:\Downloads\17monipdb.dat");
            var location = IPIPdotNET.Find(IP_Textbox.Text);
            RemoveEmptyString(ref location);
            location = location.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Result_Textbox.Text= string.Join(",", location);            
        }
    }
}
