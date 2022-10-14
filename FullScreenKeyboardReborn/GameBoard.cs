using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;



namespace FullScreenKeyboardReborn
{
    public partial class GameBoard : MetroForm
    {

        public GameBoard()
        {
            InitializeComponent();
            Location = Program.KeyboardSettings.CubeLastLocation;
            StyleManager = Program.MStyleManager;
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
            // Hide();
        }

        private void GameBoard_Move(object sender, EventArgs e)
        {
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

        private void GameBoard_VisibleChanged(object sender, EventArgs e)
        {
            Program.KeyboardSettings.CubeLastLocation = Location;
            Settings.Save(Program.KeyboardSettings);
        }
    }
}