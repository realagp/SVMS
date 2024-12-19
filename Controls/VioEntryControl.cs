using System;
using System.Data;
using System.Drawing;
using SVMS.Forms;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace SVMS.Controls
{
    public partial class VioEntryControl : UserControl
    {
        private string DbConn;
        public event Action OnDataChanged;
        private ToolTip toolTip = new ToolTip();
        private int userId = 1;
        private string userRole;
        private string userName;

        public VioEntryControl(string role, string username)
        {
            InitializeComponent();
            userRole = role;
            userName = username;
            DbConn = GetDbConnectionString();
            toolTip.SetToolTip(btnReloadDB, "Reload Recorded Violations");
            toolTip.SetToolTip(btnAddViolation, "Add New Violation");
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

        public async Task RefreshDataAsync()
        {
            await Task.WhenAll(LoadAYCodesAsync(), LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
        }

        private string ToProperCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private async Task LoadStudentViolationCountsAsync(string selectedAYCode = null)
        {
            string qRecords = @"
            SELECT 
                tblViolations.[AY-Code], 
                tblViolations.[Student ID], 
                tblStudents.[Last Name], 
                tblStudents.[First Name],
                MAX(tblViolations.[Date]) AS [MaxOfDate],
                COUNT(tblViolations.[Violation ID]) AS [Recorded Violations]
            FROM 
                tblStudents
            INNER JOIN 
                tblViolations ON tblStudents.[Student ID] = tblViolations.[Student ID]
            WHERE
                tblViolations.[IsDeleted] = False";

            List<string> filters = new List<string>();

            if (string.IsNullOrEmpty(selectedAYCode) && cbFilter.SelectedItem != null)
            {
                selectedAYCode = cbFilter.SelectedItem.ToString();
            }

            if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
            {
                filters.Add("tblViolations.[AY-Code] = @AYCode");
            }

            if (filters.Count > 0)
            {
                qRecords += " AND " + string.Join(" AND ", filters);
            }

            qRecords += @" GROUP BY 
            tblViolations.[AY-Code], 
            tblViolations.[Student ID],
            tblStudents.[Last Name], 
            tblStudents.[First Name]
            ORDER BY MAX(tblViolations.[Date]) DESC;";

            DataTable dT = new DataTable();

            await Task.Run(() =>
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    OleDbCommand command = new OleDbCommand(qRecords, connection);

                    if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
                    {
                        command.Parameters.AddWithValue("@AYCode", selectedAYCode);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    try
                    {
                        connection.Open();
                        adapter.Fill(dT);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Error: " + ex.Message);
                    }
                }
            });
            this.Invoke(new Action(() =>
            {
                recordsDGV.DataSource = dT;

                if (!recordsDGV.Columns.Contains("btnView"))
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "View",
                        Name = "btnView",
                        UseColumnTextForButtonValue = true
                    };
                    recordsDGV.Columns.Add(btnAction);
                }

                if (recordsDGV.Columns["MaxOfDate"] != null)
                {
                    recordsDGV.Columns["MaxOfDate"].Visible = false;
                }

                recordsDGV.Refresh();
            }));
        }

        private async Task LoadDataFromDatabaseAsync(string selectedAYCode = null)
        {
            if (cbFilter.SelectedItem != null)
            {
                selectedAYCode = cbFilter.SelectedItem.ToString();
            }

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
                tblViolations
                INNER JOIN tblStudents
                ON tblViolations.[Student ID] = tblStudents.[Student ID]
            WHERE 
                tblViolations.[IsDeleted] = False";

            if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
            {
                query += " AND tblViolations.[AY-Code] = @AYCode";
            }

            query += " ORDER BY tblViolations.[Date] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@AYCode", selectedAYCode);
                    }

                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    violationsDGV.DataSource = dt;
                }

                if (!violationsDGV.Columns.Contains("btnAction") && userRole != "Authorized User")
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "Manage",
                        Name = "btnAction",
                        UseColumnTextForButtonValue = true
                    };

                    violationsDGV.Columns.Add(btnAction);
                }

                if (violationsDGV.Columns["Violation ID"] != null)
                {
                    violationsDGV.Columns["Violation ID"].Visible = false;
                }

                if (violationsDGV.Columns["AY-Code"] != null)
                {
                    violationsDGV.Columns["AY-Code"].Visible = false;
                }

                violationsDGV.Refresh();
            }
        }

        private void FormatRecordsDGV()
        {
            recordsDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            recordsDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            recordsDGV.EnableHeadersVisualStyles = false;

            recordsDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            recordsDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            recordsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            recordsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            recordsDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            recordsDGV.DefaultCellStyle.ForeColor = Color.Black;

            recordsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            recordsDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            recordsDGV.DefaultCellStyle.SelectionBackColor = recordsDGV.DefaultCellStyle.BackColor;
            recordsDGV.DefaultCellStyle.SelectionForeColor = recordsDGV.DefaultCellStyle.ForeColor;

            recordsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = recordsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            recordsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = recordsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            recordsDGV.GridColor = Color.FromArgb(180, 180, 180);

            recordsDGV.ColumnHeadersHeight = 40;
            recordsDGV.RowTemplate.Height = 30;

            recordsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            recordsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            recordsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            recordsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            recordsDGV.AllowUserToResizeColumns = false;
            recordsDGV.AllowUserToResizeRows = false;
            recordsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            recordsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            recordsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in recordsDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Recorded Violations" || column.HeaderText == "View")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
        }
        private void FormatDataGridView()
        {
            violationsDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            violationsDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            violationsDGV.EnableHeadersVisualStyles = false;

            violationsDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            violationsDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            violationsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            violationsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            violationsDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            violationsDGV.DefaultCellStyle.ForeColor = Color.Black;

            violationsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            violationsDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            violationsDGV.DefaultCellStyle.SelectionBackColor = violationsDGV.DefaultCellStyle.BackColor;
            violationsDGV.DefaultCellStyle.SelectionForeColor = violationsDGV.DefaultCellStyle.ForeColor;

            violationsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = violationsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            violationsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = violationsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            violationsDGV.GridColor = Color.FromArgb(205, 205, 205);

            violationsDGV.ColumnHeadersHeight = 40;
            violationsDGV.RowTemplate.Height = 30;

            violationsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            violationsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            violationsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            violationsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            violationsDGV.AllowUserToResizeColumns = false;
            violationsDGV.AllowUserToResizeRows = false;
            violationsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            violationsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            violationsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in violationsDGV.Columns)
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

        private async void VioEntryControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            loadingProgressBar.Visible = false;
            recordsDGV.DataBindingComplete += recordsDGV_DataBindingComplete;
            violationsDGV.DataBindingComplete += violationsDGV_DataBindingComplete;
            violationsDGV.CellPainting += violationsDGV_CellPainting;
            violationsDGV.CellClick += violatioinsDGV_CellClick;
            recordsDGV.CellPainting += recordsDGV_CellPainting;
            recordsDGV.CellClick += recordsDGV_CellClick;

            await Task.WhenAll(LoadAYCodesAsync(), LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
            
            await Task.Delay(500);
            btnReloadDB_Click(sender, e);
        }

        private void violationsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDataGridView();
        }

        private void recordsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatRecordsDGV();
        }

        private void violationsDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if the "btnAction" column exists
            if (violationsDGV.Columns["btnAction"] == null)
                return;

            if (e.ColumnIndex == violationsDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image updateIcon = Properties.Resources.UpdateIcon;
                Image deleteIcon = Properties.Resources.DeleteIcon;
                Image emailIcon = Properties.Resources.GmailIcon2;

                int iconSize = 20;
                int margin = 5;

                int totalWidth = (iconSize * 3) + (margin * 2);

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var emailIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);
                var updateIconRect = new Rectangle(centerX + iconSize + margin, centerY, iconSize, iconSize);
                var deleteIconRect = new Rectangle(centerX + 2 * (iconSize + margin), centerY, iconSize, iconSize);

                e.Graphics.DrawImage(emailIcon, emailIconRect);
                e.Graphics.DrawImage(updateIcon, updateIconRect);
                e.Graphics.DrawImage(deleteIcon, deleteIconRect);

                violationsDGV.Rows[e.RowIndex].Tag = new { EmailIconRect = emailIconRect, UpdateIconRect = updateIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }

        private void violatioinsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == violationsDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = violationsDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle updateIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;
                    Rectangle emailIconRect = tag.EmailIconRect;

                    Point mousePosition = violationsDGV.PointToClient(Cursor.Position);

                    if (updateIconRect.Contains(mousePosition))
                    {
                        UpdateRecord(selectedRow);
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        MoveToTrash(selectedRow);
                    }
                    else if (emailIconRect.Contains(mousePosition))
                    {
                        string studentId = selectedRow.Cells["Student ID"].Value.ToString();
                        string violation = selectedRow.Cells["Violation"].Value.ToString();
                        DateTime violationDate = Convert.ToDateTime(selectedRow.Cells["Date"].Value);

                        string studentName = $"{selectedRow.Cells["First Name"].Value} {selectedRow.Cells["Last Name"].Value}";

                        DialogResult dialogResult = CustomMessageBox.Show(
                            $"You are about to send an email to {studentName.ToUpper()} notifying them about their violation:\n\n" +
                            $"{violation}\nDate: {violationDate.ToShortDateString()}\n\n" +
                            "Do you want to proceed?",
                            "Send Email Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (dialogResult == DialogResult.Yes)
                        {
                            SendViolationEmailToStudent(studentId, violation, violationDate);
                        }
                    }
                }
            }
        }

        private void recordsDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == recordsDGV.Columns["btnView"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image actionIcon = Properties.Resources.ViewIcon;

                int iconSize = 20;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - iconSize) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var iconRect = new Rectangle(centerX, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(actionIcon, iconRect);

                recordsDGV.Rows[e.RowIndex].Tag = iconRect;

                e.Handled = true;
            }
        }
        private void recordsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == recordsDGV.Columns["btnView"].Index)
            {
                DataGridViewRow selectedRow = recordsDGV.Rows[e.RowIndex];

                string studentID = selectedRow.Cells["Student ID"].Value.ToString();
                string ayCode = selectedRow.Cells["AY-Code"].Value.ToString();

                FilterViolationDetails(studentID, ayCode);
            }
        }

        private void FilterViolationDetails(string studentID, string ayCode)
        {
            DataTable allViolationsTable;

            if (violationsDGV.DataSource is DataView dataView)
            {
                allViolationsTable = dataView.Table;
            }
            else if (violationsDGV.DataSource is DataTable dataTable)
            {
                allViolationsTable = dataTable;
            }
            else
            {
                CustomMessageBox.Show("Data source is not valid.");
                return;
            }

            DataView filteredView = new DataView(allViolationsTable)
            {
                RowFilter = $"[Student ID] = '{studentID}' AND [AY-Code] = '{ayCode}'"
            };

            violationsDGV.DataSource = filteredView;
        }

        private async Task<string> GetStudentNameByIdAsync(string studentId)
        {
            string studentName = string.Empty;
            string query = "SELECT [First Name], [Last Name] FROM tblStudents WHERE [Student ID] = @StudentID";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    await conn.OpenAsync();
                    using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["First Name"].ToString();
                            string lastName = reader["Last Name"].ToString();
                            studentName = $"{firstName} {lastName}";
                        }
                    }
                }
            }

            return studentName;
        }

        private async Task<string> GetStudentEmailByIdAsync(string studentId)
        {
            string studentEmail = string.Empty;
            string query = "SELECT [Email] FROM tblStudents WHERE [Student ID] = @StudentID";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    await conn.OpenAsync();
                    using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            studentEmail = reader["Email"].ToString();
                        }
                    }
                }
            }

            return studentEmail;
        }

        private async void UpdateRecord(DataGridViewRow row)
        {
            string ayCode = row.Cells["AY-Code"].Value.ToString();
            string studentID = row.Cells["Student ID"].Value.ToString();
            string violationID = row.Cells["Violation ID"].Value.ToString();
            string violation = row.Cells["Violation"].Value.ToString();
            string offense = row.Cells["Offense Type"].Value.ToString();
            string sanction = row.Cells["Sanction"].Value.ToString();

            string queryFetchStudentDetails = @"
            SELECT 
                [Last Name], [First Name], [Course]
            FROM 
                tblStudents
            WHERE 
                [Student ID] = ?";

            string lastName = string.Empty;
            string firstName = string.Empty;
            string course = string.Empty;

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbCommand cmdFetchStudentDetails = new OleDbCommand(queryFetchStudentDetails, conn))
                {
                    cmdFetchStudentDetails.Parameters.AddWithValue("@StudentID", studentID);
                    using (OleDbDataReader reader = (OleDbDataReader)await cmdFetchStudentDetails.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            lastName = reader["Last Name"].ToString();
                            firstName = reader["First Name"].ToString();
                            course = reader["Course"].ToString();
                        }
                    }
                }
            }

            using (VioEntryForm updateForm = new VioEntryForm(
                isUpdate: true,
                ayCode: ayCode,
                studentID: studentID,
                violation: violation,
                offense: offense,
                sanction: sanction,
                lastName: lastName,
                firstName: firstName,
                course: course))
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    string updatedAYCode = updateForm.AYCode;
                    string updatedCourse = updateForm.Course;
                    string updatedViolation = updateForm.Violation;
                    string updatedOffense = updateForm.Offense;
                    string updatedSanction = updateForm.Sanction;

                    string queryUpdateViolationFields = "UPDATE tblViolations SET [AY-Code] = ?, [Course] = ?, [Violation] = ?, [Offense Type] = ?, [Sanction] = ? WHERE [Violation ID] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmdViolationFields = new OleDbCommand(queryUpdateViolationFields, conn))
                        {
                            cmdViolationFields.Parameters.AddWithValue("@AYCode", updatedAYCode);
                            cmdViolationFields.Parameters.AddWithValue("@Course", updatedCourse);
                            cmdViolationFields.Parameters.AddWithValue("@Violation", updatedViolation);
                            cmdViolationFields.Parameters.AddWithValue("@Offense", updatedOffense);
                            cmdViolationFields.Parameters.AddWithValue("@Sanction", updatedSanction);
                            cmdViolationFields.Parameters.AddWithValue("@ViolationID", violationID);

                            await cmdViolationFields.ExecuteNonQueryAsync();
                        }
                    }

                    List<string> changes = new List<string>();

                    if (course != updatedCourse)
                        changes.Add($"Course: {updatedCourse}");
                    if (violation != updatedViolation)
                        changes.Add($"Violation: {updatedViolation}");
                    if (offense != updatedOffense)
                        changes.Add($"Offense Type: {updatedOffense}");
                    if (sanction != updatedSanction)
                        changes.Add($"Sanction: {updatedSanction}");

                    if (changes.Count > 0)
                    {
                        string changesSummary = string.Join(" ", changes);
                        LogActivity("Update", $"Violation record details for {firstName} {lastName} were updated. \nChanges: \n{changesSummary}", userName);
                    }

                    
                }

                await Task.WhenAll(LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
                NotifyDataChanged();
            }
        }
        private async void MoveToTrash(DataGridViewRow row)
        {
            string violationID = row.Cells["Violation ID"].Value.ToString();
            string lastName = row.Cells["Last Name"].Value.ToString();
            string firstName = row.Cells["First Name"].Value.ToString();
            string violation = row.Cells["Violation"].Value.ToString();

            DialogResult initialResult = CustomMessageBox.Show(
                $"Moving this record to trash will mark the violation and associated records for {firstName} {lastName} as deleted. Are you sure you want to proceed?",
                "Confirm Move to Trash",
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
                            // Update the IsDeleted field to True
                            string moveToTrashQuery = "UPDATE tblViolations SET [IsDeleted] = True WHERE [Violation ID] = ?";
                            using (OleDbCommand moveToTrashCmd = new OleDbCommand(moveToTrashQuery, conn, transaction))
                            {
                                moveToTrashCmd.Parameters.AddWithValue("@ViolationID", violationID);

                                await moveToTrashCmd.ExecuteNonQueryAsync();

                                transaction.Commit();

                                CustomMessageBox.Show(
                                    $"Violation record {violation} for {firstName} {lastName} has been moved to trash!",
                                    "Successfully Moved to Trash",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            CustomMessageBox.Show(
                                "An error occurred while moving the record to trash: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }

                LogActivity("Trash", $"Violation record {violation} for {firstName} {lastName} was moved to trash.", userName);
                await Task.WhenAll(LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
                NotifyDataChanged();
            }
        }

        public void SendViolationEmailToStudent(string studentId, string violation, DateTime violationDate)
        {
            string studentEmail = string.Empty;
            string studentName = string.Empty;
            string senderEmail = string.Empty;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    connection.Open();

                    // Query to get student details (First Name, Last Name, Email) from tblStudents
                    string studentQuery = @"
                    SELECT [First Name], [Last Name], [Email]
                    FROM tblStudents
                    WHERE [Student ID] = @StudentID";

                    using (OleDbCommand studentCommand = new OleDbCommand(studentQuery, connection))
                    {
                        studentCommand.Parameters.AddWithValue("@StudentID", studentId);
                        OleDbDataReader reader = studentCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            studentEmail = reader["Email"].ToString();
                            string firstName = reader["First Name"].ToString();
                            string lastName = reader["Last Name"].ToString();
                            studentName = $"{firstName} {lastName}";  // Concatenate first and last name
                        }
                    }

                    // Query to get the sender's email from tblUser
                    string query = "SELECT [Email] FROM tblUser WHERE [User ID] = @userId";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                senderEmail = reader["Email"].ToString();
                            }
                        }
                    }

                    connection.Close();
                }

                // If both student and sender emails are found, send the email
                if (!string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(senderEmail))
                {
                    SendViolationEmail(senderEmail, studentEmail, studentName, violation, violationDate);
                }
                else
                {
                    CustomMessageBox.Show("No email address was found associated with this account.", "Email Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendViolationEmail(string senderEmail, string studentEmail, string studentName, string violation, DateTime violationDate)
        {
            using (EmailForm emailForm = new EmailForm())
            {
                emailForm.StudentEmail = studentEmail;
                emailForm.SenderEmail = senderEmail;

                if (emailForm.ShowDialog() == DialogResult.OK)
                {
                    string senderPassword = emailForm.SenderPassword;

                    try
                    {
                        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                        {
                            smtpClient.Port = 587;
                            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                            smtpClient.EnableSsl = true;
                            smtpClient.Timeout = 10000;

                            MailMessage mailMessage = new MailMessage();
                            mailMessage.From = new MailAddress(senderEmail, "Student Affairs Office");
                            mailMessage.To.Add(studentEmail);
                            mailMessage.Subject = "Violation Notification";
                            mailMessage.Body = $"Dear {studentName},\n\n" +
                                               $"You have been recorded for the following violation:\n" +
                                               $"{violation}\n" +
                                               $"Date: {violationDate.ToShortDateString()}\n\n" +
                                               "Please take the necessary actions to address this issue.\n\n" +
                                               "Regards,\nYour School Student Affairs";
                            smtpClient.Send(mailMessage);
                        }

                        CustomMessageBox.Show("Your email has been successfully sent!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogActivity("Email", $"Email has been successfully sent to {studentName}.", userName);
                    }
                    catch (SmtpException smtpEx)
                    {
                        CustomMessageBox.Show($"SMTP Error: {smtpEx.StatusCode} - {smtpEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"There was an error sending your email: {ex.Message}\n{ex.StackTrace}", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void txtSearchRecord__TextChanged(object sender, EventArgs e)
        {
            string searchInput = txtSeachRecord.TrimText();
            string selectedAyCode = cbFilter.SelectedItem?.ToString();

            if (txtSeachRecord.IsEmpty())
            {
                if (selectedAyCode == "Show All")
                {
                    await Task.WhenAll(LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
                }
                else
                {
                    await Task.WhenAll(LoadStudentViolationCountsAsync(selectedAyCode), LoadDataFromDatabaseAsync(selectedAyCode));
                }
            }
            else
            {
                if (selectedAyCode != "Show All")
                {
                    await Task.WhenAll(RecordsDVGSearchAsync(searchInput, selectedAyCode), ViolationsDVGSearchAsync(searchInput, selectedAyCode));
                }
                else
                {
                    await Task.WhenAll(RecordsDVGSearchAsync(searchInput), ViolationsDVGSearchAsync(searchInput));
                }
            }
        }

        private async Task RecordsDVGSearchAsync(string searchTerm, string selectedAycode = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
            {
                return;
            }

            StringBuilder qViolationRecords = new StringBuilder(@"
        SELECT 
            tblViolations.[AY-Code], 
            tblViolations.[Student ID], 
            tblStudents.[Last Name], 
            tblStudents.[First Name], 
            Count(tblViolations.[Violation ID]) AS [Recorded Violations]
        FROM 
            tblViolations 
        INNER JOIN
            tblStudents ON tblViolations.[Student ID] = tblStudents.[Student ID]
        WHERE
            ([tblViolations].[Student ID] LIKE? OR [tblStudents].[Last Name] LIKE?)");

            if (!string.IsNullOrEmpty(selectedAycode))
            {
                qViolationRecords.Append(" AND tblViolations.[AY-Code] = ?");
            }

            qViolationRecords.Append(" GROUP BY tblViolations.[AY-Code], tblViolations.[Student ID], tblStudents.[Last Name], tblStudents.[First Name]");

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(qViolationRecords.ToString(), conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("?", "%" + searchTerm + "%"); // Student ID
                    adapter.SelectCommand.Parameters.AddWithValue("?", searchTerm + "%"); // Last Name

                    if (!string.IsNullOrEmpty(selectedAycode))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("?", selectedAycode); // AY-Code
                    }

                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    recordsDGV.DataSource = dt;

                    FormatRecordsDGV();
                }
            }

            if (recordsDGV.Columns.Contains("btnView"))
            {
                recordsDGV.Columns.Remove("btnView");
            }

            DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
            {
                HeaderText = "View",
                Name = "btnView",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            recordsDGV.Columns.Add(btnAction);

            btnAction.DisplayIndex = recordsDGV.Columns.Count - 1;

            recordsDGV.Refresh();
        }

        private async Task ViolationsDVGSearchAsync(string searchTerm, string selectedAycode = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
            {
                return;
            }

            StringBuilder allViolationsQuery = new StringBuilder(@"
            SELECT
                tblViolations.[AY-Code],
                tblViolations.[Date], 
                tblViolations.[Student ID],
                tblStudents.[Last Name],
                tblStudents.[First Name], 
                tblStudents.[Course], 
                tblViolations.[Violation],
                tblViolations.[Offense Type],
                tblViolations.[Sanction]
            FROM 
                tblViolations
            INNER JOIN
                tblStudents ON tblViolations.[Student ID] = tblStudents.[Student ID]
             WHERE
                ([tblViolations].[Student ID] LIKE? OR [tblStudents].[Last Name] LIKE?)");

            if (!string.IsNullOrEmpty(selectedAycode))
            {
                allViolationsQuery.Append(" AND tblViolations.[AY-Code] = ?");
            }

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(allViolationsQuery.ToString(), conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("?", "%" + searchTerm + "%"); // Student ID
                    adapter.SelectCommand.Parameters.AddWithValue("?", searchTerm + "%"); // Last Name

                    if (!string.IsNullOrEmpty(selectedAycode))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("?", selectedAycode); // AY-Code
                    }

                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    violationsDGV.DataSource = dt;

                    FormatDataGridView();
                }
            }

            if (violationsDGV.Columns.Contains("btnAction"))
            {
                violationsDGV.Columns.Remove("btnAction");
            }

            DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
            {
                HeaderText = "Manage",
                Name = "btnAction",
                Width = 80
            };

            violationsDGV.Columns.Add(btnAction);

            btnAction.DisplayIndex = violationsDGV.Columns.Count - 1;

            violationsDGV.Refresh();
        }

        private async Task LoadAYCodesAsync()
        {
            string violationsQuery = "SELECT DISTINCT [AY-Code] FROM tblViolations";

            string activeAYQuery = "SELECT [AY-Code], [Status] FROM qActiveAY";

            DataTable dtViolations = new DataTable();
            DataTable dtActiveAY = new DataTable();
            string activeAYCode = null;

            await Task.Run(() =>
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    try
                    {
                        connection.Open();

                        using (OleDbCommand commandViolations = new OleDbCommand(violationsQuery, connection))
                        {
                            OleDbDataAdapter adapter = new OleDbDataAdapter(commandViolations);
                            adapter.Fill(dtViolations);
                        }

                        using (OleDbCommand commandActiveAY = new OleDbCommand(activeAYQuery, connection))
                        {
                            OleDbDataAdapter adapter = new OleDbDataAdapter(commandActiveAY);
                            adapter.Fill(dtActiveAY);
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Error loading AY-Codes: " + ex.Message);
                    }
                }
            });

            cbFilter.DropDownStyle = ComboBoxStyle.DropDown;
            cbFilter.Items.Clear();
            cbFilter.Items.Add("Show All");

            if (dtActiveAY.Rows.Count > 0)
            {
                DataRow activeRow = dtActiveAY.Rows[0];
                activeAYCode = activeRow["AY-Code"].ToString();
            }

            foreach (DataRow row in dtViolations.Rows)
            {
                string ayCode = row["AY-Code"].ToString();
                cbFilter.Items.Add(ayCode);
            }

            if (!string.IsNullOrEmpty(activeAYCode))
            {
                cbFilter.SelectedItem = activeAYCode;
            }
            else
            {
                cbFilter.SelectedIndex = 0;
            }
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAYCode = cbFilter.SelectedItem.ToString();

            if (selectedAYCode == "Show All")
            {
                await Task.WhenAll(LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
            }
            else
            {
                await Task.WhenAll(LoadStudentViolationCountsAsync(selectedAYCode), LoadDataFromDatabaseAsync(selectedAYCode));
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

        private async void btnAddViolation_Click(object sender, EventArgs e)
        {
            bool isValidAY = await ValidateAcademicYearAsync();

            if (!isValidAY)
            {
                return;
            }

            using (VioEntryForm addForm = new VioEntryForm(isUpdate: false))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string newAYCode = addForm.AYCode;
                        string newStudentID = addForm.StudentID;
                        string newCourse = addForm.Course;
                        string newViolation = addForm.Violation;
                        string newOffense = addForm.Offense;
                        string newSanction = addForm.Sanction;

                        string query = "INSERT INTO tblViolations ([AY-Code], [Student ID], [Course], [Violation], [Offense Type], [Sanction]) VALUES (?, ?, ?, ?, ?, ?)";

                        using (OleDbConnection conn = new OleDbConnection(DbConn))
                        {
                            await conn.OpenAsync();
                            using (OleDbCommand cmd = new OleDbCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@AY-Code", newAYCode);
                                cmd.Parameters.AddWithValue("@Student ID", newStudentID);
                                cmd.Parameters.AddWithValue("@Course", newCourse);
                                cmd.Parameters.AddWithValue("@Violation", newViolation);
                                cmd.Parameters.AddWithValue("@Offense", newOffense);
                                cmd.Parameters.AddWithValue("@Sanction", newSanction);
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("An error occurred while adding the violation: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string studentName = $"{addForm.FirstName} {addForm.LastName}";
                    LogActivity("Add", $"Violation record for {studentName} was successfully added to the system.", userName);
                }

                await Task.WhenAll(LoadAYCodesAsync(), LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
                NotifyDataChanged();
            }
        }

        private async Task<bool> ValidateAcademicYearAsync()
        {
            string activeAYQuery = "SELECT [DateCreated] FROM tblAcadYear WHERE [Status] = True";
            string mostRecentAYQuery = "SELECT MAX([DateCreated]) AS MostRecentDate FROM tblAcadYear";

            DateTime activeDateCreated;
            DateTime mostRecentDateCreated;

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    await conn.OpenAsync();

                    using (OleDbCommand activeCmd = new OleDbCommand(activeAYQuery, conn))
                    {
                        object activeResult = await activeCmd.ExecuteScalarAsync();
                        if (activeResult != null)
                        {
                            activeDateCreated = Convert.ToDateTime(activeResult);
                        }
                        else
                        {
                            CustomMessageBox.Show("No active academic year found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    using (OleDbCommand recentCmd = new OleDbCommand(mostRecentAYQuery, conn))
                    {
                        object recentResult = await recentCmd.ExecuteScalarAsync();
                        if (recentResult != null)
                        {
                            mostRecentDateCreated = Convert.ToDateTime(recentResult);
                        }
                        else
                        {
                            CustomMessageBox.Show("No academic year records found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    if (activeDateCreated < mostRecentDateCreated)
                    {
                        var result = CustomMessageBox.Show(
                            "You are adding a violation record for an older academic year. Do you want to proceed?",
                            "Warning",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation
                        );

                        if (result == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("An error occurred during validation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private async void btnReloadDB_Click(object sender, EventArgs e)
        {
            string selectedAYCode = cbFilter.SelectedItem?.ToString();

            btnReloadDB.Visible = false;
            loadingProgressBar.Visible = true;

            try
            {
                if (selectedAYCode == "Show All") 
                {
                    await Task.WhenAll(LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
                } else
                {
                    await Task.WhenAll(LoadAYCodesAsync(), LoadStudentViolationCountsAsync(), LoadDataFromDatabaseAsync());
                }
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

        private void ExportDataGridViewToPDF(DataGridView dgv, string filePath)
        {
            XUnit margin = XUnit.FromInch(0.5);
            double headerHeight = 25;

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Exported Data";

            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Landscape;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 10, XFontStyleEx.Regular);
            XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
            XFont footerFont = new XFont("Arial", 8, XFontStyleEx.Italic);

            XSolidBrush headerBrush = new XSolidBrush(XColors.LightGray);
            XSolidBrush textBrush = new XSolidBrush(XColors.Black);
            XPen borderPen = new XPen(XColors.Black);

            double padding = 5;

            double yPos = margin.Point;

            double availableWidth = page.Width.Point - 2 * margin.Point;
            double colWidth = availableWidth / dgv.Columns.Count;

            DrawHeaderTitle(gfx, "SVMS: Violation Records Report", margin, availableWidth, headerFont);
            DrawExportDate(gfx, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), margin, availableWidth, footerFont);
            yPos += headerHeight;

            DrawHeaders(gfx, dgv, margin.Point, colWidth, headerBrush, headerFont, textBrush, ref yPos, headerHeight);

            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                if (!dgv.Rows[rowIndex].IsNewRow)
                {
                    double maxRowHeight = 0;

                    for (int colIndex = 0; colIndex < dgv.Columns.Count; colIndex++)
                    {
                        object cellValueObj = dgv.Rows[rowIndex].Cells[colIndex].Value;
                        string cellValue = cellValueObj?.ToString() ?? string.Empty;

                        if (cellValueObj is DateTime dateValue)
                        {
                            cellValue = dateValue.ToString("yyyy-MM-dd");
                        }

                        XRect cellRect = new XRect(
                            margin.Point + colIndex * colWidth + padding,
                            yPos + padding,
                            colWidth - 2 * padding,
                            double.MaxValue
                        );

                        double cellContentHeight = DrawStringVerticallyCentered(gfx, cellValue, font, textBrush, cellRect, true);

                        if (cellContentHeight > maxRowHeight)
                        {
                            maxRowHeight = cellContentHeight + 2 * padding;
                        }
                    }

                    for (int colIndex = 0; colIndex < dgv.Columns.Count; colIndex++)
                    {
                        object cellValueObj = dgv.Rows[rowIndex].Cells[colIndex].Value;
                        string cellValue = cellValueObj?.ToString() ?? string.Empty;

                        if (cellValueObj is DateTime dateValue)
                        {
                            cellValue = dateValue.ToString("yyyy-MM-dd");
                        }

                        XRect cellRect = new XRect(
                            margin.Point + colIndex * colWidth + padding,
                            yPos + padding,
                            colWidth - 2 * padding,
                            maxRowHeight - 2 * padding
                        );

                        DrawStringVerticallyCentered(gfx, cellValue, font, textBrush, cellRect, true);

                        gfx.DrawRectangle(borderPen, margin.Point + colIndex * colWidth, yPos, colWidth, maxRowHeight);
                    }

                    gfx.DrawRectangle(borderPen, margin.Point, yPos, availableWidth, maxRowHeight);

                    yPos += maxRowHeight;

                    if (yPos > page.Height.Point - margin.Point - maxRowHeight)
                    {
                        AddPageFooter(gfx, document.PageCount, footerFont, margin, availableWidth);

                        page = document.AddPage();
                        page.Size = PdfSharp.PageSize.A4;
                        page.Orientation = PdfSharp.PageOrientation.Landscape;
                        gfx = XGraphics.FromPdfPage(page);
                        yPos = margin.Point;

                        DrawHeaderTitle(gfx, "SVMS: Violation Records Report", margin, availableWidth, headerFont);
                        DrawExportDate(gfx, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), margin, availableWidth, footerFont);
                        yPos += headerHeight;

                        DrawHeaders(gfx, dgv, margin.Point, colWidth, headerBrush, headerFont, textBrush, ref yPos, headerHeight);
                    }
                }
            }

            AddPageFooter(gfx, document.PageCount, footerFont, margin, availableWidth);
            document.Save(filePath);
            document.Close();
        }
        private void DrawHeaderTitle(XGraphics gfx, string title, XUnit margin, double pageWidth, XFont headerFont)
        {
            gfx.DrawString(title, headerFont, XBrushes.Black, new XRect(margin.Point, margin.Point, pageWidth - 2 * margin.Point, 25), XStringFormats.TopLeft);
        }
        private void DrawExportDate(XGraphics gfx, string date, XUnit margin, double pageWidth, XFont footerFont)
        {
            gfx.DrawString(date, footerFont, XBrushes.Black, new XRect(pageWidth - margin.Point, margin.Point, margin.Point, 25), XStringFormats.TopRight);
        }
        private void AddPageFooter(XGraphics gfx, int pageNumber, XFont footerFont, XUnit margin, double pageWidth)
        {
            double footerOffset = 0;
            double footerYPosition = gfx.PdfPage.Height.Point - margin.Point - footerOffset;

            gfx.DrawString($"Page {pageNumber}", footerFont, XBrushes.Black, new XRect(margin.Point, footerYPosition, pageWidth - 2 * margin.Point, 25), XStringFormats.TopLeft);
        }
        private void DrawHeaders(XGraphics gfx, DataGridView dgv, double margin, double colWidth, XSolidBrush headerBrush, XFont headerFont, XBrush textBrush, ref double yPos, double headerHeight)
        {
            double padding = 5;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                string headerText = dgv.Columns[i].HeaderText;

                gfx.DrawRectangle(headerBrush, margin + i * colWidth, yPos, colWidth, headerHeight);

                XRect headerRect = new XRect(
                    margin + i * colWidth + padding,
                    yPos + padding,
                    colWidth - 2 * padding,
                    headerHeight - 2 * padding
                );

                gfx.DrawString(headerText, headerFont, textBrush, headerRect, XStringFormats.TopCenter);

                gfx.DrawRectangle(XPens.Black, margin + i * colWidth, yPos, colWidth, headerHeight);
            }

            yPos += headerHeight;
        }
        private double DrawStringVerticallyCentered(XGraphics gfx, string text, XFont font, XBrush brush, XRect rect, bool allowMultiline = true)
        {
            double lineHeight = gfx.MeasureString("A", font).Height;
            double currentY = rect.Y;
            double requiredHeight = lineHeight;

            if (allowMultiline)
            {
                double maxWidth = rect.Width;
                string[] words = text.Split(' ');
                string currentLine = "";

                foreach (string word in words)
                {
                    if (gfx.MeasureString(currentLine + word + " ", font).Width > maxWidth)
                    {
                        gfx.DrawString(currentLine.TrimEnd(), font, brush, new XRect(rect.X, currentY, rect.Width, lineHeight), XStringFormats.TopLeft);
                        currentY += lineHeight;
                        currentLine = word + " ";
                        requiredHeight += lineHeight;
                    }
                    else
                    {
                        currentLine += word + " ";
                    }
                }

                if (!string.IsNullOrEmpty(currentLine))
                {
                    gfx.DrawString(currentLine.TrimEnd(), font, brush, new XRect(rect.X, currentY, rect.Width, lineHeight), XStringFormats.TopLeft);
                    requiredHeight += lineHeight;
                }
            }
            else
            {
                XSize textSize = gfx.MeasureString(text, font);
                double yCenter = rect.Y + (rect.Height - textSize.Height) / 2;
                gfx.DrawString(text, font, brush, new XRect(rect.X, yCenter, rect.Width, textSize.Height), XStringFormats.TopLeft);
            }

            return requiredHeight;
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            DialogResult localResult = CustomMessageBox.Show(
                "Do you want to generate a PDF report for the selected data?",
                "Generate PDF Report",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                //Remove unneccesary column for report temporarily
                if (violationsDGV.Columns.Contains("btnAction"))
                {
                    violationsDGV.Columns.Remove("btnAction");
                }

                if (violationsDGV.Columns.Contains("Violation ID"))
                {
                    violationsDGV.Columns.Remove("Violation ID");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save a PDF File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportDataGridViewToPDF(violationsDGV, saveFileDialog.FileName);
                        CustomMessageBox.Show("The report has been successfully generated as a PDF. You can find it in the specified location.",
                                              "PDF Report Generated",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Information);
                        
                        btnReloadDB_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"An error occurred while generating the PDF report: {ex.Message}",
                                              "Error",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error);

                        btnReloadDB_Click(sender, e);
                    }
                }
            }
        }
    }
}
