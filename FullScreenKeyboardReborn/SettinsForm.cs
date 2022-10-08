using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;



namespace FullScreenKeyboardReborn
{
    public partial class SettinsForm : MetroForm
    {

        public SettinsForm()
        {
            InitializeComponent();
            layouNameBox.Items.AddRange(new DirectoryInfo("Keyboards").GetFiles("*.txt").ToList().Select(x => x.Name).ToArray());
            actionModeLeftBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeRightBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelDownBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelUpBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            var settings = Program.KeyboardSettings;
            holdDelayBox.Text = settings.HoldDelay.ToString();
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
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var settings = Program.KeyboardSettings;
            try
            {
                settings.HoldDelay = int.Parse(holdDelayBox.Text);
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
                Settings.Save(settings);
                Close();
                Dispose();
            }
            catch (FormatException)
            {
                MetroMessageBox.Show(this, "Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MetroMessageBox.Show("Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}