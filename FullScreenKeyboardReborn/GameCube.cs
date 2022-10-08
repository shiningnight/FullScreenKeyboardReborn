using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{
    public partial class GameCube : MetroPanel
    {
        public GameCube()
        {
            InitializeComponent();
            EventsInit();
            ComponentInit();
        }

        public GameCube(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            EventsInit();
            ComponentInit();
        }

        private void EventsInit()
        {
            MouseMove += GameCube_MouseMove;
            MouseEnter += GameCube_MouseEnter;
            MouseLeave += GameCube_MouseLeave;
            MouseDown += GameCube_MouseDown;
            MouseUp += GameCube_MouseUp;
            MouseWheel += GameCube_MouseWheel;
        }

        private void ComponentInit()
        {
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.seal;
            BackgroundImageLayout = ImageLayout.Zoom;
            BorderStyle = BorderStyle.FixedSingle;
            Size = new Size(192, 192);
            Style = MetroColorStyle.Purple;
            Theme = MetroThemeStyle.Dark;
        }

        private void GameCube_MouseEnter(object sender, EventArgs e)
        {
            Focus();
        }

        private void GameCube_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeActionWheelUp, 0);
                Thread.Sleep(Program.KeyboardSettings.PressDelay);
                Program.Controller.Key(Program.KeyboardSettings.CubeActionWheelUp, 2);
            }
            else if (e.Delta < 0)
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeActionWheelDown, 0);
                Thread.Sleep(Program.KeyboardSettings.PressDelay);
                Program.Controller.Key(Program.KeyboardSettings.CubeActionWheelDown, 2);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void GameCube_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Program.Controller.Key(Program.KeyboardSettings.CubeActionLeft, 2);
                    break;
                case MouseButtons.Right:
                    Program.Controller.Key(Program.KeyboardSettings.CubeActionRight, 2);
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Middle:
                    Program.Controller.Key(Program.KeyboardSettings.CubeActionWheel, 2);
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GameCube_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Program.Controller.Key(Program.KeyboardSettings.CubeActionLeft, 0);
                    break;
                case MouseButtons.Right:
                    Program.Controller.Key(Program.KeyboardSettings.CubeActionRight, 0);
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Middle:
                    Program.Controller.Key(Program.KeyboardSettings.CubeActionWheel, 0);
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GameCube_MouseLeave(object sender, EventArgs e)
        {
            Program.Controller.Key(Program.KeyboardSettings.CubeLeft, 2);
            Program.Controller.Key(Program.KeyboardSettings.CubeRight, 2);
            Program.Controller.Key(Program.KeyboardSettings.CubeUp, 2);
            Program.Controller.Key(Program.KeyboardSettings.CubeDown, 2);
        }

        private void GameCube_MouseMove(object sender, MouseEventArgs e)
        {
            var panel = (MetroPanel)sender;
            double x = (double)e.X / (double)panel.Width;
            double y = (double)e.Y / (double)panel.Height;

            if (x < 0.33)
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeLeft, 0);
            }
            else if (x > 0.66)
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeRight, 0);
            }
            else
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeLeft, 2);
                Program.Controller.Key(Program.KeyboardSettings.CubeRight, 2);
            }
            if (y < 0.33)
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeUp, 0);
            }
            else if (y > 0.66)
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeDown, 0);
            }
            else
            {
                Program.Controller.Key(Program.KeyboardSettings.CubeUp, 2);
                Program.Controller.Key(Program.KeyboardSettings.CubeDown, 2);
            }
        }
    }
}
