using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{

    class DController : VkmController
    {
        //组合键枚举
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            Win = 8
        }

        //鼠标按键枚举 
        public enum MouseBtn
        {
            LeftDown = 1,
            LeftUp = 2,
            RightDown = 4,
            RightUp = 8
        }

        public static Dictionary<Keys, int> CommandCodeMap = new Dictionary<Keys, int>()
        {
            { Keys.LControlKey, 600 },
            { Keys.RControlKey, 607 },
            { Keys.LMenu, 602 },
            { Keys.RMenu, 604 },
            { Keys.LShiftKey, 500 },
            { Keys.RShiftKey, 511 },
            { Keys.LWin, 601 },
            { Keys.RWin, 605 },
        };

        [DllImport("Kernel32")]
        private static extern IntPtr LoadLibrary(string dllfile);

        [DllImport("Kernel32")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);


        public delegate int PDdBtn(int btn);
        public delegate int PDdWhl(int whl);
        public delegate int PDdKey(int ddcode, int flag);
        public delegate int PDdMov(int x, int y);
        public delegate int PDdMovR(int dx, int dy);
        public delegate int PDdStr(string str);
        public delegate int PDdTodc(int vkcode);

        public PDdBtn DdBtn; // 鼠标点击
        public PDdWhl DdWhl; // 鼠标滚轮
        public PDdMov DdMov; // 鼠标绝对移动
        public PDdMovR DdMovR; // 鼠标相对移动
        public PDdKey DdKey; // 键盘按键
        public PDdStr DdStr; // 键盘字符
        public PDdTodc Todc; // 标准虚拟键码转DD码

        private IntPtr _mHinst;

        public DController()
        {
            Load("ddx64.dll");
        }

        public DController(string dllPath)
        {
            Load(dllPath);
        }

         ~DController()
        {
             if (!_mHinst.Equals(IntPtr.Zero))
             {
                 FreeLibrary(_mHinst);
             }
        }

        //取函数地址
        //返回值
        //0：取通用函数地址正确
        public int Load(string dllPath)
        {
            var notFound =  new DllNotFoundException("Dd driver dll not found.");

            _mHinst = LoadLibrary(dllPath);
            if (_mHinst.Equals(IntPtr.Zero))
            {
                throw notFound;
            }

            var loadFailed = new DllNotFoundException("Could not load dd driver dll.");

            var ptr = GetProcAddress(_mHinst, "DD_btn");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            DdBtn = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdBtn)) as PDdBtn;

            ptr = GetProcAddress(_mHinst, "DD_whl");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            DdWhl = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdWhl)) as PDdWhl;
            
            ptr = GetProcAddress(_mHinst, "DD_mov");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            DdMov = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdMov)) as PDdMov;

            ptr = GetProcAddress(_mHinst, "DD_key");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            DdKey = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdKey)) as PDdKey;

            ptr = GetProcAddress(_mHinst, "DD_movR");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            DdMovR = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdMovR)) as PDdMovR;

            ptr = GetProcAddress(_mHinst, "DD_str");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            DdStr = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdStr)) as PDdStr;

            ptr = GetProcAddress(_mHinst, "DD_todc");
            if (ptr.Equals(IntPtr.Zero)) { throw loadFailed; }
            Todc = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdTodc)) as PDdTodc;

            DdBtn(9884625);

            return 0;
        }

        public int Key(Keys vkCode, int flag)
        {
            if (flag == 0)
            {
                flag = 1;
            }
            int commandCode = 0;
            if (CommandCodeMap.ContainsKey(vkCode))
            {
                commandCode = CommandCodeMap[vkCode];
            }
            else 
            {
                commandCode = Todc((int)vkCode);
            }
            return DdKey(commandCode, flag);
        }
    }

}
