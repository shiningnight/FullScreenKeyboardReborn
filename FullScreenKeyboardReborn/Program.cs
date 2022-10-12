using FullScreenKeyboardReborn.Properties;
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
                Controller = new DController();
                //Controller = new Win32Controller();
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

        public static VkmController Controller { get; private set; }
        public static Settings KeyboardSettings = Settings.Load();
        public static KeyboardHook Hook = new KeyboardHook();
        public delegate void KeyboardHookHandler(int vkCode, KeyboardHook.EventType eventType);
    }
}