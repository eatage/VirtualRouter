using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VirtualRouter.Client
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
            AppDomain.CurrentDomain.UnhandledException += (_s, _e) =>
            {
                MessageBox.Show(String.Format("好好的一个程序被你玩坏了\n{0}", _e.ExceptionObject.ToString()));
            };
            Application.Run(new FrmMain());
        }
    }
}
