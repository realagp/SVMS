using System;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class SelectUserForm : DropShadow
    {
        public enum accountType { Admin, AuthorizedUser }
        public accountType SelectedAccount { get; private set; }
        public SelectUserForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rbAdmin.Checked)
            {
                SelectedAccount = accountType.Admin;
            }
            else if (rbAuthorizedUsers.Checked)
            {
                SelectedAccount = accountType.AuthorizedUser;
            }
            else
            {
                MessageBox.Show("Please select an account to manage.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
