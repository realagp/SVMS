using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Globalization;

namespace SVMS.Forms
{
    public partial class VioEntryForm : DropShadow
    {
        private string DbConn;
        public string AYCode { get; private set; }
        public string StudentID { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Course { get; private set; }
        public string Violation { get; private set; }
        public string Offense { get; private set; }
        public string Sanction { get; private set; }
        public bool IsUpdate { get; private set; }
        public VioEntryForm(bool isUpdate, string ayCode = "", string studentID = "", string lastName = "", string firstName = "", string course = "", string violation = "", string offense = "", string sanction = "")
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            IsUpdate = isUpdate;
            AYCode = ayCode;
            StudentID = studentID;
            LastName = lastName;
            FirstName = firstName;
            Course = course;
            Violation = violation;
            Offense = offense;
            Sanction = sanction;

            txtAYCode.SetReadOnly(true);
            txtCourse.SetReadOnly(true);
            txtLastName.SetReadOnly(true);
            txtFirstName.SetReadOnly(true);
            txtStudentID.SetReadOnly(true);

        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private string ToProperCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void VioEntryForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            if (IsUpdate)
            {
                txtAYCode.Texts = AYCode;
                txtStudentID.Texts = StudentID;
                txtLastName.Texts = LastName;
                txtFirstName.Texts = FirstName;
                txtCourse.Texts = Course;
                cbViolation.Texts = Violation;
                cbOffenseType.Texts = Offense;
                cbSanction.Texts = Sanction;
            }
            else
            {
                LoadAYCode();
                ClearFormFields();
            }
        }
        private void LoadAYCode()
        {
            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT [AY-Code] FROM tblAcadYear WHERE [Status] = True";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        object ayCodeObj = cmd.ExecuteScalar();
                        if (ayCodeObj != null)
                        {
                            string ayCode = ayCodeObj.ToString();
                            txtAYCode.Texts = ayCode;
                        }
                        else
                        {
                            txtAYCode.Texts = "N/A";
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"An error occurred while retrieving the academic year.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsViolationDuplicate(string studentID, string violation, DateTime date)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tblViolations WHERE [Student ID] = ? AND [Violation] = ? AND [Date] = ?";

                using (var conn = new OleDbConnection(DbConn))
                {
                    conn.Open();
                    using (var command = new OleDbCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@Violation", violation);
                        command.Parameters.AddWithValue("@Date", date.Date);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool NoChanges(
            string ayCode,
            string studentID,
            string course,
            string violation,
            string action,
            string sanction)
        {
            using (var connection = new OleDbConnection(DbConn))
            {
                string query = "SELECT COUNT(*) FROM tblViolations WHERE [AY-Code] = ? AND [Student ID] = ? AND [Course] = ? AND [Violation] = ? AND [Offense Type] = ? AND [Sanction] = ?";
                using (var cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AY-Code", ayCode);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Course", course);
                    cmd.Parameters.AddWithValue("@Violation", violation);
                    cmd.Parameters.AddWithValue("@Offense", action);
                    cmd.Parameters.AddWithValue("@Sanction", sanction);

                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void cbOffenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected offense type
            string selectedOffenseType = cbOffenseType.SelectedItem?.ToString();

            // Clear the cbViolation ComboBox before loading new violations
            cbViolation.ClearSelection();

            // Populate cbViolation based on the selected offense type
            LoadViolationsBasedOnType(selectedOffenseType);
        }


        // Method to load violations based on selected offense type
        private void LoadViolationsBasedOnType(string offenseType)
        {
            // Clear existing items in cbViolation
            cbViolation.Items.Clear();

            // Query string for the offenses table based on the selected type
            string query = offenseType == "Minor"
                ? "SELECT [Minor Offenses] FROM tblMinorOffenses"
                : "SELECT [Major Offenses] FROM tblMajorOffenses";

            // Connect to the database and retrieve the violations
            try
            {
                using (var conn = new OleDbConnection(DbConn))
                {
                    conn.Open();
                    using (var command = new OleDbCommand(query, conn))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add the violation name to cbViolation
                                cbViolation.Items.Add(reader[0].ToString());
                            }
                        }
                    }

                    // Optionally, ensure no default selection (if you want it blank)
                    cbViolation.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"An error occurred while loading violations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentID = txtSearchID.TrimText();

            if (string.IsNullOrWhiteSpace(studentID))
            {
                CustomMessageBox.Show("Please enter a valid Student ID Number.", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    conn.Open();

                    // Query to search only students with active academic year
                    string query = @"
                SELECT [Student ID], [Last Name], [First Name], [Course] 
                FROM tblStudents s
                INNER JOIN qActiveAY a ON s.[AY-Code] = a.[AY-Code]
                WHERE [Student ID] = @StudentID AND a.[Status] = True";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve fields
                                string idNumber = reader["Student ID"].ToString();
                                string lastName = reader["Last Name"].ToString();
                                string firstName = reader["First Name"].ToString();
                                string section = reader["Course"].ToString();

                                // Set the form fields
                                txtStudentID.Texts = idNumber;
                                txtLastName.Texts = ToProperCase(lastName);
                                txtFirstName.Texts = ToProperCase(firstName);
                                txtCourse.Texts = section;
                            }
                            else
                            {
                                // Show a message indicating student not found or details not updated yet
                                CustomMessageBox.Show(
                                    "No student found with the provided ID number in the active academic year." +
                                    "The student may not have filled out the required form yet, or their details may not be updated." +
                                    "Please check the student's information and manually update the details if necessary before proceeding.",
                                    "Search Result",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation
                                );
                                ClearAutoPopulateFields();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"An error occurred while searching for the student.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtAYCode.IsEmpty() || txtAYCode.Texts == "N/A")
            {
                CustomMessageBox.Show("No active academic year.", "Academic Year Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtStudentID.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Student ID.", "Student ID Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCourse.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Course.", "Course Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtLastName.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Last Name.", "Last Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtFirstName.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a First Name.", "First Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbViolation.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Violation.", "Missing Violation Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbOffenseType.IsEmpty())
            {
                CustomMessageBox.Show("Please select Offense Type.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cbSanction.IsEmpty())
            {
                CustomMessageBox.Show("Please select or enter a Sanction.", "Sanction Not Specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AYCode = txtAYCode.Texts;
            StudentID = txtStudentID.Texts;
            LastName = txtLastName.Texts;
            FirstName = txtFirstName.Texts;
            Course = txtCourse.Texts;
            Violation = cbViolation.Texts;
            Offense = cbOffenseType.Texts;
            Sanction = cbSanction.Texts;

            

            if (IsUpdate)
            {
                if (NoChanges(AYCode, StudentID, Course, Violation, Offense, Sanction))
                {
                    CustomMessageBox.Show("No changes applied.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    CustomMessageBox.Show("Violation details successfully updated!", "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DateTime violationDate = DateTime.Now.Date;
                if (IsViolationDuplicate(StudentID, Violation, violationDate))
                {
                    CustomMessageBox.Show("This violation already exists for the selected student on the same date.", "Duplicate Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } else
                {
                    CustomMessageBox.Show("Violation record successfully added.", "Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormFields();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ClearFormFields()
        {
            txtSearchID.Clear();
            ClearAutoPopulateFields();
            cbViolation.ClearSelection();
            cbSanction.ClearSelection();
            cbOffenseType.ClearSelection();
        }
        private void ClearAutoPopulateFields()
        {
            txtStudentID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtCourse.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
