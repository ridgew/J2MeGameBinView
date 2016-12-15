using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameBinView
{
    public static class Util
    {
        /// <summary>
        /// 获取有效的文件路径
        /// </summary>
        /// <param name="strFilePath">相对或完整路径文件地址</param>
        /// <returns>完整的文件路径地址</returns>
        public static string ParseAppPath(string strFilePath)
        {
            //程序域相对目录
            if (System.Web.HttpContext.Current == null)
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    strFilePath.TrimStart('~', '/').Replace('/', '\\'));
            }
            else
            {

                //Asp.net App程序相对目录
                if (strFilePath.StartsWith("~"))
                {
                    strFilePath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + strFilePath.Substring(1).Replace("/", @"\");
                    strFilePath = strFilePath.Replace(@"\\", @"\");
                    return strFilePath;
                }
                else
                {
                    //本地文件路径
                    if (strFilePath.IndexOf(@":\") == -1)
                    {
                        strFilePath = System.Web.HttpContext.Current.Server.MapPath(strFilePath);
                    }
                }
                return strFilePath;
            }
        }
        
        /// <summary>
        /// 设置文本文件的内容
        /// </summary>
        /// <param name="filePath">文件的相对路径，如"/index.html"等。</param>
        /// <param name="charset">文件编码，如"gb2312","utf-8"等</param>
        /// <param name="TxtContent">文本文件的内容</param>
        /// <returns>成功则返回字符"0",错误则放回失败的原因。</returns>
        public static string SetTextFileContent(string filePath, string charset, string TxtContent)
        {
            string strResult = "0";
            try
            {
                string LocalFilePath = ParseAppPath(filePath);
                string fileDir = Path.GetDirectoryName(LocalFilePath);
                if (!Directory.Exists(fileDir)) Directory.CreateDirectory(fileDir);

                using (StreamWriter sw = new StreamWriter(LocalFilePath, false, System.Text.Encoding.GetEncoding(charset)))
                {
                    sw.Write(TxtContent);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception exp)
            {
                strResult = exp.Message;
            }
            return strResult;
        }

        /// <summary>
        /// 从文本文件模板加载文本内容
        /// </summary>
        /// <param name="strFilePath">文件保存路径，相对路径或物理路径。</param>
        /// <param name="charset">文件编码</param>
        /// <returns>文本文件中的内容</returns>
        public static string GetTextFileContent(string strFilePath, string charset)
        {
            String TempletPath = Util.ParseAppPath(strFilePath);
            if (!File.Exists(TempletPath)) { return "指定文件不存在！"; }
            FileStream fs = new FileStream(TempletPath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Encoding Charset = Encoding.GetEncoding(charset);
            return Charset.GetString(bytes);
        }

        /// <summary>
        /// 附加文本内容到文本文件
        /// </summary>
        public static void AppendToFile(bool IsAppend, string filePath, string TxtContent)
        {
            StreamWriter sw = new StreamWriter(Util.ParseAppPath(filePath), IsAppend, System.Text.Encoding.Default);
            sw.Write(TxtContent);
            sw.Flush();
            sw.Close();
        }

    }
}
