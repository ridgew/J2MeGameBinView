using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GameBinView
{
    
    public partial class Bin2PartGen : Form
    {
        public Bin2PartGen()
        {
            InitializeComponent();
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
        /// 创建独立资源文件块
        /// </summary>
        /// <param name="imgBinPath">binCompiler编译资源文件地址</param>
        /// <param name="idxFilePath">编译资源相关索引文件地址</param>
        /// <param name="splitSize">分块文件分割大小</param>
        public static void GenStandAlonePartFile(string imgBinPath, string idxFilePath, int splitSize)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);

            FileInfo binFile = new FileInfo(imgBinPath);
            //数据总大小
            bw.Write(ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(binFile.Length))));

            //输出图片二进制数据
            using (FileStream fs = binFile.OpenRead())
            {
                int totalLen = (int)fs.Length;
                byte[] fDat = new byte[totalLen];
                fs.Read(fDat, 0, totalLen);
                fs.Close();
                bw.Write(fDat);

            }

            StreamReader sr = new StreamReader(idxFilePath);
            string lineStr;
            int lineCount = 0;

            //占位更新
            long pos = ms.Position;
            bw.Write((int)lineCount);

            #region 解析以表格符号、包含表头名称：分隔的索引文件
            string[] lineArr;
            while ((lineStr = sr.ReadLine()) != null)
            {
                lineArr = lineStr.Trim().Split('\t');
                if (lineArr[0] == "FName") continue;

                lineCount++;

                if (lineArr.Length == 4)
                {
                    //img_n_start
                    bw.Write(ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(lineArr[2]))));
                    //img_n_size
                    bw.Write(ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(lineArr[3]))));
                    //Regex.Replace(lineArr[0], @"[^\d+]", "").TrimStart('0')
                    //img_n_id
                    bw.Write(ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Regex.Match(lineArr[0], "^(\\d+)(.*)\\.png", RegexOptions.IgnoreCase).Groups[1].Value))));
                }
                else
                {
                    break;
                }

            }
            #endregion

            sr.Close();
            sr.Dispose();

            //图片总数
            //ms.Position = pos;
            bw.BaseStream.Position = pos;
            bw.Write(ReverseBytes(BitConverter.GetBytes(lineCount)));

            byte[] totalBytes = ms.ToArray();
            bw.Close();

            if (totalBytes.Length <= splitSize)
            {
                using (FileStream fs = new FileStream(Path.GetDirectoryName(imgBinPath) + "\\part1.dat",
                    FileMode.Create,
                    FileAccess.Write, FileShare.None))
                {
                    fs.Write(totalBytes, 0, totalBytes.Length);
                    fs.Close();
                }
            }
            else
            {
                int totalPart = totalBytes.Length / splitSize;
                bool appendFile = (totalBytes.Length % splitSize != 0);
                int offset = 0;

                //全部文件
                using (FileStream fs = new FileStream(Path.GetDirectoryName(imgBinPath) + "\\binWithIdx.dat",
                    FileMode.Create,
                    FileAccess.Write, FileShare.None))
                {
                    fs.Write(totalBytes, 0, totalBytes.Length);
                    fs.Close();
                }

                #region 创建分块文件
                for (int i = 1; i <= totalPart; i++)
                {
                    using (FileStream fs = new FileStream(Path.GetDirectoryName(imgBinPath) + "\\part" + i.ToString() + ".dat",
                    FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        fs.Write(totalBytes, offset, splitSize);
                        fs.Close();
                    }
                    offset += splitSize;
                }

                if (appendFile == true)
                {
                    using (FileStream fs = new FileStream(Path.GetDirectoryName(imgBinPath) + "\\part" + (totalPart + 1).ToString() + ".dat",
                    FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        fs.Write(totalBytes, offset, totalBytes.Length - offset);
                        fs.Close();
                    }
                }
                #endregion
            }

        }

        private void GenResCombo_Click(object sender, EventArgs e)
        {
            GenStandAlonePartFile(tbxPngBinPath.Text, tbxResIndex.Text, Convert.ToInt32(tbxBlockSize.Text.Trim()) * 1024);

            MessageBox.Show("处理完成！", "操作结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void SelectFile(SetResultFile sf)
        { 
            using (OpenFileDialog oFd = new OpenFileDialog())
            {
                oFd.Multiselect = false;
                oFd.Filter = "所有文件(*.*)|*.*|图片文件(*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";

                DialogResult dr = oFd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    sf(oFd.FileName);
                }
            }
        }


        private void btnSelectBin_Click(object sender, EventArgs e)
        {
            SelectFile(new SetResultFile(delegate(string result)
                {
                    tbxPngBinPath.Text = result;

                    string idxFileName = Path.ChangeExtension(result, ".idx");
                    if (File.Exists(idxFileName))
                    {
                        tbxResIndex.Text = idxFileName;
                    }
                    else
                    {
                        tbxResIndex.Text = "";
                    }

                }));
        }

        private void btnSelIndex_Click(object sender, EventArgs e)
        {
            SelectFile(new SetResultFile(delegate(string result)
            {
                tbxResIndex.Text = result;
            }));
        }

        private void tbxPngBinPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string str in data)
                {
                    tbxPngBinPath.Text = str;
                    tbxPngBinPath.ScrollToCaret();

                    string idxFileName = Path.Combine(Path.GetDirectoryName(str), "index.txt");
                    if (File.Exists(idxFileName))
                    {
                        tbxResIndex.Text = idxFileName;
                    }
                    else
                    {
                        tbxResIndex.Text = "";
                    }

                    break;
                }
            } 
        }

        private void tbxPngBinPath_DragEnter(object sender, DragEventArgs e)
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

    public delegate void SetResultFile(string result);
}
