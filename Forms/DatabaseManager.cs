using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using SVMS.Controls;
using System.Data;
using System.Data.OleDb;
using Ionic.Zip;

namespace SVMS.Forms
{
    public partial class DatabaseManager : DropShadow
    {
        private string DbConn;
        private string userRole;
        private string userName;

        string googleDriveBackupPath = Properties.Settings.Default.GoogleDriveBackupDirectory;
        string localBackupPath = Properties.Settings.Default.LocalBackupDirectory;
        string sourcePath = Properties.Settings.Default.DatabasePath;

        private StdEntryControl stdEntryControl;
        private readonly DashboardControl dashboard;

        public DatabaseManager(StdEntryControl control, DashboardControl dbControl, string role, string username)
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            stdEntryControl = control;
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

        public void SelectBackupDirectory(string backupType)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = $"Select a {backupType} backup directory";
                folderDialog.ShowNewFolderButton = true;

                // Show the dialog and check the result
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;

                    // Save the selected path to user settings based on the backup type
                    if (backupType == "Local")
                    {
                        Properties.Settings.Default.LocalBackupDirectory = selectedPath;
                        CustomMessageBox.Show($"The Local Drive backup directory has been updated successfully. Future backups will be saved to this location {selectedPath}", "Backup Directory Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LogActivity("Update", "Local Drive backup directory successfully updated.", userName);
                        NotifyDataChanged();
                    }
                    else if (backupType == "Google Drive")
                    {
                        Properties.Settings.Default.GoogleDriveBackupDirectory = selectedPath;
                        CustomMessageBox.Show($"The Google Drive backup directory has been updated successfully. Future backups will be saved to this location {selectedPath}", "Backup Directory Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LogActivity("Update", "Google Drive backup directory successfully updated.", userName);
                        NotifyDataChanged();
                    }

                    Properties.Settings.Default.Save();
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

                        LogActivity("Backup", $"Database backup completed to Local Drive  _{encryptedBackupFileName}.", userName);
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

        private void RestoreFromLocalBackup()
        {
            string localBackupPath = Properties.Settings.Default.LocalBackupDirectory;
            string restorePath = sourcePath;

            if (string.IsNullOrEmpty(localBackupPath))
            {
                CustomMessageBox.Show("Local backup directory is not set. Please select one.", "Restore Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var backupFiles = Directory.GetFiles(localBackupPath, "StudentViolationDB_*.svmsdb")
                                       .OrderByDescending(f => File.GetCreationTime(f))
                                       .ToList();

            if (backupFiles.Count == 0)
            {
                CustomMessageBox.Show("No local backup files found.", "Backup File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var fileSelectionForm = new FileSelectionForm(backupFiles, FileSelectionForm.DriveType.Local))
            {
                if (fileSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    DialogResult confirm = CustomMessageBox.Show(
                        "Restoring this backup will overwrite current data. Do you want to proceed?",
                        "Confirm Restore Overwrite",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.OK)
                    {
                        string selectedFile = fileSelectionForm.SelectedFile;

                        // Make a temporary backup of the current database
                        string tempBackupPath = restorePath + ".bak";
                        try
                        {
                            File.Copy(restorePath, tempBackupPath, true);
                        }
                        catch (Exception ex)
                        {
                            CustomMessageBox.Show($"Failed to create a backup of the current database: {ex.Message}", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (var passwordForm = new PromptPassword(PromptPassword.OperationType.Restore))
                        {
                            if (passwordForm.ShowDialog() == DialogResult.OK)
                            {
                                string password = passwordForm.Password;

                                try
                                {
                                    // Decrypt the selected backup file to the restore path
                                    FileEncryption.DecryptFile(selectedFile, restorePath, password);

                                    CustomMessageBox.Show("Database restored from Local Backup successfully!", "Restore Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DialogResult restartResult = CustomMessageBox.Show(
                                        "The application needs to restart to apply the restored database.",
                                        "Restart Required",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);

                                    if (restartResult == DialogResult.OK)
                                    {
                                        LogActivity("Restore", "Database restoration completed from Local Drive backup.", userName);
                                        NotifyDataChanged();

                                        Application.Restart();
                                    }
                                }
                                catch
                                {
                                    File.Copy(tempBackupPath, restorePath, true);
                                    CustomMessageBox.Show("Restore failed: Invalid password or corrupted backup file. Original database restored.", "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    if (File.Exists(tempBackupPath))
                                    {
                                        File.Delete(tempBackupPath);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RestoreFromGoogleDrive()
        {
            string googleDriveBackupPath = Properties.Settings.Default.GoogleDriveBackupDirectory;
            string restorePath = sourcePath;

            if (string.IsNullOrEmpty(googleDriveBackupPath))
            {
                CustomMessageBox.Show("Google Drive backup directory is not set. Please select one.", "Restore Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Look for encrypted backup files
            var backupFiles = Directory.GetFiles(googleDriveBackupPath, "StudentViolationDB_*.svmsdb")
                                       .OrderByDescending(f => File.GetCreationTime(f))
                                       .ToList();

            if (backupFiles.Count == 0)
            {
                CustomMessageBox.Show("No Google Drive backup files found.", "Backup File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var fileSelectionForm = new FileSelectionForm(backupFiles, FileSelectionForm.DriveType.gDrive))
            {
                if (fileSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    DialogResult confirm = CustomMessageBox.Show(
                        "Restoring this backup will overwrite current data. Do you want to proceed?",
                        "Confirm Restore Overwrite",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.OK)
                    {
                        string selectedFile = fileSelectionForm.SelectedFile;

                        // Create a temporary backup of the current database
                        string tempBackupPath = Path.Combine(Path.GetDirectoryName(restorePath), "temp_backup.svmsdb");
                        File.Copy(restorePath, tempBackupPath, true);

                        using (var passwordForm = new PromptPassword(PromptPassword.OperationType.Restore))
                        {
                            if (passwordForm.ShowDialog() == DialogResult.OK)
                            {
                                string password = passwordForm.Password;

                                try
                                {
                                    // Decrypt the selected backup file to the restore path
                                    FileEncryption.DecryptFile(selectedFile, restorePath, password);

                                    CustomMessageBox.Show("Database restored from Google Drive Backup successfully!", "Restore Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DialogResult restartResult = CustomMessageBox.Show(
                                        "The application needs to restart to apply the restored database.",
                                        "Restart Required",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);

                                    if (restartResult == DialogResult.OK)
                                    {
                                        LogActivity("Restore", "Database restoration completed from Google Drive backup.", userName);
                                        NotifyDataChanged();

                                        Application.Restart();
                                    }
                                }
                                catch
                                {
                                    // Restore the original database from the temp backup if decryption fails
                                    File.Copy(tempBackupPath, restorePath, true);
                                    CustomMessageBox.Show("Restore failed: Invalid password or corrupted backup file. Original database restored.", "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    // Delete the temporary backup file after the restore attempt
                                    if (File.Exists(tempBackupPath))
                                    {
                                        File.Delete(tempBackupPath);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ExportDataTableToCSV(DataTable dataTable, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            var headers = dataTable.Columns.Cast<DataColumn>();
            csvContent.AppendLine(string.Join(",", headers.Select(header => "\"" + header.ColumnName + "\"")));

            foreach (DataRow row in dataTable.Rows)
            {
                var cells = row.ItemArray.Select(cell => "\"" + cell.ToString() + "\"");
                csvContent.AppendLine(string.Join(",", cells));
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show($"Current database file path: {sourcePath}",
        "Info",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

            DialogResult change = CustomMessageBox.Show(
                "Would you like to change the database file path? This may affect data accessibility.",
                "Change Database File Path",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (change == DialogResult.Yes)
            {
                DialogResult result = CustomMessageBox.Show(
                    "Changing the database file path will disconnect from the current database. Do you want to proceed?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        string currentDatabasePath = Properties.Settings.Default.DatabasePath;

                        if (!string.IsNullOrEmpty(currentDatabasePath))
                        {
                            string directoryPath = Path.GetDirectoryName(currentDatabasePath);
                            if (Directory.Exists(directoryPath))
                            {
                                openFileDialog.InitialDirectory = directoryPath;
                            }
                        }

                        openFileDialog.Filter = "Access Database (*.accdb)|*.accdb";
                        openFileDialog.Title = "Select a Database File";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string newPath = openFileDialog.FileName;

                            Properties.Settings.Default.DatabasePath = newPath;
                            Properties.Settings.Default.Save();

                            CustomMessageBox.Show($"Database path updated to: {newPath}");

                            LogActivity("Update", $"Database path successfully updated.", userName);
                            NotifyDataChanged();

                            DialogResult restartResult = CustomMessageBox.Show(
                                "The database path has been changed. Please restart the application for the changes to take effect.",
                                "Restart Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                            if (restartResult == DialogResult.OK)
                            {
                                Application.Restart();
                            }
                        }
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show($"Local Drive backup directory: {Properties.Settings.Default.LocalBackupDirectory} \nGoogle Drive backup directory: {Properties.Settings.Default.GoogleDriveBackupDirectory} ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult localResult = CustomMessageBox.Show(
                "Would you like to set a new directory for storing backups?",
                "Set Backup Directory",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                using (DirectoryForm directoryForm = new DirectoryForm(DirectoryForm.OperationType.Select))
                {
                    if (directoryForm.ShowDialog() == DialogResult.OK)
                    {
                        if (directoryForm.SelectedBackup == DirectoryForm.DriveType.Local)
                        {
                            SelectBackupDirectory("Local");
                        }
                        else if (directoryForm.SelectedBackup == DirectoryForm.DriveType.GoogleDrive)
                        {
                            SelectBackupDirectory("Google Drive");
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            DialogResult localResult = CustomMessageBox.Show(
                "Do you want to start a backup process?",
                "Start Backup Process",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                using (DirectoryForm directoryForm = new DirectoryForm(DirectoryForm.OperationType.Backup))
                {
                    if (directoryForm.ShowDialog() == DialogResult.OK)
                    {
                        if (directoryForm.SelectedBackup == DirectoryForm.DriveType.Local)
                        {
                            BackupToLocalDrive();
                        }
                        else if (directoryForm.SelectedBackup == DirectoryForm.DriveType.GoogleDrive)
                        {
                            BackupToGoogleDrive();
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DialogResult localResult = CustomMessageBox.Show(
                "Do you want to restore data from backup file? Current data will be replaced.",
                "Start Data Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                using (DirectoryForm directoryForm = new DirectoryForm(DirectoryForm.OperationType.Restore))
                {
                    if (directoryForm.ShowDialog() == DialogResult.OK)
                    {
                        if (directoryForm.SelectedBackup == DirectoryForm.DriveType.Local)
                        {
                            RestoreFromLocalBackup();
                        }
                        else if (directoryForm.SelectedBackup == DirectoryForm.DriveType.GoogleDrive)
                        {
                            RestoreFromGoogleDrive();
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            DialogResult import = CustomMessageBox.Show(
                "Please select a CSV file to import students' information.",
                "Import CSV File",
                MessageBoxButtons.OKCancel);

            if (import == DialogResult.OK)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    openFileDialog.Title = "Select CSV File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string csvFilePath = openFileDialog.FileName;
                        string accessDbPath = sourcePath;

                        CsvToAccessImporter importer = new CsvToAccessImporter(dashboard, userName);
                        importer.ImportCsvToAccess(csvFilePath);
                    }
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            // Ask if the user wants to restore from Local Backup
            DialogResult export = CustomMessageBox.Show(
                "Are you sure want to export the current students' information to a CSV file? This action will create a new file.",
                "Export Data to CSV",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (export == DialogResult.Yes)
            {
                DialogResult choose = CustomMessageBox.Show(
                "Please choose a location to save the exported student data file.",
                "Export Student Data",
                MessageBoxButtons.OKCancel);

                if (choose == DialogResult.OK)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        saveFileDialog.Title = "Save as CSV";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (stdEntryControl != null && stdEntryControl.StudentsDataSource != null)
                            {
                                ExportDataTableToCSV(stdEntryControl.StudentsDataSource, saveFileDialog.FileName);
                                CustomMessageBox.Show("The students' information has been exported successfully. You can find the file in the selected location.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LogActivity("Export", $"The students' information has been successfully exported.", userName);
                                NotifyDataChanged();
                            }
                            else
                            {
                                CustomMessageBox.Show("No data to export.", "Export Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            var mainForm = (Form1)Application.OpenForms["Form1"];
            mainForm.disabledBtn();
            DialogResult = DialogResult.Cancel;
            Close();
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
                        // Add parameters with their respective values
                        cmd.Parameters.Add("@Date", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Username", username);

                        // Open the connection and execute the query
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
