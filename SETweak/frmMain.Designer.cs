namespace SETweak
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.pgbStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabEnvironment = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pgModProperties = new System.Windows.Forms.PropertyGrid();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCommonOptions = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuLightLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDarkShadows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPitchBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbMaxSpeed = new System.Windows.Forms.ToolStripComboBox();
            this.statusBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbStatusBar,
            this.lblStatusBar});
            this.statusBar.Location = new System.Drawing.Point(0, 468);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(611, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // pgbStatusBar
            // 
            this.pgbStatusBar.Name = "pgbStatusBar";
            this.pgbStatusBar.Size = new System.Drawing.Size(100, 16);
            this.pgbStatusBar.Visible = false;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(69, 17);
            this.lblStatusBar.Text = "lblStatusBar";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(611, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuOpen.Text = "&Open";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(103, 22);
            this.mnuSave.Text = "&Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(103, 22);
            this.mnuExit.Text = "E&xit";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabGeneral);
            this.tabs.Controls.Add(this.tabEnvironment);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 24);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(611, 444);
            this.tabs.TabIndex = 2;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.pgModProperties);
            this.tabGeneral.Controls.Add(this.toolStrip1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(603, 418);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabEnvironment
            // 
            this.tabEnvironment.Location = new System.Drawing.Point(4, 22);
            this.tabEnvironment.Name = "tabEnvironment";
            this.tabEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnvironment.Size = new System.Drawing.Size(603, 418);
            this.tabEnvironment.TabIndex = 1;
            this.tabEnvironment.Text = "tabPage2";
            this.tabEnvironment.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator2,
            this.mnuCommonOptions});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(597, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pgModProperties
            // 
            this.pgModProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgModProperties.Location = new System.Drawing.Point(3, 28);
            this.pgModProperties.Name = "pgModProperties";
            this.pgModProperties.Size = new System.Drawing.Size(597, 387);
            this.pgModProperties.TabIndex = 2;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuCommonOptions
            // 
            this.mnuCommonOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCommonOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLightLevel,
            this.cmbMaxSpeed});
            this.mnuCommonOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnuCommonOptions.Image")));
            this.mnuCommonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCommonOptions.Name = "mnuCommonOptions";
            this.mnuCommonOptions.Size = new System.Drawing.Size(32, 22);
            this.mnuCommonOptions.Text = "Common Operations";
            // 
            // mnuLightLevel
            // 
            this.mnuLightLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDarkShadows,
            this.mnuPitchBlack});
            this.mnuLightLevel.Name = "mnuLightLevel";
            this.mnuLightLevel.Size = new System.Drawing.Size(181, 22);
            this.mnuLightLevel.Text = "Light Level Mods...";
            // 
            // mnuDarkShadows
            // 
            this.mnuDarkShadows.CheckOnClick = true;
            this.mnuDarkShadows.Name = "mnuDarkShadows";
            this.mnuDarkShadows.Size = new System.Drawing.Size(209, 22);
            this.mnuDarkShadows.Text = "Bright Sun, Dark Shadows";
            // 
            // mnuPitchBlack
            // 
            this.mnuPitchBlack.CheckOnClick = true;
            this.mnuPitchBlack.Name = "mnuPitchBlack";
            this.mnuPitchBlack.Size = new System.Drawing.Size(209, 22);
            this.mnuPitchBlack.Text = "Pitch Black";
            // 
            // cmbMaxSpeed
            // 
            this.cmbMaxSpeed.Name = "cmbMaxSpeed";
            this.cmbMaxSpeed.Size = new System.Drawing.Size(121, 23);
            this.cmbMaxSpeed.Text = "Max Speed";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 490);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "SETweak";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripProgressBar pgbStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabEnvironment;
        private System.Windows.Forms.PropertyGrid pgModProperties;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton mnuCommonOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuLightLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuDarkShadows;
        private System.Windows.Forms.ToolStripMenuItem mnuPitchBlack;
        private System.Windows.Forms.ToolStripComboBox cmbMaxSpeed;

    }
}

