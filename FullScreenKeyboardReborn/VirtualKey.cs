using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        public enum KeyCodeType
        {
            Common,
            Dd
        }

        public VirtualKey()
        {
            InitializeComponent();
            EventsInit();
        }

        public VirtualKey(String keyName, Rectangle bounds, int[] keyCodes, KeyCodeType type)
        {
            InitializeComponent();
            EventsInit();

            this.Bounds = bounds;
            this.KeyName = keyName;

            switch (type)
            {
                case KeyCodeType.Common:
                {
                    foreach (var keyCode in keyCodes)
                    {
                        this.DdKeyCodes.Add(dc.Todc(keyCode));
                    }

                    break;
                }
                case KeyCodeType.Dd:
                {
                    foreach (var keyCode in keyCodes)
                    {
                        this.DdKeyCodes.Add(keyCode);
                    }

                    break;
                }
            }
        }

        private void Down()
        {
            foreach (var keyCode in DdKeyCodes)
            {
                dc.Key(keyCode, 1);
            }
        }

        private void Up()
        {
            foreach (var keyCode in DdKeyCodes)
            {
                dc.Key(keyCode, 2);
            }
        }

        private void Strum()
        {
            foreach (var keyCode in DdKeyCodes)
            {
                dc.Key(keyCode, 1);
                Thread.Sleep(PressDelay);
                dc.Key(keyCode, 2);
            }
        }

        private void Press()
        {
            Down();
            Thread.Sleep(PressDelay);
            Up();
        }

        private void Toggle()
        {
            if (Holding)
            {
                Up();
            }
            else
            {
                Down();
            }
        }

        private void Repaint()
        {
            this.ForeColor = (Holding || Repeating) ? PressedForeColor : NormalForeColor;
            this.BackColor = (Holding || Repeating) ? PressedBackColor : NormalBackColor;
            this.Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // todo Designer Support fix: Override each following fields' Reset method, to avoid duplicated initializing, and to improve property window display(default value still gets bolded).
            this.Theme = MetroThemeStyle.Dark;
            this.Style = MetroColorStyle.Purple;
            this.SetStyle(ControlStyles.Selectable, false);
            this.UseCustomForeColor = true;
            this.UseCustomBackColor = true;
            this.ForeColor = NormalForeColor;
            this.BackColor = NormalBackColor;
            this.Font = DefaultFont;
            this.Size = new Size(36, 36);
            this.Margin = new Padding(1);

            this.ResumeLayout(false);
        }

        private void EventsInit()
        {
            var repeatTimer = new Timer(RepeatInterval);
            repeatTimer.Elapsed += delegate { Press(); };

            var holdDelayTimer = new Timer(5);
            holdDelayTimer.Elapsed += delegate
            {
                holdTriggerTick -= 5;
                if (holdTriggerTick <= 0)
                {
                    Holding = true;
                    holdTriggerTick = HoldDelay;
                    holdDelayTimer.Stop();
                }
            };

            // todo Intergrated Key Repeat improvement: feature works, but not ideally(separeted mouse button).

            this.MouseDown += new MouseEventHandler((sender, e) =>
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            Down();
                            Holding = false;
                            holdDelayTimer.Start();
                            break;
                        case MouseButtons.Right:
                            if (!Repeating)
                            {
                                repeatTimer.Start();
                                Repeating = true;
                            }
                            break;
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Middle:
                            break;
                        case MouseButtons.XButton1:
                            break;
                        case MouseButtons.XButton2:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Repaint();
                }
            );
            this.MouseUp += new MouseEventHandler((sender, e) =>
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            if (!Holding)
                            {
                                Up();
                            }
                            holdDelayTimer.Stop();
                            holdTriggerTick = HoldDelay;
                            break;
                        case MouseButtons.Right:
                            if (Repeating)
                            {
                                repeatTimer.Stop();
                                Repeating = false;
                            }
                            break;
                        case MouseButtons.None:
                            break;
                        case MouseButtons.Middle:
                            break;
                        case MouseButtons.XButton1:
                            break;
                        case MouseButtons.XButton2:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Repaint();
                }
            );
        }

        private static readonly DController dc = Program.VkmController;
        private const int HoldDelay = 180;
        private const int RepeatInterval = 16;
        private const int PressDelay = 90;
        private const int ActionDelay = 0;
        private readonly Color NormalBackColor = Color.FromName("#202020");
        private readonly Color PressedBackColor = Color.White;
        private readonly Color NormalForeColor = Color.White;
        private readonly Color PressedForeColor = Color.Black;
        private new readonly Font DefaultFont = new Font("monofur", 9, FontStyle.Bold);
        private int holdTriggerTick = HoldDelay;
        private bool Holding = false;
        private bool Repeating = false;

        [Browsable(true)]
        [Description("Key name. Alias of Text.")]
        [Category("!VKProperties")]
        public string KeyName
        {
            get => this.Text;
            set => this.Text = value;
        }

        // todo Designer Support fix: still can't edit key code directly, any way to avoid Object edit window?
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description(
            "Dd format key codes for the corresponding physical key. Consulting the key code table executive or use dc.Todc for standard VK codes."
        )]
        [Category("!VKProperties")]
        public List<int> DdKeyCodes { get; set; } = new List<int>();
    }
}