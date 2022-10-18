using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Timer = System.Timers.Timer;

namespace FullScreenKeyboardReborn
{
    // todo Next version: Image Button tag(key name) feature
    internal class VirtualKey : MetroButton
    {
        public enum ActionMode
        {
            None,
            Hold,
            HoldLock,
            Strum,
            Repeat,
            RepeatLock,
            AutoShift
        }

        public static Keys[] AutoHoldKeys = new Keys[] {
            Keys.LControlKey,
            Keys.RControlKey,
            Keys.LMenu,
            Keys.RMenu,
            Keys.LShiftKey,
            Keys.RShiftKey,
            Keys.LWin,
            Keys.RWin,
        };

        public static readonly Dictionary<Keys, string> DefaultKeyNames = new Dictionary<Keys, string>() {
            { Keys.Enter, "Enter" },
            { Keys.Escape, "Esc" },
            { Keys.Space, "" },
            { Keys.Back, "⬅" },
            { Keys.Up, "⬆" },
            { Keys.Down, "⬇" },
            { Keys.Left, "⬅" },
            { Keys.Right, "➡" },
            { Keys.PageUp, "PgUp" },
            { Keys.PageDown, "PgDn" },
            { Keys.Insert, "Ins" },
            { Keys.Delete, "Del" },
            { Keys.PrintScreen, "\uf030" },//📸
            { Keys.NumLock, "NumL" },
            { Keys.CapsLock, "Caps" },
            { Keys.Scroll, "ScrL" },
            { Keys.Oemtilde, "`" },
            { Keys.OemQuestion, "/" },
            { Keys.OemPeriod, "." },
            { Keys.Oemcomma, "," },
            { Keys.OemSemicolon, ";" },
            { Keys.OemQuotes, "\'" },
            { Keys.OemOpenBrackets, "[" },
            { Keys.OemCloseBrackets, "]" },
            { Keys.OemMinus, "-" },
            { Keys.Oemplus, "=" },
            { Keys.OemPipe, "\\" },
            { Keys.ControlKey, "Ctrl" },
            { Keys.LControlKey, "Ctrl" },
            { Keys.RControlKey, "Ctrl" },
            { Keys.Menu, "Alt" },
            { Keys.LMenu, "Alt" },
            { Keys.RMenu, "Alt" },
            { Keys.ShiftKey, "Shift" },
            { Keys.LShiftKey, "Shift" },
            { Keys.RShiftKey, "Shift" },
            { Keys.LWin, "\uf17a" },
            { Keys.RWin, "\uf17a" },
            { Keys.Add, "+" },
            { Keys.Subtract, "-" },
            { Keys.Multiply, "*" },
            { Keys.Divide, "/" },
            { Keys.Decimal, "." },
            //↗↘↙↖
        };
        public static readonly Dictionary<Keys, string> ShiftKeyNames = new Dictionary<Keys, string>() {
            { Keys.Oemtilde, "~" },
            { Keys.OemQuestion, "?" },
            { Keys.OemPeriod, ">" },
            { Keys.Oemcomma, "<" },
            { Keys.OemSemicolon, ":" },
            { Keys.OemQuotes, "\"" },
            { Keys.OemOpenBrackets, "{" },
            { Keys.OemCloseBrackets, "}" },
            { Keys.OemMinus, "_" },
            { Keys.Oemplus, "+" },
            { Keys.OemPipe, "|" },
            { Keys.Decimal, "Del" },
            { Keys.NumPad0, "Ins" },
            { Keys.NumPad2, "⬇" },
            { Keys.NumPad4, "⬅" },
            { Keys.NumPad6, "➡" },
            { Keys.NumPad8, "⬆" },
            { Keys.NumPad1, "End" },
            { Keys.NumPad3, "PgDn" },
            { Keys.NumPad5, "" },
            { Keys.NumPad7, "Home" },
            { Keys.NumPad9, "PgUp" },
            { Keys.D0, ")" },
            { Keys.D1, "!" },
            { Keys.D2, "@" },
            { Keys.D3, "#" },
            { Keys.D4, "$" },
            { Keys.D5, "%" },
            { Keys.D6, "^" },
            { Keys.D7, "&" },
            { Keys.D8, "*" },
            { Keys.D9, "(" },
        };

        public VirtualKey()
        {
            EventsInit();
            ComponentInit();
        }

        public VirtualKey(string keyLabel, List<Point> boundry, List<Keys> vkCodes, Font mainFont, Dictionary<string, string> parameters)
        {
            EventsInit();
            ComponentInit();

            Boundary = boundry;
            if (Boundary.Count == 2)
            {
                Location = Boundary[0];
                Size = new Size(Boundary[1].X - Boundary[0].X, Boundary[1].Y - Boundary[0].Y);
                BoundryPath = GetRoundedRectPath(new Rectangle(0, 0, Width, Height), 10);
                Region = new Region(BoundryPath);
            }
            else if (Boundary.Count > 2)
            {
                var Xs = new List<int>();
                var Ys = new List<int>();
                Boundary.ForEach(delegate (Point point)
                {
                    Xs.Add(point.X);
                    Ys.Add(point.Y);
                });
                int xMin = Xs.Min();
                int yMin = Ys.Min();

                Location = new Point(xMin, yMin);
                Size = new Size(Xs.Max() - xMin, Ys.Max() - yMin);
                var points = new List<Point>();
                Boundary.ForEach(delegate (Point point)
                {
                    points.Add(new Point(point.X - xMin, point.Y - yMin));
                });

                BoundryPath.AddClosedCurve(points.ToArray(), 0);
                Region = new Region(BoundryPath);
            }

            string keyName = vkCodes[0].ToString();
            if (keyLabel != "")
            {
                KeyLabel = keyLabel;
            }
            else if (DefaultKeyNames.ContainsKey(vkCodes[0]))
            {
                KeyLabel = DefaultKeyNames[vkCodes[0]];
            }
            else if (keyName.Contains("D") && keyName.Length == 2)
            {
                KeyLabel = keyName.Substring(1);
            }
            else if (keyName.Contains("Num") && keyName.Length == 7)
            {
                KeyLabel = keyName.Substring(6);
            }
            else if (keyName[0] <= 'Z' && keyName[0] >= 'A' && keyName.Length == 1)
            {
                if (!Program.VKeyboard.LockStatus[Keys.CapsLock])
                {
                    KeyLabel = keyName.ToLower();
                }
                else
                {
                    KeyLabel = keyName.ToUpper();
                }
            }
            else
            {
                KeyLabel = keyName;
            }

            NormalKeyLabel = KeyLabel.ToString();
            if (vkCodes.Count == 1 && ShiftKeyNames.ContainsKey(vkCodes[0]))
            {
                ShiftKeyLabel = ShiftKeyNames[vkCodes[0]];
            }
            else
            {
                ShiftKeyLabel = "";
            }

            if (vkCodes.Count == 1
            && ((vkCodes[0] >= Keys.NumPad0 && vkCodes[0] <= Keys.NumPad9) || vkCodes[0] == Keys.Decimal)
            )
            {
                if (Program.VKeyboard.LockStatus[Keys.NumLock])
                {
                    KeyLabel = NormalKeyLabel;
                }
                else
                {
                    KeyLabel = ShiftKeyLabel;
                }
            }

            if (KeyLabel.Length > 0 && KeyLabel[0] >= '\uf000')
            {
                Font = NormalIconFont;
            }
            else
            {
                Font = mainFont;
            }

            if (vkCodes.Count == 1 && Program.VKeyboard.LockStatus.ContainsKey(vkCodes[0]))
            {
                Pressed = Program.VKeyboard.LockStatus[vkCodes[0]];
                Repaint();
            }

            VkCodes.AddRange(vkCodes);
            #region KeysTable
            /*if(vkCodes.Length == 1)
            {
                switch (vkCodes[0])
                {
                    case Keys.KeyCode:
                        break;
                    case Keys.Modifiers:
                        break;
                    case Keys.None:
                        break;
                    case Keys.LButton:
                        break;
                    case Keys.RButton:
                        break;
                    case Keys.Cancel:
                        break;
                    case Keys.MButton:
                        break;
                    case Keys.XButton1:
                        break;
                    case Keys.XButton2:
                        break;
                    case Keys.Back:
                        break;
                    case Keys.Tab:
                        break;
                    case Keys.LineFeed:
                        break;
                    case Keys.Clear:
                        break;
                    case Keys.Enter:
                        break;
                    case Keys.ShiftKey:
                        break;
                    case Keys.ControlKey:
                        break;
                    case Keys.Menu:
                        break;
                    case Keys.Pause:
                        break;
                    case Keys.CapsLock:
                        break;
                    case Keys.KanaMode:
                        break;
                    case Keys.JunjaMode:
                        break;
                    case Keys.FinalMode:
                        break;
                    case Keys.KanjiMode:
                        break;
                    case Keys.Escape:
                        break;
                    case Keys.IMEConvert:
                        break;
                    case Keys.IMENonconvert:
                        break;
                    case Keys.IMEAccept:
                        break;
                    case Keys.IMEModeChange:
                        break;
                    case Keys.Space:
                        break;
                    case Keys.PageUp:
                        break;
                    case Keys.PageDown:
                        break;
                    case Keys.End:
                        break;
                    case Keys.Home:
                        break;
                    case Keys.Left:
                        break;
                    case Keys.Up:
                        break;
                    case Keys.Right:
                        break;
                    case Keys.Down:
                        break;
                    case Keys.Select:
                        break;
                    case Keys.Print:
                        break;
                    case Keys.Execute:
                        break;
                    case Keys.PrintScreen:
                        break;
                    case Keys.Insert:
                        break;
                    case Keys.Delete:
                        break;
                    case Keys.Help:
                        break;
                    case Keys.D0:
                        break;
                    case Keys.D1:
                        break;
                    case Keys.D2:
                        break;
                    case Keys.D3:
                        break;
                    case Keys.D4:
                        break;
                    case Keys.D5:
                        break;
                    case Keys.D6:
                        break;
                    case Keys.D7:
                        break;
                    case Keys.D8:
                        break;
                    case Keys.D9:
                        break;
                    case Keys.A:
                        break;
                    case Keys.B:
                        break;
                    case Keys.C:
                        break;
                    case Keys.D:
                        break;
                    case Keys.E:
                        break;
                    case Keys.F:
                        break;
                    case Keys.G:
                        break;
                    case Keys.H:
                        break;
                    case Keys.I:
                        break;
                    case Keys.J:
                        break;
                    case Keys.K:
                        break;
                    case Keys.L:
                        break;
                    case Keys.M:
                        break;
                    case Keys.N:
                        break;
                    case Keys.O:
                        break;
                    case Keys.P:
                        break;
                    case Keys.Q:
                        break;
                    case Keys.R:
                        break;
                    case Keys.S:
                        break;
                    case Keys.T:
                        break;
                    case Keys.U:
                        break;
                    case Keys.V:
                        break;
                    case Keys.W:
                        break;
                    case Keys.X:
                        break;
                    case Keys.Y:
                        break;
                    case Keys.Z:
                        break;
                    case Keys.LWin:
                        break;
                    case Keys.RWin:
                        break;
                    case Keys.Apps:
                        break;
                    case Keys.Sleep:
                        break;
                    case Keys.NumPad0:
                        break;
                    case Keys.NumPad1:
                        break;
                    case Keys.NumPad2:
                        break;
                    case Keys.NumPad3:
                        break;
                    case Keys.NumPad4:
                        break;
                    case Keys.NumPad5:
                        break;
                    case Keys.NumPad6:
                        break;
                    case Keys.NumPad7:
                        break;
                    case Keys.NumPad8:
                        break;
                    case Keys.NumPad9:
                        break;
                    case Keys.Multiply:
                        break;
                    case Keys.Add:
                        break;
                    case Keys.Separator:
                        break;
                    case Keys.Subtract:
                        break;
                    case Keys.Decimal:
                        break;
                    case Keys.Divide:
                        break;
                    case Keys.F1:
                        break;
                    case Keys.F2:
                        break;
                    case Keys.F3:
                        break;
                    case Keys.F4:
                        break;
                    case Keys.F5:
                        break;
                    case Keys.F6:
                        break;
                    case Keys.F7:
                        break;
                    case Keys.F8:
                        break;
                    case Keys.F9:
                        break;
                    case Keys.F10:
                        break;
                    case Keys.F11:
                        break;
                    case Keys.F12:
                        break;
                    case Keys.F13:
                        break;
                    case Keys.F14:
                        break;
                    case Keys.F15:
                        break;
                    case Keys.F16:
                        break;
                    case Keys.F17:
                        break;
                    case Keys.F18:
                        break;
                    case Keys.F19:
                        break;
                    case Keys.F20:
                        break;
                    case Keys.F21:
                        break;
                    case Keys.F22:
                        break;
                    case Keys.F23:
                        break;
                    case Keys.F24:
                        break;
                    case Keys.NumLock:
                        break;
                    case Keys.Scroll:
                        break;
                    case Keys.LShiftKey:
                        break;
                    case Keys.RShiftKey:
                        break;
                    case Keys.LControlKey:
                        break;
                    case Keys.RControlKey:
                        break;
                    case Keys.LMenu:
                        break;
                    case Keys.RMenu:
                        break;
                    case Keys.BrowserBack:
                        break;
                    case Keys.BrowserForward:
                        break;
                    case Keys.BrowserRefresh:
                        break;
                    case Keys.BrowserStop:
                        break;
                    case Keys.BrowserSearch:
                        break;
                    case Keys.BrowserFavorites:
                        break;
                    case Keys.BrowserHome:
                        break;
                    case Keys.VolumeMute:
                        break;
                    case Keys.VolumeDown:
                        break;
                    case Keys.VolumeUp:
                        break;
                    case Keys.MediaNextTrack:
                        break;
                    case Keys.MediaPreviousTrack:
                        break;
                    case Keys.MediaStop:
                        break;
                    case Keys.MediaPlayPause:
                        break;
                    case Keys.LaunchMail:
                        break;
                    case Keys.SelectMedia:
                        break;
                    case Keys.LaunchApplication1:
                        break;
                    case Keys.LaunchApplication2:
                        break;
                    case Keys.OemSemicolon:
                        break;
                    case Keys.Oemplus:
                        break;
                    case Keys.Oemcomma:
                        break;
                    case Keys.OemMinus:
                        break;
                    case Keys.OemPeriod:
                        break;
                    case Keys.OemQuestion:
                        break;
                    case Keys.Oemtilde:
                        break;
                    case Keys.OemOpenBrackets:
                        break;
                    case Keys.OemPipe:
                        break;
                    case Keys.OemCloseBrackets:
                        break;
                    case Keys.OemQuotes:
                        break;
                    case Keys.Oem8:
                        break;
                    case Keys.OemBackslash:
                        break;
                    case Keys.ProcessKey:
                        break;
                    case Keys.Packet:
                        break;
                    case Keys.Attn:
                        break;
                    case Keys.Crsel:
                        break;
                    case Keys.Exsel:
                        break;
                    case Keys.EraseEof:
                        break;
                    case Keys.Play:
                        break;
                    case Keys.Zoom:
                        break;
                    case Keys.NoName:
                        break;
                    case Keys.Pa1:
                        break;
                    case Keys.OemClear:
                        break;
                    case Keys.Shift:
                        break;
                    case Keys.Control:
                        break;
                    case Keys.Alt:
                        break;
                    default:
                        break;
                }
            }*/
            #endregion
        }

        private void Down()
        {
            foreach (var keyCode in VkCodes)
            {
                Program.Controller.Key(keyCode, 0);
            }
        }

        private void Up()
        {
            //VkCodes.Reverse();
            foreach (var keyCode in VkCodes)
            {
                Program.Controller.Key(keyCode, 2);
            }
            //VkCodes.Reverse();
        }

        private void Strum()
        {
            foreach (var keyCode in VkCodes)
            {
                Program.Controller.Key(keyCode, 0);
                Thread.Sleep(Program.KeyboardSettings.PressDelay);
                Program.Controller.Key(keyCode, 2);
                Thread.Sleep(Program.KeyboardSettings.ActionDelay);
            }
        }

        private void Press()
        {
            Down();
            Thread.Sleep(Program.KeyboardSettings.PressDelay);
            Up();
        }

        private void Toggle()
        {
            if (Holding)
            {
                Up();
                Holding = false;
            }
            else
            {
                Down();
                Holding = true;
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Boundary == null)
            {
                return;
            }
            e.Graphics.Clear(BackColor);
            if (Hovering)
            {
                //e.Graphics.DrawRectangle(new Pen(BorderColor, 2), 0, 0, Width, Height);
                e.Graphics.DrawPath(new Pen(BorderColor, 3), BoundryPath);
            }

            StringFormat gs = new StringFormat();
            gs.Alignment = StringAlignment.Center;
            gs.LineAlignment = StringAlignment.Center;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString(KeyLabel, Font, new SolidBrush(ForeColor), Width / 2, Height / 2, gs);
            //e.Graphics.DrawString(KeyLabel, Font, new SolidBrush(ForeColor), new RectangleF(0, 0, Width, Height), gs);

        }

        private void Repaint()
        {
            if (Repeating)
            {
                ForeColor = RepeatingForeColor;
            }
            else if (Pressed)
            {
                ForeColor = PressedForeColor;
            }
            else if (Hovering)
            {
                ForeColor = NormalForeColor;
                BackColor = HoveringBackColor;
            }
            else
            {
                ForeColor = NormalForeColor;
                BackColor = NormalBackColor;
            }
            if (Pressed)
            {
                BackColor = PressedBackColor;
            }
            Refresh();
        }

        private void ComponentInit()
        {
            SuspendLayout();
            // todo Designer Support fix: Override each following fields' Reset method, to avoid duplicated initializing, and to improve property window display(default value still gets bolded).
            //Theme = MetroThemeStyle.Dark;
            //Style = MetroColorStyle.Purple;
            UseCustomForeColor = true;
            UseCustomBackColor = true;
            SetStyle(ControlStyles.Selectable, false);
            //Highlight = true;
            ForeColor = NormalForeColor;
            BackColor = NormalBackColor;
            Font = NormalFont;
            Size = new Size(36, 36);
            Margin = new Padding(1);
            ResumeLayout(false);
        }

        private void BeginAction(ActionMode actionMode)
        {
            switch (actionMode)
            {
                case ActionMode.None:
                    break;
                case ActionMode.Hold:
                    if (AutoHoldKeys.Contains(VkCodes[0]) && VkCodes.Count() == 1)
                    {
                        Toggle();
                    }
                    else
                    {
                        Down();
                        if (Program.KeyboardSettings.AllowRepeating)
                        {
                            repeatDelayTimer.Interval = Program.KeyboardSettings.RepeatDelay;
                            repeatDelayTimer.Start();
                            Holding = true;
                        }
                    }
                    break;
                case ActionMode.HoldLock:
                    break;
                case ActionMode.Strum:
                    break;
                case ActionMode.Repeat:
                    if (!Repeating)
                    {
                        repeatTimer.Interval = Program.KeyboardSettings.RepeatInterval;
                        repeatTimer.Start();
                        Repeating = true;
                    }
                    break;
                case ActionMode.RepeatLock:
                    break;
                case ActionMode.AutoShift:
                    Program.Controller.Key(Keys.LShiftKey, 0);
                    BeginAction(ActionMode.Hold);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //Repaint();
        }

        private void EndAction(ActionMode actionMode)
        {
            switch (actionMode)
            {
                case ActionMode.None:
                    break;
                case ActionMode.Hold:
                    if (AutoHoldKeys.Contains(VkCodes[0]) && VkCodes.Count() == 1)
                    {

                    }
                    else
                    {
                        Up();
                        if (Holding && !Repeating)
                        {
                            repeatDelayTimer.Stop();
                            Holding = false;
                        }
                        if (Repeating)
                        {
                            repeatTimer.Stop();
                            Repeating = false;
                        }
                    }
                    break;
                case ActionMode.HoldLock:
                    if (Repeating)
                    {
                        break;
                    }
                    Toggle();
                    HoldLocked = !HoldLocked;
                    break;
                case ActionMode.Strum:
                    Strum();
                    break;
                case ActionMode.Repeat:
                    if (Repeating)
                    {
                        repeatTimer.Stop();
                        Repeating = false;
                        Up();
                    }
                    break;
                case ActionMode.RepeatLock:
                    if (Holding)
                    {
                        break;
                    }
                    if (Repeating)
                    {
                        repeatTimer.Stop();
                        Repeating = false;
                        Up();
                    }
                    else
                    {
                        BeginAction(ActionMode.Repeat);
                    }
                    break;
                case ActionMode.AutoShift:
                    EndAction(ActionMode.Hold);
                    Program.Controller.Key(Keys.LShiftKey, 2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //Repaint();
        }

        private void EventsInit()
        {
            repeatTimer.Elapsed += delegate { Down(); };
            repeatDelayTimer.Elapsed += delegate
            {
                BeginAction(ActionMode.Repeat);
            };
            repeatDelayTimer.AutoReset = false;

            MouseDown += new MouseEventHandler((sender, e) =>
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            BeginAction(Program.KeyboardSettings.ActionModeLeft);
                            break;
                        case MouseButtons.Right:
                            BeginAction((Program.KeyboardSettings.ActionModeRight));
                            break;
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Middle:
                            BeginAction(Program.KeyboardSettings.ActionModeWheel);
                            break;
                        case MouseButtons.XButton1:
                            break;
                        case MouseButtons.XButton2:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            );
            MouseUp += new MouseEventHandler((sender, e) =>
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            EndAction(Program.KeyboardSettings.ActionModeLeft);
                            break;
                        case MouseButtons.Right:
                            EndAction((Program.KeyboardSettings.ActionModeRight));
                            break;
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Middle:
                            EndAction(Program.KeyboardSettings.ActionModeWheel);
                            break;
                        case MouseButtons.XButton1:
                            break;
                        case MouseButtons.XButton2:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            );
            MouseEnter += new EventHandler((sender, e) =>
                {
                    Focus();
                    Hovering = true;
                    Repaint();
                }
            );
            MouseLeave += new EventHandler((sender, e) =>
                {
                    Hovering = false;
                    Repaint();
                }
            );
            MouseWheel += new MouseEventHandler((sender, e) =>
                {
                    if (e.Delta > 0)
                    {
                        EndAction(Program.KeyboardSettings.ActionModeWheelUp);
                    }
                    else if (e.Delta < 0)
                    {
                        EndAction(Program.KeyboardSettings.ActionModeWheelDown);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            );

            Program.VKeyboard.KeyEvent += new Program.KeyboardEventHandler((vkCode, eventType) =>
                {
                    if (VkCodes.Count == 1 && vkCode == VkCodes[0])
                    {
                        switch (eventType)
                        {
                            case Keyboard.EventType.Down:
                                Pressed = true;
                                break;
                            case Keyboard.EventType.Up:
                                Pressed = false;
                                break;
                            case Keyboard.EventType.Press:
                                break;
                            default:
                                break;
                        }
                        Repaint();
                    }

                    if (!AutoHoldKeys.Contains(vkCode)
                    && VkCodes.Count == 1 && AutoHoldKeys.Contains(VkCodes[0])
                    && eventType == Keyboard.EventType.Up && vkCode != VkCodes[0]
                    && !Repeating && !HoldLocked && Pressed)
                    {
                        Up();
                        Holding = false;
                        Pressed = false;
                    }

                    if ((ShiftKeyNames.ContainsKey(VkCodes[0]) || (VkCodes[0] >= Keys.A && VkCodes[0] <= Keys.Z)) && VkCodes.Count == 1
                    && (vkCode == Keys.LShiftKey || vkCode == Keys.RShiftKey)
                    )
                    {
                        if (VkCodes.Count == 1
                        && ((VkCodes[0] >= Keys.NumPad0 && VkCodes[0] <= Keys.NumPad9) || VkCodes[0] == Keys.Decimal)
                        && !Program.VKeyboard.LockStatus[Keys.NumLock])
                        {

                        }
                        else
                        {
                            switch (eventType)
                            {
                                case Keyboard.EventType.Down:
                                    if (VkCodes[0] >= Keys.A && VkCodes[0] <= Keys.Z)
                                    {
                                        if (!Program.VKeyboard.LockStatus[Keys.CapsLock])
                                        {
                                            KeyLabel = KeyLabel.ToUpper();
                                        }
                                        else
                                        {
                                            KeyLabel = KeyLabel.ToLower();
                                        }
                                    }
                                    else
                                    {
                                        KeyLabel = ShiftKeyLabel;
                                    }
                                    break;
                                case Keyboard.EventType.Up:
                                    if (VkCodes[0] >= Keys.A && VkCodes[0] <= Keys.Z)
                                    {
                                        if (!Program.VKeyboard.LockStatus[Keys.CapsLock])
                                        {
                                            KeyLabel = KeyLabel.ToLower();
                                        }
                                        else
                                        {
                                            KeyLabel = KeyLabel.ToUpper();
                                        }
                                    }
                                    else
                                    {
                                        KeyLabel = NormalKeyLabel;
                                    }
                                    break;
                                case Keyboard.EventType.Press:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                }
            );

            Program.VKeyboard.LockEvent += OnKeyboardLockChange;
        }

        private void OnKeyboardLockChange(Keys lockKey, bool isOn)
        {
            if (VkCodes.Count == 1
            && ((VkCodes[0] >= Keys.NumPad0 && VkCodes[0] <= Keys.NumPad9) || VkCodes[0] == Keys.Decimal)
            && lockKey == Keys.NumLock
            )
            {
                if (isOn)
                {
                    KeyLabel = NormalKeyLabel;
                }
                else
                {
                    KeyLabel = ShiftKeyLabel;
                }
            }
            else if (VkCodes.Count == 1
            && (VkCodes[0] >= Keys.A && VkCodes[0] <= Keys.Z)
            && lockKey == Keys.CapsLock
            )
            {
                if (isOn)
                {
                    KeyLabel = KeyLabel.ToUpper();
                }
                else
                {
                    KeyLabel = KeyLabel.ToLower();
                }
            }
            else if (VkCodes.Count == 1 && VkCodes[0] == lockKey)
            {
                Pressed = isOn;
                Repaint();
            }
        }

        private readonly Color NormalBackColor = MetroColors.Silver;
        private readonly Color PressedBackColor = Color.LightCyan;
        private readonly Color NormalForeColor = Color.White;
        private readonly Color PressedForeColor = Color.Black;
        private readonly Color HoveringBackColor = Color.DarkGray;
        private readonly Color RepeatingForeColor = MetroColors.Red;
        private readonly Color BorderColor = MetroColors.Blue;
        //private readonly Font NormalFont = new Font("monofur", 10, FontStyle.Regular);
        private readonly Font NormalFont = Program.KeyboardSettings.MainFont;
        private readonly Font NormalIconFont = new Font(Program.IconFontFamily, 10, FontStyle.Regular);

        private string NormalKeyLabel;
        private string ShiftKeyLabel;

        private bool Holding = false;
        private bool HoldLocked = false;
        private bool Repeating = false;
        private bool Hovering = false;
        private bool Pressed = false;

        private readonly Timer repeatTimer = new Timer(Program.KeyboardSettings.RepeatInterval);
        private readonly Timer repeatDelayTimer = new Timer(Program.KeyboardSettings.RepeatDelay);

        GraphicsPath BoundryPath = new GraphicsPath();

        [Browsable(true)]
        [Description("Boundary points of the button.")]
        [Category("!VKProperties")]
        public List<Point> Boundary { get; set; } = new List<Point>();

        [Browsable(true)]
        [Description("Displayed label on the button. Alias of Text.")]
        [Category("!VKProperties")]
        public string KeyLabel
        {
            get => Text;
            set => Text = value;
        }

        // todo Designer Support fix: still can't edit key code directly, any way to avoid Object edit window?
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description(
            "Virtual key codes for the corresponding physical key."
        )]
        [Category("!VKProperties")]
        public List<Keys> VkCodes { get; set; } = new List<Keys>();


    }
}