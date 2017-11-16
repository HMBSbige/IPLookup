namespace IPLookup
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPIPNETCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPIPNETEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CZDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.IP_Textbox = new System.Windows.Forms.ToolStripTextBox();
            this.Lookup_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.localIP_Textbox = new System.Windows.Forms.ToolStripTextBox();
            this.GetIP_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TableRightMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.IP,
            this.IPIPNETCN,
            this.IPIPNETEn,
            this.CZDB});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(722, 412);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // index
            // 
            this.index.FillWeight = 20F;
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.FillWeight = 35F;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // IPIPNETCN
            // 
            this.IPIPNETCN.FillWeight = 35F;
            this.IPIPNETCN.HeaderText = "IPIPNET CN";
            this.IPIPNETCN.Name = "IPIPNETCN";
            this.IPIPNETCN.ReadOnly = true;
            // 
            // IPIPNETEn
            // 
            this.IPIPNETEn.HeaderText = "IPIPNET EN";
            this.IPIPNETEn.Name = "IPIPNETEn";
            this.IPIPNETEn.ReadOnly = true;
            // 
            // CZDB
            // 
            this.CZDB.FillWeight = 50F;
            this.CZDB.HeaderText = "纯真";
            this.CZDB.Name = "CZDB";
            this.CZDB.ReadOnly = true;
            // 
            // TableRightMenu
            // 
            this.TableRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem});
            this.TableRightMenu.Name = "contextMenuStrip1";
            this.TableRightMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(364, 5);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 20);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "监视剪贴板";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 469);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IP查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HTTP状态查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.IP_Textbox,
            this.Lookup_button,
            this.toolStripSeparator1,
            this.localIP_Textbox,
            this.GetIP_button,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(722, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // IP_Textbox
            // 
            this.IP_Textbox.Name = "IP_Textbox";
            this.IP_Textbox.Size = new System.Drawing.Size(100, 25);
            this.IP_Textbox.Text = "59.43.248.105";
            // 
            // Lookup_button
            // 
            this.Lookup_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Lookup_button.Image = ((System.Drawing.Image)(resources.GetObject("Lookup_button.Image")));
            this.Lookup_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Lookup_button.Name = "Lookup_button";
            this.Lookup_button.Size = new System.Drawing.Size(36, 22);
            this.Lookup_button.Text = "查询";
            this.Lookup_button.Click += new System.EventHandler(this.Lookup_button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // localIP_Textbox
            // 
            this.localIP_Textbox.Name = "localIP_Textbox";
            this.localIP_Textbox.ReadOnly = true;
            this.localIP_Textbox.Size = new System.Drawing.Size(100, 25);
            // 
            // GetIP_button
            // 
            this.GetIP_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GetIP_button.Image = ((System.Drawing.Image)(resources.GetObject("GetIP_button.Image")));
            this.GetIP_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GetIP_button.Name = "GetIP_button";
            this.GetIP_button.Size = new System.Drawing.Size(71, 22);
            this.GetIP_button.Text = "获取公网IP";
            this.GetIP_button.Click += new System.EventHandler(this.GetIP_button_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "IP：";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 469);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "MainWindow";
            this.Text = "Lookup IP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TableRightMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip TableRightMenu;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPIPNETCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPIPNETEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CZDB;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox IP_Textbox;
        private System.Windows.Forms.ToolStripButton Lookup_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox localIP_Textbox;
        private System.Windows.Forms.ToolStripButton GetIP_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

