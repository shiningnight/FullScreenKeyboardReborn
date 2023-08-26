using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace FullScreenKeyboardReborn
{
    public partial class GameBoard : MetroForm
    {

        public GameBoard()
        {
            InitializeComponent();
            Location = Program.KeyboardSettings.CubeLastLocation;
            foreach (Control item in Controls)
            {
                OrginalControlBounds.Add(item, new Rectangle(item.Bounds.Location, item.Bounds.Size));
            }
            LoadLayout(Program.KeyboardSettings.ScaleFactor);
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
                    Location = Settings.Default.CubeLastLocation;
                    result = Screen.GetWorkingArea(Location);
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

        public void LoadLayout(decimal scaleFactor)
        {
            double scaledScaleFactor = (double)scaleFactor * 1.6;
            foreach (Control item in Controls)
            {
                var bounds = OrginalControlBounds[item];
                item.Bounds = new Rectangle((int)(bounds.X*scaledScaleFactor), (int)(bounds.Y*scaledScaleFactor), (int)(bounds.Width*scaledScaleFactor), (int)(bounds.Height*scaledScaleFactor));
            }
        }

        private Dictionary<Control, Rectangle> OrginalControlBounds = new Dictionary<Control, Rectangle>();
    }
}