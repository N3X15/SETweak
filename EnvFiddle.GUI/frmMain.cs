using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using SETweaks;

namespace EnvFiddle.GUI
{
    public partial class frmMain : Form
    {
        static Regex regSteamWorkshopURL = new Regex(@"^http://steamcommunity\.com/sharedfiles/filedetails/?id=\d+$");
        static Regex regValidModName = new Regex(@"^[a-zA-Z0-9 \-_]+$");
        private Dictionary<object, bool> mControlValidationStatus = new Dictionary<object, bool>();
        private EnvFiddleOptions opts = new EnvFiddleOptions();
        public frmMain()
        {
            InitializeComponent();

            nudMaxSpeedLarge.Value = (decimal)opts.MaxSpeedLargeShip;
            nudMaxSpeedSmall.Value = (decimal)opts.MaxSpeedSmallShip;

            tabs.SelectedIndex = 0;
            cmbGameType.SelectedIndex = 0;

            nudMaxSpeedLarge.Maximum = (decimal)SEConstants.SPEED_OF_LIGHT;
            nudMaxSpeedSmall.Maximum = (decimal)SEConstants.SPEED_OF_LIGHT;

            ValidateEverything();
        }

        private void SetValid(object o, Label lbl, bool isValid)
        {
            mControlValidationStatus[o] = isValid;
            ValidateEverything();
            SetFieldValidity(lbl, (Control)o, isValid);
        }

        private void SetFieldValidity(Label lbl, Control ctl, bool validity)
        {
            if(lbl!=null) lbl.ForeColor = validity ? SystemColors.WindowText : Color.Red;
            ctl.BackColor = validity ? SystemColors.Window : Color.Salmon;
        }

        private void txtSourceURL_Validating(object sender, CancelEventArgs e)
        {
            SetValid(sender, null, true);
            if (!string.IsNullOrEmpty(txtSourceURL.Text))
            {
                if (File.Exists(txtSourceURL.Text))
                {
                    if (Path.GetExtension(txtSourceURL.Text) == ".sbm")
                    {
                        return;
                    }
                }
                else if (Directory.Exists(txtSourceURL.Text))
                {
                    return;
                }
                else if (regSteamWorkshopURL.Match(txtSourceURL.Text) != null)
                {
                    return;
                }
            }
            SetValid(sender, null, false);
            e.Cancel = true;
        }

        private void MoveToTab(int offset)
        {
            tabs.SelectedIndex = Math.Min(Math.Max(tabs.SelectedIndex + offset, 0), tabs.TabCount - 1);
            ValidateEverything();
        }

        private void ValidateEverything()
        {
            lblProgress.Text = string.Format("Page {0}/{1}", tabs.SelectedIndex + 1, tabs.TabCount);
            cmdNext.Enabled = tabs.SelectedIndex+1 < tabs.TabCount && canProceed();
            cmdPrevious.Enabled = tabs.SelectedIndex > 0 && canProceed();
            txtCommandLine.Text = "envfiddle.exe " + opts.ToString();
            cmdExecute.Enabled = canProceed() && chkCYA1.Checked && chkCYA2.Checked;
        }

        private bool canProceed()
        {
            foreach (var control in this.Controls)
            {
                if (!ControlIsValid(control))
                {
                    Console.WriteLine("{0} is invalid!", (control as Control).Name);
                    return false;
                }
            }
            return true;
        }

        private bool ControlIsValid(object control)
        {
            if (!mControlValidationStatus.ContainsKey(control))
                return true;
            return mControlValidationStatus[control];
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
            if(canProceed()) MoveToTab(1);
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
            if(canProceed()) MoveToTab(-1);
        }

        private void nudMaxSpeedLarge_ValueChanged(object sender, EventArgs e)
        {
            opts.MaxSpeedLargeShip = (float)nudMaxSpeedLarge.Value;
        }

        private void nudMaxSpeedSmall_ValueChanged(object sender, EventArgs e)
        {
            opts.MaxSpeedSmallShip = (float)nudMaxSpeedSmall.Value;
        }

        private void cmbGameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOutputDir();
        }

        private void UpdateOutputDir()
        {
            if (string.IsNullOrEmpty(cmbGameType.Text)) return;
            if (string.IsNullOrEmpty(txtModName.Text)) return;
            txtOutputPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cmbGameType.Text, "Mods", txtModName.Text);
            opts.OutDir = txtOutputPath.Text;
        }

        private void txtOutputPath_TextChanged(object sender, EventArgs e)
        {
            opts.OutDir = txtOutputPath.Text;
        }

        private void txtModName_Validating(object sender, CancelEventArgs e)
        {
            if (regValidModName.IsMatch(txtModName.Text))
            {
                SetValid(sender, lblModName, true);
                UpdateOutputDir();
                return;
            }
            else
            {
                e.Cancel = true;
                SetValid(sender, lblModName, false);
            }
        }

        private void cmdSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderFinder = new FolderBrowserDialog();
            folderFinder.RootFolder = Environment.SpecialFolder.ApplicationData;
            folderFinder.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"SpaceEngineers","Mods");
            folderFinder.Description = "Select the mod's folder.";
            folderFinder.ShowNewFolderButton = false;
            if (folderFinder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtSourceURL.Text = opts.Path = folderFinder.SelectedPath;
                ValidateChildren(ValidationConstraints.Enabled);
            }
        }

        private void cmdSourceBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileFinder = new OpenFileDialog();
            fileFinder.CheckFileExists = true;
            fileFinder.AutoUpgradeEnabled = true;
            fileFinder.Filter = "SBM Files (*.sbm)|*.sbm";
            fileFinder.Multiselect = false;
            fileFinder.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SpaceEngineers", "Mods");
            if (fileFinder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtSourceURL.Text = opts.Path = fileFinder.FileName;
                ValidateChildren(ValidationConstraints.Enabled);
            }
        }

        private void chkCYA1_CheckedChanged(object sender, EventArgs e)
        {
            ValidateEverything();
        }

        private void chkCYA2_CheckedChanged(object sender, EventArgs e)
        {
            ValidateEverything();
        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.Arguments = opts.ToString();
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.ErrorDialog = true;
            proc.StartInfo.FileName = "EnvFiddle.exe";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
            proc.WaitForExit();
        }

        private void chkDarkShadows_CheckedChanged(object sender, EventArgs e)
        {
            opts.DarkShadows = chkDarkShadows.Checked;
        }
    }
}
