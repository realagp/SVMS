using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class PromptPassword : DropShadow
    {
        private string DbConn;

        public enum OperationType { Backup, Restore, Delete }
        public string Password { get; private set; }

        private OperationType operationType;
        public PromptPassword(OperationType operationType)
        {
            InitializeComponent();
            this.operationType = operationType;
            DbConn = GetDbConnectionString();

            if (operationType == OperationType.Backup)
            {
                lblOperationType.Text = "Enter your password to confirm the backup process.";
            }
            else if (operationType == OperationType.Restore)
            {
                lblOperationType.Text = "Enter your password to restoring backup."; 
            }
            else
            {
                lblOperationType.Text = "Enter your password to confirm the deletion.";
            }
        }

        private void PromptPassword_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private void chkShowHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = !chkShowHidePassword.Checked;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPassword.IsEmpty())
            {
                CustomMessageBox.Show("Please enter your password to confirm.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (OleDbConnection connection = new OleDbConnection(DbConn))
            {
                connection.Open();

                string query = "SELECT [Password] FROM tblUser WHERE [User ID] = 1";
                OleDbCommand cmd = new OleDbCommand(query, connection);

                var storedPasswordHash = cmd.ExecuteScalar();

                if (storedPasswordHash == null)
                {
                    CustomMessageBox.Show("Failed to retrieve stored password. Please try again.", "Retrieval Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string enteredPasswordHash = PasswordHelper.HashPassword(txtPassword.TrimText());

                if (enteredPasswordHash.Equals(storedPasswordHash.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    Password = txtPassword.Texts;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    CustomMessageBox.Show("Incorrect password. Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
