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
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
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
            this.gameCubeGToolStripMenuItem.CheckOnClick = true;
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
            // MainBoard
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainBoard_FormClosing);
            this.Load += new System.EventHandler(this.MainBoard_Load);
            this.Move += new System.EventHandler(this.MainBoard_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroFramework.Controls.MetroContextMenu contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameCubeGToolStripMenuItem;
    }
}

