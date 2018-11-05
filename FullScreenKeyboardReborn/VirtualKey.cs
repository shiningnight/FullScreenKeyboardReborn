using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MetroFramework.Controls;
using Timer = System.Timers.Timer;

namespace FullScreenKeyboardReborn
{
    internal class VirtualKey : Button
    {
        public enum KeyCodeType
        {
            Common,
            Dd
        }

        public VirtualKey(String keyName, Rectangle bounds, int keyCode, KeyCodeType type, DController dc)
        {
            this.Bounds = bounds;
            this.BackColor = Color.DarkGray;
            this.Text = keyName;
            this.dc = dc;
            switch (type)
            {
                case KeyCodeType.Common:
                {
                    this.ddKeyCode = this.dc.Todc(keyCode);
                    break;
                }
                case KeyCodeType.Dd:
                {
                    this.ddKeyCode = keyCode;
                    break;
                }
            }

            var repeatDelayTimer = new Timer(5);
            repeatDelayTimer.Elapsed += delegate
            {
                repeatTriggerTick -= 5;
                if (repeatTriggerTick == 0)
                {
                    repeatActionTimer.Start();
                    repeatDelayTimer.Stop();
                    repeatTriggerTick = 150;
                }
            };

            repeatActionTimer = new Timer(133);
            repeatActionTimer.Elapsed += delegate
            {
                Press();
            };

            this.MouseDown += new MouseEventHandler((sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Press();
                        repeatDelayTimer.Start();
                    }
                }
            );
            this.MouseUp += new MouseEventHandler((sender, e) =>
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            repeatDelayTimer.Stop();
                            repeatActionTimer.Stop();
                            break;
                        case MouseButtons.Right:
                            Toggle();
                            break;
                    }

                    Repaint();
                }
            );

        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        private void Press()
        {
            Down();
            Thread.Sleep(30);
            Up();
        }

        private void Down()
        {
            dc.Key(this.ddKeyCode, 1);
        }

        private void Up()
        {
            dc.Key(this.ddKeyCode, 2);
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

        private void Repaint()
        {
            this.BackColor = Holding ? Color.DarkSlateBlue : Color.DarkGray;
            this.Refresh();
        }

        private bool Holding = false;
        private readonly int ddKeyCode;
        private readonly DController dc;
        private readonly Timer repeatActionTimer;
        private int repeatTriggerTick = 150;
    }
}