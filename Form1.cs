using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace GameBinView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer;
            if (System.Text.RegularExpressions.Regex.IsMatch(tbxInput.Text.Trim(), @"[^\d]+"))
            {
                cbxType.Text = "string";
            }

            if (cbxType.Text == "string")
            {
                Encoding enc = Encoding.UTF8;
                if (cbxCharset.Text.Trim() != string.Empty)
                {
                    if (cbxCharset.Text == "ANSI")
                    {
                        enc = Encoding.Default;
                    }
                    else
                    {
                        enc = Encoding.GetEncoding(cbxCharset.Text);
                    }
                }
                else
                {
                    cbxCharset.Text = "utf-8";
                }
                buffer = enc.GetBytes(tbxInput.Text.Trim());
            }
            else
            {
                switch (cbxType.Text.ToLower())
                {
                    case "byte":
                        buffer = BitConverter.GetBytes(Convert.ToByte(tbxInput.Text.Trim()));
                        break;
                    case "short":
                        buffer = BitConverter.GetBytes(Convert.ToInt16(tbxInput.Text.Trim()));
                        break;
                    case "int":
                        buffer = BitConverter.GetBytes(Convert.ToInt32(tbxInput.Text.Trim()));
                        break;
                    case "long":
                        buffer = BitConverter.GetBytes(Convert.ToInt64(tbxInput.Text.Trim()));
                        break;
                    default :
                        buffer = new byte[0];
                        break;
                }
            }
            if (cbxRevert.Checked) buffer = ReverseBytes(buffer);

            //MessageBox.Show(buffer.Length.ToString(), "测试", MessageBoxButtons.OK);
            ReportHexView(buffer); 
        }

        private void ReportHexView(byte[] binDat)
        {
            tbxBinView.Text = "总长度：" + binDat.Length.ToString() + "字节"
                + Environment.NewLine + Environment.NewLine;

            StringBuilder sb = new StringBuilder();
            for (int i = 0, j = binDat.Length; i < j; i++)
            {
                if (i == 0)
                {
                    sb.Append("00000000  ");
                }
                sb.Append(binDat[i].ToString("X2") + " ");

                if (i > 0 && (i + 1) % 8 == 0 && (i + 1) % 16 != 0)
                {
                    sb.Append(" ");
                }

                if (i > 0 && (i + 1) % 16 == 0)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append((i + 1).ToString("X2").PadLeft(8, '0') + "  ");
                }
            }

            tbxBinView.Text += sb.ToString();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //获取有效二进制序列数据
            string rawHexStr = tbxBinView.Text.Trim().Replace("\r", "");
            string[] hexStr = rawHexStr.Split('\n');
            StringBuilder rb = new StringBuilder();
            foreach (string line in hexStr)
            {
                if (Regex.IsMatch(line, @"^[0-9a-f]{8}\s{2}", RegexOptions.IgnoreCase) && line.Length>10)
                {
                    rb.Append(line.Substring(10));
                }
				else if (Regex.IsMatch(line, @"^([0-9a-f]{2}\s{1,2})+", RegexOptions.IgnoreCase))
				{
					rb.Append(line);
				}
            }
            rawHexStr = rb.ToString().Replace(" ", "");

            int total = rawHexStr.Length;
            if (total % 2 == 0)
            {
                byte[] rawBin = new byte[total / 2];
                for (int i = 0; i < total; i = i+2)
                {
                    rawBin[i / 2] = Convert.ToByte(int.Parse(rawHexStr.Substring(i, 2),
                        NumberStyles.AllowHexSpecifier));
                }

                if (cbxRevert.Checked) rawBin = ReverseBytes(rawBin);

                if (cbxType.Text == "string")
                {
                    Encoding enc = Encoding.UTF8;
                    if (cbxCharset.Text.Trim() != string.Empty)
                    {
                        if (cbxCharset.Text == "ANSI")
                        {
                            enc = Encoding.Default;
                        }
                        else
                        {
                            enc = Encoding.GetEncoding(cbxCharset.Text);
                        }
                    }
                    tbxInput.Text = enc.GetString(rawBin);
                }
                else
                {
                    switch (cbxType.Text.ToLower())
                    {
                        case "byte":
                            tbxInput.Text = BitConverter.ToInt16(rawBin, 0).ToString();
                            break;
                        case "short":
                            tbxInput.Text = BitConverter.ToInt16(rawBin, 0).ToString();
                            break;
                        case "int":
                            tbxInput.Text = BitConverter.ToInt32(rawBin, 0).ToString();
                            break;
                        case "long":
                            tbxInput.Text = BitConverter.ToInt64(rawBin, 0).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void btnGenBin_Click(object sender, EventArgs e)
        {
            ImageBinGen bGin = new ImageBinGen();
            bGin.ShowDialog(this);
        }

        private void btnBase64En_Click(object sender, EventArgs e)
        {
            string strBase64 = tbxInput.Text.Trim();
            Encoding Enc = Encoding.Default;
            if (cbxCharset.SelectedText != "") Enc = Encoding.GetEncoding(cbxCharset.SelectedText);
            byte[] bytes = Enc.GetBytes(strBase64);
            strBase64 = Convert.ToBase64String(bytes);
            tbxBinView.Text = strBase64;
        }

        private void btnBase64De_Click(object sender, EventArgs e)
        {
            string strSourceText = tbxBinView.Text.Trim();
            byte[] bytes = Convert.FromBase64String(strSourceText);
            Encoding Enc = Encoding.Default;
            if (cbxCharset.SelectedText != "") Enc = Encoding.GetEncoding(cbxCharset.SelectedText);
            tbxInput.Text = Enc.GetString(bytes);
        }

        /// <summary>
        /// 反转二进制字节序列
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ReverseBytes(byte[] bytes)
        {
            int num = bytes.Length / 2;
            byte by;
            int idx;
            for (int i = 0; i < num; i++)
            {
                by = bytes[i];
                idx = bytes.Length - i - 1;
                bytes[i] = bytes[idx];
                bytes[idx] = by;
            }
            return bytes;
        }

        /// <summary>
        /// bin2part
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Bin2PartGen gen = new Bin2PartGen();
            gen.ShowDialog(this);
        }

        public void ShowMsg(string msg)
        {
            tStripLable.Text = msg;
        }

        private void tbxBinView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string str in data)
                {
                    FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    byte[] fileBin = new byte[fs.Length];
                    fs.Read(fileBin, 0, fileBin.Length);
                    fs.Close();
                    fs.Dispose();

                    ReportHexView(fileBin);

                    //MessageBox.Show("已显示文件：" + str + " 的二进制形式！");
                    break;
                }
            }
        }

        private void tbxBinView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
