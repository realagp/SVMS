using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using SVMS.Controls;
using Ionic.Zip;

namespace SVMS.Forms
{
    public partial class UpdateAccounts : DropShadow
    {
        private string DbConn;
        private string userRole;
        private string userName;
        private int userId = 1;

        private string storedPasswordHash;
        private string storedRecoveryEmail;
        private readonly DashboardControl dashboard;
        string sourcePath = Properties.Settings.Default.DatabasePath;

        // Flag to track if the password change notification has been shown
        //private bool isPasswordChangedNotificationShown = false;

        public UpdateAccounts(DashboardControl dbControl, string role, string username)
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            dashboard = dbControl;
            userRole = role;
            userName = username;
        }

        protected void NotifyDataChanged()
        {
            dashboard?.RefreshData();
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private void UpdateAccounts_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            LoadUserData();
        }

        private void LoadUserData()
        {
            string query = "SELECT [Name], [Username], [Password], [Email] FROM tblUser WHERE [User ID] = @userId";
            using (OleDbCommand cmd = new OleDbCommand(query, new OleDbConnection(DbConn)))
            {
                cmd.Parameters.AddWithValue("@userId", userId);

                cmd.Connection.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtName.Texts = reader["Name"].ToString();
                        txtUsername.Texts = reader["Username"].ToString();
                        storedPasswordHash = reader["Password"].ToString();
                        storedRecoveryEmail = reader["Email"].ToString();
                        txtEmail.Texts = storedRecoveryEmail;
                    }
                }
            }
        }

        private void chkShowHideAdminPass_CheckedChanged(object sender, EventArgs e)
        {
            txtOldPassword.PasswordChar = !chkShowHideAdminPass.Checked;
            txtNewPassword.PasswordChar = !chkShowHideAdminPass.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(DbConn))
            {
                try
                {
                    connection.Open();

                    string storedName = null;
                    string storedUsername = null;
                    string storedPasswordHash = null;
                    string storedRecoveryEmail = null;

                    string getUserQuery = "SELECT [Name], [Username], [Password], [Email] FROM tblUser WHERE [User ID] = @userId";
                    using (OleDbCommand getUserCmd = new OleDbCommand(getUserQuery, connection))
                    {
                        getUserCmd.Parameters.AddWithValue("@userId", userId);
                        using (OleDbDataReader reader = getUserCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                storedName = reader["Name"].ToString();
                                storedUsername = reader["Username"].ToString();
                                storedPasswordHash = reader["Password"].ToString();
                                storedRecoveryEmail = reader["Email"].ToString();
                            }
                        }
                    }

                    bool isPasswordChange = !txtNewPassword.IsEmpty();
                    bool hasChanges = false;
                    bool passwordChanged = false;

                    string newRecoveryEmail = txtEmail.Texts; // Assuming you have a TextBox for recovery email
                    if (newRecoveryEmail != storedRecoveryEmail)
                    {
                        // Require current password for email change
                        if (txtOldPassword.IsEmpty())
                        {
                            CustomMessageBox.Show("Current password is required to change the recovery email.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        string oldPasswordHash = PasswordHelper.HashPassword(txtOldPassword.Texts);
                        
                        if (oldPasswordHash != storedPasswordHash)
                        {
                            CustomMessageBox.Show("The current password you entered is incorrect. Please check and try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        if (string.IsNullOrEmpty(newRecoveryEmail) || !newRecoveryEmail.EndsWith("@gmail.com"))
                        {
                            CustomMessageBox.Show("Email must be a valid Gmail address ending in '@gmail.com'.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        hasChanges = true;
                    }

                    if (txtName.Texts != storedName || txtUsername.Texts != storedUsername)
                    {
                        hasChanges = true;
                    }

                    if (isPasswordChange)
                    {
                        string oldPasswordHash = PasswordHelper.HashPassword(txtOldPassword.Texts);
                        if (oldPasswordHash != storedPasswordHash)
                        {
                            if (txtOldPassword.IsEmpty())
                            {
                                CustomMessageBox.Show("Please enter your current password to set a new password.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            CustomMessageBox.Show("The current password you entered is incorrect. Please check and try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        passwordChanged = true;
                    }

                    if (!hasChanges && !passwordChanged)
                    {
                        CustomMessageBox.Show("No changes applied.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string updateQuery = "UPDATE tblUser SET [Name] = @name, [Username] = @username" +
                                         (isPasswordChange ? ", [Password] = @password" : "") +
                                         (newRecoveryEmail != storedRecoveryEmail ? ", [Email] = @recoveryEmail" : "") +
                                         " WHERE [User ID] = @userId";

                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@name", txtName.Texts);
                        updateCmd.Parameters.AddWithValue("@username", txtUsername.Texts);
                        if (isPasswordChange)
                        {
                            updateCmd.Parameters.AddWithValue("@password", PasswordHelper.HashPassword(txtNewPassword.Texts));
                        }
                        if (newRecoveryEmail != storedRecoveryEmail)
                        {
                            updateCmd.Parameters.AddWithValue("@recoveryEmail", newRecoveryEmail);
                        }
                        updateCmd.Parameters.AddWithValue("@userId", userId);

                        updateCmd.ExecuteNonQuery();
                    }

                    CustomMessageBox.Show("Account details have been successfully updated!", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (hasChanges && passwordChanged)
                    {
                        LogActivity("Change", "Administrator account details and password have been updated.", userName);
                        CustomMessageBox.Show("Your password has been changed. Please create a new backup of the database to ensure the encryption password is updated.", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotifyDataChanged();
                        backupDatabase(sender, e);
                    }
                    else if (passwordChanged)
                    {
                        // Log activity and handle specific actions based on the password change
                        LogActivity("Change", "The administrator's account password has been changed.", userName);
                        CustomMessageBox.Show("Your password has been changed. Please create a new backup of the database to ensure the encryption password is updated.", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotifyDataChanged();
                        backupDatabase(sender, e);
                    }
                    else
                    {
                        LogActivity("Update", "Administrator account details have been updated.", userName);
                        NotifyDataChanged();
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"An error occurred: {ex.Message}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }

            var mainForm = (Form1)Application.OpenForms["Form1"];
            mainForm.RefreshUserData();
            mainForm.disabledBtn();
            this.Close();
        }

        private void backupDatabase(object sender, EventArgs e)
        {
            DialogResult localResult = CustomMessageBox.Show(
                "Start a backup of the current database to Local Drive.",
                "Start Backup Process",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            if (localResult == DialogResult.OK)
            {
                BackupToLocalDrive();

                DialogResult gDriveResult = CustomMessageBox.Show(
                    "Start a backup of the current database to Google Drive.",
                    "Start Backup Process",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                if (gDriveResult == DialogResult.OK)
                {
                    BackupToGoogleDrive();
                }
            }
        }

        private void BackupToLocalDrive()
        {
            string localBackupPath = Properties.Settings.Default.LocalBackupDirectory;

            if (string.IsNullOrEmpty(localBackupPath))
            {
                CustomMessageBox.Show("Local backup directory is not set.", "Backup Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prepare file names for backup
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            string encryptedBackupFileName = $"StudentViolationDB_{timestamp}.svmsdb"; // Encrypted file
            string originalDatabaseFileName = $"StudentViolationDB.accdb"; // Original database file
            string encryptedBackupPath = Path.Combine(localBackupPath, encryptedBackupFileName);
            string originalDatabasePath = Properties.Settings.Default.DatabasePath; // Source of the original database

            using (var passwordForm = new PromptPassword(PromptPassword.OperationType.Backup))
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    string password = passwordForm.Password;

                    try
                    {
                        // Step 1: Create an encrypted backup of the original database file
                        FileEncryption.EncryptFile(originalDatabasePath, encryptedBackupPath, password);
                        CustomMessageBox.Show("Encrypted database backup to Local Drive completed successfully!", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Step 2: Create a password-protected ZIP file containing the original database file
                        string zipFileName = $"StudentViolationDB_{timestamp}.zip"; // ZIP file name
                        string zipFilePath = Path.Combine(localBackupPath, zipFileName);

                        // Create password-protected ZIP file using DotNetZip
                        using (var zip = new ZipFile())
                        {
                            zip.Password = password; // Set the password for the ZIP
                            zip.AddFile(originalDatabasePath, ""); // Add the original database file to the ZIP
                            zip.Save(zipFilePath); // Save the ZIP file
                        }

                        // Notify user of successful backup
                        CustomMessageBox.Show("Password-protected ZIP backup to Local Drive completed successfully!", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimitBackups(localBackupPath); // Optional: Limit the number of backups stored

                        LogActivity("Backup", $"Database backup completed to Local Drive _{encryptedBackupFileName}.", userName);
                        LogActivity("Backup", $"Database backup completed to Local Drive _{zipFileName}.", userName);

                        NotifyDataChanged();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"Local backup failed: {ex.Message}", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BackupToGoogleDrive()
        {
            string googleDriveBackupPath = Properties.Settings.Default.GoogleDriveBackupDirectory;

            if (string.IsNullOrEmpty(googleDriveBackupPath))
            {
                CustomMessageBox.Show("Google Drive backup directory is not set.", "Backup Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Backup file names
            string encryptedBackupFileName = $"StudentViolationDB_{DateTime.Now:yyyyMMdd_HHmmss}.svmsdb";
            string encryptedBackupPath = Path.Combine(googleDriveBackupPath, encryptedBackupFileName);

            string zipBackupFileName = $"StudentViolationDB_{DateTime.Now:yyyyMMdd_HHmmss}.zip";
            string zipBackupPath = Path.Combine(googleDriveBackupPath, zipBackupFileName);

            using (var passwordForm = new PromptPassword(PromptPassword.OperationType.Backup))
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    string password = passwordForm.Password;

                    try
                    {
                        // Step 1: Encrypt the database and save as .svmsdb
                        FileEncryption.EncryptFile(sourcePath, encryptedBackupPath, password);
                        CustomMessageBox.Show("Encrypted database backup to Google Drive completed successfully!", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Step 2: Create a password-protected ZIP file of the original database
                        using (var zip = new ZipFile())
                        {
                            zip.Password = password; // Set the password for the ZIP file
                            zip.AddFile(sourcePath, ""); // Add the original database file to the ZIP
                            zip.Save(zipBackupPath); // Save the ZIP file
                        }
                        CustomMessageBox.Show("Password-protected ZIP backup to Google Drive completed successfully!", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Step 3: Limit the number of backups
                        LimitBackups(googleDriveBackupPath);

                        // Log the activity and notify any data change if necessary
                        LogActivity("Backup", $"Database backup completed to Google Drive _{encryptedBackupFileName}.", userName);
                        LogActivity("Backup", $"Database backup completed to Google Drive _{zipBackupFileName}.", userName);

                        NotifyDataChanged();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"Google Drive backup failed: {ex.Message}", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimitBackups(string backupDirectory)
        {
            // Limit backups for encrypted .svmsdb files
            LimitBackupFiles(backupDirectory, "StudentViolationDB_*.svmsdb");

            // Limit backups for password-protected .zip files
            LimitBackupFiles(backupDirectory, "StudentViolationDB_*.zip");
        }

        private void LimitBackupFiles(string backupDirectory, string searchPattern)
        {
            var backupFiles = Directory.GetFiles(backupDirectory, searchPattern);

            if (backupFiles.Length > 1)
            {
                // Order files by creation time, oldest first
                var filesToDelete = backupFiles.OrderBy(f => File.GetCreationTime(f)).ToList();

                // Keep the most recent file and delete the rest
                for (int i = 0; i < filesToDelete.Count - 1; i++)
                {
                    try
                    {
                        File.Delete(filesToDelete[i]);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"Failed to delete backup file {filesToDelete[i]}: {ex.Message}", "Backup Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var mainForm = (Form1)Application.OpenForms["Form1"];
            mainForm.disabledBtn();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void LogActivity(string action, string description, string username)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    string query = @"
                        INSERT INTO tblActivityLog ([Date/Time], [Action], [Description], [Username]) 
                        VALUES (?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.Add("@Date", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Description", description);

                        cmd.Parameters.AddWithValue("@Username", username);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error logging activity: " + ex.Message);
            }
        }
    }
}
