using System;
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class YearForm : DropShadow
    {
        private string DbConn;
        public string AYCode { get; private set; }
        public string FromYear { get; private set; }
        public string ToYear { get; private set; }
        public string Semester { get; private set; }
        public bool Status { get; private set; }

        private bool isUpdate;
        public YearForm(bool isUpdate, string ayCode = "", string fromYear = "", string toYear = "", string sem = "", bool status = false)
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            this.isUpdate = isUpdate;

            if (isUpdate)
            {
                txtFromYear.Texts = fromYear;
                txtToYear.Texts = toYear;
                cbSemester.Texts = sem;
                chkActive.Checked = status;

                AYCode = ayCode;
                txtAyCode.Text = AYCode;
            }
            else
            {
                txtAyCode.Text = "Auto generate";
            }
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        private void YearForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }
        }

        private bool IsDuplicate(string fromYear, string toYear, string sem, bool stats)
        {
            using (var connection = new OleDbConnection(DbConn))
            {
                string query = "SELECT COUNT(*) FROM tblAcadYear WHERE [From Year] = ? AND [To Year] = ? AND [Semester] = ? AND [Status] = ?";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromYear", fromYear);
                    command.Parameters.AddWithValue("@ToYear", toYear);
                    command.Parameters.AddWithValue("@ToYear", sem);
                    command.Parameters.AddWithValue("@Status", stats);


                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string statusText = chkActive.Checked ? "Active" : "Inactive";

            if (txtFromYear.IsEmpty() || txtToYear.IsEmpty())
            {
                CustomMessageBox.Show("All fields are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FromYear = txtFromYear.TrimText();
            ToYear = txtToYear.TrimText();
            Semester = cbSemester.Texts;
            Status = chkActive.Checked;

            AYCode = $"AY-{FromYear}/{ToYear} {Semester}";

            txtAyCode.Text = AYCode;

            if(isUpdate)
            {                
                if (IsDuplicate(txtFromYear.Texts, txtToYear.Texts, Semester, Status))
                {
                    CustomMessageBox.Show("No changes applied.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } else
                {
                    CustomMessageBox.Show($"Academic year {AYCode} successfully updated and set as {statusText}!", "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            } else if (IsDuplicate(txtFromYear.Texts, txtToYear.Texts, Semester, Status))
            {
                CustomMessageBox.Show("Academic year already exists.", "Duplicate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            } else
            {
                CustomMessageBox.Show($"New academic year successfully added and set as {statusText}.", "Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
