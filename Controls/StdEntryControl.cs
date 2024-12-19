using SVMS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace SVMS.Controls
{
    public partial class StdEntryControl : UserControl
    {
        private string DbConn;
        private string userRole;
        private string userName;

        public event Action OnDataChanged;

        public DataTable StudentsDataSource
        {
            get { return (DataTable)studentsDGV.DataSource; }
        }

        private ToolTip toolTip = new ToolTip();

        public StdEntryControl(string role, string username)
        {
            InitializeComponent();
            userRole = role;
            userName = username;
            DbConn = GetDbConnectionString();
            toolTip.SetToolTip(btnReloadDB, "Reload Students' Data");
            toolTip.SetToolTip(btnAddStudent, "Add New Student");

            txtActiveAYCode.SetReadOnly(true);
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
            await LoadCourseSectionsAsync();
            await LoadAYCodeAsync();
        }

        private async Task<bool> CheckStudentIDExistsAsync(string studentID)
        {
            string query = "SELECT COUNT(*) FROM tblStudents WHERE [Student ID] = ?";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbCommand command = new OleDbCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    await conn.OpenAsync();
                    int count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        private async Task<bool> CheckCourseExistsAsync(string course)
        {
            string query = "SELECT COUNT(*) FROM tblStudents WHERE [Course] = ?";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                await conn.OpenAsync();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Course", course);

                    int count = (int)await cmd.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        private async Task LoadAYCodeAsync()
        {
            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    await conn.OpenAsync();
                    string query = "SELECT [AY-Code] FROM tblAcadYear WHERE [Status] = True";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        object ayCodeObj = await cmd.ExecuteScalarAsync();
                        if (ayCodeObj != null)
                        {
                            string ayCode = ayCodeObj.ToString();
                            txtActiveAYCode.Texts = ayCode;
                        }
                        else
                        {
                            txtActiveAYCode.Texts = "N/A";
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"An error occurred while retrieving the academic year.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private async Task LoadDataFromDatabaseAsync(string studentIDFilter = null, string CourseFilter = null)
        {
            if (!string.IsNullOrEmpty(studentIDFilter))
            {
                if (!await CheckStudentIDExistsAsync(studentIDFilter))
                {
                    CustomMessageBox.Show($"No Student is associated with this ID: '{studentIDFilter.ToUpper()}'. This ID might not exist.", "Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    studentIDFilter = null;
                }
            }

            // Main query to fetch students based on active AY-Code
            string query = @"
        SELECT 
            tblStudents.[Student ID], 
            tblStudents.[AY-Code], 
            tblStudents.[Last Name], 
            tblStudents.[First Name], 
            tblStudents.[Course], 
            tblStudents.[Address], 
            tblStudents.[Contact No], 
            tblStudents.[Email] 
        FROM tblStudents
        INNER JOIN qActiveAY 
            ON tblStudents.[AY-Code] = qActiveAY.[AY-Code]
        WHERE 
            qActiveAY.[Status] = True AND
            tblStudents.[IsDeleted] = False";

            // Add filters if provided
            if (!string.IsNullOrEmpty(studentIDFilter) || !string.IsNullOrEmpty(CourseFilter))
            {
                query += " AND";

                if (!string.IsNullOrEmpty(studentIDFilter))
                {
                    query += " [Student ID] LIKE ?";
                }

                if (!string.IsNullOrEmpty(CourseFilter))
                {
                    if (!string.IsNullOrEmpty(studentIDFilter))
                    {
                        query += " AND";
                    }
                    query += " [Course] LIKE ?";
                }
            }

            // Sorting logic
            query += " ORDER BY [Course], [Last Name], [First Name]";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    // Add parameters for filtering if needed
                    if (!string.IsNullOrEmpty(studentIDFilter))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@StudentID", "%" + studentIDFilter + "%");
                    }
                    if (!string.IsNullOrEmpty(CourseFilter))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@Course", "%" + CourseFilter + "%");
                    }

                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    // Process the data rows (e.g., format names and contact numbers)
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Last Name"] = ToProperCase(row["Last Name"].ToString());
                        row["First Name"] = ToProperCase(row["First Name"].ToString());
                        row["Address"] = ToProperCase(row["Address"].ToString());

                        string contactNo = row["Contact No"].ToString();
                        row["Contact No"] = FormatPhoneNumber(contactNo);
                    }

                    studentsDGV.DataSource = dt;
                }

                FormatDataGridView();

                if (!studentsDGV.Columns.Contains("btnAction") && userRole != "Authorized User")
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "Manage",
                        Name = "btnAction",
                        UseColumnTextForButtonValue = true
                    };
                    studentsDGV.Columns.Add(btnAction);
                }

                if (studentsDGV.Columns["AY-Code"] != null)
                {
                    studentsDGV.Columns["AY-Code"].Visible = false;
                }

                studentsDGV.Refresh();
            }
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = cbFilter.SelectedItem?.ToString();

            if (selectedCourse == "Show All")
            {
                await LoadDataFromDatabaseAsync();
                txtSearchID.Clear();
            }
            else
            {
                await LoadDataFromDatabaseAsync(CourseFilter: selectedCourse);
                txtSearchID.Clear();
            }
        }

        #region -> Load Courses
        private async Task LoadCourseSectionsAsync()
        {
            await Task.Run(() =>
            {
                string query = "SELECT DISTINCT [Course] FROM tblStudents";

                using (OleDbConnection conn = new OleDbConnection(DbConn))
                {
                    try
                    {
                        conn.Open();

                        using (OleDbCommand command = new OleDbCommand(query, conn))
                        {
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                cbFilter.Invoke((MethodInvoker)delegate
                                {
                                    cbFilter.Items.Clear();
                                    cbFilter.Items.Add("Show All");
                                });

                                while (reader.Read())
                                {
                                    if (reader["Course"] != DBNull.Value)
                                    {
                                        string CourseSection = reader["Course"].ToString();

                                        cbFilter.Invoke((MethodInvoker)delegate
                                        {
                                            cbFilter.Items.Add(CourseSection);
                                        });
                                    }
                                }
                            }

                            cbFilter.Invoke((MethodInvoker)delegate
                            {
                                cbFilter.SelectedIndex = 0;
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Error loading Course data: " + ex.Message);
                    }
                }
            });
        }
        #endregion

        #region -> Format DGV
        private void FormatDataGridView()
        {
            studentsDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            studentsDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            studentsDGV.EnableHeadersVisualStyles = false;

            studentsDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            studentsDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            studentsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            studentsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            studentsDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            studentsDGV.DefaultCellStyle.ForeColor = Color.Black;

            studentsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            studentsDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            studentsDGV.DefaultCellStyle.SelectionBackColor = studentsDGV.DefaultCellStyle.BackColor;
            studentsDGV.DefaultCellStyle.SelectionForeColor = studentsDGV.DefaultCellStyle.ForeColor;

            studentsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = studentsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            studentsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = studentsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            studentsDGV.GridColor = Color.FromArgb(180, 180, 180);

            studentsDGV.ColumnHeadersHeight = 40;
            studentsDGV.RowTemplate.Height = 30;

            studentsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            studentsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            studentsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            studentsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            studentsDGV.AllowUserToResizeColumns = false;
            studentsDGV.AllowUserToResizeRows = false;
            studentsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            studentsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            studentsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in studentsDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Address")
                {
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                }
                else if (column.HeaderText == "Student ID")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
        }
        #endregion
        private async void StdEntryControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            
            loadingProgressBar.Visible = false;
            txtSearchID.TextChanged += txtSearchID__TextChanged;
            studentsDGV.CellPainting += studentsDGV_CellPainting;
            studentsDGV.CellClick += studentsDGV_CellClick;

            await Task.WhenAll(LoadAYCodeAsync(), LoadCourseSectionsAsync(), LoadDataFromDatabaseAsync());

            await Task.Delay(500);
            btnReloadDB_Click(sender, e);
        }

        #region -> CellPainting/CellClick
        private void studentsDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (studentsDGV.Columns["btnAction"] == null)
                return;

            if (e.ColumnIndex == studentsDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
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

                studentsDGV.Rows[e.RowIndex].Tag = new { UpdateIconRect = updateIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }
        private void studentsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == studentsDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = studentsDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle updateIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;

                    Point mousePosition = studentsDGV.PointToClient(Cursor.Position);

                    if (updateIconRect.Contains(mousePosition))
                    {
                        UpdateRecord(selectedRow); // Admin or other roles can update
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        MoveToTrash(selectedRow); // Admin or other roles can delete
                    }
                }
            }
        }
        #endregion

        #region -> Add/Update/Delete
        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            bool isValidAY = await ValidateAcademicYearAsync();

            if (!isValidAY)
            {
                return;
            }

            using (StudentEntryForm addForm = new StudentEntryForm(isUpdate: false))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    string newStudentID = addForm.StudentID;
                    string newAYCode = addForm.AYCode;
                    string newLastname = addForm.LastName;
                    string newFirstName = addForm.FirstName;
                    string newCourse = addForm.Course;
                    string newAddress = addForm.Address;
                    string newContactNo = addForm.ContactNo;
                    string newEmail = addForm.Email;

                    string query = "INSERT INTO tblStudents ([Student ID], [AY-Code], [Last Name], [First Name], [Course], [Address], [Contact No], [Email]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", newStudentID);
                            cmd.Parameters.AddWithValue("@AY-Code", newAYCode);
                            cmd.Parameters.AddWithValue("@LastName", newLastname);
                            cmd.Parameters.AddWithValue("@FirstName", newFirstName);
                            cmd.Parameters.AddWithValue("@Course", newCourse);
                            cmd.Parameters.AddWithValue("@Address", newAddress);
                            cmd.Parameters.AddWithValue("@ContactNo", newContactNo);
                            cmd.Parameters.AddWithValue("@Email", newEmail);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    LogActivity("Add", $"Student with ID No. {newStudentID} was successfully added to the system.", userName);
                    await LoadDataFromDatabaseAsync();

                    if (!cbFilter.Items.Contains(newCourse))
                    {
                        await LoadCourseSectionsAsync();
                    }
                }

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
                            "You are adding a record for an older academic year. Do you want to proceed?",
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

        private async void UpdateRecord(DataGridViewRow row)
        {
            string studentID = row.Cells["Student ID"].Value.ToString();
            string ayCode = row.Cells["AY-Code"].Value.ToString();
            string lastName = row.Cells["Last Name"].Value.ToString();
            string firstName = row.Cells["First Name"].Value.ToString();
            string course = row.Cells["Course"].Value.ToString();
            string address = row.Cells["Address"].Value.ToString();
            string contactNo = row.Cells["Contact No"].Value.ToString();
            string email = row.Cells["Email"].Value.ToString();

            using (StudentEntryForm updateForm = new StudentEntryForm(
                isUpdate: true,
                studentID: studentID,
                ayCode: ayCode,
                lastName: lastName,
                firstName: firstName,
                course: course,
                address: address,
                contactNo: contactNo,
                email: email))
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    string query = "UPDATE tblStudents SET [Student ID] = ?, [AY-Code] = ?, [Last Name] = ?, [First Name] = ?, [Course] = ?, [Address] = ?, [Contact No] = ?, [Email] = ? WHERE [Student ID] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", updateForm.StudentID);
                            cmd.Parameters.AddWithValue("@AY-Code", updateForm.AYCode);
                            cmd.Parameters.AddWithValue("@LastName", updateForm.LastName);
                            cmd.Parameters.AddWithValue("@FirstName", updateForm.FirstName);
                            cmd.Parameters.AddWithValue("@CourseSection", updateForm.Course);
                            cmd.Parameters.AddWithValue("@Address", updateForm.Address);
                            cmd.Parameters.AddWithValue("@ContactNo", updateForm.ContactNo);
                            cmd.Parameters.AddWithValue("@Email", updateForm.Email);
                            cmd.Parameters.AddWithValue("@OldStudentID", studentID);

                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    List<string> changes = new List<string>();

                    if (studentID != updateForm.StudentID)
                        changes.Add($"Student ID: {updateForm.StudentID}");
                    if (ayCode != updateForm.AYCode)
                        changes.Add($"AY-Code: {updateForm.AYCode}");
                    if (lastName != updateForm.LastName)
                        changes.Add($"Last Name: {updateForm.LastName}");
                    if (firstName != updateForm.FirstName)
                        changes.Add($"First Name: {updateForm.FirstName}");
                    if (course != updateForm.Course)
                        changes.Add($"Course: {updateForm.Course}");
                    if (address != updateForm.Address)
                        changes.Add($"Address: {updateForm.Address}");
                    if (contactNo != updateForm.ContactNo)
                        changes.Add($"Contact No: {updateForm.ContactNo}");
                    if (email != updateForm.Email)
                        changes.Add($"Email: {updateForm.Email}");

                    if (changes.Count > 0)
                    {
                        string changesSummary = string.Join(", ", changes);
                        LogActivity("Update", $"Information for the student with ID No. {studentID} has been updated. \nChanges: \n{changesSummary}", userName);
                    }

                    await LoadDataFromDatabaseAsync();
                }

                NotifyDataChanged();
            }
        }
        private async void MoveToTrash(DataGridViewRow row)
        {
            string studentID = row.Cells["Student ID"].Value.ToString();
            string firstName = row.Cells["First Name"].Value.ToString();
            string lastName = row.Cells["Last Name"].Value.ToString();
            string course = row.Cells["Course"].Value.ToString();

            DialogResult result = CustomMessageBox.Show($"Moving this student record to trash will remove it from active views, but it can be restored later. Are you sure you want to proceed with moving {firstName.ToUpper()} {lastName.ToUpper()} to trash?", "Confirm Move to Trash", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE tblStudents SET IsDeleted = True WHERE [Student ID] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", studentID);
                            await cmd.ExecuteNonQueryAsync();

                            CustomMessageBox.Show($"Student record for {firstName} {lastName} has been moved to trash.", "Successfully Moved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("An error occurred while moving the student record to trash: " + ex.Message, "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LogActivity("Move", $"Student with ID No. {studentID} was moved to trash.", userName);

            
            await LoadDataFromDatabaseAsync();

            if (!await CheckCourseExistsAsync(course))
            {
                cbFilter.Items.Remove(course);
            }

            NotifyDataChanged();
        }
        #endregion


        private async void txtSearchID__TextChanged(object sender, EventArgs e)
        {
            string searchInput = txtSearchID.TrimText();
            string selectedCourseSection = cbFilter.SelectedItem?.ToString();

            if (txtSearchID.IsEmpty())
            {
                if (selectedCourseSection == "Show All")
                {
                    await LoadDataFromDatabaseAsync();
                }
                else
                {
                    await LoadDataFromDatabaseAsync(CourseFilter: selectedCourseSection);
                }
            }
            else
            {
                if (selectedCourseSection != "Show All")
                {
                    await SearchByStudentIDOrLastNameAsync(searchInput, selectedCourseSection);
                }
                else
                {
                    await SearchByStudentIDOrLastNameAsync(searchInput);
                }
            }
        }
        private async Task SearchByStudentIDOrLastNameAsync(string searchTerm, string courseSection = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) ||
                searchTerm.Length < 2 ||
                !searchTerm.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                return;
            }

            // Query without AY-Code or active status filtering
            string query = @"
        SELECT [Student ID], [AY-Code], [Last Name], [First Name], [Course], [Address], [Contact No], [Email] 
        FROM tblStudents
        WHERE ([Student ID] LIKE @StudentID OR [Last Name] LIKE @LastName)";

            if (!string.IsNullOrEmpty(courseSection))
            {
                query += " AND [Course] = @Course";
            }

            query += " ORDER BY [Last Name], [First Name]";

            // Execute query and populate DataGridView
            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbCommand command = new OleDbCommand(query, conn))
                {
                    // Add parameters for the query
                    command.Parameters.AddWithValue("@StudentID", "%" + searchTerm + "%");
                    command.Parameters.AddWithValue("@LastName", searchTerm + "%");
                    if (!string.IsNullOrEmpty(courseSection))
                    {
                        command.Parameters.AddWithValue("@Course", courseSection);
                    }

                    DataTable dt = new DataTable();
                    await conn.OpenAsync();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        await Task.Run(() => adapter.Fill(dt));
                    }

                    ProcessDataTableRows(dt);
                    studentsDGV.DataSource = dt;
                }
            }

            if (studentsDGV.Columns.Contains("btnAction"))
            {
                studentsDGV.Columns.Remove("btnAction");
            }

            DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
            {
                HeaderText = "Manage",
                Name = "btnAction",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };

            studentsDGV.Columns.Add(btnAction);

            btnAction.DisplayIndex = studentsDGV.Columns.Count - 1;
            studentsDGV.Refresh();
        }

        private void ProcessDataTableRows(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                row["Last Name"] = ToProperCase(row["Last Name"].ToString());
                row["First Name"] = ToProperCase(row["First Name"].ToString());
                row["Address"] = ToProperCase(row["Address"].ToString());

                string contactNo = row["Contact No"].ToString();
                row["Contact No"] = FormatPhoneNumber(contactNo);
            }
        }

        private async void btnReloadDB_Click(object sender, EventArgs e)
        {

            btnReloadDB.Visible = false;
            loadingProgressBar.Visible = true;
            try
            {
                await Task.WhenAll(LoadDataFromDatabaseAsync(), LoadAYCodeAsync());
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
