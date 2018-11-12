using System;
using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //todo Single Instance feature: if there is already a instance running, toggle its visible status instead of opening a new one.

            try
            {
                VkmController = new DController("ddx64.dll");
            }
            catch (DllNotFoundException e)
            {
                Console.WriteLine(e);
                Environment.Exit(-1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainBoard());
        }

        public static DController VkmController { get; private set; }
    }
}