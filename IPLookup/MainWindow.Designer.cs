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
            this.SuspendLayout();
            // 
            // Lookup_button
            // 
            this.Lookup_button.Location = new System.Drawing.Point(195, 30);
            this.Lookup_button.Name = "Lookup_button";
            this.Lookup_button.Size = new System.Drawing.Size(91, 29);
            this.Lookup_button.TabIndex = 0;
            this.Lookup_button.Text = "查询";
            this.Lookup_button.UseVisualStyleBackColor = true;
            this.Lookup_button.Click += new System.EventHandler(this.Lookup_button_Click);
            // 
            // Result_Textbox
            // 
            this.Result_Textbox.Location = new System.Drawing.Point(39, 78);
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
            this.IP_Textbox.Text = "218.30.48.174";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 260);
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
    }
}

