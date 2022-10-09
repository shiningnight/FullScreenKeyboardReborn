using System.ComponentModel;

namespace FullScreenKeyboardReborn
{
    partial class MainBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.gameCubeGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideButton = new MetroFramework.Controls.MetroButton();
            this.gameCube2 = new FullScreenKeyboardReborn.GameCube(this.components);
            this.virtualKey24 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey30 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey29 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey28 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey27 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey26 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey25 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey23 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey22 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey21 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey20 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey19 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey18 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey17 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey16 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey15 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey14 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey13 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey12 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey11 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey10 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey9 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey8 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey7 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey2 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey1 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey3 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey5 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey4 = new FullScreenKeyboardReborn.VirtualKey();
            this.virtualKey6 = new FullScreenKeyboardReborn.VirtualKey();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameCubeGToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitEToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Style = MetroFramework.MetroColorStyle.Purple;
            this.contextMenuStrip1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // gameCubeGToolStripMenuItem
            // 
            this.gameCubeGToolStripMenuItem.Checked = true;
            this.gameCubeGToolStripMenuItem.CheckOnClick = true;
            this.gameCubeGToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gameCubeGToolStripMenuItem.Name = "gameCubeGToolStripMenuItem";
            resources.ApplyResources(this.gameCubeGToolStripMenuItem, "gameCubeGToolStripMenuItem");
            this.gameCubeGToolStripMenuItem.Click += new System.EventHandler(this.gameCubeGToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitEToolStripMenuItem
            // 
            this.exitEToolStripMenuItem.Name = "exitEToolStripMenuItem";
            resources.ApplyResources(this.exitEToolStripMenuItem, "exitEToolStripMenuItem");
            this.exitEToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // hideButton
            // 
            this.hideButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.hideButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            resources.ApplyResources(this.hideButton, "hideButton");
            this.hideButton.Name = "hideButton";
            this.hideButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.hideButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.hideButton.UseSelectable = true;
            this.hideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // gameCube2
            // 
            this.gameCube2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.gameCube2, "gameCube2");
            this.gameCube2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameCube2.HorizontalScrollbarBarColor = true;
            this.gameCube2.HorizontalScrollbarHighlightOnWheel = false;
            this.gameCube2.HorizontalScrollbarSize = 10;
            this.gameCube2.Name = "gameCube2";
            this.gameCube2.Style = MetroFramework.MetroColorStyle.Purple;
            this.gameCube2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.gameCube2.VerticalScrollbarBarColor = true;
            this.gameCube2.VerticalScrollbarHighlightOnWheel = false;
            this.gameCube2.VerticalScrollbarSize = 10;
            // 
            // virtualKey24
            // 
            this.virtualKey24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey24.Bundary = null;
            this.virtualKey24.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey24.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey24.ForeColor = System.Drawing.Color.White;
            this.virtualKey24.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey24.HookResponseCodes")));
            this.virtualKey24.KeyLabel = "❉";
            resources.ApplyResources(this.virtualKey24, "virtualKey24");
            this.virtualKey24.Name = "virtualKey24";
            this.virtualKey24.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey24.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey24.UseCustomBackColor = true;
            this.virtualKey24.UseCustomForeColor = true;
            this.virtualKey24.VkCodes.Add(System.Windows.Forms.Keys.Apps);
            // 
            // virtualKey30
            // 
            this.virtualKey30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey30.Bundary = null;
            this.virtualKey30.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey30.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey30.ForeColor = System.Drawing.Color.White;
            this.virtualKey30.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey30.HookResponseCodes")));
            this.virtualKey30.KeyLabel = "Alt";
            resources.ApplyResources(this.virtualKey30, "virtualKey30");
            this.virtualKey30.Name = "virtualKey30";
            this.virtualKey30.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey30.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey30.UseCustomBackColor = true;
            this.virtualKey30.UseCustomForeColor = true;
            this.virtualKey30.VkCodes.Add(System.Windows.Forms.Keys.Menu);
            // 
            // virtualKey29
            // 
            this.virtualKey29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey29.Bundary = null;
            this.virtualKey29.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey29.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey29.ForeColor = System.Drawing.Color.White;
            this.virtualKey29.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey29.HookResponseCodes")));
            this.virtualKey29.KeyLabel = "Esc";
            resources.ApplyResources(this.virtualKey29, "virtualKey29");
            this.virtualKey29.Name = "virtualKey29";
            this.virtualKey29.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey29.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey29.UseCustomBackColor = true;
            this.virtualKey29.UseCustomForeColor = true;
            this.virtualKey29.VkCodes.Add(System.Windows.Forms.Keys.Escape);
            // 
            // virtualKey28
            // 
            this.virtualKey28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey28.Bundary = null;
            this.virtualKey28.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey28.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey28.ForeColor = System.Drawing.Color.White;
            this.virtualKey28.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey28.HookResponseCodes")));
            this.virtualKey28.KeyLabel = "Shift";
            resources.ApplyResources(this.virtualKey28, "virtualKey28");
            this.virtualKey28.Name = "virtualKey28";
            this.virtualKey28.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey28.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey28.UseCustomBackColor = true;
            this.virtualKey28.UseCustomForeColor = true;
            this.virtualKey28.VkCodes.Add(System.Windows.Forms.Keys.ShiftKey);
            // 
            // virtualKey27
            // 
            this.virtualKey27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey27.Bundary = null;
            this.virtualKey27.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey27.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey27.ForeColor = System.Drawing.Color.White;
            this.virtualKey27.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey27.HookResponseCodes")));
            this.virtualKey27.KeyLabel = "Ctrl";
            resources.ApplyResources(this.virtualKey27, "virtualKey27");
            this.virtualKey27.Name = "virtualKey27";
            this.virtualKey27.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey27.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey27.UseCustomBackColor = true;
            this.virtualKey27.UseCustomForeColor = true;
            this.virtualKey27.VkCodes.Add(System.Windows.Forms.Keys.RControlKey);
            // 
            // virtualKey26
            // 
            this.virtualKey26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey26.Bundary = null;
            this.virtualKey26.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey26.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey26.ForeColor = System.Drawing.Color.White;
            this.virtualKey26.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey26.HookResponseCodes")));
            this.virtualKey26.KeyLabel = "Enter";
            resources.ApplyResources(this.virtualKey26, "virtualKey26");
            this.virtualKey26.Name = "virtualKey26";
            this.virtualKey26.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey26.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey26.UseCustomBackColor = true;
            this.virtualKey26.UseCustomForeColor = true;
            this.virtualKey26.VkCodes.Add(System.Windows.Forms.Keys.Return);
            // 
            // virtualKey25
            // 
            this.virtualKey25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey25.Bundary = null;
            this.virtualKey25.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey25.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey25.ForeColor = System.Drawing.Color.White;
            this.virtualKey25.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey25.HookResponseCodes")));
            this.virtualKey25.KeyLabel = "";
            resources.ApplyResources(this.virtualKey25, "virtualKey25");
            this.virtualKey25.Name = "virtualKey25";
            this.virtualKey25.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey25.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey25.UseCustomBackColor = true;
            this.virtualKey25.UseCustomForeColor = true;
            this.virtualKey25.VkCodes.Add(System.Windows.Forms.Keys.Space);
            // 
            // virtualKey23
            // 
            this.virtualKey23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey23.Bundary = null;
            this.virtualKey23.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey23.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey23.ForeColor = System.Drawing.Color.White;
            this.virtualKey23.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey23.HookResponseCodes")));
            this.virtualKey23.KeyLabel = "Tab";
            resources.ApplyResources(this.virtualKey23, "virtualKey23");
            this.virtualKey23.Name = "virtualKey23";
            this.virtualKey23.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey23.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey23.UseCustomBackColor = true;
            this.virtualKey23.UseCustomForeColor = true;
            this.virtualKey23.VkCodes.Add(System.Windows.Forms.Keys.Tab);
            // 
            // virtualKey22
            // 
            this.virtualKey22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey22.Bundary = null;
            this.virtualKey22.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey22.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey22.ForeColor = System.Drawing.Color.White;
            this.virtualKey22.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey22.HookResponseCodes")));
            this.virtualKey22.KeyLabel = "PgDn";
            resources.ApplyResources(this.virtualKey22, "virtualKey22");
            this.virtualKey22.Name = "virtualKey22";
            this.virtualKey22.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey22.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey22.UseCustomBackColor = true;
            this.virtualKey22.UseCustomForeColor = true;
            this.virtualKey22.VkCodes.Add(System.Windows.Forms.Keys.Next);
            // 
            // virtualKey21
            // 
            this.virtualKey21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey21.Bundary = null;
            this.virtualKey21.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey21.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey21.ForeColor = System.Drawing.Color.White;
            this.virtualKey21.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey21.HookResponseCodes")));
            this.virtualKey21.KeyLabel = "PgUp";
            resources.ApplyResources(this.virtualKey21, "virtualKey21");
            this.virtualKey21.Name = "virtualKey21";
            this.virtualKey21.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey21.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey21.UseCustomBackColor = true;
            this.virtualKey21.UseCustomForeColor = true;
            this.virtualKey21.VkCodes.Add(System.Windows.Forms.Keys.PageUp);
            // 
            // virtualKey20
            // 
            this.virtualKey20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey20.Bundary = null;
            this.virtualKey20.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey20.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey20.ForeColor = System.Drawing.Color.White;
            this.virtualKey20.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey20.HookResponseCodes")));
            this.virtualKey20.KeyLabel = "F";
            resources.ApplyResources(this.virtualKey20, "virtualKey20");
            this.virtualKey20.Name = "virtualKey20";
            this.virtualKey20.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey20.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey20.UseCustomBackColor = true;
            this.virtualKey20.UseCustomForeColor = true;
            this.virtualKey20.VkCodes.Add(System.Windows.Forms.Keys.F);
            // 
            // virtualKey19
            // 
            this.virtualKey19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey19.Bundary = null;
            this.virtualKey19.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey19.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey19.ForeColor = System.Drawing.Color.White;
            this.virtualKey19.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey19.HookResponseCodes")));
            this.virtualKey19.KeyLabel = "D";
            resources.ApplyResources(this.virtualKey19, "virtualKey19");
            this.virtualKey19.Name = "virtualKey19";
            this.virtualKey19.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey19.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey19.UseCustomBackColor = true;
            this.virtualKey19.UseCustomForeColor = true;
            this.virtualKey19.VkCodes.Add(System.Windows.Forms.Keys.D);
            // 
            // virtualKey18
            // 
            this.virtualKey18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey18.Bundary = null;
            this.virtualKey18.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey18.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey18.ForeColor = System.Drawing.Color.White;
            this.virtualKey18.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey18.HookResponseCodes")));
            this.virtualKey18.KeyLabel = "S";
            resources.ApplyResources(this.virtualKey18, "virtualKey18");
            this.virtualKey18.Name = "virtualKey18";
            this.virtualKey18.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey18.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey18.UseCustomBackColor = true;
            this.virtualKey18.UseCustomForeColor = true;
            this.virtualKey18.VkCodes.Add(System.Windows.Forms.Keys.S);
            // 
            // virtualKey17
            // 
            this.virtualKey17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey17.Bundary = null;
            this.virtualKey17.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey17.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey17.ForeColor = System.Drawing.Color.White;
            this.virtualKey17.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey17.HookResponseCodes")));
            this.virtualKey17.KeyLabel = "A";
            resources.ApplyResources(this.virtualKey17, "virtualKey17");
            this.virtualKey17.Name = "virtualKey17";
            this.virtualKey17.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey17.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey17.UseCustomBackColor = true;
            this.virtualKey17.UseCustomForeColor = true;
            this.virtualKey17.VkCodes.Add(System.Windows.Forms.Keys.A);
            // 
            // virtualKey16
            // 
            this.virtualKey16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey16.Bundary = null;
            this.virtualKey16.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey16.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey16.ForeColor = System.Drawing.Color.White;
            this.virtualKey16.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey16.HookResponseCodes")));
            this.virtualKey16.KeyLabel = "R";
            resources.ApplyResources(this.virtualKey16, "virtualKey16");
            this.virtualKey16.Name = "virtualKey16";
            this.virtualKey16.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey16.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey16.UseCustomBackColor = true;
            this.virtualKey16.UseCustomForeColor = true;
            this.virtualKey16.VkCodes.Add(System.Windows.Forms.Keys.R);
            // 
            // virtualKey15
            // 
            this.virtualKey15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey15.Bundary = null;
            this.virtualKey15.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey15.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey15.ForeColor = System.Drawing.Color.White;
            this.virtualKey15.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey15.HookResponseCodes")));
            this.virtualKey15.KeyLabel = "E";
            resources.ApplyResources(this.virtualKey15, "virtualKey15");
            this.virtualKey15.Name = "virtualKey15";
            this.virtualKey15.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey15.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey15.UseCustomBackColor = true;
            this.virtualKey15.UseCustomForeColor = true;
            this.virtualKey15.VkCodes.Add(System.Windows.Forms.Keys.E);
            // 
            // virtualKey14
            // 
            this.virtualKey14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey14.Bundary = null;
            this.virtualKey14.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey14.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey14.ForeColor = System.Drawing.Color.White;
            this.virtualKey14.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey14.HookResponseCodes")));
            this.virtualKey14.KeyLabel = "W";
            resources.ApplyResources(this.virtualKey14, "virtualKey14");
            this.virtualKey14.Name = "virtualKey14";
            this.virtualKey14.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey14.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey14.UseCustomBackColor = true;
            this.virtualKey14.UseCustomForeColor = true;
            this.virtualKey14.VkCodes.Add(System.Windows.Forms.Keys.W);
            // 
            // virtualKey13
            // 
            this.virtualKey13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey13.Bundary = null;
            this.virtualKey13.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey13.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey13.ForeColor = System.Drawing.Color.White;
            this.virtualKey13.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey13.HookResponseCodes")));
            this.virtualKey13.KeyLabel = "Q";
            resources.ApplyResources(this.virtualKey13, "virtualKey13");
            this.virtualKey13.Name = "virtualKey13";
            this.virtualKey13.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey13.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey13.UseCustomBackColor = true;
            this.virtualKey13.UseCustomForeColor = true;
            this.virtualKey13.VkCodes.Add(System.Windows.Forms.Keys.Q);
            // 
            // virtualKey12
            // 
            this.virtualKey12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey12.Bundary = null;
            this.virtualKey12.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey12.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey12.ForeColor = System.Drawing.Color.White;
            this.virtualKey12.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey12.HookResponseCodes")));
            this.virtualKey12.KeyLabel = "V";
            resources.ApplyResources(this.virtualKey12, "virtualKey12");
            this.virtualKey12.Name = "virtualKey12";
            this.virtualKey12.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey12.UseCustomBackColor = true;
            this.virtualKey12.UseCustomForeColor = true;
            this.virtualKey12.VkCodes.Add(System.Windows.Forms.Keys.V);
            // 
            // virtualKey11
            // 
            this.virtualKey11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey11.Bundary = null;
            this.virtualKey11.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey11.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey11.ForeColor = System.Drawing.Color.White;
            this.virtualKey11.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey11.HookResponseCodes")));
            this.virtualKey11.KeyLabel = "C";
            resources.ApplyResources(this.virtualKey11, "virtualKey11");
            this.virtualKey11.Name = "virtualKey11";
            this.virtualKey11.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey11.UseCustomBackColor = true;
            this.virtualKey11.UseCustomForeColor = true;
            this.virtualKey11.VkCodes.Add(System.Windows.Forms.Keys.C);
            // 
            // virtualKey10
            // 
            this.virtualKey10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey10.Bundary = null;
            this.virtualKey10.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey10.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey10.ForeColor = System.Drawing.Color.White;
            this.virtualKey10.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey10.HookResponseCodes")));
            this.virtualKey10.KeyLabel = "X";
            resources.ApplyResources(this.virtualKey10, "virtualKey10");
            this.virtualKey10.Name = "virtualKey10";
            this.virtualKey10.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey10.UseCustomBackColor = true;
            this.virtualKey10.UseCustomForeColor = true;
            this.virtualKey10.VkCodes.Add(System.Windows.Forms.Keys.X);
            // 
            // virtualKey9
            // 
            this.virtualKey9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey9.Bundary = null;
            this.virtualKey9.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey9.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey9.ForeColor = System.Drawing.Color.White;
            this.virtualKey9.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey9.HookResponseCodes")));
            this.virtualKey9.KeyLabel = "Z";
            resources.ApplyResources(this.virtualKey9, "virtualKey9");
            this.virtualKey9.Name = "virtualKey9";
            this.virtualKey9.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey9.UseCustomBackColor = true;
            this.virtualKey9.UseCustomForeColor = true;
            this.virtualKey9.VkCodes.Add(System.Windows.Forms.Keys.Z);
            // 
            // virtualKey8
            // 
            this.virtualKey8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey8.Bundary = null;
            this.virtualKey8.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey8.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey8.ForeColor = System.Drawing.Color.White;
            this.virtualKey8.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey8.HookResponseCodes")));
            this.virtualKey8.KeyLabel = "↖";
            resources.ApplyResources(this.virtualKey8, "virtualKey8");
            this.virtualKey8.Name = "virtualKey8";
            this.virtualKey8.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey8.UseCustomBackColor = true;
            this.virtualKey8.UseCustomForeColor = true;
            this.virtualKey8.VkCodes.Add(System.Windows.Forms.Keys.Up);
            this.virtualKey8.VkCodes.Add(System.Windows.Forms.Keys.Left);
            // 
            // virtualKey7
            // 
            this.virtualKey7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey7.Bundary = null;
            this.virtualKey7.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey7.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey7.ForeColor = System.Drawing.Color.White;
            this.virtualKey7.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey7.HookResponseCodes")));
            this.virtualKey7.KeyLabel = "←";
            resources.ApplyResources(this.virtualKey7, "virtualKey7");
            this.virtualKey7.Name = "virtualKey7";
            this.virtualKey7.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey7.UseCustomBackColor = true;
            this.virtualKey7.UseCustomForeColor = true;
            this.virtualKey7.VkCodes.Add(System.Windows.Forms.Keys.Left);
            // 
            // virtualKey2
            // 
            this.virtualKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey2.Bundary = null;
            this.virtualKey2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey2.ForeColor = System.Drawing.Color.White;
            this.virtualKey2.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey2.HookResponseCodes")));
            this.virtualKey2.KeyLabel = "↗";
            resources.ApplyResources(this.virtualKey2, "virtualKey2");
            this.virtualKey2.Name = "virtualKey2";
            this.virtualKey2.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey2.UseCustomBackColor = true;
            this.virtualKey2.UseCustomForeColor = true;
            this.virtualKey2.VkCodes.Add(System.Windows.Forms.Keys.Up);
            this.virtualKey2.VkCodes.Add(System.Windows.Forms.Keys.Right);
            // 
            // virtualKey1
            // 
            this.virtualKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey1.Bundary = null;
            this.virtualKey1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey1.ForeColor = System.Drawing.Color.White;
            this.virtualKey1.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey1.HookResponseCodes")));
            this.virtualKey1.KeyLabel = "↑";
            resources.ApplyResources(this.virtualKey1, "virtualKey1");
            this.virtualKey1.Name = "virtualKey1";
            this.virtualKey1.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey1.UseCustomBackColor = true;
            this.virtualKey1.UseCustomForeColor = true;
            this.virtualKey1.VkCodes.Add(System.Windows.Forms.Keys.Up);
            // 
            // virtualKey3
            // 
            this.virtualKey3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey3.Bundary = null;
            this.virtualKey3.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey3.ForeColor = System.Drawing.Color.White;
            this.virtualKey3.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey3.HookResponseCodes")));
            this.virtualKey3.KeyLabel = "→";
            resources.ApplyResources(this.virtualKey3, "virtualKey3");
            this.virtualKey3.Name = "virtualKey3";
            this.virtualKey3.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey3.UseCustomBackColor = true;
            this.virtualKey3.UseCustomForeColor = true;
            this.virtualKey3.VkCodes.Add(System.Windows.Forms.Keys.Right);
            // 
            // virtualKey5
            // 
            this.virtualKey5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey5.Bundary = null;
            this.virtualKey5.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey5.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey5.ForeColor = System.Drawing.Color.White;
            this.virtualKey5.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey5.HookResponseCodes")));
            this.virtualKey5.KeyLabel = "↓";
            resources.ApplyResources(this.virtualKey5, "virtualKey5");
            this.virtualKey5.Name = "virtualKey5";
            this.virtualKey5.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey5.UseCustomBackColor = true;
            this.virtualKey5.UseCustomForeColor = true;
            this.virtualKey5.VkCodes.Add(System.Windows.Forms.Keys.Down);
            // 
            // virtualKey4
            // 
            this.virtualKey4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey4.Bundary = null;
            this.virtualKey4.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey4.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey4.ForeColor = System.Drawing.Color.White;
            this.virtualKey4.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey4.HookResponseCodes")));
            this.virtualKey4.KeyLabel = "↘";
            resources.ApplyResources(this.virtualKey4, "virtualKey4");
            this.virtualKey4.Name = "virtualKey4";
            this.virtualKey4.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey4.UseCustomBackColor = true;
            this.virtualKey4.UseCustomForeColor = true;
            this.virtualKey4.VkCodes.Add(System.Windows.Forms.Keys.Down);
            this.virtualKey4.VkCodes.Add(System.Windows.Forms.Keys.Right);
            // 
            // virtualKey6
            // 
            this.virtualKey6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.virtualKey6.Bundary = null;
            this.virtualKey6.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.virtualKey6.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.virtualKey6.ForeColor = System.Drawing.Color.White;
            this.virtualKey6.HookResponseCodes = ((System.Collections.Generic.List<int>)(resources.GetObject("virtualKey6.HookResponseCodes")));
            this.virtualKey6.KeyLabel = "↙";
            resources.ApplyResources(this.virtualKey6, "virtualKey6");
            this.virtualKey6.Name = "virtualKey6";
            this.virtualKey6.Style = MetroFramework.MetroColorStyle.Purple;
            this.virtualKey6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.virtualKey6.UseCustomBackColor = true;
            this.virtualKey6.UseCustomForeColor = true;
            this.virtualKey6.VkCodes.Add(System.Windows.Forms.Keys.Down);
            this.virtualKey6.VkCodes.Add(System.Windows.Forms.Keys.Left);
            // 
            // MainBoard
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.gameCube2);
            this.Controls.Add(this.virtualKey24);
            this.Controls.Add(this.virtualKey30);
            this.Controls.Add(this.virtualKey29);
            this.Controls.Add(this.virtualKey28);
            this.Controls.Add(this.virtualKey27);
            this.Controls.Add(this.virtualKey26);
            this.Controls.Add(this.virtualKey25);
            this.Controls.Add(this.virtualKey23);
            this.Controls.Add(this.virtualKey22);
            this.Controls.Add(this.virtualKey21);
            this.Controls.Add(this.virtualKey20);
            this.Controls.Add(this.virtualKey19);
            this.Controls.Add(this.virtualKey18);
            this.Controls.Add(this.virtualKey17);
            this.Controls.Add(this.virtualKey16);
            this.Controls.Add(this.virtualKey15);
            this.Controls.Add(this.virtualKey14);
            this.Controls.Add(this.virtualKey13);
            this.Controls.Add(this.virtualKey12);
            this.Controls.Add(this.virtualKey11);
            this.Controls.Add(this.virtualKey10);
            this.Controls.Add(this.virtualKey9);
            this.Controls.Add(this.virtualKey8);
            this.Controls.Add(this.virtualKey7);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.virtualKey2);
            this.Controls.Add(this.virtualKey1);
            this.Controls.Add(this.virtualKey3);
            this.Controls.Add(this.virtualKey5);
            this.Controls.Add(this.virtualKey4);
            this.Controls.Add(this.virtualKey6);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.Name = "MainBoard";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainBoard_FormClosed);
            this.Load += new System.EventHandler(this.MainBoard_Load);
            this.Move += new System.EventHandler(this.MainBoard_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroFramework.Controls.MetroContextMenu contextMenuStrip1;
        private MetroFramework.Controls.MetroButton hideButton;
        private VirtualKey virtualKey1;
        private System.Windows.Forms.ToolStripMenuItem exitEToolStripMenuItem;
        private VirtualKey virtualKey2;
        private VirtualKey virtualKey3;
        private VirtualKey virtualKey4;
        private VirtualKey virtualKey5;
        private VirtualKey virtualKey6;
        private VirtualKey virtualKey7;
        private VirtualKey virtualKey8;
        private VirtualKey virtualKey9;
        private VirtualKey virtualKey10;
        private VirtualKey virtualKey11;
        private VirtualKey virtualKey12;
        private VirtualKey virtualKey13;
        private VirtualKey virtualKey14;
        private VirtualKey virtualKey15;
        private VirtualKey virtualKey16;
        private VirtualKey virtualKey17;
        private VirtualKey virtualKey18;
        private VirtualKey virtualKey19;
        private VirtualKey virtualKey20;
        private VirtualKey virtualKey21;
        private VirtualKey virtualKey22;
        private VirtualKey virtualKey23;
        private VirtualKey virtualKey25;
        private VirtualKey virtualKey26;
        private VirtualKey virtualKey27;
        private VirtualKey virtualKey28;
        private VirtualKey virtualKey29;
        private VirtualKey virtualKey30;
        private VirtualKey virtualKey24;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameCubeGToolStripMenuItem;
        private GameCube gameCube2;
    }
}

