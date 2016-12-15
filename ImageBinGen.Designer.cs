namespace GameBinView
{
    partial class ImageBinGen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fbdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbxDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPattern = new System.Windows.Forms.TextBox();
            this.btnGenBin = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxBlockSize = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.foDialog = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.tbxBinCompiler = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fbdialog
            // 
            this.fbdialog.Description = "选择游戏图片文件所在文件夹";
            this.fbdialog.ShowNewFolderButton = false;
            // 
            // tbxDir
            // 
            this.tbxDir.Location = new System.Drawing.Point(139, 59);
            this.tbxDir.Name = "tbxDir";
            this.tbxDir.Size = new System.Drawing.Size(200, 21);
            this.tbxDir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "资源文件目录";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "选择...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件名匹配模式";
            // 
            // tbxPattern
            // 
            this.tbxPattern.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GameBinView.Properties.Settings.Default, "ResExt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbxPattern.Location = new System.Drawing.Point(140, 132);
            this.tbxPattern.Name = "tbxPattern";
            this.tbxPattern.Size = new System.Drawing.Size(81, 21);
            this.tbxPattern.TabIndex = 4;
            this.tbxPattern.Text = global::GameBinView.Properties.Settings.Default.ResExt;
            // 
            // btnGenBin
            // 
            this.btnGenBin.Location = new System.Drawing.Point(230, 191);
            this.btnGenBin.Name = "btnGenBin";
            this.btnGenBin.Size = new System.Drawing.Size(89, 23);
            this.btnGenBin.TabIndex = 5;
            this.btnGenBin.Text = "原始合并文件";
            this.btnGenBin.UseVisualStyleBackColor = true;
            this.btnGenBin.Click += new System.EventHandler(this.btnGenBin_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(360, 191);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(96, 23);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "还原原始合并";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "K";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "独立分块大小";
            // 
            // tbxBlockSize
            // 
            this.tbxBlockSize.Location = new System.Drawing.Point(379, 131);
            this.tbxBlockSize.Name = "tbxBlockSize";
            this.tbxBlockSize.Size = new System.Drawing.Size(28, 21);
            this.tbxBlockSize.TabIndex = 7;
            this.tbxBlockSize.Text = "30";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(346, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "选择...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSelFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(41, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "BINCompiler地址";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "创建独立文件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tbxBinCompiler
            // 
            this.tbxBinCompiler.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GameBinView.Properties.Settings.Default, "BinCompiler", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbxBinCompiler.ForeColor = System.Drawing.Color.Maroon;
            this.tbxBinCompiler.Location = new System.Drawing.Point(139, 92);
            this.tbxBinCompiler.Name = "tbxBinCompiler";
            this.tbxBinCompiler.Size = new System.Drawing.Size(200, 21);
            this.tbxBinCompiler.TabIndex = 10;
            this.tbxBinCompiler.Text = global::GameBinView.Properties.Settings.Default.BinCompiler;
            // 
            // ImageBinGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 259);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxBinCompiler);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnGenBin);
            this.Controls.Add(this.tbxPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDir);
            this.Controls.Add(this.tbxBlockSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageBinGen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二进制图片文件合并生成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdialog;
        private System.Windows.Forms.TextBox tbxDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPattern;
        private System.Windows.Forms.Button btnGenBin;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxBlockSize;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxBinCompiler;
        private System.Windows.Forms.OpenFileDialog foDialog;
        private System.Windows.Forms.Button button3;
    }
}