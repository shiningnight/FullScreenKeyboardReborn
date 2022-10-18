using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Windows.Forms;
using FullScreenKeyboardReborn.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json;

namespace FullScreenKeyboardReborn
{
    public partial class SettinsForm : MetroForm
    {
        MainBoard mainBoard;

        public SettinsForm(MainBoard mainBoard)
        {
            InitializeComponent();
            //ReloadLayoutList();
            actionModeLeftBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeRightBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelDownBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelUpBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));

            ReloadSettings();

            this.mainBoard = mainBoard;
        }

        private void ReloadSettings()
        {
            var settings = Program.KeyboardSettings;
            repeatToggle.Checked = settings.AllowRepeating;
            repeatDelayBox.Text = settings.RepeatDelay.ToString();
            pressDelayBox.Text = settings.PressDelay.ToString();
            actionDelayBox.Text = settings.ActionDelay.ToString();
            repeatIntervalBox.Text = settings.RepeatInterval.ToString();
            actionModeLeftBox.SelectedItem = settings.ActionModeLeft.ToString();
            actionModeRightBox.SelectedItem = settings.ActionModeRight.ToString();
            actionModeWheelBox.SelectedItem = settings.ActionModeWheel.ToString();
            actionModeWheelDownBox.SelectedItem = settings.ActionModeWheelDown.ToString();
            actionModeWheelUpBox.SelectedItem = settings.ActionModeWheelUp.ToString();
            cubeUpBox.Text = settings.CubeUp.ToString();
            cubeDownBox.Text = settings.CubeDown.ToString();
            cubeLeftBox.Text = settings.CubeLeft.ToString();
            cubeRightBox.Text = settings.CubeRight.ToString();
            cubeActionLeftBox.Text = settings.CubeActionLeft.ToString();
            cubeActionRightBox.Text = settings.CubeActionRight.ToString();
            cubeActionWheelBox.Text = settings.CubeActionWheel.ToString();
            cubeActionWheelUpBox.Text = settings.CubeActionWheelUp.ToString();
            cubeActionWheelDownBox.Text = settings.CubeActionWheelDown.ToString();
            layouNameBox.SelectedItem = settings.LayoutName.ToString();
            scaleUpDown.Value = settings.ScaleFactor;
            scaleTrackbar.Value = (int)(settings.ScaleFactor * 100);
            fontDialog.Font = settings.MainFont;
            fontBox.Text = JsonConvert.SerializeObject(fontDialog.Font);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var settings = Program.KeyboardSettings;
            try
            {
                settings.AllowRepeating = repeatToggle.Checked;
                settings.RepeatDelay = int.Parse(repeatDelayBox.Text);
                settings.PressDelay = int.Parse(pressDelayBox.Text);
                settings.ActionDelay = int.Parse(actionDelayBox.Text);
                settings.RepeatInterval = int.Parse(repeatIntervalBox.Text);
                settings.ActionModeLeft = (VirtualKey.ActionMode)Enum.Parse(typeof(VirtualKey.ActionMode), actionModeLeftBox.Text);
                settings.ActionModeRight = (VirtualKey.ActionMode)Enum.Parse(typeof(VirtualKey.ActionMode), actionModeRightBox.Text);
                settings.ActionModeWheel = (VirtualKey.ActionMode)Enum.Parse(typeof(VirtualKey.ActionMode), actionModeWheelBox.Text);
                settings.ActionModeWheelDown = (VirtualKey.ActionMode)Enum.Parse(typeof(VirtualKey.ActionMode), actionModeWheelDownBox.Text);
                settings.ActionModeWheelUp = (VirtualKey.ActionMode)Enum.Parse(typeof(VirtualKey.ActionMode), actionModeWheelUpBox.Text);
                settings.CubeUp = (Keys)Enum.Parse(typeof(Keys),cubeUpBox.Text);
                settings.CubeDown = (Keys)Enum.Parse(typeof(Keys),cubeDownBox.Text);
                settings.CubeLeft = (Keys)Enum.Parse(typeof(Keys),cubeLeftBox.Text);
                settings.CubeRight = (Keys)Enum.Parse(typeof(Keys),cubeRightBox.Text);
                settings.CubeActionLeft = (Keys)Enum.Parse(typeof(Keys),cubeActionLeftBox.Text);
                settings.CubeActionRight = (Keys)Enum.Parse(typeof(Keys),cubeActionRightBox.Text);
                settings.CubeActionWheel = (Keys)Enum.Parse(typeof(Keys),cubeActionWheelBox.Text);
                settings.CubeActionWheelUp = (Keys)Enum.Parse(typeof(Keys),cubeActionWheelUpBox.Text);
                settings.CubeActionWheelDown = (Keys)Enum.Parse(typeof(Keys),cubeActionWheelDownBox.Text);
                settings.LayoutName = layouNameBox.Text;
                settings.ScaleFactor = scaleUpDown.Value;
                settings.MainFont = fontDialog.Font;
                Settings.Save(settings);
                Hide();
            }
            catch (FormatException)
            {
                MetroMessageBox.Show(this, "Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ReloadSettings();
            mainBoard.LoadLayout(Program.KeyboardSettings.LayoutName, Program.KeyboardSettings.ScaleFactor, Program.KeyboardSettings.MainFont);
            Hide();
        }

        private void setKeyPress(object sender, KeyEventArgs e)
        {
            var box = (MetroTextBox)sender;
            box.Text = e.KeyCode.ToString();
        }

        private void layouNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadLayout();
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            scaleTrackbar.Value = (int)(scaleUpDown.Value * 100);
            ReloadLayout();
        }

        private void scaleTrackbar_ValueChanged(object sender, EventArgs e)
        {
            scaleUpDown.Value = (decimal)scaleTrackbar.Value / 100;
            ReloadLayout();
        }

        private void ReloadLayout()
        {
            if (mainBoard != null)
            {
                mainBoard.LoadLayout(layouNameBox.Text, scaleUpDown.Value, fontDialog.Font);
            }
        }

        private void repeatToggle_CheckedChanged(object sender, EventArgs e)
        {
            repeatDelayBox.Enabled = repeatToggle.Checked;
        }

        private void fontBox_ButtonClick(object sender, EventArgs e)
        {
            var result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fontBox.Text = JsonConvert.SerializeObject(fontDialog.Font);
                ReloadLayout();
            }
        }

        private void SettinsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                ReloadLayoutList();
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            ReloadLayoutList();
        }

        private void ReloadLayoutList()
        {
            layouNameBox.Items.Clear();
            layouNameBox.Items.AddRange(new DirectoryInfo("Keyboards").GetFiles("*.txt").ToList().Select(x => x.Name).ToArray());
            layouNameBox.SelectedItem = Program.KeyboardSettings.LayoutName.ToString();

        }
    }
}