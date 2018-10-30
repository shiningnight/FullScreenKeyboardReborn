﻿using System;
using System.Runtime.InteropServices;

namespace FullScreenKeyboardReborn
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

    class DController
    {
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

        public PDdBtn Btn; // 鼠标点击
        public PDdWhl Whl; // 鼠标滚轮
        public PDdMov Mov; // 鼠标绝对移动
        public PDdMovR MovR; // 鼠标相对移动
        public PDdKey Key; // 键盘按键
        public PDdStr Str; // 键盘字符
        public PDdTodc Todc; // 标准虚拟键码转DD码

        private IntPtr _mHinst;

         ~DController()
        {
             if (!_mHinst.Equals(IntPtr.Zero))
             {
                 bool b = FreeLibrary(_mHinst);
             }
        }


        public int Load(string dllfile)
        {
            _mHinst = LoadLibrary(dllfile);
            if (_mHinst.Equals(IntPtr.Zero))
            {
                return -2;
            }

            return InitDdFuncEndpoint(_mHinst);
        }

        //取函数地址
        //返回值
        //-1：取通用函数地址错误,0：取通用函数地址正确
        private int InitDdFuncEndpoint(IntPtr hinst)
        {
            IntPtr ptr;

            ptr = GetProcAddress(hinst, "DD_btn");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            Btn = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdBtn)) as PDdBtn;

            ptr = GetProcAddress(hinst, "DD_whl");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            Whl = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdWhl)) as PDdWhl;
            
            ptr = GetProcAddress(hinst, "DD_mov");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            Mov = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdMov)) as PDdMov;

            ptr = GetProcAddress(hinst, "DD_key");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            Key = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdKey)) as PDdKey;

            ptr = GetProcAddress(hinst, "DD_movR");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            MovR = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdMovR)) as PDdMovR;

            ptr = GetProcAddress(hinst, "DD_str");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            Str = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdStr)) as PDdStr;

            ptr = GetProcAddress(hinst, "DD_todc");
            if (ptr.Equals(IntPtr.Zero)) { return -1; }
            Todc = Marshal.GetDelegateForFunctionPointer(ptr, typeof(PDdTodc)) as PDdTodc;

            return 0;
        }
    }

}
