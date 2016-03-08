using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisWarTranslater
{
    static internal class Program
    {
        static internal ThisWarTranslaterMain m_mainWindow = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static internal void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_mainWindow = new ThisWarTranslaterMain();
            Application.Run(m_mainWindow);
        }
    }
}
