using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace GenelSurecler
{

    /// <summary>
    /// RunTime Design Mode Program
    /// </summary>
    public class Program
    {
        public static String AnaForm = "Form1";

        [STAThread]
        public static void Main()
        {
            Thread.CurrentThread.IsBackground = false;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadExit += new EventHandler(e1);
            Application.ApplicationExit += new EventHandler(e2);
            Control.CheckForIllegalCrossThreadCalls = false;
            Form ana = new Form1();
            ana.Name = AnaForm;
            ana.Closed += new EventHandler(e4);
            ana.Closing += new CancelEventHandler(e3);
            Application.Run(ana);
        }

        private static void e1(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        private static void e2(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private static void e3(object sender, EventArgs e)
        {
        }
        private static void e4(object sender, EventArgs e)
        {
        }
    }
}
