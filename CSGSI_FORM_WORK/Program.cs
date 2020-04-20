using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSGSITools
{
    static class Program
    {
        public static string AppName = "CSGSITools";
        public static string Version = "1.0.0";

        public static readonly Process[] CurrentProcesses = Process.GetProcesses();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
