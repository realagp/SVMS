using System;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class OffensesForm : DropShadow
    {
        public OffensesForm()
        {
            InitializeComponent();
        }
        public string OffenseName => txtNewOffense.TrimText();

        public bool IsMinorOffense => rbMinorOffense.Checked;

        public void InitializeForUpdate(string offenseName, bool isMinorOffense)
        {
            txtNewOffense.Texts = offenseName;

            if (isMinorOffense)
            {
                rbMinorOffense.Checked = true;
                rbMajorOffense.Checked = false;
            }
            else
            {
                rbMinorOffense.Checked = false;
                rbMajorOffense.Checked = true;
            }

            rbMinorOffense.Enabled = isMinorOffense;
            rbMajorOffense.Enabled = !isMinorOffense;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewOffense.IsEmpty())
            {
                CustomMessageBox.Show("Please enter an offense name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbMinorOffense.Checked && !rbMajorOffense.Checked)
            {
                CustomMessageBox.Show("Please select the type of offense (Minor or Major).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
