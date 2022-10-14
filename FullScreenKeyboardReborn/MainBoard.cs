using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FullScreenKeyboardReborn.Properties;
using MetroFramework.Controls;
using MetroFramework.Forms;



namespace FullScreenKeyboardReborn
{
    public partial class MainBoard : MetroForm
    {

        public MainBoard()
        {
            InitializeComponent();
            settinsForm = new SettinsForm(this);
            Location = Program.KeyboardSettings.MainLastLocation;
            LoadLayout(Program.KeyboardSettings.LayoutName, Program.KeyboardSettings.ScaleFactor);
            StyleManager = Program.MStyleManager;
            // todo Next version: Another layout editor.Manually coding out UI is acceptable? Never!)
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
                if (e.Clicks == 0)
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
                else if (e.Clicks == 2)
                {
                    if (!gameBoard.Visible)
                    {
                        gameBoard.Show();
                        gameCubeGToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        gameBoard.Hide();
                        gameCubeGToolStripMenuItem.Checked = false;
                    }
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
                return (Rectangle)result;
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
            if (!settinsForm.Visible)
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

        public void LoadLayout(string layoutName, decimal scaleFactor)
        {
            using (var reader = new StreamReader($"Keyboards\\{layoutName}", Encoding.UTF8))
            {
                Controls.Clear();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line[0] == ';')
                    {
                        continue;
                    }
                    else if (line[0] > '9' || line[0] < '0')
                    {
                        continue;
                    }
                    else
                    {
                        var parts = line.Split('=');
                        var vkCodeParts = parts[0].Split(',');
                        var vkCodes = new List<Keys>();
                        foreach (var vkCode in vkCodeParts)
                        {
                            vkCodes.Add((Keys)Enum.Parse(typeof(Keys), vkCode));
                        }

                        var props = parts[1].Split(';');
                        bool keyFinished = false;
                        var boundry = new List<Point>();
                        var parameters = new Dictionary<string, string>();
                        parameters["label"] = "";
                        foreach (var p in props)
                        {
                            //Console.WriteLine(p);
                            if (p[0] == '-')
                            {
                                Controls.Add(new VirtualKey(parameters["label"], boundry, vkCodes, parameters));
                                boundry = new List<Point>();
                            }
                            else if (p[0] > '9' || p[0] < '0')
                            {
                                string[] kvPair = p.Split(':');
                                parameters[kvPair[0]] = kvPair[1];
                                if (!keyFinished)
                                {
                                    keyFinished = true;
                                    Controls.Add(new VirtualKey(parameters["label"], boundry, vkCodes, parameters));
                                }
                            }
                            else
                            {
                                var pointParts = p.Split(',');
                                boundry.Add(new Point((int)(int.Parse(pointParts[0]) * scaleFactor), (int)(int.Parse(pointParts[1]) * scaleFactor)));
                                if (p.Contains(props.Last()))
                                {
                                    Controls.Add(new VirtualKey(parameters["label"], boundry, vkCodes, parameters));
                                }

                            }
                        }
                    }
                }
                Console.WriteLine("f");
            }
        }

        private GameBoard gameBoard = new GameBoard();
        private SettinsForm settinsForm;

    }
}