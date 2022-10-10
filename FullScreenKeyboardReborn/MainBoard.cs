using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;



namespace FullScreenKeyboardReborn
{
    public partial class MainBoard : MetroForm
    {

        public MainBoard()
        {
            InitializeComponent();
            Location = Program.KeyboardSettings.MainLastLocation;
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

        private void HideButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!Visible)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }

        private void MainBoard_Load(object sender, EventArgs e)
        {
            Program.Hook.Start();
            notifyIcon1.ShowBalloonTip(3);
        }

        private void MainBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exiting();
        }

        private void MainBoard_Move(object sender, EventArgs e)
        {
            //todo Boundary Snap fix: though moving window by mouse can't go out of any screen bottom right corners, there are still certain ways to do so, thus needs further fix.
            if (Left < 0) Left = 0;
            if (Top < 0) Top = 0;

            var workingArea = CurrentScreenWorkingArea;
            var screenLeft = workingArea.Left;
            var screenRight = workingArea.Right;
            var screenBottom = workingArea.Bottom;
            var screenTop = workingArea.Top;

            if (Math.Abs(screenRight - Right) <= SnapThreshold)
                Location = new Point(screenRight - Width, Top);

            if (Math.Abs(screenLeft - Left) <= SnapThreshold)
                Location = new Point(screenLeft, Top);

            if (Math.Abs(screenBottom - Bottom) <= SnapThreshold)
                Location = new Point(Left, screenBottom - Height);

            if (Math.Abs(screenTop - Top) <= SnapThreshold)
                Location = new Point(Left, screenTop);
        }

        private Rectangle CurrentScreenWorkingArea
        {
            get
            {
                Rectangle? result = null;
                foreach (var screen in Screen.AllScreens)
                {
                    if (screen.Bounds.Contains(Location))
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

        private void gameCubeGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameBoard.Visible)
            {
                gameBoard.Show();
            }
            else
            {
                gameBoard.Hide();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!settinsForm.Visible)
            {
                settinsForm.ShowDialog();
            }
        }

        private void Exiting()
        {
            Program.KeyboardSettings.MainLastLocation = Location;
            Program.KeyboardSettings.CubeLastLocation = gameBoard.Location;
            Settings.Save(Program.KeyboardSettings);
            notifyIcon1.Dispose();
            Program.Hook.Stop();
            Environment.Exit(0);
        }

        private void LoadLayout()
        {

        }

        private GameBoard gameBoard = new GameBoard();
        private SettinsForm settinsForm = new SettinsForm();

    }
}