using System;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class DirectoryForm : DropShadow
    {
        public enum DriveType { Local, GoogleDrive }
        public enum OperationType { Backup, Restore, Select }

        public DriveType SelectedBackup { get; private set; }
        private OperationType operationType;
        public DirectoryForm(OperationType operationType)
        {
            InitializeComponent();
            this.operationType = operationType;

            if (operationType == OperationType.Backup)
            {
                lblBackupRestore.Text = "Select a location to save the backup file:";
            } else if (operationType == OperationType.Restore)
            {
                lblBackupRestore.Text = "Select a location to restore the backup file from:";
            } else
            {
                lblBackupRestore.Text = "Select a location to set a new directory for storing backups:";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rbLocalDrive.Checked)
            {
                SelectedBackup = DriveType.Local;
            }
            else if (rbGoogleDrive.Checked)
            {
                SelectedBackup = DriveType.GoogleDrive;
            }
            else
            {
                MessageBox.Show("Please select a backup location.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
