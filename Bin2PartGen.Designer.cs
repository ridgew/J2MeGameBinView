namespace GameBinView
{
    partial class Bin2PartGen
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
            this.tbxPngBinPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectBin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxResIndex = new System.Windows.Forms.TextBox();
            this.btnSelIndex = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxBlockSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxPngBinPath
            // 
            this.tbxPngBinPath.AllowDrop = true;
            this.tbxPngBinPath.Location = new System.Drawing.Point(104, 30);
            this.tbxPngBinPath.Name = "tbxPngBinPath";
            this.tbxPngBinPath.Size = new System.Drawing.Size(193, 21);
            this.tbxPngBinPath.TabIndex = 0;
            this.tbxPngBinPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbxPngBinPath_DragDrop);
            this.tbxPngBinPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbxPngBinPath_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "PNG压缩资源";
            // 
            // btnSelectBin
            // 
            this.btnSelectBin.Location = new System.Drawing.Point(303, 28);
            this.btnSelectBin.Name = "btnSelectBin";
            this.btnSelectBin.Size = new System.Drawing.Size(58, 23);
            this.btnSelectBin.TabIndex = 2;
            this.btnSelectBin.Text = "选择...";
            this.btnSelectBin.UseVisualStyleBackColor = true;
            this.btnSelectBin.Click += new System.EventHandler(this.btnSelectBin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "索引文件";
            // 
            // tbxResIndex
            // 
            this.tbxResIndex.Location = new System.Drawing.Point(104, 61);
            this.tbxResIndex.Name = "tbxResIndex";
            this.tbxResIndex.Size = new System.Drawing.Size(193, 21);
            this.tbxResIndex.TabIndex = 0;
            // 
            // btnSelIndex
            // 
            this.btnSelIndex.Location = new System.Drawing.Point(303, 59);
            this.btnSelIndex.Name = "btnSelIndex";
            this.btnSelIndex.Size = new System.Drawing.Size(58, 23);
            this.btnSelIndex.TabIndex = 2;
            this.btnSelIndex.Text = "选择...";
            this.btnSelIndex.UseVisualStyleBackColor = true;
            this.btnSelIndex.Click += new System.EventHandler(this.btnSelIndex_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "分块大小";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "生成分块文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenResCombo_Click);
            // 
            // tbxBlockSize
            // 
            this.tbxBlockSize.Location = new System.Drawing.Point(104, 88);
            this.tbxBlockSize.Name = "tbxBlockSize";
            this.tbxBlockSize.Size = new System.Drawing.Size(46, 21);
            this.tbxBlockSize.TabIndex = 0;
            this.tbxBlockSize.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "K";
            // 
            // Bin2PartGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 177);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelIndex);
            this.Controls.Add(this.btnSelectBin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxBlockSize);
            this.Controls.Add(this.tbxResIndex);
            this.Controls.Add(this.tbxPngBinPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Bin2PartGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PNG资源分块";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPngBinPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectBin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxResIndex;
        private System.Windows.Forms.Button btnSelIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxBlockSize;
        private System.Windows.Forms.Label label4;
    }
}