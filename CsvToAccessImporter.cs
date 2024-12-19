using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using SVMS.Controls;

namespace SVMS
{
    public class CsvToAccessImporter
    {
        private string userName;
        private readonly DashboardControl dashboard;

        // Constructor that accepts a DashboardControl instance
        public CsvToAccessImporter(DashboardControl dashboardControl, string username)
        {
            dashboard = dashboardControl;
            userName = username;
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        // Notify DashboardControl to refresh data if it's available
        protected void NotifyDataChanged()
        {
            dashboard?.RefreshData();
        }

        public void ImportCsvToAccess(string csvFilePath)
        {
            DialogResult confirm = CustomMessageBox.Show(
        "Are you sure you want to import this CSV file? Existing records may be updated.",
        "Confirm CSV Import",
        MessageBoxButtons.OKCancel,
        MessageBoxIcon.Question);

            if (confirm == DialogResult.OK)
            {
                try
                {
                    string dbConn = GetDbConnectionString();

                    using (OleDbConnection connection = new OleDbConnection(dbConn))
                    {
                        connection.Open();
                        OleDbTransaction transaction = connection.BeginTransaction();
                        int recordsInsertedOrUpdated = 0;

                        // Fetch the active AY-Code
                        string activeAyCodeQuery = "SELECT [AY-Code] FROM tblAcadYear WHERE [Status] = True";
                        string activeAyCode = string.Empty;
                        using (OleDbCommand ayCodeCommand = new OleDbCommand(activeAyCodeQuery, connection, transaction))
                        {
                            using (OleDbDataReader reader = ayCodeCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    activeAyCode = reader["AY-Code"].ToString();
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(activeAyCode))
                        {
                            CustomMessageBox.Show("No active academic year found.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (TextFieldParser parser = new TextFieldParser(csvFilePath))
                        {
                            parser.TextFieldType = FieldType.Delimited;
                            parser.SetDelimiters(",");

                            string[] headers = parser.ReadFields();

                            while (!parser.EndOfData)
                            {
                                string[] values = parser.ReadFields();
                                string studentId = values[0];

                                string checkQuery = "SELECT * FROM tblStudents WHERE [Student ID] = @StudentId";
                                using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection, transaction))
                                {
                                    checkCommand.Parameters.AddWithValue("@StudentId", studentId);

                                    using (OleDbDataReader reader = checkCommand.ExecuteReader())
                                    {
                                        if (!reader.Read())
                                        {
                                            // Insert the student along with the active AY-Code
                                            string insertQuery = $"INSERT INTO tblStudents ([{string.Join("],[", headers)}], [AY-Code]) VALUES (@{string.Join(",@", headers.Select(h => h.Replace(" ", "_")))}, @AyCode)";

                                            using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection, transaction))
                                            {
                                                for (int i = 0; i < headers.Length; i++)
                                                {
                                                    string paramName = $"@{headers[i].Replace(" ", "_")}";
                                                    insertCommand.Parameters.AddWithValue(paramName, values[i]);
                                                }

                                                insertCommand.Parameters.AddWithValue("@AyCode", activeAyCode); // Add AY-Code as a parameter

                                                insertCommand.ExecuteNonQuery();
                                                recordsInsertedOrUpdated++;
                                            }
                                        }
                                        else
                                        {
                                            bool needsUpdate = false;

                                            for (int i = 1; i < headers.Length; i++)
                                            {
                                                string header = headers[i];
                                                string currentValue = reader[header].ToString();
                                                string newValue = values[i];

                                                if (currentValue != newValue)
                                                {
                                                    needsUpdate = true;
                                                    break;
                                                }
                                            }

                                            string currentAyCode = reader["AY-Code"].ToString();
                                            if (currentAyCode != activeAyCode)
                                            {
                                                needsUpdate = true;
                                            }

                                            if (needsUpdate)
                                            {
                                                string updateQuery = $"UPDATE tblStudents SET {string.Join(", ", headers.Skip(1).Select(h => $"[{h}] = @{h.Replace(" ", "_")}"))}, [AY-Code] = @AyCode WHERE [Student ID] = @StudentId";

                                                using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection, transaction))
                                                {
                                                    for (int i = 1; i < headers.Length; i++)
                                                    {
                                                        string paramName = $"@{headers[i].Replace(" ", "_")}";
                                                        updateCommand.Parameters.AddWithValue(paramName, values[i]);
                                                    }

                                                    updateCommand.Parameters.AddWithValue("@AyCode", activeAyCode); // Add AY-Code as parameter
                                                    updateCommand.Parameters.AddWithValue("@StudentId", studentId);

                                                    updateCommand.ExecuteNonQuery();
                                                    recordsInsertedOrUpdated++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (recordsInsertedOrUpdated > 0)
                            {
                                transaction.Commit();
                                CustomMessageBox.Show($"The students' information has been imported successfully. Review the imported data for accuracy.\n\nRecords Inserted or Updated: {recordsInsertedOrUpdated}",
                                    "Import Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                LogActivity("Import", $"The students' data has been successfully imported.", userName);
                                NotifyDataChanged();

                                DialogResult restartResult = CustomMessageBox.Show(
                                    "The application needs to restart to apply the changes.",
                                    "Restart Required",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                                if (restartResult == DialogResult.OK)
                                {
                                    Application.Restart();
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                CustomMessageBox.Show("The import process was canceled. No changes were made to the student information.",
                                    "Import Canceled",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                catch
                {
                    CustomMessageBox.Show($"Please ensure the file is a valid CSV.",
                                "Import Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
        }

        public void LogActivity(string action, string description, string username)
        {
            try
            {
                string dbConn = GetDbConnectionString();

                using (OleDbConnection connection = new OleDbConnection(dbConn))
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
