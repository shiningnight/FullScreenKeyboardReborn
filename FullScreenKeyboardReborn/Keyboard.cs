using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FullScreenKeyboardReborn.Keyboard;

namespace FullScreenKeyboardReborn
{
    internal class Keyboard
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

        public Dictionary<Keys, bool> LockStatus = new Dictionary<Keys, bool>()
        {
            {Keys.NumLock, false},
            {Keys.CapsLock, false},
            {Keys.Scroll, false},
        };
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
        public event Program.KeyboardEventHandler KeyEvent;
        public event Program.KeyboardLockEventHandler LockEvent;

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

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

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
                Keys vkCode = (Keys)keyboardMessage.vkCode;
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    KeyEvent(vkCode, EventType.Down);
                }

                if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                {
                    KeyEvent(vkCode, EventType.Up);
                }

                if ((vkCode == Keys.CapsLock
                    || vkCode == Keys.NumLock
                    || vkCode == Keys.Scroll)
                    //&& (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                    && LockEvent != null)
                {
                    UpdateLockStatus();
                    LockEvent(vkCode, (((ushort)GetKeyState(keyboardMessage.vkCode)) & 1) != 0);
                }

            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        public Keyboard()
        {
            UpdateLockStatus();
        }

        private void UpdateLockStatus()
        {
            LockStatus[Keys.NumLock] = ((ushort)GetKeyState((int)Keys.NumLock) & 1) != 0;
            LockStatus[Keys.CapsLock] = ((ushort)GetKeyState((int)Keys.CapsLock) & 1) != 0;
            LockStatus[Keys.Scroll] = ((ushort)GetKeyState((int)Keys.Scroll) & 1) != 0;
        }

        ~Keyboard()
        {
            Stop();
        }
    }
}
