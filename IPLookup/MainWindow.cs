using System;
using System.Runtime.InteropServices;
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
            // 监视剪贴板
            AddClipboardFormatListener(Handle);
            AutoLookupIP = AutoLookup;
        }
        // Windows API Clipboard
        [DllImport("user32.dll")]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll")]
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
            LookupIP(IP_Textbox.Text);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex < 0)
                return;
            dataGridView1.ClearSelection();
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
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
                    IP_Textbox.Text = t;
                    LookupIP(IP_Textbox.Text);
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
    }
}