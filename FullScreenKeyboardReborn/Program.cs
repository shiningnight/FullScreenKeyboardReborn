using FullScreenKeyboardReborn.Properties;
using MetroFramework.Components;
using MetroFramework.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Resources = FullScreenKeyboardReborn.Properties.Resources;

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
            Logger.AutoFlush = true;
            try
            {
                Controller = new DController();
                //Controller = new Win32Controller();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
                MStyleManager.Style = MetroFramework.MetroColorStyle.Purple;
                //IconFontFamily = new FontFamily("FontAwesome");
                IconFontFamily = LoadIconFontFamily();
                Application.Run(new MainBoard());
            }
            catch (Exception e)
            {
                Console.WriteLine($"[E][{DateTime.Now}]{e}");
                Logger.WriteLine($"[E][{DateTime.Now}]{e}");
                MessageBox.Show($"{e}");
                Environment.Exit(-1);
            }
        }

        static FontFamily LoadIconFontFamily()
        {
            var pfc = new PrivateFontCollection();
            //byte[] fontData = Resources.FontAwesome;
            //byte[] fontData = Resources.NotoEmoji;
            byte[] fontData = Resources.fontawesomettf;
            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    pfc.AddMemoryFont((IntPtr)pFontData, fontData.Length);
                }
            }
            //pfc.AddFontFile("Resources\\FontAwesome.otf");
            return pfc.Families.FirstOrDefault();
        }

        public static VkmController Controller { get; private set; }
        public static FontFamily IconFontFamily;
        public static Settings KeyboardSettings = Settings.Load();
        public static MetroStyleManager MStyleManager = new MetroStyleManager();
        public static Keyboard VKeyboard = new Keyboard();
        public static StreamWriter Logger = new StreamWriter("fskr.log", true);

        public delegate void KeyboardEventHandler(Keys vkCode, Keyboard.EventType eventType);
        public delegate void KeyboardLockEventHandler(Keys lockKey, bool isOn);
    }
}