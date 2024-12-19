using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace SVMS.Forms
{
    public partial class StudentEntryForm : DropShadow
    {
        private string DbConn;
        public string StudentID { get; private set; }
        public string AYCode { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Initial { get; private set; }
        public string Course { get; private set; }
        public string Address { get; private set; }
        public string ContactNo { get; private set; }
        public string Email { get; private set; }
        public bool IsUpdate { get; private set; }

        public StudentEntryForm(bool isUpdate, string studentID = "", string ayCode = "", string lastName = "", string firstName = "", string course = "", string address = "", string contactNo = "", string email = "")
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            IsUpdate = isUpdate;
            StudentID = studentID;
            AYCode = ayCode;
            LastName = lastName;
            FirstName = firstName;
            Course = course;
            Address = address;
            ContactNo = contactNo;
            Email = email;

            txtAYCode.SetReadOnly(true);
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private void StudentEntryForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            LoadProgramCodes();
            LoadAYCode();

            if (IsUpdate)
            {
                txtIdNumber.Texts = StudentID;
                txtLastName.Texts = LastName;
                txtFirstName.Texts = FirstName;
                txtAddress.Texts = Address;
                txtContactNo.Texts = ContactNo;
                txtEmail.Texts = Email;
                cbCourse.Texts = Course;
            }
            else
            {
                txtIdNumber.Clear();
                txtLastName.Clear();
                txtFirstName.Clear();
                txtAddress.Clear();
                txtContactNo.Clear();
                txtEmail.Clear();
                cbCourse.ClearSelection();
            }
        }
        private void LoadProgramCodes()
        {
            string query = "SELECT [Course] FROM tblStudents";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        HashSet<string> programCodes = new HashSet<string>();
                        while (reader.Read())
                        {
                            programCodes.Add(reader["Course"].ToString());
                        }

                        var sortedProgramCodes = programCodes.OrderBy(code => code).ToList();
                        cbCourse.Items.AddRange(sortedProgramCodes.ToArray());
                    }
                }
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
        private bool IsDuplicateStudentID(
            string studentID)
        {
            using (var connection = new OleDbConnection(DbConn))
            {
                string query = "SELECT COUNT(*) FROM tblStudents WHERE [Student ID] = ?";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Student ID", studentID);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool NoChanges(
            string studentID,
            string ayCode,
            string lastName,
            string firstName,
            string course,
            string address,
            string contactNo,
            string email
            )
        {
            using (var connection = new OleDbConnection(DbConn))
            {
                string query = "SELECT COUNT(*) FROM tblStudents WHERE [Student ID] = ? AND [AY-Code] = ? AND [Last Name] = ? AND [First Name] = ? AND [Course] = ? AND [Address] = ? AND [Contact No] = ? AND [Email] = ?";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@AY-Code", ayCode);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@Course", course);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@Email", email); ;

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            SetStudentDetails();

            if (IsUpdate)
            {
                if (NoChanges(StudentID, AYCode, LastName, FirstName, Course, Address, ContactNo, Email))
                {
                    CustomMessageBox.Show("No changes applied.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    CustomMessageBox.Show("Student details successfully updated!", "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (IsDuplicateStudentID(StudentID))
            {
                CustomMessageBox.Show("Student ID already exists.", "Duplicate Student ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                CustomMessageBox.Show("New student successfully added!", "Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetStudentDetails()
        {
            StudentID = txtIdNumber.TrimText();
            AYCode = txtAYCode.TrimText();
            Course = cbCourse.TrimText();
            LastName = txtLastName.TrimText();
            FirstName = txtFirstName.TrimText();
            Address = txtAddress.TrimText();
            Email = txtEmail.TrimText();
            ContactNo = txtContactNo.TrimText();
            
        }

        private bool ValidateForm()
        {
            if (txtAYCode.IsEmpty() || txtAYCode.Texts == "N/A")
            {
                CustomMessageBox.Show("No active academic year.", "Academic Year Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtIdNumber.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Student ID.", "Student ID Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbCourse.IsEmpty())
            {
                CustomMessageBox.Show("Please select or enter a Course.", "Course Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtLastName.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Last Name.", "Last Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtFirstName.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a First Name.", "First Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtAddress.IsEmpty())
            {
                CustomMessageBox.Show("Please enter an Address.", "Address Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtEmail.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a valid Email.", "Email Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtContactNo.IsEmpty())
            {
                CustomMessageBox.Show("Please enter a Contact Number.", "Contact Number Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
