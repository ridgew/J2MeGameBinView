namespace GameBinView
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.tbxBinView = new System.Windows.Forms.TextBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxCharset = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.cbxRevert = new System.Windows.Forms.CheckBox();
            this.btnGenBin = new System.Windows.Forms.Button();
            this.btnBase64En = new System.Windows.Forms.Button();
            this.btnBase64De = new System.Windows.Forms.Button();
            this.bin2Part = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tStripLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxInput
            // 
            this.tbxInput.Location = new System.Drawing.Point(87, 32);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(443, 21);
            this.tbxInput.TabIndex = 0;
            // 
            // tbxBinView
            // 
            this.tbxBinView.AllowDrop = true;
            this.tbxBinView.BackColor = System.Drawing.SystemColors.Info;
            this.tbxBinView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxBinView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBinView.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbxBinView.Location = new System.Drawing.Point(87, 119);
            this.tbxBinView.Multiline = true;
            this.tbxBinView.Name = "tbxBinView";
            this.tbxBinView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxBinView.Size = new System.Drawing.Size(446, 105);
            this.tbxBinView.TabIndex = 1;
            this.tbxBinView.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbxBinView_DragDrop);
            this.tbxBinView.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbxBinView_DragEnter);
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "short",
            "int",
            "long",
            "byte",
            "string"});
            this.cbxType.Location = new System.Drawing.Point(87, 75);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(215, 20);
            this.cbxType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "测试数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "数据类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "16进制查看";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查看测试数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxCharset
            // 
            this.cbxCharset.FormattingEnabled = true;
            this.cbxCharset.Items.AddRange(new object[] {
            "ANSI",
            "gb2312",
            "gbk",
            "iso-8859-1",
            "utf-8",
            "unicode"});
            this.cbxCharset.Location = new System.Drawing.Point(430, 75);
            this.cbxCharset.Name = "cbxCharset";
            this.cbxCharset.Size = new System.Drawing.Size(100, 20);
            this.cbxCharset.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "字符编码";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(205, 246);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(97, 23);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "还原测试数据";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // cbxRevert
            // 
            this.cbxRevert.AutoSize = true;
            this.cbxRevert.Checked = true;
            this.cbxRevert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRevert.Location = new System.Drawing.Point(18, 188);
            this.cbxRevert.Name = "cbxRevert";
            this.cbxRevert.Size = new System.Drawing.Size(72, 16);
            this.cbxRevert.TabIndex = 10;
            this.cbxRevert.Text = "反转字节";
            this.cbxRevert.UseVisualStyleBackColor = true;
            // 
            // btnGenBin
            // 
            this.btnGenBin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGenBin.ForeColor = System.Drawing.SystemColors.Info;
            this.btnGenBin.Location = new System.Drawing.Point(130, 281);
            this.btnGenBin.Name = "btnGenBin";
            this.btnGenBin.Size = new System.Drawing.Size(143, 23);
            this.btnGenBin.TabIndex = 11;
            this.btnGenBin.Text = "游戏二进制文件生成";
            this.btnGenBin.UseVisualStyleBackColor = false;
            this.btnGenBin.Click += new System.EventHandler(this.btnGenBin_Click);
            // 
            // btnBase64En
            // 
            this.btnBase64En.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBase64En.Location = new System.Drawing.Point(327, 246);
            this.btnBase64En.Name = "btnBase64En";
            this.btnBase64En.Size = new System.Drawing.Size(86, 23);
            this.btnBase64En.TabIndex = 12;
            this.btnBase64En.Text = "Base64Encode";
            this.btnBase64En.UseVisualStyleBackColor = true;
            this.btnBase64En.Click += new System.EventHandler(this.btnBase64En_Click);
            // 
            // btnBase64De
            // 
            this.btnBase64De.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBase64De.Location = new System.Drawing.Point(430, 246);
            this.btnBase64De.Name = "btnBase64De";
            this.btnBase64De.Size = new System.Drawing.Size(91, 23);
            this.btnBase64De.TabIndex = 13;
            this.btnBase64De.Text = "Base64Decode";
            this.btnBase64De.UseVisualStyleBackColor = true;
            this.btnBase64De.Click += new System.EventHandler(this.btnBase64De_Click);
            // 
            // bin2Part
            // 
            this.bin2Part.BackColor = System.Drawing.SystemColors.Highlight;
            this.bin2Part.ForeColor = System.Drawing.SystemColors.Info;
            this.bin2Part.Location = new System.Drawing.Point(307, 281);
            this.bin2Part.Name = "bin2Part";
            this.bin2Part.Size = new System.Drawing.Size(106, 23);
            this.bin2Part.TabIndex = 14;
            this.bin2Part.Text = "资源Bin2Part";
            this.bin2Part.UseVisualStyleBackColor = false;
            this.bin2Part.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripLable});
            this.statusStrip.Location = new System.Drawing.Point(0, 310);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(564, 22);
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tStripLable
            // 
            this.tStripLable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tStripLable.Name = "tStripLable";
            this.tStripLable.Size = new System.Drawing.Size(53, 17);
            this.tStripLable.Text = "准备就绪";
            this.tStripLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 332);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bin2Part);
            this.Controls.Add(this.btnBase64De);
            this.Controls.Add(this.btnBase64En);
            this.Controls.Add(this.btnGenBin);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxCharset);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.tbxBinView);
            this.Controls.Add(this.tbxInput);
            this.Controls.Add(this.cbxRevert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手机游戏JAVA ME交互数据测试";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.TextBox tbxBinView;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxCharset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.CheckBox cbxRevert;
        private System.Windows.Forms.Button btnGenBin;
        private System.Windows.Forms.Button btnBase64En;
        private System.Windows.Forms.Button btnBase64De;
        private System.Windows.Forms.Button bin2Part;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tStripLable;
    }
}

