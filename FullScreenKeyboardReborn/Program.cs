﻿using FullScreenKeyboardReborn.Properties;
using MetroFramework.Components;
using MetroFramework.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
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
            MStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            MStyleManager.Style = MetroFramework.MetroColorStyle.Purple;
            IconFontFamily = LoadIconFontFamily();
            Application.Run(new MainBoard());
        }

        static FontFamily LoadIconFontFamily()
        {
            var pfc = new PrivateFontCollection();
            byte[] fontData = Resources.FontAwesome;
            //byte[] fontData = Resources.NotoEmoji;
            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    pfc.AddMemoryFont((IntPtr)pFontData, fontData.Length);
                    return pfc.Families[0];
                }
            }
        }

        public static VkmController Controller { get; private set; }
        public static Settings KeyboardSettings = Settings.Load();
        public static MetroStyleManager MStyleManager = new MetroStyleManager();
        public static Keyboard VKeyboard = new Keyboard();
        public static FontFamily IconFontFamily = new FontFamily(GenericFontFamilies.SansSerif);
        public delegate void KeyboardEventHandler(Keys vkCode, Keyboard.EventType eventType);
        public delegate void KeyboardLockEventHandler(Keys lockKey, bool isOn);
    }
}