using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SVMS.Forms;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace SVMS.Controls
{
    public partial class YearControl : UserControl
    {
        private string DbConn;
        private string userRole;
        private string userName;

        public event Action OnDataChanged;

        private ToolTip toolTip = new ToolTip();
        public YearControl(string role, string username)
        {
            InitializeComponent();
            userRole = role;
            userName = username;
            DbConn = GetDbConnectionString();
            toolTip.SetToolTip(btnReloadDB, "Reload Academic Years");
            toolTip.SetToolTip(btnAddYear, "Add New Academic Year");
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

        private async Task LoadDataFromDatabaseAsync()
        {
            string query = "SELECT [AY-Code], [From Year], [To Year], [Semester], [Status] FROM tblAcadYear ORDER BY [AY-Code] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    acadyearDGV.DataSource = dt;
                }

                if (!acadyearDGV.Columns.Contains("btnAction") && userRole != "Authorized User")
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "Manage",
                        Name = "btnAction",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    acadyearDGV.Columns.Add(btnAction);
                }

                if (!acadyearDGV.Columns.Contains("Status"))
                {
                    DataGridViewCheckBoxColumn statusColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Status",
                        HeaderText = "Status",
                        DataPropertyName = "Status",
                        TrueValue = true,
                        FalseValue = false,
                        ThreeState = false
                    };
                    acadyearDGV.Columns.Insert(acadyearDGV.Columns.Count - 1, statusColumn);
                }

                acadyearDGV.Refresh();
            }
        }

        #region -> DataGridView Format
        private void FormatDataGridView()
        {
            acadyearDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            acadyearDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            acadyearDGV.EnableHeadersVisualStyles = false;

            acadyearDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            acadyearDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            acadyearDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            acadyearDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            acadyearDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            acadyearDGV.DefaultCellStyle.ForeColor = Color.Black;

            acadyearDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            acadyearDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            acadyearDGV.DefaultCellStyle.SelectionBackColor = acadyearDGV.DefaultCellStyle.BackColor;
            acadyearDGV.DefaultCellStyle.SelectionForeColor = acadyearDGV.DefaultCellStyle.ForeColor;

            acadyearDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = acadyearDGV.AlternatingRowsDefaultCellStyle.BackColor;
            acadyearDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = acadyearDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            acadyearDGV.GridColor = Color.FromArgb(180, 180, 180);

            acadyearDGV.ColumnHeadersHeight = 40;
            acadyearDGV.RowTemplate.Height = 30;

            acadyearDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            acadyearDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            acadyearDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acadyearDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            acadyearDGV.AllowUserToResizeColumns = false;
            acadyearDGV.AllowUserToResizeRows = false;
            acadyearDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            acadyearDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            acadyearDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in acadyearDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Status" || column.HeaderText == "Manage")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
        #endregion
        private async void YearControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            loadingProgressBar.Visible = false;
            acadyearDGV.DataBindingComplete += acadyearDGV_DataBindingComplete;
            acadyearDGV.CellPainting += acadyearDGV_CellPainting;
            acadyearDGV.CellFormatting += acadyearDGV_CellFormatting;
            acadyearDGV.CellClick += acadyearDGV_CellClick;
            await LoadDataFromDatabaseAsync();
            await Task.Delay(500);
            btnReloadDB_Click(sender, e);
        }

        private void acadyearDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDataGridView();
        }

        #region -> Actions
        private void acadyearDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (acadyearDGV.Columns["btnAction"] == null)
                return;

            if (e.ColumnIndex == acadyearDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image updateIcon = Properties.Resources.UpdateIcon;

                int iconSize = 20;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - iconSize) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var updateIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(updateIcon, updateIconRect);

                acadyearDGV.Rows[e.RowIndex].Tag = new { UpdateIconRect = updateIconRect};

                e.Handled = true;
            }
        }

        private void acadyearDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (acadyearDGV.Columns[e.ColumnIndex].Name == "Status")
            {
                bool isActive = (bool)e.Value;

                if (isActive)
                {
                    e.CellStyle.BackColor = Color.FromArgb(30, 212, 133);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(30, 212, 133);
                } else if (!isActive)
                {
                    e.CellStyle.BackColor = Color.FromArgb(153, 153, 153);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(153, 153, 153);
                }
            }
        }

        private void acadyearDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == acadyearDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = acadyearDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle updateIconRect = tag.UpdateIconRect;

                    Point mousePosition = acadyearDGV.PointToClient(Cursor.Position);

                    if (updateIconRect.Contains(mousePosition))
                    {
                        UpdateRecord(selectedRow);
                    }
                }
            }
        }
        #endregion

        private async void btnAddYear_Click(object sender, EventArgs e)
        {
            using (YearForm addForm = new YearForm(isUpdate: false))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {

                    string newAYCode = addForm.AYCode;
                    string newFromYear = addForm.FromYear;
                    string newToYear = addForm.ToYear;
                    string newSem = addForm.Semester;
                    bool newStatus = addForm.Status;

                    await SetAllAcademicYearsInactiveAsync();


                    string query = "INSERT INTO tblAcadYear ([AY-Code], [From Year], [To Year], [Semester], [Status]) VALUES (?, ?, ?, ?, ?)";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AY-Code", newAYCode);
                            cmd.Parameters.AddWithValue("@From Year", newFromYear);
                            cmd.Parameters.AddWithValue("@To Year", newToYear);
                            cmd.Parameters.AddWithValue("@Semester", newSem);
                            cmd.Parameters.AddWithValue("@Status", newStatus);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    LogActivity("Add", $"Successfully added a new academic year '{newAYCode}' to the system.", userName);
                    await LoadDataFromDatabaseAsync();
                }

                NotifyDataChanged();
            }
        }

        private async Task SetAllAcademicYearsInactiveAsync()
        {
            string query = "UPDATE tblAcadYear SET [Status] = False WHERE [Status] = True";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        private bool IsAYCodeExists(string ayCode)
        {
            string query = "SELECT COUNT(*) FROM tblAcadYear WHERE [AY-Code] = ?";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AY-Code", ayCode);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private async void UpdateRecord(DataGridViewRow row)
        {
            string ayCode = row.Cells["AY-Code"].Value.ToString();
            string fromYear = row.Cells["From Year"].Value.ToString();
            string toYear = row.Cells["To Year"].Value.ToString();
            string sem = row.Cells["Semester"].Value.ToString();
            bool status = Convert.ToBoolean(row.Cells["Status"].Value);

            using (YearForm updateForm = new YearForm(isUpdate: true, ayCode, fromYear, toYear, sem, status))
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    
                    string newAYCode = updateForm.AYCode;
                    string newFromYear = updateForm.FromYear;
                    string newToYear = updateForm.ToYear;
                    string newSem = updateForm.Semester;
                    bool newStatus = updateForm.Status;

                    // Check if the status is being changed
                    if (status != newStatus)
                    {
                        // Set all academic years inactive if the new status is true
                        if (newStatus)
                        {
                            await SetAllAcademicYearsInactiveAsync();
                        }
                    }

                    string statusText = newStatus ? "Active" : "Inactive";
                    // Prepare to update the record
                    string query = "UPDATE tblAcadYear SET [AY-Code] = ?, [From Year] = ?, [To Year] = ?, [Semester] = ?, [Status] = ? WHERE [AY-Code] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AY-Code", newAYCode);
                            cmd.Parameters.AddWithValue("@FromYear", newFromYear);
                            cmd.Parameters.AddWithValue("@ToYear", newToYear);
                            cmd.Parameters.AddWithValue("@Semester", newSem);
                            cmd.Parameters.AddWithValue("@Status", newStatus);
                            cmd.Parameters.AddWithValue("@OldAY-Code", ayCode);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    if (ayCode != newAYCode)
                    {
                        if (status != newStatus)
                        {
                            LogActivity("Update", $"Academic year successfully updated and set the status to {statusText}.", userName);
                        }
                        else
                        {
                            LogActivity("Update", $"Academic year successfully updated.", userName);
                        }
                    }
                    else if (status != newStatus)
                    {
                        LogActivity("Update", $"Academic year '{ayCode}' status has been changed to {statusText}.", userName);
                    }

                    await LoadDataFromDatabaseAsync();
                }

                NotifyDataChanged();
            }
        }

        private async void DeleteRecord(DataGridViewRow row)
        {
            string ayCode = row.Cells["AY-Code"].Value.ToString();

            if (CustomMessageBox.Show("Are you sure you want to delete this Academic Year? Deleting it will also remove all associated violation records. Do you want to proceed?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM tblAcadYear WHERE [AY-Code] = ?";

                using (OleDbConnection conn = new OleDbConnection(DbConn))
                {
                    await conn.OpenAsync();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AY-Code", ayCode);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                CustomMessageBox.Show("Academic Year successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LogActivity("Delete", $"Academic year '{ayCode}' was successfully removed from the system.", userName);
                await LoadDataFromDatabaseAsync();
            }

            NotifyDataChanged();
        }

        private async void btnReloadDB_Click(object sender, EventArgs e)
        {
            btnReloadDB.Visible = false;
            loadingProgressBar.Visible = true;
            try
            {
                await LoadDataFromDatabaseAsync();
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
