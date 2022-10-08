using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{
    internal class KeyboardHook
    {

        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardMessage
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        public enum EventType
        {
            Down,
            Up,
            Press
        }

        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        public event Program.KeyboardHookHandler KeyEvent;

        private HookProc KeyboardHookProcedure;
        private static int hKeyboardHook = 0; 

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public void Start()
        {
            // 安装键盘钩子
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);

                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("Keyboard Hook Installing Failed.");
                }
            }
        }
        public void Stop()
        {
            bool retKeyboard = true;

            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }

            if (!(retKeyboard)) throw new Exception("Keyboard Hook Uninstalling Failed.");
        }


        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (nCode >= 0 && KeyEvent != null)
            {
                KeyboardMessage keyboardMessage = (KeyboardMessage)Marshal.PtrToStructure(lParam, typeof(KeyboardMessage));

                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    KeyEvent(keyboardMessage.vkCode, EventType.Down);
                }

                if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                {
                    KeyEvent(keyboardMessage.vkCode, EventType.Up);
                }

            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
        ~KeyboardHook()
        {
            Stop();
        }
    }
}
