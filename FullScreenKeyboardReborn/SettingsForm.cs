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
    public partial class SettingsForm : MetroForm
    {
        MainBoard mainBoard;
        GameBoard gameBoard;

        public SettingsForm(MainBoard mainBoard, GameBoard gameBoard)
        {
            InitializeComponent();
            //ReloadLayoutList();
            actionModeLeftBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeRightBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelDownBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));
            actionModeWheelUpBox.DataSource = Enum.GetNames(typeof(VirtualKey.ActionMode));

            // Initialize language selector
            languageSelector.Items.Clear();
            languageSelector.Items.Add("中文 (zh-CN)");
            languageSelector.Items.Add("English (en-US)");
            
            // Set current language
            string currentCulture = LocalizationManager.Instance.CurrentCulture;
            languageSelector.SelectedIndex = currentCulture == "zh-CN" ? 0 : 1;

            ReloadSettings();

            this.mainBoard = mainBoard;
            this.gameBoard = gameBoard;
            
            // Subscribe to language changed event
            LocalizationManager.Instance.LanguageChanged += OnLanguageChanged;
            
            // Apply initial localization
            ApplyLocalization();
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
                
                // Parse ActionMode from selected index instead of text
                var actionModes = Enum.GetValues(typeof(VirtualKey.ActionMode));
                settings.ActionModeLeft = (VirtualKey.ActionMode)actionModes.GetValue(actionModeLeftBox.SelectedIndex);
                settings.ActionModeRight = (VirtualKey.ActionMode)actionModes.GetValue(actionModeRightBox.SelectedIndex);
                settings.ActionModeWheel = (VirtualKey.ActionMode)actionModes.GetValue(actionModeWheelBox.SelectedIndex);
                settings.ActionModeWheelDown = (VirtualKey.ActionMode)actionModes.GetValue(actionModeWheelDownBox.SelectedIndex);
                settings.ActionModeWheelUp = (VirtualKey.ActionMode)actionModes.GetValue(actionModeWheelUpBox.SelectedIndex);
                
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
                var lm = LocalizationManager.Instance;
                MetroMessageBox.Show(this, lm.GetString("SettingsForm.InvalidInputError"), 
                    lm.GetString("Common.Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (gameBoard != null)
            {
                gameBoard.LoadLayout(scaleUpDown.Value);
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

        /// <summary>
        /// Applies localization to all UI elements
        /// </summary>
        private void ApplyLocalization()
        {
            var lm = LocalizationManager.Instance;
            
            // Form title
            this.Text = lm.GetString("SettingsForm.Title");
            
            // Tab pages
            tabPage1.Text = lm.GetString("SettingsForm.TabLayout");
            tabPage2.Text = lm.GetString("SettingsForm.TabMouse");
            tabPage3.Text = lm.GetString("SettingsForm.TabGameCube");
            tabPage4.Text = lm.GetString("SettingsForm.TabAppearance");
            
            // Layout tab labels
            metroLabel1.Text = lm.GetString("SettingsForm.LayoutLabel");
            metroLabel20.Text = lm.GetString("SettingsForm.ScaleLabel");
            metroLabel22.Text = lm.GetString("SettingsForm.FontLabel");
            metroLabel23.Text = lm.GetString("SettingsForm.LanguageLabel");
            
            // Mouse tab labels
            metroLabel21.Text = lm.GetString("SettingsForm.AllowRepeating");
            metroLabel2.Text = lm.GetString("SettingsForm.RepeatDelay");
            metroLabel3.Text = lm.GetString("SettingsForm.PressDelay");
            metroLabel4.Text = lm.GetString("SettingsForm.ActionDelay");
            metroLabel5.Text = lm.GetString("SettingsForm.RepeatInterval");
            metroLabel15.Text = lm.GetString("SettingsForm.ActionModeLeft");
            metroLabel16.Text = lm.GetString("SettingsForm.ActionModeRight");
            metroLabel17.Text = lm.GetString("SettingsForm.ActionModeWheel");
            metroLabel18.Text = lm.GetString("SettingsForm.ActionModeWheelUp");
            metroLabel19.Text = lm.GetString("SettingsForm.ActionModeWheelDown");
            
            // Game Cube tab labels
            metroLabel9.Text = lm.GetString("SettingsForm.CubeUp");
            metroLabel8.Text = lm.GetString("SettingsForm.CubeDown");
            metroLabel7.Text = lm.GetString("SettingsForm.CubeLeft");
            metroLabel6.Text = lm.GetString("SettingsForm.CubeRight");
            metroLabel11.Text = lm.GetString("SettingsForm.CubeActionLeft");
            metroLabel10.Text = lm.GetString("SettingsForm.CubeActionRight");
            metroLabel14.Text = lm.GetString("SettingsForm.CubeActionWheel");
            metroLabel13.Text = lm.GetString("SettingsForm.CubeActionWheelUp");
            metroLabel12.Text = lm.GetString("SettingsForm.CubeActionWheelDown");
            
            // Appearance tab labels
            metroTile1.Text = lm.GetString("SettingsForm.RefreshLayoutList");
            
            // Buttons
            saveButton.Text = lm.GetString("Common.Save");
            cancelButton.Text = lm.GetString("Common.Cancel");
            
            // Reload ActionMode combo boxes with localized values
            ReloadActionModeComboBoxes();
        }

        /// <summary>
        /// Reloads ActionMode combo boxes with localized enum values
        /// </summary>
        private void ReloadActionModeComboBoxes()
        {
            var lm = LocalizationManager.Instance;
            var actionModes = Enum.GetValues(typeof(VirtualKey.ActionMode));
            var localizedModes = new string[actionModes.Length];
            
            for (int i = 0; i < actionModes.Length; i++)
            {
                var mode = (VirtualKey.ActionMode)actionModes.GetValue(i);
                localizedModes[i] = lm.GetEnumString(mode);
            }
            
            // Store current selections
            var leftMode = actionModeLeftBox.SelectedIndex;
            var rightMode = actionModeRightBox.SelectedIndex;
            var wheelMode = actionModeWheelBox.SelectedIndex;
            var wheelUpMode = actionModeWheelUpBox.SelectedIndex;
            var wheelDownMode = actionModeWheelDownBox.SelectedIndex;
            
            // Update data sources
            actionModeLeftBox.DataSource = localizedModes.ToArray();
            actionModeRightBox.DataSource = localizedModes.ToArray();
            actionModeWheelBox.DataSource = localizedModes.ToArray();
            actionModeWheelDownBox.DataSource = localizedModes.ToArray();
            actionModeWheelUpBox.DataSource = localizedModes.ToArray();
            
            // Restore selections
            actionModeLeftBox.SelectedIndex = leftMode;
            actionModeRightBox.SelectedIndex = rightMode;
            actionModeWheelBox.SelectedIndex = wheelMode;
            actionModeWheelUpBox.SelectedIndex = wheelUpMode;
            actionModeWheelDownBox.SelectedIndex = wheelDownMode;
        }

        /// <summary>
        /// Handles language change event
        /// </summary>
        private void OnLanguageChanged(object sender, EventArgs e)
        {
            ApplyLocalization();
        }

        /// <summary>
        /// Handles language selector change
        /// </summary>
        private void languageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newCulture = languageSelector.SelectedIndex == 0 ? "zh-CN" : "en-US";
            LocalizationManager.Instance.ChangeLanguage(newCulture);
        }
    }
}