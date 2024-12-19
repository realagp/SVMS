using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SVMS
{
    public partial class MessageBoxForm : DropShadow
    {
        private Color primaryColor = Color.White;
        private int borderSize = 2;

        public Color PrimaryColor
        {
            get { return primaryColor; }
            set
            {
                primaryColor = value;
                this.BackColor = primaryColor;
                this.panelTitleBar.BackColor = PrimaryColor;
            }
        }

        public MessageBoxForm(string text)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = "";
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }

        public MessageBoxForm(string text, string caption)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);//Set Default Buttons
        }
        public MessageBoxForm(string text, string caption, MessageBoxButtons buttons)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);//Set [Default Button 1]
        }
        public MessageBoxForm(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);//Set [Default Button 1]
            SetIcon(icon);
        }
        public MessageBoxForm(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, defaultButton);
            SetIcon(icon);
        }

        private void InitializeItems()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.labelMessage.MaximumSize = new Size(550, 0);
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
        }
        private void SetFormSize()
        {
            int widht = this.labelMessage.Width + this.pictureBoxIcon.Width + this.panelBody.Padding.Left;
            int height = this.panelTitleBar.Height + this.labelMessage.Height + this.panelButtons.Height + this.panelBody.Padding.Top;
            this.Size = new Size(widht, height);
        }
        private void SetButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            int xCenter = (this.panelButtons.Width - button1.Width) / 2;
            int yCenter = (this.panelButtons.Height - button1.Height) / 2;

            switch (buttons)
            {
                case MessageBoxButtons.OK:

                    button1.Visible = true;
                    button1.Location = new Point(xCenter, yCenter);
                    button1.Text = "Ok";
                    button1.DialogResult = DialogResult.OK;//Set DialogResult

                    SetDefaultButton(defaultButton);
                    break;
                case MessageBoxButtons.OKCancel:

                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = "Ok";
                    button1.DialogResult = DialogResult.OK;//Set DialogResult

                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = "Cancel";
                    button2.DialogResult = DialogResult.Cancel;//Set DialogResult
                    button2.BackColor = Color.DimGray;

                    if (defaultButton != MessageBoxDefaultButton.Button3)//There are only 2 buttons, so the Default Button cannot be Button3
                        SetDefaultButton(defaultButton);
                    else SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.RetryCancel:

                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = "Retry";
                    button1.DialogResult = DialogResult.Retry;//Set DialogResult

                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = "Cancel";
                    button2.DialogResult = DialogResult.Cancel;//Set DialogResult
                    button2.BackColor = Color.DimGray;

                    if (defaultButton != MessageBoxDefaultButton.Button3)//There are only 2 buttons, so the Default Button cannot be Button3
                        SetDefaultButton(defaultButton);
                    else SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.YesNo:

                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = "Yes";
                    button1.DialogResult = DialogResult.Yes;//Set DialogResult

                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = "No";
                    button2.DialogResult = DialogResult.No;//Set DialogResult
                    button2.BackColor = Color.IndianRed;

                    if (defaultButton != MessageBoxDefaultButton.Button3)//There are only 2 buttons, so the Default Button cannot be Button3
                        SetDefaultButton(defaultButton);
                    else SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                    button1.Text = "Yes";
                    button1.DialogResult = DialogResult.Yes;//Set DialogResult

                    button2.Visible = true;
                    button2.Location = new Point(xCenter, yCenter);
                    button2.Text = "No";
                    button2.DialogResult = DialogResult.No;//Set DialogResult
                    button2.BackColor = Color.FromArgb(230, 57, 70);

                    button3.Visible = true;
                    button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                    button3.Text = "Cancel";
                    button3.DialogResult = DialogResult.Cancel;//Set DialogResult
                    button3.BackColor = Color.DimGray;

                    SetDefaultButton(defaultButton);
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                 
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                    button1.Text = "Abort";
                    button1.DialogResult = DialogResult.Abort;//Set DialogResult
                    button1.BackColor = Color.Goldenrod;

                    
                    button2.Visible = true;
                    button2.Location = new Point(xCenter, yCenter);
                    button2.Text = "Retry";
                    button2.DialogResult = DialogResult.Retry;//Set DialogResult                    

                    
                    button3.Visible = true;
                    button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                    button3.Text = "Ignore";
                    button3.DialogResult = DialogResult.Ignore;//Set DialogResult
                    button3.BackColor = Color.IndianRed;

                    
                    SetDefaultButton(defaultButton);
                    break;
            }
        }
        private void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1://Focus button 1
                    button1.Select();
                    button1.ForeColor = Color.White;
                    button1.Font = new Font(button1.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button2://Focus button 2
                    button2.Select();
                    button2.ForeColor = Color.White;
                    button2.Font = new Font(button2.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button3://Focus button 3
                    button3.Select();
                    button3.ForeColor = Color.White;
                    button3.Font = new Font(button3.Font, FontStyle.Underline);
                    break;
            }
        }
        private void SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error: //Error
                    this.pictureBoxIcon.Image = Properties.Resources.error;
                    PrimaryColor = Color.White;
                    break;
                case MessageBoxIcon.Information: //Information
                    this.pictureBoxIcon.Image = Properties.Resources.information;
                    PrimaryColor = Color.White; 
                    break;
                case MessageBoxIcon.Question://Question
                    this.pictureBoxIcon.Image = Properties.Resources.question;
                    PrimaryColor = Color.White;
                    break;
                case MessageBoxIcon.Exclamation://Exclamation
                    this.pictureBoxIcon.Image = Properties.Resources.exclamation;
                    PrimaryColor = Color.White;
                    break;
                case MessageBoxIcon.None: //None
                    this.pictureBoxIcon.Image = Properties.Resources.chat;
                    PrimaryColor = Color.White;
                    break;
            }
        }

        #region -> Drag Form
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
