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
            this.Lookup_button = new System.Windows.Forms.Button();
            this.Result_Textbox = new System.Windows.Forms.TextBox();
            this.IP_Textbox = new System.Windows.Forms.TextBox();
            this.GetIP_button = new System.Windows.Forms.Button();
            this.localIP_Textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lookup_button
            // 
            this.Lookup_button.Location = new System.Drawing.Point(150, 30);
            this.Lookup_button.Name = "Lookup_button";
            this.Lookup_button.Size = new System.Drawing.Size(91, 29);
            this.Lookup_button.TabIndex = 0;
            this.Lookup_button.Text = "查询";
            this.Lookup_button.UseVisualStyleBackColor = true;
            this.Lookup_button.Click += new System.EventHandler(this.Lookup_button_Click);
            // 
            // Result_Textbox
            // 
            this.Result_Textbox.Location = new System.Drawing.Point(23, 79);
            this.Result_Textbox.Multiline = true;
            this.Result_Textbox.Name = "Result_Textbox";
            this.Result_Textbox.Size = new System.Drawing.Size(490, 121);
            this.Result_Textbox.TabIndex = 1;
            // 
            // IP_Textbox
            // 
            this.IP_Textbox.Location = new System.Drawing.Point(39, 35);
            this.IP_Textbox.Name = "IP_Textbox";
            this.IP_Textbox.Size = new System.Drawing.Size(105, 21);
            this.IP_Textbox.TabIndex = 2;
            this.IP_Textbox.Text = "59.43.248.105";
            // 
            // GetIP_button
            // 
            this.GetIP_button.Location = new System.Drawing.Point(404, 30);
            this.GetIP_button.Name = "GetIP_button";
            this.GetIP_button.Size = new System.Drawing.Size(98, 29);
            this.GetIP_button.TabIndex = 3;
            this.GetIP_button.Text = "获取公网IP";
            this.GetIP_button.UseVisualStyleBackColor = true;
            this.GetIP_button.Click += new System.EventHandler(this.GetIP_button_Click);
            // 
            // localIP_Textbox
            // 
            this.localIP_Textbox.Location = new System.Drawing.Point(289, 35);
            this.localIP_Textbox.Name = "localIP_Textbox";
            this.localIP_Textbox.ReadOnly = true;
            this.localIP_Textbox.Size = new System.Drawing.Size(100, 21);
            this.localIP_Textbox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.localIP_Textbox);
            this.Controls.Add(this.GetIP_button);
            this.Controls.Add(this.IP_Textbox);
            this.Controls.Add(this.Result_Textbox);
            this.Controls.Add(this.Lookup_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Lookup IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lookup_button;
        private System.Windows.Forms.TextBox Result_Textbox;
        private System.Windows.Forms.TextBox IP_Textbox;
        private System.Windows.Forms.Button GetIP_button;
        private System.Windows.Forms.TextBox localIP_Textbox;
        private System.Windows.Forms.Button button1;
    }
}

