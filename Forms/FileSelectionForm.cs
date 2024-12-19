using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class FileSelectionForm : DropShadow
    {
        public enum DriveType { Local, gDrive }
        public string SelectedFile { get; private set; }

        private DriveType driveType;
        public FileSelectionForm(List<string> backupFiles, DriveType driveType)
        {
            InitializeComponent();
            this.driveType = driveType;
            listBoxFiles.DataSource = backupFiles;

            lblOperationType.Text = driveType == DriveType.Local
            ? "Select backup file from Local Drive:"
            : "Select backup file from Google Drive:";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem != null)
            {
                SelectedFile = listBoxFiles.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                CustomMessageBox.Show("Please choose a backup file to restore data from.", "Select Backup File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
