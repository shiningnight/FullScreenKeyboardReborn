using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{
    internal class Win32Controller : VkmController
    {

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        private static extern void KeyEvent(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public int Key(Keys vkCode, int flag)
        {
            KeyEvent(vkCode, 0, (uint)flag, 0);
            return 0;
        }
    }
}
