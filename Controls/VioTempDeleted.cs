﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMS.Controls
{
    public partial class VioTempDeleted : UserControl
    {
        private string DbConn;
        private string userName;

        public event Action OnDataChanged;
        public VioTempDeleted(string username)
        {
            InitializeComponent();
            userName = username;
            DbConn = GetDbConnectionString();
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        protected void NotifyDataChanged()
        {
            OnDataChanged?.Invoke();
        }

        public async void RefreshData()
        {
            await LoadDataFromDatabaseAsync();
        }

        #region -> Proper Casing
        private string ToProperCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());

            result = result.Replace("1St", "1st")
                           .Replace("2Nd", "2nd")
                           .Replace("3Rd", "3rd")
                           .Replace("4Th", "4th")
                           .Replace("5Th", "5th")
                           .Replace("6Th", "6th");
            return result;
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();

            if (phoneNumber.StartsWith("9") && phoneNumber.Length == 10)
            {
                return "0" + phoneNumber;
            }

            return phoneNumber;
        }
        #endregion

        private async Task LoadDataFromDatabaseAsync()
        {
            string query = @"
            SELECT 
                tblViolations.[Violation ID], 
                tblViolations.[AY-Code], 
                tblViolations.[Date], 
                tblViolations.[Student ID], 
                tblStudents.[Last Name], 
                tblStudents.[First Name], 
                tblViolations.[Course], 
                tblViolations.[Violation], 
                tblViolations.[Offense Type], 
                tblViolations.[Sanction]
            FROM 
                (tblViolations 
                INNER JOIN 
                tblStudents
                ON
                tblViolations.[Student ID] = tblStudents.[Student ID])
            WHERE 
                tblViolations.[IsDeleted] = True
                AND tblViolations.[IsArchive] = False";

                    query += " ORDER BY tblViolations.[Date] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    deletedDGV.DataSource = dt;
                }

                FormatDataGridView();

                if (!deletedDGV.Columns.Contains("btnAction"))
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "Manage",
                        Name = "btnAction",
                        UseColumnTextForButtonValue = true
                    };

                    deletedDGV.Columns.Add(btnAction);
                }

                if (deletedDGV.Columns["AY-Code"] != null)
                {
                    deletedDGV.Columns["AY-Code"].Visible = false;
                }

                if (deletedDGV.Columns["Violation ID"] != null)
                {
                    deletedDGV.Columns["Violation ID"].Visible = false;
                }

                deletedDGV.Refresh();
            }
        }

        private async void VioTempDeleted_Load(object sender, EventArgs e)
        {
            deletedDGV.CellPainting += deletedDGV_CellPainting;
            deletedDGV.CellClick += deletedDGV_CellClick;
            await LoadDataFromDatabaseAsync();
        }

        private void FormatDataGridView()
        {
            deletedDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            deletedDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            deletedDGV.EnableHeadersVisualStyles = false;

            deletedDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(106, 106, 106);
            deletedDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            deletedDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(106, 106, 106);
            deletedDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            deletedDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            deletedDGV.DefaultCellStyle.ForeColor = Color.Black;

            deletedDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            deletedDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            deletedDGV.DefaultCellStyle.SelectionBackColor = deletedDGV.DefaultCellStyle.BackColor;
            deletedDGV.DefaultCellStyle.SelectionForeColor = deletedDGV.DefaultCellStyle.ForeColor;

            deletedDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = deletedDGV.AlternatingRowsDefaultCellStyle.BackColor;
            deletedDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = deletedDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            deletedDGV.GridColor = Color.FromArgb(205, 205, 205);

            deletedDGV.ColumnHeadersHeight = 40;
            deletedDGV.RowTemplate.Height = 30;

            deletedDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            deletedDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            deletedDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            deletedDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            deletedDGV.AllowUserToResizeColumns = false;
            deletedDGV.AllowUserToResizeRows = false;
            deletedDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            deletedDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            deletedDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in deletedDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Violation")
                {
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (column.HeaderText == "Manage")
                {
                    column.Width = 80;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void deletedDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == deletedDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image restoreIcon = Properties.Resources.RestoreIcon;
                Image deleteIcon = Properties.Resources.DeleteIcon;

                int iconSize = 20;
                int margin = 5;

                int totalWidth = (iconSize * 2) + margin;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var restoreIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);
                var deleteIconRect = new Rectangle(centerX + iconSize + margin, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(restoreIcon, restoreIconRect);
                e.Graphics.DrawImage(deleteIcon, deleteIconRect);

                deletedDGV.Rows[e.RowIndex].Tag = new { UpdateIconRect = restoreIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }
        private void deletedDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == deletedDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = deletedDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle restoreIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;

                    Point mousePosition = deletedDGV.PointToClient(Cursor.Position);

                    if (restoreIconRect.Contains(mousePosition))
                    {
                        RestoreFromTrash(selectedRow);
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        DeleteFromTrash(selectedRow);
                    }
                }
            }
        }

        private async void RestoreFromTrash(DataGridViewRow row)
        {
            string violationID = row.Cells["Violation ID"].Value.ToString();
            string lastName = row.Cells["Last Name"].Value.ToString();
            string firstName = row.Cells["First Name"].Value.ToString();
            string violation = row.Cells["Violation"].Value.ToString();

            DialogResult initialResult = CustomMessageBox.Show(
                $"Are you sure you want to restore the record for {firstName} {lastName} from the trash?",
                "Confirm Restore",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (initialResult == DialogResult.OK)
            {
                using (OleDbConnection conn = new OleDbConnection(DbConn))
                {
                    await conn.OpenAsync();

                    using (OleDbTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string restoreQuery = "UPDATE tblViolations SET [IsDeleted] = False WHERE [Violation ID] = ?";
                            using (OleDbCommand restoreCmd = new OleDbCommand(restoreQuery, conn, transaction))
                            {
                                restoreCmd.Parameters.AddWithValue("@ViolationID", violationID);

                                await restoreCmd.ExecuteNonQueryAsync();

                                transaction.Commit();

                                CustomMessageBox.Show(
                                    $"Violation record '{violation}' for {firstName} {lastName} has been restored successfully!",
                                    "Successfully Restored",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            CustomMessageBox.Show(
                                "An error occurred while restoring the record: " + ex.Message,
                                "Restoration Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }

                LogActivity("Restore", $"The violation record '{violation}' for {firstName} {lastName} has been successfully restored.", userName);
                await LoadDataFromDatabaseAsync();
                NotifyDataChanged();
            }
        }

        private async void DeleteFromTrash(DataGridViewRow row)
        {
            string violationID = row.Cells["Violation ID"].Value.ToString();
            string lastName = row.Cells["Last Name"].Value.ToString();
            string firstName = row.Cells["First Name"].Value.ToString();
            string violation = row.Cells["Violation"].Value.ToString();

            DialogResult initialResult = CustomMessageBox.Show($"Deleting will remove the violation and associated records for {firstName} {lastName}. Are you sure you want to proceed?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;

            if (initialResult == DialogResult.OK)
            {
                using (OleDbConnection conn = new OleDbConnection(DbConn))
                {
                    await conn.OpenAsync();

                    using (OleDbTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string deleteViolationQuery = "DELETE FROM tblViolations WHERE [Violation ID] = ?";
                            using (OleDbCommand deleteViolationCmd = new OleDbCommand(deleteViolationQuery, conn, transaction))
                            {
                                deleteViolationCmd.Parameters.AddWithValue("@ViolationID", violationID);

                                await deleteViolationCmd.ExecuteNonQueryAsync();

                                transaction.Commit();

                                CustomMessageBox.Show($"The violation record '{violation}' for {firstName} {lastName} has been permanently deleted.", "Successfully Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            CustomMessageBox.Show("An error occurred while deleting the program: " + ex.Message, "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                LogActivity("Delete", $"The violation record '{violation}' for {firstName} {lastName} has been permanently deleted.", userName);
                await LoadDataFromDatabaseAsync();
                NotifyDataChanged();
            }
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.Show(
            "Are you sure you want to permanently delete all violation records in the Trash? This action cannot be undone.",
            "Confirm Empty Trash",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM tblViolations WHERE [IsDeleted] = True";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    CustomMessageBox.Show(
                        "Trash has been successfully emptied.",
                        "Trash Emptied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    
                    LogActivity("Delete", $"Trash emptied. All violation records have been permanently deleted.", userName);
                    await LoadDataFromDatabaseAsync();
                    NotifyDataChanged();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(
                        "An error occurred while emptying the recycle bin: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
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
