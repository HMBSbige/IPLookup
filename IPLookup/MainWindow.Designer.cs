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
            this.Lookup_button = new System.Windows.Forms.Button();
            this.IP_Textbox = new System.Windows.Forms.TextBox();
            this.GetIP_button = new System.Windows.Forms.Button();
            this.localIP_Textbox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPIPNETCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPIPNETEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CZDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lookup_button
            // 
            this.Lookup_button.Location = new System.Drawing.Point(133, 32);
            this.Lookup_button.Name = "Lookup_button";
            this.Lookup_button.Size = new System.Drawing.Size(91, 22);
            this.Lookup_button.TabIndex = 0;
            this.Lookup_button.Text = "查询";
            this.Lookup_button.UseVisualStyleBackColor = true;
            this.Lookup_button.Click += new System.EventHandler(this.Lookup_button_Click);
            // 
            // IP_Textbox
            // 
            this.IP_Textbox.Location = new System.Drawing.Point(22, 33);
            this.IP_Textbox.Name = "IP_Textbox";
            this.IP_Textbox.Size = new System.Drawing.Size(105, 21);
            this.IP_Textbox.TabIndex = 2;
            this.IP_Textbox.Text = "59.43.248.105";
            // 
            // GetIP_button
            // 
            this.GetIP_button.Location = new System.Drawing.Point(336, 32);
            this.GetIP_button.Name = "GetIP_button";
            this.GetIP_button.Size = new System.Drawing.Size(99, 22);
            this.GetIP_button.TabIndex = 3;
            this.GetIP_button.Text = "获取公网IP";
            this.GetIP_button.UseVisualStyleBackColor = true;
            this.GetIP_button.Click += new System.EventHandler(this.GetIP_button_Click);
            // 
            // localIP_Textbox
            // 
            this.localIP_Textbox.Location = new System.Drawing.Point(230, 33);
            this.localIP_Textbox.Name = "localIP_Textbox";
            this.localIP_Textbox.ReadOnly = true;
            this.localIP_Textbox.Size = new System.Drawing.Size(100, 21);
            this.localIP_Textbox.TabIndex = 4;
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
            this.dataGridView1.Location = new System.Drawing.Point(22, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(638, 356);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
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
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(486, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "监视剪贴板";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 443);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.localIP_Textbox);
            this.Controls.Add(this.GetIP_button);
            this.Controls.Add(this.IP_Textbox);
            this.Controls.Add(this.Lookup_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Lookup IP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lookup_button;
        private System.Windows.Forms.TextBox IP_Textbox;
        private System.Windows.Forms.Button GetIP_button;
        private System.Windows.Forms.TextBox localIP_Textbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPIPNETCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPIPNETEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CZDB;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

