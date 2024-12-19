using System;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Text;

namespace SVMS.Forms
{
    public partial class PasswordRecoveryForm : DropShadow
    {
        private string DbConn;
        
        private string recoveryEmail;
        public PasswordRecoveryForm()
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            txtRecoveryEmail.SetReadOnly(true);
            txtSenderEmail.SetReadOnly(true);
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private void PasswordRecoveryForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT [Email] FROM tblUser WHERE [User ID] = 1", conn))
                {
                    recoveryEmail = cmd.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(recoveryEmail))
                    {
                        txtRecoveryEmail.Texts = recoveryEmail;
                        txtSenderEmail.Texts = recoveryEmail;
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string senderEmail = txtSenderEmail.Texts;
            string senderPassword = txtSenderPassword.Texts;
            string username = txtUsername.Texts;

            if (string.IsNullOrEmpty(username))
            {
                CustomMessageBox.Show("Please enter a valid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate if the username exists in the database
            if (!DoesUsernameExist(username))
            {
                CustomMessageBox.Show("Username not found. Please check the entered username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tempPassword = GenerateTemporaryPassword();
            string hashedTempPassword = HashPassword(tempPassword);

            UpdatePasswordInDatabase(username, hashedTempPassword);

            SendRecoveryEmail(recoveryEmail, username, tempPassword, senderEmail, senderPassword);
        }

        private bool DoesUsernameExist(string username)
        {
            bool exists = false;

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM tblUser WHERE [Username] = ?", conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                    exists = userCount > 0;
                }
            }

            return exists;
        }

        private string GenerateTemporaryPassword()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }

        private void UpdatePasswordInDatabase(string username, string hashedTempPassword)
        {
            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                string query = "UPDATE tblUser SET [Password] = ? WHERE [Username] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", hashedTempPassword);
                    cmd.Parameters.AddWithValue("?", username);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SendRecoveryEmail(string recipientEmail, string username, string tempPassword, string senderEmail, string senderEmailPassword)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderEmailPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(senderEmail);
                    mailMessage.To.Add(recipientEmail);
                    mailMessage.Subject = "Password Recovery";
                    mailMessage.Body = $"Your username is: {username}\nYour temporary password is: {tempPassword}"; // Sending temporary password

                    smtpClient.Send(mailMessage);
                }

                CustomMessageBox.Show($"The email has been successfully sent to {recoveryEmail}!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error sending email: {ex.Message}", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkShowHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtSenderPassword.PasswordChar = !chkShowHidePassword.Checked;
        }
    }
}
