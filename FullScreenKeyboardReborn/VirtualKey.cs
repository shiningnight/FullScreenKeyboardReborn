using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Timer = System.Timers.Timer;

namespace FullScreenKeyboardReborn
{
    // todo Next version: Polygon Button feature(needs override onPaint for sure)
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
            RepeatLock
        }

        public VirtualKey()
        {
            EventsInit();
            ComponentInit();
        }

        public VirtualKey(string keyLabel, List<Point> boundry, List<Keys> vkCodes)
        {
            EventsInit();
            ComponentInit();

            Boundary = boundry;
            if (Boundary != null && Boundary.Count == 2)
            {
                Bounds = new Rectangle(Boundary[0], new Size(Boundary[1].X - Boundary[0].X, Boundary[1].Y - Boundary[0].Y));
            }

            KeyLabel = keyLabel;
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
            VkCodes.Reverse();
            foreach (var keyCode in VkCodes)
            {
                Program.Controller.Key(keyCode, 2);
            }
            VkCodes.Reverse();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            //Console.WriteLine($"paint>{KeyLabel}");
            base.OnPaint(e);
            if (Boundary != null && Boundary.Count > 2)
            {
                Bounds = new Rectangle(1000, 1000, 36, 36);
            }
        }

        private void Repaint()
        {
            ForeColor = Pressed ? PressedForeColor : NormalForeColor;
            BackColor = Pressed ? PressedBackColor : NormalBackColor;
            Refresh();
        }

        private void ComponentInit()
        {
            SuspendLayout();
            // todo Designer Support fix: Override each following fields' Reset method, to avoid duplicated initializing, and to improve property window display(default value still gets bolded).
            Theme = MetroThemeStyle.Dark;
            Style = MetroColorStyle.Purple;
            UseCustomForeColor = true;
            UseCustomBackColor = true;
            SetStyle(ControlStyles.Selectable, false);
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
                    Down();
                    //Holding = false;
                    //holdDelayTimer.Start();
                    break;
                case ActionMode.HoldLock:
                    break;
                case ActionMode.Strum:
                    break;
                case ActionMode.Repeat:
                    if (!Repeating)
                    {
                        repeatTimer.Start();
                        Repeating = true;
                    }
                    break;
                case ActionMode.RepeatLock:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void EndAction(ActionMode actionMode)
        {
            switch (actionMode)
            {
                case ActionMode.None:
                    break;
                case ActionMode.Hold:
                    Up();
                    //if (!Holding)
                    //{
                    //    Up();
                    //}
                    //holdDelayTimer.Stop();
                    //holdTriggerTick = Program.KeyboardSettings.HoldDelay;
                    break;
                case ActionMode.HoldLock:
                    if (Repeating)
                    {
                        break;
                    }
                    Toggle();
                    break;
                case ActionMode.Strum:
                    Strum();
                    break;
                case ActionMode.Repeat:
                    if (Repeating)
                    {
                        repeatTimer.Stop();
                        Repeating = false;
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
                    }
                    else
                    {
                        BeginAction(ActionMode.Repeat);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void EventsInit()
        {
            repeatTimer.Elapsed += delegate { Press(); };
            holdDelayTimer.Elapsed += delegate
            {
                holdTriggerTick -= 5;
                if (holdTriggerTick <= 0)
                {
                    Holding = true;
                    holdTriggerTick = Program.KeyboardSettings.HoldDelay;
                    holdDelayTimer.Stop();
                }
            };

            // todo Intergrated DdKey Repeat improvement: feature works, but not ideally(separeted mouse button).

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
                    //Repaint();
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
                    //Repaint();
                }
            );
            MouseEnter += new EventHandler((sender, e) =>
                {
                    Focus();
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
                    //Repaint();
                }
            );

            Program.Hook.KeyEvent += new Program.KeyboardHookHandler((vkCode, eventType) =>
                {
                    if (VkCodes.Count == 1 && vkCode == (int)VkCodes[0])
                    {
                        switch (eventType)
                        {
                            case KeyboardHook.EventType.Down:
                                Pressed = true;
                                break;
                            case KeyboardHook.EventType.Up:
                                Pressed = false;
                                break;
                            case KeyboardHook.EventType.Press:
                                break;
                            default:
                                break;
                        }
                        Repaint();
                    }
                }
            );

        }

        private readonly Color NormalBackColor = Color.FromName("#202020");
        private readonly Color PressedBackColor = Color.White;
        private readonly Color NormalForeColor = Color.White;
        private readonly Color PressedForeColor = Color.Black;
        private readonly Font NormalFont = new Font("宋体", 9, FontStyle.Bold);
        private int holdTriggerTick = Program.KeyboardSettings.HoldDelay;
        private bool Holding = false;
        private bool Repeating = false;
        private bool Pressed = false;

        private readonly Timer repeatTimer = new Timer(Program.KeyboardSettings.RepeatInterval);
        private readonly Timer holdDelayTimer = new Timer(5);

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