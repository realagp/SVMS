using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class AddUserForm : DropShadow
    {
        private string DbConn;
        public enum OperationType { Add, Update }

        private OperationType operationType;

        public string Role { get; private set; }
        public string accountName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        bool IsUpdate;
        public AddUserForm(OperationType operationType, bool isUpdate, string role = "", string account = "", string username = "", string password = "")
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();

            this.operationType = operationType;
            IsUpdate = isUpdate;
            Role = role;
            accountName = account;
            Username = username;
            Password = password;

            if (operationType == OperationType.Add)
            {
                lblUser.Text = "ADD AUTHORIZED USER";
            }
            else if (operationType == OperationType.Update)
            {
                lblUser.Text = "UPDATE AUTHORIZED USER";
            }

            if (IsUpdate)
            {
                tbMakeSubAdmin.Checked = Role == "Sub-Admin";
                txtName.Texts = accountName;
                txtUsername.Texts = Username;
                txtPassword.Clear();
            } else
            {
                txtName.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                tbMakeSubAdmin.Checked = false;
            }
        }

        private void tbMakeAdmin_CheckedChanged(object sender, EventArgs e)
        {
            Role = tbMakeSubAdmin.Checked ? "Sub-Admin" : "Authorized User";
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private bool IsDuplicate(string name, string username, string password = null)
        {
            using (var connection = new OleDbConnection(DbConn))
            {
                string query = password == null
                    ? "SELECT COUNT(*) FROM tblUser WHERE [Name] = ? OR [Username] = ?"
                    : "SELECT COUNT(*) FROM tblUser WHERE [Name] = ? AND [Username] = ? AND [Password] = ?";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);

                    if (password != null) // Add password only for update
                    {
                        command.Parameters.AddWithValue("@Password", password);
                    }

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void chkShowHideAdminPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = !chkShowHidePassword.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string newRole = tbMakeSubAdmin.Checked ? "Sub-Admin" : "Authorized User";
            bool roleChanged = newRole != Role;

            if (!IsUpdate)
            {
                if (txtName.IsEmpty() || txtUsername.IsEmpty() || txtPassword.IsEmpty())
                {
                    CustomMessageBox.Show("All fields are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            } else
            {
                if (txtName.IsEmpty() || txtUsername.IsEmpty())
                {
                    CustomMessageBox.Show("All fields are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtPassword.IsEmpty())
                {
                    CustomMessageBox.Show("Please provide your current password if you do not wish to change it, or enter a new password to update.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Role = newRole;
            accountName = txtName.TrimText();
            Username = txtUsername.TrimText();
            Password = txtPassword.TrimText();

            string hashedPassword = PasswordHelper.HashPassword(Password);

            if (!IsUpdate)
            {
                if (IsDuplicate(accountName, Username))
                {
                    CustomMessageBox.Show("Name or username already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Password = hashedPassword;
                CustomMessageBox.Show($"{newRole} account successfully added!", "Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (IsDuplicate(accountName, Username, hashedPassword) && !roleChanged)
                {
                    CustomMessageBox.Show("No changes applied.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Password = hashedPassword;
                CustomMessageBox.Show($"Authorized user account successfully updated!", "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
