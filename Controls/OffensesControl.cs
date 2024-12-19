using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using SVMS.Forms;
using System;

namespace SVMS.Controls
{
    public partial class OffensesControl : UserControl
    {
        private string DbConn;
        private string userRole;
        private string userName;

        private readonly VioEntryControl violation;
        private readonly DashboardControl dashboard;
        public OffensesControl(VioEntryControl vioEntry, DashboardControl dbControl, string role, string username)
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            violation = vioEntry;
            dashboard = dbControl;
            userRole = role;
            userName = username;
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        protected void NotifyDataChanged()
        {
            violation?.RefreshDataAsync();
            dashboard?.RefreshData();
        }

        private async Task LoadOffensesDataAsync()
        {
            await Task.WhenAll(LoadMinorOffensesAsync(), LoadMajorOffensesAsync());
        }

        private async Task LoadMinorOffensesAsync()
        {
            string query = "SELECT [Minor ID], [Minor Offenses] FROM tblMinorOffenses";
            await LoadOffenseAsync(query, minorOffensesDGV, "Minor ID");
        }

        private async Task LoadMajorOffensesAsync()
        {
            string query = "SELECT [Major ID], [Major Offenses] FROM tblMajorOffenses";
            await LoadOffenseAsync(query, majorOffensesDGV, "Major ID");
        }

        private async Task LoadOffenseAsync(string query, DataGridView dgv, string offenseID)
        {
            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    dgv.DataSource = dt;
                }

                // Add "Manage" button if not already present
                if (!dgv.Columns.Contains("btnAction"))
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "Manage",
                        Name = "btnAction",
                        UseColumnTextForButtonValue = true
                    };
                    dgv.Columns.Add(btnAction);
                }

                // Rename the ID column for display
                //dgv.Columns[offenseID].HeaderText = "ID No.";

                if (dgv.Columns[offenseID] != null)
                {
                    dgv.Columns[offenseID].Visible = false;
                }
            }
        }

        private void FormatDataGridView(DataGridView dgv, string headerName)
        {
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = dgv.AlternatingRowsDefaultCellStyle.ForeColor;

            dgv.GridColor = Color.FromArgb(180, 180, 180);
            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 30;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == headerName)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || !dgv.Columns.Contains("btnAction")) return;

            if (e.ColumnIndex == dgv.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image updateIcon = Properties.Resources.UpdateIcon;
                Image deleteIcon = Properties.Resources.DeleteIcon;

                int iconSize = 20;
                int margin = 5;

                int totalWidth = (iconSize * 2) + margin;
                int centerX = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var updateIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);
                var deleteIconRect = new Rectangle(centerX + iconSize + margin, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(updateIcon, updateIconRect);
                e.Graphics.DrawImage(deleteIcon, deleteIconRect);

                dgv.Rows[e.RowIndex].Tag = new { UpdateIconRect = updateIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }

        private async void HandleOffenseDGVCellClick(DataGridView offenseDGV, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == offenseDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = offenseDGV.Rows[e.RowIndex];
                var tag = selectedRow.Tag as dynamic;

                if (tag != null)
                {
                    // Retrieve the icon rectangles for Update and Delete actions.
                    Rectangle updateIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;

                    // Get the mouse position relative to the DataGridView.
                    Point mousePosition = offenseDGV.PointToClient(Cursor.Position);

                    if (updateIconRect.Contains(mousePosition))
                    {
                        // Call your Update logic here.
                        await UpdateRecordAsync(offenseDGV, selectedRow);
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        // Confirm deletion.
                        DialogResult confirmDelete = CustomMessageBox.Show(
                            "Are you sure you want to delete this offense from the list?",
                            "Confirm Deletion",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (confirmDelete == DialogResult.Yes)
                        {
                            DeleteRecord(offenseDGV, selectedRow);
                        }
                    }
                }
            }
        }

        private void minorOffensesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleOffenseDGVCellClick(minorOffensesDGV, e);
        }

        private void majorOffensesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleOffenseDGVCellClick(majorOffensesDGV, e);
        }

        private async void OffensesControl_Load(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            loadingProgressBar.Visible = false;

            minorOffensesDGV.DataBindingComplete += minorOffensesDGV_DataBindingComplete;
            minorOffensesDGV.CellContentClick += minorOffensesDGV_CellClick;
            minorOffensesDGV.CellPainting += dgv_CellPainting;
           
            majorOffensesDGV.DataBindingComplete += majorOffensesDGV_DataBindingComplete;
            majorOffensesDGV.CellContentClick += majorOffensesDGV_CellClick;
            majorOffensesDGV.CellPainting += dgv_CellPainting;

            await LoadOffensesDataAsync();

            await Task.Delay(500);
            btnReloadDB_Click(sender, e);
        }

        // Call this method in the DataBindingComplete event handlers
        private void minorOffensesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDataGridView(minorOffensesDGV, "Minor Offenses");
        }

        private void majorOffensesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDataGridView(majorOffensesDGV, "Major Offenses");
        }

        private async void btnAddOffense_Click(object sender, System.EventArgs e)
        {
            using (OffensesForm addForm = new OffensesForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve data from the OffensesForm
                    string offenseName = addForm.OffenseName;
                    bool isMinor = addForm.IsMinorOffense; // Check if Minor Offense radio button is selected

                    // Determine the table and query based on offense type
                    string query = isMinor
                        ? "INSERT INTO tblMinorOffenses ([Minor Offenses]) VALUES (?)"
                        : "INSERT INTO tblMajorOffenses ([Major Offenses]) VALUES (?)";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Offense", offenseName);
                            await cmd.ExecuteNonQueryAsync();

                            CustomMessageBox.Show("Offense added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Reload data
                    if (isMinor)
                    {
                        LogActivity("Add", $"A new minor offense named '{offenseName}' was successfully added to the system.", userName);
                        await LoadMinorOffensesAsync();
                        NotifyDataChanged();
                    }
                    else
                    {
                        LogActivity("Add", $"A new major offense named '{offenseName}' was successfully added to the system.", userName);
                        await LoadMajorOffensesAsync();
                        NotifyDataChanged();
                    }
                }
            }
        }

        private async Task UpdateRecordAsync(DataGridView offenseDGV, DataGridViewRow selectedRow)
        {
            // Determine if the DataGridView is for minor or major offenses
            string idColumnName = offenseDGV == minorOffensesDGV ? "Minor ID" : "Major ID";
            string offenseColumnName = offenseDGV == minorOffensesDGV ? "Minor Offenses" : "Major Offenses";
            string tableName = offenseDGV == minorOffensesDGV ? "tblMinorOffenses" : "tblMajorOffenses";

            // Retrieve the ID and offense name from the selected row
            string id = selectedRow.Cells[idColumnName].Value.ToString();  // Use appropriate ID column
            string offenseName = selectedRow.Cells[offenseColumnName].Value.ToString(); // Use appropriate offense column name

            // Check if the offense is minor or major based on the DataGridView
            bool isMinorOffense = offenseDGV == minorOffensesDGV;

            // Create the OffensesForm instance
            using (OffensesForm offenseForm = new OffensesForm())
            {
                // Initialize the form for updating
                offenseForm.InitializeForUpdate(offenseName, isMinorOffense);

                // Show the form and check if the user clicked OK
                if (offenseForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the updated offense name and type
                    string updatedOffenseName = offenseForm.OffenseName;
                    bool updatedIsMinorOffense = offenseForm.IsMinorOffense;



                    // Now, save the updated information to the database
                    try
                    {
                        // SQL query for updating minor or major offenses based on the selected table
                        string updateQuery = offenseDGV == minorOffensesDGV
                            ? "UPDATE tblMinorOffenses SET [Minor Offenses] = @OffenseName WHERE [Minor ID] = @ID"
                            : "UPDATE tblMajorOffenses SET [Major Offenses] = @OffenseName WHERE [Major ID] = @ID";

                        using (var conn = new OleDbConnection(DbConn))
                        {
                            await conn.OpenAsync(); // Open the connection asynchronously

                            using (var command = new OleDbCommand(updateQuery, conn))
                            {
                                // Add parameters to the query
                                command.Parameters.AddWithValue("@OffenseName", updatedOffenseName);
                                command.Parameters.AddWithValue("@ID", id);

                                // Execute the update query asynchronously
                                int rowsAffected = await command.ExecuteNonQueryAsync();
                                if (rowsAffected > 0)
                                {
                                    CustomMessageBox.Show("Offense updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Update tblViolations with the new offense name
                                    await UpdateViolationsAsync(offenseName, updatedOffenseName);

                                    string offenseType = isMinorOffense ? "Minor" : "Major";
                                    // Reload data
                                    if (isMinorOffense)
                                    {
                                        LogActivity("Update", $"A listed {offenseType} offense with ID No.{id} was successfully updated.", userName);
                                        await LoadMinorOffensesAsync();
                                        NotifyDataChanged();
                                    }
                                    else
                                    {
                                        LogActivity("Update", $"A listed {offenseType} offense with ID No.{id} was successfully updated.", userName);
                                        await LoadMajorOffensesAsync();
                                        NotifyDataChanged();
                                    }
                                }
                                else
                                {
                                    CustomMessageBox.Show("Failed to update offense.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"An error occurred while updating the offense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async Task UpdateViolationsAsync(string oldOffenseName, string updatedOffenseName)
        {
            string query = "UPDATE tblViolations SET [Violation] = @UpdatedOffenseName WHERE [Violation] = @OldOffenseName";

            try
            {
                using (var conn = new OleDbConnection(DbConn))
                {
                    await conn.OpenAsync();
                    using (var command = new OleDbCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@UpdatedOffenseName", updatedOffenseName);
                        command.Parameters.AddWithValue("@OldOffenseName", oldOffenseName);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected == 0)
                        {
                            return;
                        }
                        else
                        {
                            CustomMessageBox.Show($"Changes have also been applied to {rowsAffected} violation record{(rowsAffected != 1 ? "s" : "")}.", "Changes Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        NotifyDataChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"An error occurred while updating violations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteRecord(DataGridView offenseDGV, DataGridViewRow selectedRow)
        {
            try
            {
                // Get the ID and offense type based on the DataGridView
                string idColumnName = offenseDGV == minorOffensesDGV ? "Minor ID" : "Major ID";
                string tableName = offenseDGV == minorOffensesDGV ? "tblMinorOffenses" : "tblMajorOffenses";

                // Retrieve the ID of the selected row
                string id = selectedRow.Cells[idColumnName].Value.ToString();

                // Delete query
                string query = $"DELETE FROM {tableName} WHERE [{idColumnName}] = ?";

                using (OleDbConnection conn = new OleDbConnection(DbConn))
                {
                    await conn.OpenAsync();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", id);
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            CustomMessageBox.Show("Offense deleted from the list successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Reload the data
                            if (offenseDGV == minorOffensesDGV)
                            {
                                LogActivity("Delete", $"A listed offense was successfully deleted and removed from the system.", userName);
                                await LoadMinorOffensesAsync();
                                NotifyDataChanged();
                            }
                            else
                            {
                                LogActivity("Delete", $"A listed offense was successfully deleted and removed from the system.", userName);
                                await LoadMajorOffensesAsync();
                                NotifyDataChanged();
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show("Failed to delete the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnReloadDB_Click(object sender, EventArgs e)
        {
            btnReloadDB.Visible = false;
            loadingProgressBar.Visible = true;

            try
            {
                await LoadOffensesDataAsync();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingProgressBar.Visible = false;
                btnReloadDB.Visible = true;
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
