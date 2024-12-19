using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using SVMS.Forms;

namespace SVMS.Controls
{
    public partial class DashboardControl : UserControl
    {
        private string DbConn;
        private string userRole;
        DateTime selectedDate = DateTime.Now.Date;

        private ToolTip toolTip = new ToolTip();
        public DashboardControl(string role)
        {
            InitializeComponent();
            userRole = role;
            DbConn = GetDbConnectionString();
            toolTip.SetToolTip(btnDeleteLogs, "Delete 15 days old logs");
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }
        public void RefreshData()
        {
            LoadDashboardData();
            LoadActivityLogs(selectedDate);
            LoadTopViolationsToDGV();
        }

        private void LoadDashboardData()
        {
            string query = @"
                SELECT qActiveAY.[AY-Code], 
                       qActiveAY.[Status], 
                       qStudentsWithViolations.[Students with Violations], 
                       qTotalViolationActiveAY.[Total Violations (Active AY)]
                FROM qActiveAY, 
                       qStudentsWithViolations, 
                       qTotalViolationActiveAY;";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                try
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isActive = Convert.ToBoolean(reader["Status"]);

                            if (isActive)
                            {
                                txtActiveAcademicYear.Text = reader["AY-Code"].ToString();
                            }
                            else
                            {
                                txtActiveAcademicYear.Text = "No Active";
                            }

                            txtStudentsWithViolations.Text = reader["Students with Violations"].ToString();
                            txtTotalViolationsAY.Text = reader["Total Violations (Active AY)"].ToString();
                        }
                        else
                        {
                            txtActiveAcademicYear.Text = "No Active";
                            txtStudentsWithViolations.Text = "0";
                            txtTotalViolationsAY.Text = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Error loading dashboard data: " + ex.Message);
                }
            }
        }

        private DataTable GetTopViolations()
        {
            string qStatistics = @"
                SELECT TOP 3 
                    [Violation], 
                    Count(tblViolations.Violation) AS CountOfViolation
                FROM 
                    tblViolations
                GROUP BY 
                    tblViolations.Violation
                ORDER BY 
                    Count(tblViolations.Violation) DESC,
                    [Violation] ASC";

            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                conn.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(qStatistics, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private void LoadTopViolationsToDGV()
        {
            DataTable topViolations = GetTopViolations();

            if (topViolations.Rows.Count == 0)
            {
                if (!topViolations.Columns.Contains("Violation"))
                    topViolations.Columns.Add("Violation", typeof(string));
                if (!topViolations.Columns.Contains("CountOfViolation"))
                    topViolations.Columns.Add("CountOfViolation", typeof(int));
            }

            StatsDGV.DataSource = topViolations;

            StatsDGV.Columns["Violation"].HeaderText = "Top 3 Most Common Student Violations";
            StatsDGV.Columns["CountOfViolation"].HeaderText = "Count(s)";

            StatsDGV.Columns["Violation"].Visible = true;
            StatsDGV.Columns["CountOfViolation"].Visible = true;

            StatsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadActivityLogs(DateTime selectedDate)
        {
            string query = @"
            SELECT [Log ID], [Date/Time], [Action], [Description], [Username]
            FROM tblActivityLog
            WHERE FORMAT([Date/Time], 'yyyy-mm-dd') = ?
            ORDER BY [Date/Time] DESC;";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                try
                {
                    conn.Open();

                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@SelectedDate", formattedDate);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        activityDGV.DataSource = dataTable;
                    }

                    if (activityDGV.Columns["Log ID"] != null)
                    {
                        activityDGV.Columns["Log ID"].Visible = false;
                    }

                    activityDGV.Columns["Username"].HeaderText = "Performed By";
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Error loading activity logs: " + ex.Message);
                }
            }
        }

        private void DeleteActivityLogs()
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM tblActivityLog WHERE [Date/Time] < ?";
                DateTime cutoffDate = DateTime.Now.AddDays(-15);
                int logsToDeleteCount;

                using (OleDbConnection conn = new OleDbConnection(DbConn))
                {
                    conn.Open();

                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@cutoffDate", OleDbType.Date).Value = cutoffDate;
                        logsToDeleteCount = (int)checkCmd.ExecuteScalar();
                    }

                    if (logsToDeleteCount > 0)
                    {
                        string deleteQuery = "DELETE FROM tblActivityLog WHERE [Date/Time] < ?";

                        using (OleDbCommand deleteCmd = new OleDbCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.Add("@cutoffDate", OleDbType.Date).Value = cutoffDate;
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            CustomMessageBox.Show($"{rowsAffected} old activity logs deleted.", "Successfully Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show("No activity logs older than 15 days to delete.", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"An error occurred while deleting activity logs: {ex.Message}", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureUIBasedOnRole()
        {
            if (userRole == "Authorized User" || userRole == "Sub-Admin")
            {
                btnDeleteLogs.Visible = false;
            }
        }

        private void FormatDataGridView()
        {
            activityDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            activityDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            activityDGV.EnableHeadersVisualStyles = false;

            activityDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(190, 190, 190);
            activityDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(38, 40, 44);

            activityDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(190, 190, 190);
            activityDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(38, 40, 44);

            activityDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            activityDGV.DefaultCellStyle.ForeColor = Color.FromArgb(38, 40, 44);

            activityDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            activityDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(38, 40, 44);

            activityDGV.DefaultCellStyle.SelectionBackColor = activityDGV.DefaultCellStyle.BackColor;
            activityDGV.DefaultCellStyle.SelectionForeColor = activityDGV.DefaultCellStyle.ForeColor;

            activityDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = activityDGV.AlternatingRowsDefaultCellStyle.BackColor;
            activityDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = activityDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            activityDGV.GridColor = Color.FromArgb(180, 180, 180);

            activityDGV.ColumnHeadersHeight = 40;
            activityDGV.RowTemplate.Height = 30;

            activityDGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            activityDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            activityDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            activityDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            activityDGV.AllowUserToResizeColumns = false;
            activityDGV.AllowUserToResizeRows = false;
            activityDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            activityDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            activityDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in activityDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Description")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (column.HeaderText == "Date/Time" || column.HeaderText == "Action")
                {
                    column.Width = 150;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void FormatStatsDGV()
        {
            StatsDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            StatsDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            StatsDGV.EnableHeadersVisualStyles = false;

            StatsDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(205, 92, 92);
            StatsDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            StatsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(205, 92, 92);
            StatsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            StatsDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            StatsDGV.DefaultCellStyle.ForeColor = Color.FromArgb(38, 40, 44);

            StatsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 218, 218);
            StatsDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(38, 40, 44);

            StatsDGV.DefaultCellStyle.SelectionBackColor = StatsDGV.DefaultCellStyle.BackColor;
            StatsDGV.DefaultCellStyle.SelectionForeColor = StatsDGV.DefaultCellStyle.ForeColor;

            StatsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = StatsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            StatsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = StatsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            StatsDGV.GridColor = Color.FromArgb(237, 109, 113);

            StatsDGV.ColumnHeadersHeight = 30;
            StatsDGV.RowTemplate.Height = 30;

            StatsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StatsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            StatsDGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            StatsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            StatsDGV.AllowUserToResizeColumns = false;
            StatsDGV.AllowUserToResizeRows = false;
            StatsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            StatsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            StatsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in StatsDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "CountOfViolation")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            ConfigureUIBasedOnRole();
            LoadDashboardData();
            
            StatsDGV.DataBindingComplete += StatsDGV_DataBindingComplete;
            LoadTopViolationsToDGV();
            
            activityDGV.DataBindingComplete += activityDGV_DataBindingComplete;
            LoadActivityLogs(selectedDate);
            
        }

        private void activityDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDataGridView();
        }

        private void StatsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatStatsDGV();
        }

        private void btnDeleteLogs_Click(object sender, EventArgs e)
        {
            DialogResult initialResult = CustomMessageBox.Show($"Are you sure you want to delete 15 days old activity logs?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (initialResult == DialogResult.OK)
            {
                using (PromptPassword confirmForm = new PromptPassword(PromptPassword.OperationType.Delete))
                {
                    DialogResult confirmResult = confirmForm.ShowDialog();

                    if (confirmResult == DialogResult.OK)
                    {
                        DeleteActivityLogs();
                    }

                    LoadActivityLogs(selectedDate);
                }
            }
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFilter.Value.Date;
            LoadActivityLogs(selectedDate);
        }
    }
}
