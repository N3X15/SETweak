namespace EnvFiddle.GUI
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.tabs = new EnvFiddle.GUI.TablessControl();
            this.tabSource = new System.Windows.Forms.TabPage();
            this.cmdSourceBrowseFile = new System.Windows.Forms.Button();
            this.cmdSourceBrowse = new System.Windows.Forms.Button();
            this.txtSourceURL = new System.Windows.Forms.TextBox();
            this.lblSourceIntro = new System.Windows.Forms.Label();
            this.tabSpeeds = new System.Windows.Forms.TabPage();
            this.lblSpeedSmallShips = new System.Windows.Forms.Label();
            this.cmdMaxSpeedSmall = new System.Windows.Forms.Button();
            this.cmdResetSpeedSmall = new System.Windows.Forms.Button();
            this.nudMaxSpeedSmall = new System.Windows.Forms.NumericUpDown();
            this.lblSpeedLargeShips = new System.Windows.Forms.Label();
            this.cmdMaxSpeedLarge = new System.Windows.Forms.Button();
            this.cmdResetSpeedLarge = new System.Windows.Forms.Button();
            this.nudMaxSpeedLarge = new System.Windows.Forms.NumericUpDown();
            this.lblSpeedsIntro = new System.Windows.Forms.Label();
            this.tabLighting = new System.Windows.Forms.TabPage();
            this.chkRemoveFog = new System.Windows.Forms.CheckBox();
            this.chkDarkShadows = new System.Windows.Forms.CheckBox();
            this.grpPresets = new System.Windows.Forms.GroupBox();
            this.clbLightingPresets = new System.Windows.Forms.CheckedListBox();
            this.lblLightingIntro = new System.Windows.Forms.Label();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.cmdOutputBrowse = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lblFinalOutput = new System.Windows.Forms.Label();
            this.cmbGameType = new System.Windows.Forms.ComboBox();
            this.lblModType = new System.Windows.Forms.Label();
            this.txtModName = new System.Windows.Forms.TextBox();
            this.lblModName = new System.Windows.Forms.Label();
            this.lblOutputIntro = new System.Windows.Forms.Label();
            this.tabFinalCheck = new System.Windows.Forms.TabPage();
            this.chkCYA1 = new System.Windows.Forms.CheckBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.lblCommandLine = new System.Windows.Forms.Label();
            this.chkCYA2 = new System.Windows.Forms.CheckBox();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabSource.SuspendLayout();
            this.tabSpeeds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeedSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeedLarge)).BeginInit();
            this.tabLighting.SuspendLayout();
            this.grpPresets.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.tabFinalCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblProgress);
            this.pnlBottom.Controls.Add(this.cmdPrevious);
            this.pnlBottom.Controls.Add(this.cmdNext);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 271);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(458, 53);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(32, 23);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(52, 13);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "Page 0/0";
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Location = new System.Drawing.Point(290, 18);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(75, 23);
            this.cmdPrevious.TabIndex = 1;
            this.cmdPrevious.Text = "Back";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(371, 18);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 0;
            this.cmdNext.Text = "Next";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabSource);
            this.tabs.Controls.Add(this.tabSpeeds);
            this.tabs.Controls.Add(this.tabLighting);
            this.tabs.Controls.Add(this.tabOutput);
            this.tabs.Controls.Add(this.tabFinalCheck);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(458, 271);
            this.tabs.TabIndex = 2;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.cmdSourceBrowseFile);
            this.tabSource.Controls.Add(this.cmdSourceBrowse);
            this.tabSource.Controls.Add(this.txtSourceURL);
            this.tabSource.Controls.Add(this.lblSourceIntro);
            this.tabSource.Location = new System.Drawing.Point(4, 22);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(450, 183);
            this.tabSource.TabIndex = 0;
            this.tabSource.Text = "Source";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // cmdSourceBrowseFile
            // 
            this.cmdSourceBrowseFile.Location = new System.Drawing.Point(318, 97);
            this.cmdSourceBrowseFile.Name = "cmdSourceBrowseFile";
            this.cmdSourceBrowseFile.Size = new System.Drawing.Size(97, 23);
            this.cmdSourceBrowseFile.TabIndex = 3;
            this.cmdSourceBrowseFile.Text = "Select File...";
            this.cmdSourceBrowseFile.UseVisualStyleBackColor = true;
            this.cmdSourceBrowseFile.Click += new System.EventHandler(this.cmdSourceBrowseFile_Click);
            // 
            // cmdSourceBrowse
            // 
            this.cmdSourceBrowse.Location = new System.Drawing.Point(318, 68);
            this.cmdSourceBrowse.Name = "cmdSourceBrowse";
            this.cmdSourceBrowse.Size = new System.Drawing.Size(97, 23);
            this.cmdSourceBrowse.TabIndex = 2;
            this.cmdSourceBrowse.Text = "Select Folder...";
            this.cmdSourceBrowse.UseVisualStyleBackColor = true;
            this.cmdSourceBrowse.Click += new System.EventHandler(this.cmdSourceBrowse_Click);
            // 
            // txtSourceURL
            // 
            this.txtSourceURL.Location = new System.Drawing.Point(49, 70);
            this.txtSourceURL.Name = "txtSourceURL";
            this.txtSourceURL.Size = new System.Drawing.Size(263, 20);
            this.txtSourceURL.TabIndex = 1;
            this.txtSourceURL.Validating += new System.ComponentModel.CancelEventHandler(this.txtSourceURL_Validating);
            // 
            // lblSourceIntro
            // 
            this.lblSourceIntro.Location = new System.Drawing.Point(8, 3);
            this.lblSourceIntro.Name = "lblSourceIntro";
            this.lblSourceIntro.Size = new System.Drawing.Size(434, 62);
            this.lblSourceIntro.TabIndex = 0;
            this.lblSourceIntro.Text = "EnvFiddle applies filters to an existing skybox.  Therefore, it needs to know wha" +
    "t skybox to start from.\r\n\r\nYou can use either a file path to the sbm, or a Steam" +
    " Workshop URL.";
            // 
            // tabSpeeds
            // 
            this.tabSpeeds.Controls.Add(this.lblSpeedSmallShips);
            this.tabSpeeds.Controls.Add(this.cmdMaxSpeedSmall);
            this.tabSpeeds.Controls.Add(this.cmdResetSpeedSmall);
            this.tabSpeeds.Controls.Add(this.nudMaxSpeedSmall);
            this.tabSpeeds.Controls.Add(this.lblSpeedLargeShips);
            this.tabSpeeds.Controls.Add(this.cmdMaxSpeedLarge);
            this.tabSpeeds.Controls.Add(this.cmdResetSpeedLarge);
            this.tabSpeeds.Controls.Add(this.nudMaxSpeedLarge);
            this.tabSpeeds.Controls.Add(this.lblSpeedsIntro);
            this.tabSpeeds.Location = new System.Drawing.Point(4, 22);
            this.tabSpeeds.Name = "tabSpeeds";
            this.tabSpeeds.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpeeds.Size = new System.Drawing.Size(450, 183);
            this.tabSpeeds.TabIndex = 1;
            this.tabSpeeds.Text = "Speeds";
            this.tabSpeeds.UseVisualStyleBackColor = true;
            // 
            // lblSpeedSmallShips
            // 
            this.lblSpeedSmallShips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeedSmallShips.AutoSize = true;
            this.lblSpeedSmallShips.Location = new System.Drawing.Point(48, 107);
            this.lblSpeedSmallShips.Name = "lblSpeedSmallShips";
            this.lblSpeedSmallShips.Size = new System.Drawing.Size(64, 13);
            this.lblSpeedSmallShips.TabIndex = 8;
            this.lblSpeedSmallShips.Text = "Small Ships:";
            // 
            // cmdMaxSpeedSmall
            // 
            this.cmdMaxSpeedSmall.Location = new System.Drawing.Point(301, 102);
            this.cmdMaxSpeedSmall.Name = "cmdMaxSpeedSmall";
            this.cmdMaxSpeedSmall.Size = new System.Drawing.Size(23, 23);
            this.cmdMaxSpeedSmall.TabIndex = 7;
            this.cmdMaxSpeedSmall.Text = "C";
            this.cmdMaxSpeedSmall.UseVisualStyleBackColor = true;
            // 
            // cmdResetSpeedSmall
            // 
            this.cmdResetSpeedSmall.Location = new System.Drawing.Point(245, 102);
            this.cmdResetSpeedSmall.Name = "cmdResetSpeedSmall";
            this.cmdResetSpeedSmall.Size = new System.Drawing.Size(50, 23);
            this.cmdResetSpeedSmall.TabIndex = 6;
            this.cmdResetSpeedSmall.Text = "Reset";
            this.cmdResetSpeedSmall.UseVisualStyleBackColor = true;
            // 
            // nudMaxSpeedSmall
            // 
            this.nudMaxSpeedSmall.Location = new System.Drawing.Point(118, 105);
            this.nudMaxSpeedSmall.Name = "nudMaxSpeedSmall";
            this.nudMaxSpeedSmall.Size = new System.Drawing.Size(120, 20);
            this.nudMaxSpeedSmall.TabIndex = 5;
            this.nudMaxSpeedSmall.ValueChanged += new System.EventHandler(this.nudMaxSpeedSmall_ValueChanged);
            // 
            // lblSpeedLargeShips
            // 
            this.lblSpeedLargeShips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeedLargeShips.AutoSize = true;
            this.lblSpeedLargeShips.Location = new System.Drawing.Point(46, 78);
            this.lblSpeedLargeShips.Name = "lblSpeedLargeShips";
            this.lblSpeedLargeShips.Size = new System.Drawing.Size(66, 13);
            this.lblSpeedLargeShips.TabIndex = 4;
            this.lblSpeedLargeShips.Text = "Large Ships:";
            // 
            // cmdMaxSpeedLarge
            // 
            this.cmdMaxSpeedLarge.Location = new System.Drawing.Point(301, 73);
            this.cmdMaxSpeedLarge.Name = "cmdMaxSpeedLarge";
            this.cmdMaxSpeedLarge.Size = new System.Drawing.Size(23, 23);
            this.cmdMaxSpeedLarge.TabIndex = 3;
            this.cmdMaxSpeedLarge.Text = "C";
            this.cmdMaxSpeedLarge.UseVisualStyleBackColor = true;
            // 
            // cmdResetSpeedLarge
            // 
            this.cmdResetSpeedLarge.Location = new System.Drawing.Point(245, 73);
            this.cmdResetSpeedLarge.Name = "cmdResetSpeedLarge";
            this.cmdResetSpeedLarge.Size = new System.Drawing.Size(50, 23);
            this.cmdResetSpeedLarge.TabIndex = 2;
            this.cmdResetSpeedLarge.Text = "Reset";
            this.cmdResetSpeedLarge.UseVisualStyleBackColor = true;
            // 
            // nudMaxSpeedLarge
            // 
            this.nudMaxSpeedLarge.Location = new System.Drawing.Point(118, 76);
            this.nudMaxSpeedLarge.Name = "nudMaxSpeedLarge";
            this.nudMaxSpeedLarge.Size = new System.Drawing.Size(120, 20);
            this.nudMaxSpeedLarge.TabIndex = 1;
            this.nudMaxSpeedLarge.ValueChanged += new System.EventHandler(this.nudMaxSpeedLarge_ValueChanged);
            // 
            // lblSpeedsIntro
            // 
            this.lblSpeedsIntro.Location = new System.Drawing.Point(9, 7);
            this.lblSpeedsIntro.Name = "lblSpeedsIntro";
            this.lblSpeedsIntro.Size = new System.Drawing.Size(433, 55);
            this.lblSpeedsIntro.TabIndex = 0;
            this.lblSpeedsIntro.Text = resources.GetString("lblSpeedsIntro.Text");
            // 
            // tabLighting
            // 
            this.tabLighting.Controls.Add(this.chkRemoveFog);
            this.tabLighting.Controls.Add(this.chkDarkShadows);
            this.tabLighting.Controls.Add(this.grpPresets);
            this.tabLighting.Controls.Add(this.lblLightingIntro);
            this.tabLighting.Location = new System.Drawing.Point(4, 22);
            this.tabLighting.Name = "tabLighting";
            this.tabLighting.Padding = new System.Windows.Forms.Padding(3);
            this.tabLighting.Size = new System.Drawing.Size(450, 245);
            this.tabLighting.TabIndex = 2;
            this.tabLighting.Text = "Lighting";
            this.tabLighting.UseVisualStyleBackColor = true;
            // 
            // chkRemoveFog
            // 
            this.chkRemoveFog.AutoSize = true;
            this.chkRemoveFog.Location = new System.Drawing.Point(231, 78);
            this.chkRemoveFog.Name = "chkRemoveFog";
            this.chkRemoveFog.Size = new System.Drawing.Size(87, 17);
            this.chkRemoveFog.TabIndex = 3;
            this.chkRemoveFog.Text = "Remove Fog";
            this.chkRemoveFog.UseVisualStyleBackColor = true;
            // 
            // chkDarkShadows
            // 
            this.chkDarkShadows.AutoSize = true;
            this.chkDarkShadows.Location = new System.Drawing.Point(231, 54);
            this.chkDarkShadows.Name = "chkDarkShadows";
            this.chkDarkShadows.Size = new System.Drawing.Size(96, 17);
            this.chkDarkShadows.TabIndex = 2;
            this.chkDarkShadows.Text = "Dark Shadows";
            this.chkDarkShadows.UseVisualStyleBackColor = true;
            this.chkDarkShadows.CheckedChanged += new System.EventHandler(this.chkDarkShadows_CheckedChanged);
            // 
            // grpPresets
            // 
            this.grpPresets.Controls.Add(this.clbLightingPresets);
            this.grpPresets.Location = new System.Drawing.Point(9, 54);
            this.grpPresets.Name = "grpPresets";
            this.grpPresets.Size = new System.Drawing.Size(200, 123);
            this.grpPresets.TabIndex = 1;
            this.grpPresets.TabStop = false;
            this.grpPresets.Text = "Presets";
            // 
            // clbLightingPresets
            // 
            this.clbLightingPresets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbLightingPresets.CheckOnClick = true;
            this.clbLightingPresets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLightingPresets.FormattingEnabled = true;
            this.clbLightingPresets.Location = new System.Drawing.Point(3, 16);
            this.clbLightingPresets.Name = "clbLightingPresets";
            this.clbLightingPresets.Size = new System.Drawing.Size(194, 104);
            this.clbLightingPresets.Sorted = true;
            this.clbLightingPresets.TabIndex = 0;
            // 
            // lblLightingIntro
            // 
            this.lblLightingIntro.Location = new System.Drawing.Point(6, 7);
            this.lblLightingIntro.Name = "lblLightingIntro";
            this.lblLightingIntro.Size = new System.Drawing.Size(438, 43);
            this.lblLightingIntro.TabIndex = 0;
            this.lblLightingIntro.Text = "This page allows you to set lighting constants.  \r\n\r\nThe presets are available in" +
    " the Presets directory.";
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.cmdOutputBrowse);
            this.tabOutput.Controls.Add(this.txtOutputPath);
            this.tabOutput.Controls.Add(this.lblFinalOutput);
            this.tabOutput.Controls.Add(this.cmbGameType);
            this.tabOutput.Controls.Add(this.lblModType);
            this.tabOutput.Controls.Add(this.txtModName);
            this.tabOutput.Controls.Add(this.lblModName);
            this.tabOutput.Controls.Add(this.lblOutputIntro);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(450, 245);
            this.tabOutput.TabIndex = 3;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // cmdOutputBrowse
            // 
            this.cmdOutputBrowse.Location = new System.Drawing.Point(367, 87);
            this.cmdOutputBrowse.Name = "cmdOutputBrowse";
            this.cmdOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdOutputBrowse.TabIndex = 7;
            this.cmdOutputBrowse.Text = "Browse...";
            this.cmdOutputBrowse.UseVisualStyleBackColor = true;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(133, 89);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(228, 20);
            this.txtOutputPath.TabIndex = 6;
            this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
            // 
            // lblFinalOutput
            // 
            this.lblFinalOutput.AutoSize = true;
            this.lblFinalOutput.Location = new System.Drawing.Point(15, 92);
            this.lblFinalOutput.Name = "lblFinalOutput";
            this.lblFinalOutput.Size = new System.Drawing.Size(112, 13);
            this.lblFinalOutput.TabIndex = 5;
            this.lblFinalOutput.Text = "Final Output Directory:";
            // 
            // cmbGameType
            // 
            this.cmbGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameType.Items.AddRange(new object[] {
            "SpaceEngineers",
            "SpaceEngineersDedicated"});
            this.cmbGameType.Location = new System.Drawing.Point(96, 59);
            this.cmbGameType.Name = "cmbGameType";
            this.cmbGameType.Size = new System.Drawing.Size(212, 21);
            this.cmbGameType.TabIndex = 4;
            this.cmbGameType.SelectedIndexChanged += new System.EventHandler(this.cmbGameType_SelectedIndexChanged);
            // 
            // lblModType
            // 
            this.lblModType.AutoSize = true;
            this.lblModType.Location = new System.Drawing.Point(15, 62);
            this.lblModType.Name = "lblModType";
            this.lblModType.Size = new System.Drawing.Size(75, 13);
            this.lblModType.TabIndex = 3;
            this.lblModType.Text = "Mod made for:";
            // 
            // txtModName
            // 
            this.txtModName.Location = new System.Drawing.Point(96, 31);
            this.txtModName.Name = "txtModName";
            this.txtModName.Size = new System.Drawing.Size(212, 20);
            this.txtModName.TabIndex = 2;
            this.txtModName.Validating += new System.ComponentModel.CancelEventHandler(this.txtModName_Validating);
            // 
            // lblModName
            // 
            this.lblModName.AutoSize = true;
            this.lblModName.Location = new System.Drawing.Point(28, 34);
            this.lblModName.Name = "lblModName";
            this.lblModName.Size = new System.Drawing.Size(62, 13);
            this.lblModName.TabIndex = 1;
            this.lblModName.Text = "Mod Name:";
            // 
            // lblOutputIntro
            // 
            this.lblOutputIntro.AutoSize = true;
            this.lblOutputIntro.Location = new System.Drawing.Point(9, 7);
            this.lblOutputIntro.Name = "lblOutputIntro";
            this.lblOutputIntro.Size = new System.Drawing.Size(423, 13);
            this.lblOutputIntro.TabIndex = 0;
            this.lblOutputIntro.Text = "This page allows you to decide where to store the completed environment mod direc" +
    "tory.";
            // 
            // tabFinalCheck
            // 
            this.tabFinalCheck.Controls.Add(this.cmdExecute);
            this.tabFinalCheck.Controls.Add(this.chkCYA2);
            this.tabFinalCheck.Controls.Add(this.chkCYA1);
            this.tabFinalCheck.Controls.Add(this.txtCommandLine);
            this.tabFinalCheck.Controls.Add(this.lblCommandLine);
            this.tabFinalCheck.Location = new System.Drawing.Point(4, 22);
            this.tabFinalCheck.Name = "tabFinalCheck";
            this.tabFinalCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinalCheck.Size = new System.Drawing.Size(450, 245);
            this.tabFinalCheck.TabIndex = 4;
            this.tabFinalCheck.Text = "Confirmation";
            this.tabFinalCheck.UseVisualStyleBackColor = true;
            // 
            // chkCYA1
            // 
            this.chkCYA1.Location = new System.Drawing.Point(81, 150);
            this.chkCYA1.Name = "chkCYA1";
            this.chkCYA1.Size = new System.Drawing.Size(310, 30);
            this.chkCYA1.TabIndex = 2;
            this.chkCYA1.Text = "I understand that this may end up breaking my skybox, and that EnvFiddle is used " +
    "at my own risk.";
            this.chkCYA1.UseVisualStyleBackColor = true;
            this.chkCYA1.CheckedChanged += new System.EventHandler(this.chkCYA1_CheckedChanged);
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(10, 43);
            this.txtCommandLine.Multiline = true;
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(432, 101);
            this.txtCommandLine.TabIndex = 1;
            // 
            // lblCommandLine
            // 
            this.lblCommandLine.Location = new System.Drawing.Point(7, 7);
            this.lblCommandLine.Name = "lblCommandLine";
            this.lblCommandLine.Size = new System.Drawing.Size(435, 32);
            this.lblCommandLine.TabIndex = 0;
            this.lblCommandLine.Text = "Here\'s what we will call EnvFiddle with.  Check that it\'s accurate, and save it t" +
    "o a batch file, if you want.";
            // 
            // chkCYA2
            // 
            this.chkCYA2.Location = new System.Drawing.Point(81, 186);
            this.chkCYA2.Name = "chkCYA2";
            this.chkCYA2.Size = new System.Drawing.Size(310, 30);
            this.chkCYA2.TabIndex = 3;
            this.chkCYA2.Text = "I will not upload the result to the workshop, unless the original is my own work." +
    "";
            this.chkCYA2.UseVisualStyleBackColor = true;
            this.chkCYA2.CheckedChanged += new System.EventHandler(this.chkCYA2_CheckedChanged);
            // 
            // cmdExecute
            // 
            this.cmdExecute.Location = new System.Drawing.Point(184, 222);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(75, 23);
            this.cmdExecute.TabIndex = 4;
            this.cmdExecute.Text = "Go!";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 324);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmMain";
            this.Text = "Environment Fiddler";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            this.tabSource.PerformLayout();
            this.tabSpeeds.ResumeLayout(false);
            this.tabSpeeds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeedSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeedLarge)).EndInit();
            this.tabLighting.ResumeLayout(false);
            this.tabLighting.PerformLayout();
            this.grpPresets.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.tabFinalCheck.ResumeLayout(false);
            this.tabFinalCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Button cmdNext;
        private EnvFiddle.GUI.TablessControl tabs;
        private System.Windows.Forms.TabPage tabSource;
        private System.Windows.Forms.Button cmdSourceBrowse;
        private System.Windows.Forms.TextBox txtSourceURL;
        private System.Windows.Forms.Label lblSourceIntro;
        private System.Windows.Forms.TabPage tabSpeeds;
        private System.Windows.Forms.NumericUpDown nudMaxSpeedLarge;
        private System.Windows.Forms.Label lblSpeedsIntro;
        private System.Windows.Forms.Label lblSpeedSmallShips;
        private System.Windows.Forms.Button cmdMaxSpeedSmall;
        private System.Windows.Forms.Button cmdResetSpeedSmall;
        private System.Windows.Forms.NumericUpDown nudMaxSpeedSmall;
        private System.Windows.Forms.Label lblSpeedLargeShips;
        private System.Windows.Forms.Button cmdMaxSpeedLarge;
        private System.Windows.Forms.Button cmdResetSpeedLarge;
        private System.Windows.Forms.TabPage tabLighting;
        private System.Windows.Forms.CheckBox chkRemoveFog;
        private System.Windows.Forms.CheckBox chkDarkShadows;
        private System.Windows.Forms.GroupBox grpPresets;
        private System.Windows.Forms.CheckedListBox clbLightingPresets;
        private System.Windows.Forms.Label lblLightingIntro;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.Button cmdOutputBrowse;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label lblFinalOutput;
        private System.Windows.Forms.ComboBox cmbGameType;
        private System.Windows.Forms.Label lblModType;
        private System.Windows.Forms.TextBox txtModName;
        private System.Windows.Forms.Label lblModName;
        private System.Windows.Forms.Label lblOutputIntro;
        private System.Windows.Forms.TabPage tabFinalCheck;
        private System.Windows.Forms.CheckBox chkCYA1;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Label lblCommandLine;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button cmdSourceBrowseFile;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.CheckBox chkCYA2;
    }
}

