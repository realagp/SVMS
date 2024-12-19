using System;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class EmailForm : DropShadow
    {
        public string SenderPassword { get; private set; }
        public string StudentEmail
        {
            get => txtStudentEmail.Texts;
            set => txtStudentEmail.Texts = value;
        }

        public string SenderEmail
        {
            get => txtSenderEmail.Texts;
            set => txtSenderEmail.Texts = value;
        }
        public EmailForm()
        {
            InitializeComponent();
            txtStudentEmail.SetReadOnly(true);
            txtSenderEmail.SetReadOnly(true);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SenderPassword = txtSenderPassword.Texts;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkShowHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtSenderPassword.PasswordChar = !chkShowHidePassword.Checked;
        }
    }
}
