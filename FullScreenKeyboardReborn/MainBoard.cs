using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;



namespace FullScreenKeyboardReborn
{
    public partial class MainBoard : MetroForm
    {

        public MainBoard()
        {
            InitializeComponent();
            // todo Next version: Virtual Keyboard Layout Management feature(load Comfort Onscreen Keyboard -ish layout profile, maybe another layout editor.Manually coding out UI is acceptable? Never!)
        }


        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                var ret = base.CreateParams;
                ret.ExStyle |= (int)Flags.WindowStyles.WS_EX_NOACTIVATE;
                return ret;
            }
        }


        private void HideButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.Visible)
                {
                    this.Show();
                }
                else
                {
                    this.Hide();
                }
            }
        }

        private void MainBoard_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(3);

        }

        private void MainBoard_Move(object sender, EventArgs e)
        {
            //todo Boundary Snap fix: though moving window by mouse can't go out of any screen bottom right corners, there are still certain ways to do so, thus needs further fix.
            if (this.Left < 0) this.Left = 0;
            if (this.Top < 0) this.Top = 0;

            var workingArea = CurrentScreenWorkingArea;
            var screenLeft = workingArea.Left;
            var screenRight = workingArea.Right;
            var screenBottom = workingArea.Bottom;
            var screenTop = workingArea.Top;

            if (Math.Abs(screenRight - this.Right) <= SnapThreshold)
                this.Location = new Point(screenRight - this.Width, this.Top);

            if (Math.Abs(screenLeft - this.Left) <= SnapThreshold)
                this.Location = new Point(screenLeft, this.Top);

            if (Math.Abs(screenBottom - this.Bottom) <= SnapThreshold)
                this.Location = new Point(this.Left, screenBottom - this.Height);

            if (Math.Abs(screenTop - this.Top) <= SnapThreshold)
                this.Location = new Point(this.Left, screenTop);
        }

        private Rectangle CurrentScreenWorkingArea
        {
            get
            {
                Rectangle? result = null;
                foreach (var screen in Screen.AllScreens)
                {
                    if (screen.Bounds.Contains(this.Location))
                    {
                        result = screen.WorkingArea;
                    }
                }

                if (result == null)
                {
                    throw new NullReferenceException();
                }
                return (Rectangle) result;
            }
        }

        private const int SnapThreshold = 10;

    }
}