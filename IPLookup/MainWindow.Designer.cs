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
            this.Table1RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IPaddressLookup = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ip_Textbox = new System.Windows.Forms.ToolStripTextBox();
            this.iplookup_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.localIP_Textbox = new System.Windows.Forms.ToolStripTextBox();
            this.getIP_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dalay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.HTTPStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.HttpResult = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.hostnameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.DNSServer = new System.Windows.Forms.ToolStripComboBox();
            this.nslookupButton = new System.Windows.Forms.ToolStripButton();
            this.hostIPTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.HTTPStatusButton = new System.Windows.Forms.ToolStripButton();
            this.Table2RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Table1RightMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.IPaddressLookup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.HttpResult.SuspendLayout();
            this.Table2RightMenu.SuspendLayout();
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
            // Table1RightMenu
            // 
            this.Table1RightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem});
            this.Table1RightMenu.Name = "contextMenuStrip1";
            this.Table1RightMenu.Size = new System.Drawing.Size(101, 26);
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
            this.tabPage1.Controls.Add(this.IPaddressLookup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IP查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // IPaddressLookup
            // 
            this.IPaddressLookup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.IPaddressLookup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ip_Textbox,
            this.iplookup_button,
            this.toolStripSeparator1,
            this.localIP_Textbox,
            this.getIP_button,
            this.toolStripSeparator2});
            this.IPaddressLookup.Location = new System.Drawing.Point(3, 3);
            this.IPaddressLookup.Name = "IPaddressLookup";
            this.IPaddressLookup.Size = new System.Drawing.Size(722, 25);
            this.IPaddressLookup.TabIndex = 8;
            this.IPaddressLookup.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "IP：";
            // 
            // ip_Textbox
            // 
            this.ip_Textbox.Name = "ip_Textbox";
            this.ip_Textbox.Size = new System.Drawing.Size(100, 25);
            this.ip_Textbox.Text = "59.43.248.105";
            // 
            // iplookup_button
            // 
            this.iplookup_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.iplookup_button.Image = ((System.Drawing.Image)(resources.GetObject("iplookup_button.Image")));
            this.iplookup_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iplookup_button.Name = "iplookup_button";
            this.iplookup_button.Size = new System.Drawing.Size(36, 22);
            this.iplookup_button.Text = "查询";
            this.iplookup_button.Click += new System.EventHandler(this.Lookup_button_Click);
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
            // getIP_button
            // 
            this.getIP_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.getIP_button.Image = ((System.Drawing.Image)(resources.GetObject("getIP_button.Image")));
            this.getIP_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.getIP_button.Name = "getIP_button";
            this.getIP_button.Size = new System.Drawing.Size(71, 22);
            this.getIP_button.Text = "获取公网IP";
            this.getIP_button.Click += new System.EventHandler(this.GetIP_button_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.statusStrip1);
            this.tabPage2.Controls.Add(this.HttpResult);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HTTP状态查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hostname,
            this.Host,
            this.Dalay,
            this.Status});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(722, 390);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDown);
            // 
            // Hostname
            // 
            this.Hostname.HeaderText = "主机名";
            this.Hostname.Name = "Hostname";
            this.Hostname.ReadOnly = true;
            // 
            // Host
            // 
            this.Host.HeaderText = "IP";
            this.Host.Name = "Host";
            this.Host.ReadOnly = true;
            // 
            // Dalay
            // 
            this.Dalay.HeaderText = "延迟";
            this.Dalay.Name = "Dalay";
            this.Dalay.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "HTTP状态码";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HTTPStatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(722, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // HTTPStatus
            // 
            this.HTTPStatus.Name = "HTTPStatus";
            this.HTTPStatus.Size = new System.Drawing.Size(308, 17);
            this.HTTPStatus.Text = "服务器 IP 为空时，程序将自动根据IE代理获取HTTP状态";
            // 
            // HttpResult
            // 
            this.HttpResult.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.HttpResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.hostnameTextBox,
            this.DNSServer,
            this.nslookupButton,
            this.hostIPTextBox,
            this.HTTPStatusButton});
            this.HttpResult.Location = new System.Drawing.Point(3, 3);
            this.HttpResult.Name = "HttpResult";
            this.HttpResult.Size = new System.Drawing.Size(722, 25);
            this.HttpResult.TabIndex = 1;
            this.HttpResult.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "主机名：";
            // 
            // hostnameTextBox
            // 
            this.hostnameTextBox.Name = "hostnameTextBox";
            this.hostnameTextBox.Size = new System.Drawing.Size(200, 25);
            this.hostnameTextBox.Text = "store.steampowered.com";
            // 
            // DNSServer
            // 
            this.DNSServer.Items.AddRange(new object[] {
            "系统DNS",
            "115.159.223.25",
            "114.114.114.114",
            "114.114.115.115",
            "119.29.29.29",
            "182.254.116.116",
            "182.254.118.118",
            "180.76.76.76",
            "223.5.5.5",
            "223.6.6.6",
            "1.2.4.8",
            "210.2.4.8",
            "8.8.8.8",
            "8.8.4.4",
            "9.9.9.9"});
            this.DNSServer.Name = "DNSServer";
            this.DNSServer.Size = new System.Drawing.Size(121, 25);
            this.DNSServer.Text = "系统DNS";
            // 
            // nslookupButton
            // 
            this.nslookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nslookupButton.Image = ((System.Drawing.Image)(resources.GetObject("nslookupButton.Image")));
            this.nslookupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nslookupButton.Name = "nslookupButton";
            this.nslookupButton.Size = new System.Drawing.Size(48, 22);
            this.nslookupButton.Text = "解析→";
            this.nslookupButton.Click += new System.EventHandler(this.nslookupButton_Click);
            // 
            // hostIPTextBox
            // 
            this.hostIPTextBox.Name = "hostIPTextBox";
            this.hostIPTextBox.Size = new System.Drawing.Size(100, 25);
            this.hostIPTextBox.ToolTipText = "服务端 IP";
            // 
            // HTTPStatusButton
            // 
            this.HTTPStatusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HTTPStatusButton.Image = ((System.Drawing.Image)(resources.GetObject("HTTPStatusButton.Image")));
            this.HTTPStatusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HTTPStatusButton.Name = "HTTPStatusButton";
            this.HTTPStatusButton.Size = new System.Drawing.Size(90, 22);
            this.HTTPStatusButton.Text = "查询HTTP状态";
            this.HTTPStatusButton.Click += new System.EventHandler(this.HTTPStatusButton_Click);
            // 
            // Table2RightMenu
            // 
            this.Table2RightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.Table2RightMenu.Name = "contextMenuStrip1";
            this.Table2RightMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "复制";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            this.Table1RightMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.IPaddressLookup.ResumeLayout(false);
            this.IPaddressLookup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.HttpResult.ResumeLayout(false);
            this.HttpResult.PerformLayout();
            this.Table2RightMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip Table1RightMenu;
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
        private System.Windows.Forms.ToolStrip IPaddressLookup;
        private System.Windows.Forms.ToolStripTextBox ip_Textbox;
        private System.Windows.Forms.ToolStripButton iplookup_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox localIP_Textbox;
        private System.Windows.Forms.ToolStripButton getIP_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip HttpResult;
        private System.Windows.Forms.ToolStripTextBox hostnameTextBox;
        private System.Windows.Forms.ToolStripButton nslookupButton;
        private System.Windows.Forms.ToolStripTextBox hostIPTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel HTTPStatus;
        private System.Windows.Forms.ToolStripComboBox DNSServer;
        private System.Windows.Forms.ToolStripButton HTTPStatusButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dalay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ContextMenuStrip Table2RightMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

