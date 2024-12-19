using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using SVMS.Forms;
using System.IO;
using System.Reflection;

namespace SVMS
{
    public partial class LoginUI : DropShadow
    {
        private string DbConn;
        string sourcePath;
        public LoginUI()
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            transBackground.BackColor = Color.FromArgb(100, 0, 0, 0);

            txtUsername.KeyDown += TextBox_KeyDown;
            txtPassword.KeyDown += TextBox_KeyDown;
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            sourcePath = Properties.Settings.Default.DatabasePath;

            if (string.IsNullOrEmpty(sourcePath) ||
                !File.Exists(sourcePath))
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "StudentViolationDB.accdb");

                if (!File.Exists(tempFilePath))
                {
                    CustomMessageBox.Show("Extracting embedded database file.", "Database Initialization");
                    // Extract the PDF from resources
                    using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SVMS.StudentViolationDB.accdb"))
                    using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                    {
                        resourceStream.CopyTo(fileStream);
                    }

                    Properties.Settings.Default.DatabasePath = tempFilePath;
                    Properties.Settings.Default.Save();

                    CustomMessageBox.Show("Setting up database file path for initial use.", "Database Initialization");
                    SetupDatabase();
                }
            }
            else
            {
                return;
            }
        }

        private void SetupDatabase()
        {
            string dbDirectory = @"C:\SVMS\Utilities\Database";
            string tempDbPath = Path.Combine(Path.GetTempPath(), "StudentViolationDB.accdb");
            string newDbPath = Path.Combine(dbDirectory, "StudentViolationDB.accdb");

            // Ensure the database directory exists
            CreateDatabaseDirectory(dbDirectory);

            // Try copying the database from Temp to the new directory
            if (!CopyDatabase(tempDbPath, newDbPath))
            {
                // If copying fails, open the OpenFileDialog for manual selection
                OpenDatabaseFileDialog();
            }
        }

        private void CreateDatabaseDirectory(string dbDirectory)
        {
            try
            {
                Directory.CreateDirectory(dbDirectory);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Failed to create directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CopyDatabase(string tempDbPath, string newDbPath)
        {
            try
            {
                // Check if the temporary database file exists
                if (File.Exists(tempDbPath))
                {
                    // Copy the database file to the new directory
                    File.Copy(tempDbPath, newDbPath, true); // Overwrite if the file exists

                    // Update the database path in the application settings
                    Properties.Settings.Default.DatabasePath = newDbPath;
                    Properties.Settings.Default.Save();
                    CustomMessageBox.Show($"Database File Location: {newDbPath}", "Database Path Set");

                    // Notify the user to restart the application
                    if (ShowRestartMessage())
                    {
                        Application.Restart();
                    }

                    return true; // Indicate success
                }
                else
                {
                    CustomMessageBox.Show("Temporary database file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Failed to copy database file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void OpenDatabaseFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Access Database (*.accdb)|*.accdb";
                openFileDialog.InitialDirectory = Path.GetTempPath(); // Default to Temp path
                openFileDialog.Title = "Select an Access Database File";
                openFileDialog.CheckFileExists = true; // Ensures the file must exist

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedDbPath = openFileDialog.FileName; // Get the selected file path

                    // Ensure the selected file is an Access database
                    if (Path.GetExtension(selectedDbPath).Equals(".accdb", StringComparison.OrdinalIgnoreCase))
                    {
                        Properties.Settings.Default.DatabasePath = selectedDbPath;
                        Properties.Settings.Default.Save();
                        CustomMessageBox.Show($"Database path updated to: {selectedDbPath}");

                        if (ShowRestartMessage())
                        {
                            Application.Restart();
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show("Please select a valid Access database file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private bool ShowRestartMessage()
        {
            return CustomMessageBox.Show(
                "Database path configured! Please relaunch the application to load the new settings.",
                "Restart Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation) == DialogResult.OK;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.TrimText();
            string password = txtPassword.TrimText();

            if (txtUsername.IsEmpty() || txtPassword.IsEmpty())
            {
                CustomMessageBox.Show("Username and password are required.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            using (var connection = new OleDbConnection(DbConn))
            {
                connection.Open();

                string query = "SELECT [User ID], [Username], [Password], [Role] FROM tblUser WHERE [Username] = @username";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedUsername = reader["Username"].ToString();
                    string storedPassword = reader["Password"].ToString();
                    int userId = Convert.ToInt32(reader["User ID"]);
                    string roleName = reader["Role"].ToString(); // Fetch the role

                    if (storedUsername == username && storedPassword == hashedPassword)
                    {
                        LogActivity("Login", $"Successfully logged in.", username);
                        CustomMessageBox.Show($"Welcome, {roleName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        Form1 mainForm = new Form1(roleName, username, userId); // Pass the role to the main form
                        mainForm.Show();

                        mainForm.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        CustomMessageBox.Show("Incorrect password. Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    CustomMessageBox.Show("Username does not exist. Please try again.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                connection.Close();
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            PasswordRecoveryForm recoveryForm = new PasswordRecoveryForm();
            recoveryForm.ShowDialog();
        }

        private void chkShowHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = !chkShowHidePassword.Checked;
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}