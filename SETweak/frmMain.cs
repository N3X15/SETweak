using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SETweaks.Steam;
using SETweaks.Steam.DataBindings;
using System.Text.RegularExpressions;

namespace SETweak
{
    public partial class frmMain : Form
    {
        string validAIDChars = "0123456789";
        private PublishedFileDetails details;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        private void LoadDetails(ulong ID) {
            details = WorkshopAPI.GetFileInfo(ID);
        }
        private void SetFieldValidity(Label lbl, Control ctl, bool validity)
        {
            lbl.ForeColor = validity ? Color.Black : Color.Red;
            ctl.BackColor = validity ? Color.White : Color.Salmon;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

    }
}
