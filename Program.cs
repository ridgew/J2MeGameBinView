using System;
using System.Threading;
using System.Windows.Forms;

namespace GameBinView
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Source + ":" + e.Exception.Message + "\n"
                + e.Exception.StackTrace,
                "程序错误！", MessageBoxButtons.OK);
        }
    }
}
