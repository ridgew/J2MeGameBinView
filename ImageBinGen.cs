using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Diagnostics;

namespace GameBinView
{
    public partial class ImageBinGen : Form
    {
        public ImageBinGen()
        {
            InitializeComponent();
            fbdialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;

            tbxDir.Text = fbdialog.SelectedPath;
            tbxPattern.Text = "*.png";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult drt = fbdialog.ShowDialog(this);
            if (drt == DialogResult.OK)
            {
                tbxDir.Text = fbdialog.SelectedPath;
            }
        }

        /// <summary>
        /// Takes a binary input buffer and GZip encodes the input
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <returns></returns>
        public static byte[] GZipMemory(byte[] Buffer)
        {

            MemoryStream ms = new MemoryStream();
            GZipStream GZip = new GZipStream(ms, CompressionMode.Compress);
            GZip.Write(Buffer, 0, Buffer.Length);
            GZip.Close();
            byte[] Result = ms.ToArray();
            ms.Close();
            return Result;
        }

        public static byte[] DeflateMemory(byte[] Buffer)
        {
            MemoryStream ms = new MemoryStream();
            DeflateStream fls = new DeflateStream(ms, CompressionMode.Compress);
            fls.Write(Buffer, 0, Buffer.Length);
            fls.Close();

            byte[] Result = ms.ToArray();
            ms.Close();
            return Result;
        }

        private void btnGenBin_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(tbxDir.Text))
            {

                MessageBox.Show("选择的文件目录不存在！", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DirectoryInfo dif = new DirectoryInfo(tbxDir.Text);
            FileInfo[] files = dif.GetFiles(tbxPattern.Text, SearchOption.TopDirectoryOnly);
            string curDir = AppDomain.CurrentDomain.BaseDirectory;

            #region 数据规范
            //图片文件长度	int	
            //图片数据流内容	二进制内容	byte

            //图片张数	int
            //img_1（起始位置）	int
            //img_1（图片大小）	int
            //……	
            //img_n（起始位置）	int
            //img_n（图片大小）	int

            /*
                imgSize:19150 //int
                imgNum:4 //int
                img_1_start:0	//int
                img_1_size:6507
                img_2_start:6511
                img_2_size:6116
                img_3_start:12631
                img_3_size:2763
                img_4_start:15398
                img_4_size:3748
             */

            #endregion


            FileStream fsBin = new FileStream(curDir + @"\data.bin", FileMode.Create, FileAccess.Write);
            FileStream fs;
            byte[] buffer;
            StreamWriter swInfo = new StreamWriter(curDir + @"\data.txt", false);
            string[] arrStart = new string[files.Length];
            string[] arrSize = new string[files.Length];
            int idx = 1;
            long offset = 0;

            StringBuilder sb = new StringBuilder();
            foreach (FileInfo fi in files)
            {
                sb.AppendLine(string.Format("img_{0}_start:{1} //int", idx, offset));
                sb.AppendLine(string.Format("img_{0}_size:{1} //int", idx, fi.Length));
                sb.AppendLine(string.Format("img_{0}_id:{1} //int", idx, Regex.Replace(fi.Name, @"[^\d+]", "").TrimStart('0')));

                using (fs = fi.OpenRead())
                {
                    buffer = new byte[(int)fi.Length];
                    fs.Read(buffer, 0, (int)fi.Length);
                    fs.Close();

                    #region 执行相应压缩算法
                    //buffer = DeflateMemory(buffer);
                    #endregion

                    fsBin.Write(buffer, 0, buffer.Length);
                    fsBin.Flush();
                }

                offset += fi.Length;
                idx++;
            }

            swInfo.WriteLine(string.Format("imgSize:{0}", offset));
            //图片数据流内容	二进制内容	byte
            swInfo.WriteLine(string.Format("imgNum:{0}", files.Length));
            swInfo.Write(sb.ToString());

            swInfo.Flush();
            swInfo.Close();
            swInfo.Dispose();

            fsBin.Close();
            fsBin.Dispose();

            MessageBox.Show("找到相关图片文件" + files.Length + "个，并生成两个相关文件！",
                this.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 获取单一匹配项组的值 ，如果有多项则选最后一项。
        /// </summary>
        /// <param name="pattern">匹配模式，支持直接量语法和选项‘/regex/gim’。</param>
        /// <param name="strInput">匹配查找源</param>
        /// <param name="objMatch">捕获匹配项集合</param>
        /// <returns>是否找到匹配</returns>
        public static bool GetSingleMatchValue(string pattern, string strInput, out string[] objMatch)
        {
            RegexOptions ExOption = RegexOptions.IgnoreCase | RegexOptions.Multiline;
            Match m = Regex.Match(pattern, "^/(.+)/(g?i?m?)$", ExOption);
            if (m.Success)
            {
                pattern = m.Groups[1].Value;
                string strOption = m.Groups[2].Value;
                if (strOption != string.Empty)
                {
                    ExOption = (strOption.IndexOf("g") != -1) ? RegexOptions.Multiline : RegexOptions.Singleline;
                    if (strOption.IndexOf("i") != -1)
                    {
                        ExOption |= RegexOptions.IgnoreCase;
                    }
                }
            }

            m = Regex.Match(strInput, pattern, ExOption);
            if (m.Success)
            {
                objMatch = new string[m.Groups.Count];
                for (int i = 0; i < objMatch.Length; i++)
                {
                    objMatch[i] = m.Groups[i].Value;
                }
                return true;
            }
            else
            {
                objMatch = null;
                return false;
            }
        } 

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string curDir = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(curDir + @"\data.txt")
                || !File.Exists(curDir + @"\data.bin"))
            {
                MessageBox.Show("生成文件和二进制数据不存在！", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                FileStream fsBin = new FileStream(curDir + @"\data.bin", FileMode.Open, FileAccess.Read);
                StreamReader npw = new StreamReader(curDir + @"\data.txt");
                string lineStr;
                bool gotted = false;
                string[] numArray = null;
                int offset = 0, idx = 1, size=0;
                byte[] buffer = new byte[0];
                string imgExt = ".jpg";
                string[] strExt = new string[0];
                if (GetSingleMatchValue(@"/.(\.)([a-z0-9]+)$/gi", tbxPattern.Text.Trim(), out strExt))
                {
                    imgExt = strExt[1] + strExt[2];
                }
                while ((lineStr = npw.ReadLine()) != null)
                {
                    if (lineStr.StartsWith("img"))
                    {
                        gotted = true;

                        if (GetSingleMatchValue(@"(:|：)\s*(\d+)", lineStr, out numArray))
                        {
                            if (lineStr.StartsWith("imgSize"))
                            {
                                //效验文件大小
                                if (fsBin.Length != Convert.ToInt64(numArray[2]))
                                {
                                    MessageBox.Show("图片文件大小和二进制数据不一致，系统退出还原操作！", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                //img_1_start:0
                                //img_1_size:4663
                                if (lineStr.Contains("_start"))
                                {
                                    offset = Convert.ToInt32(numArray[2]);
                                }

                                if (lineStr.Contains("_size"))
                                {
                                    size = Convert.ToInt32(numArray[2]);
                                    buffer = new byte[size];
                                }

                                if (lineStr.Contains("_id"))
                                {
                                    fsBin.Position = offset;
                                    fsBin.Read(buffer, 0, size);

                                    using (FileStream fsPic = new FileStream(curDir + @"\r_" + Convert.ToInt32(numArray[2]) + imgExt,
                                        FileMode.Create, FileAccess.Write, FileShare.Read))
                                    {
                                        fsPic.Write(buffer, 0, size);
                                        fsPic.Flush();
                                        fsPic.Close();
                                    }

                                    idx++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (gotted == true) break;
                    }
                }
                npw.Close();
                npw.Dispose();

                fsBin.Close();
                fsBin.Dispose();

                if (idx > 1)
                {
                    MessageBox.Show("已分解为" + (idx-1) + "个图片文件！", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            foDialog.CheckFileExists = true;
            foDialog.Multiselect = false;
            foDialog.Filter = "所有文件(*.*)|*.*|应用程序文件(*.exe)|*.exe";
            foDialog.FilterIndex = 2;

            DialogResult dResult = foDialog.ShowDialog(this);
            if (dResult == DialogResult.OK)
            {
                tbxBinCompiler.Text = foDialog.FileName;
            }
        }

        public static void ShowMessage(string msg, bool isError, Form frm)
        {
            MessageBox.Show(msg, frm.Text,
                    MessageBoxButtons.OK,
                    isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(tbxDir.Text))
            {
                ShowMessage("选择的文件目录不存在！", false, this);
                return;
            }

            if (!File.Exists(tbxBinCompiler.Text))
            {
                ShowMessage("BinCompiler程序不存在！", false, this);
                return;
            }

            DirectoryInfo dif = new DirectoryInfo(tbxDir.Text);
            FileInfo[] files = dif.GetFiles(tbxPattern.Text, SearchOption.TopDirectoryOnly);
            string appDir = AppDomain.CurrentDomain.BaseDirectory;

            if (files.Length < 1)
            {
                ShowMessage("没有找到相关资源文件！", true, this);
            }
            else
            {

                #region 设置应用程序的脚本宿主环境
                string strFilePath = appDir + "\\setHScript.vbs";
                Util.SetTextFileContent(strFilePath,
                    Encoding.Default.WebName,
                    ReflectHelper.GetManifestString(this.GetType(), null, "Resource/setHScript.vbs"));
                RunProcess("CScript", strFilePath);
                #endregion

                string currentDir = tbxDir.Text;
                long totalSize = 0L;
                int idx = 1;

                List<FileInfo> fList = new List<FileInfo>();
                long BlockSize = Convert.ToInt64(tbxBlockSize.Text) * 1024;
                foreach (FileInfo currentFile in files)
                {
                    totalSize += currentFile.Length;
                    if (totalSize > BlockSize)
                    {
                        CreateSubDirAndMake(appDir, currentDir, "part" + idx.ToString(), fList);

                        //清零并重新记数
                        totalSize = 0;
                        fList.Clear();
                        idx++;
                    }
                    fList.Add(currentFile);
                }

                if (fList.Count > 0)
                {
                    CreateSubDirAndMake(appDir, currentDir, "part" + idx.ToString(), fList);
                    //ShowMessage(idx.ToString(), false, this);
                }

            }

        }

        private void CreateSubDirAndMake(string scriptDir, string curDir, string subDirName, List<FileInfo> fList)
        {
            //ShowMessage(subDirName + "\n" + fList.Count .ToString() , false, this);
            //return;

            string currentDirName = Path.Combine(curDir, subDirName);
            if (!Directory.Exists(currentDirName))
            {
                Directory.CreateDirectory(currentDirName);
            }

            foreach (FileInfo file in fList)
            {
                file.MoveTo(currentDirName + "\\" + file.Name);
            }


            #region 调用外部软件生成相关资源文件
            string strFilePath = scriptDir + "\\AutoBuild.vbs";
            Util.SetTextFileContent(strFilePath,
                Encoding.Default.WebName,

                string.Concat("const BCPath = \"" + tbxBinCompiler.Text + "\"",
                Environment.NewLine,
                "const SourceDir =  \"" + currentDirName + "\"",
                Environment.NewLine,
                "const OutFileNamePath =  \"" + currentDirName + "\\png.bin\"",
                Environment.NewLine, Environment.NewLine,
                ReflectHelper.GetManifestString(this.GetType(), null, "Resource/AutoBuild.vbs")));

            //创建自动构建脚本、运行生成
            string sResult = RunProcess("CScript", "//U \"" + strFilePath + "\"");
            //System.Threading.Thread.Sleep(5000);

            
            //ShowMessage("生成目录[" + currentDirName + "]下的资源结果：" + Environment.NewLine 
            //    + sResult, false, this);

            #endregion
        }


        /// <summary>
        /// Runs the process.
        /// </summary>
        /// <param name="proceFilePath">The proce file path.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string RunProcess(string proceFilePath, string args)
        {
            Process proc = new Process();
            ProcessStartInfo psInfo = new ProcessStartInfo(proceFilePath, args);
            psInfo.UseShellExecute = false;
            psInfo.RedirectStandardError = true;
            psInfo.RedirectStandardOutput = true;
            psInfo.RedirectStandardInput = true;
            psInfo.WindowStyle = ProcessWindowStyle.Hidden;
            psInfo.WorkingDirectory = Path.GetDirectoryName(proceFilePath);

            proc.StartInfo = psInfo;
            proc.Start();
            string result = "";
            while (!proc.HasExited)
            {
                result = proc.StandardOutput.ReadToEnd().Replace("\r", "");
                System.Threading.Thread.Sleep(50);
            }
            proc.Close();
            proc.Dispose();

            return result;
        }


    }
}
