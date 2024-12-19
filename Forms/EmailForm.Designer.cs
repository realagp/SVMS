
namespace SVMS.Forms
{
    partial class EmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailForm));
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSendEmail = new System.Windows.Forms.Label();
            this.formBorder = new System.Windows.Forms.Panel();
            this.closeButton = new SVMS.CustomButtons();
            this.btnSend = new SVMS.CustomButtons();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtStudentEmail = new SVMS.CustomTextBox();
            this.txtSenderEmail = new SVMS.CustomTextBox();
            this.txtSenderPassword = new SVMS.CustomTextBox();
            this.chkShowHidePassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblPassword.Location = new System.Drawing.Point(28, 289);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 16);
            this.lblPassword.TabIndex = 39;
            this.lblPassword.Text = "PASSWORD:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblEmail.Location = new System.Drawing.Point(28, 232);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 38;
            this.lblEmail.Text = "E-MAIL:";
            // 
            // lblSendEmail
            // 
            this.lblSendEmail.AutoSize = true;
            this.lblSendEmail.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblSendEmail.Location = new System.Drawing.Point(75, 85);
            this.lblSendEmail.Name = "lblSendEmail";
            this.lblSendEmail.Size = new System.Drawing.Size(162, 20);
            this.lblSendEmail.TabIndex = 37;
            this.lblSendEmail.Text = "SEND EMAIL VIA GMAIL";
            // 
            // formBorder
            // 
            this.formBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.formBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBorder.Location = new System.Drawing.Point(0, 0);
            this.formBorder.Name = "formBorder";
            this.formBorder.Size = new System.Drawing.Size(313, 5);
            this.formBorder.TabIndex = 35;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.BackgroundColor = System.Drawing.Color.White;
            this.closeButton.BorderColor = System.Drawing.Color.Empty;
            this.closeButton.BorderRadius = 0;
            this.closeButton.BorderSize = 0;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(289, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 26);
            this.closeButton.TabIndex = 36;
            this.closeButton.TextColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSend.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnSend.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnSend.BorderRadius = 0;
            this.btnSend.BorderSize = 1;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(31, 375);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(251, 35);
            this.btnSend.TabIndex = 32;
            this.btnSend.Text = "SEND";
            this.btnSend.TextColor = System.Drawing.Color.White;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(124, 14);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(60, 60);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 40;
            this.pbGmailIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(28, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "RECIPIENT:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(140, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // txtStudentEmail
            // 
            this.txtStudentEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStudentEmail.BorderColor = System.Drawing.Color.DarkGray;
            this.txtStudentEmail.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtStudentEmail.BorderRadius = 0;
            this.txtStudentEmail.BorderSize = 2;
            this.txtStudentEmail.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentEmail.Location = new System.Drawing.Point(31, 137);
            this.txtStudentEmail.Multiline = false;
            this.txtStudentEmail.Name = "txtStudentEmail";
            this.txtStudentEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtStudentEmail.PasswordChar = false;
            this.txtStudentEmail.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtStudentEmail.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentEmail.PlaceholderText = "Enter Recipient Email...";
            this.txtStudentEmail.Size = new System.Drawing.Size(251, 35);
            this.txtStudentEmail.TabIndex = 44;
            this.txtStudentEmail.Texts = "";
            this.txtStudentEmail.UnderlinedStyle = false;
            // 
            // txtSenderEmail
            // 
            this.txtSenderEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSenderEmail.BorderColor = System.Drawing.Color.DarkGray;
            this.txtSenderEmail.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtSenderEmail.BorderRadius = 0;
            this.txtSenderEmail.BorderSize = 2;
            this.txtSenderEmail.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtSenderEmail.Location = new System.Drawing.Point(31, 251);
            this.txtSenderEmail.Multiline = false;
            this.txtSenderEmail.Name = "txtSenderEmail";
            this.txtSenderEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSenderEmail.PasswordChar = false;
            this.txtSenderEmail.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSenderEmail.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderEmail.PlaceholderText = "Enter Sender Email...";
            this.txtSenderEmail.Size = new System.Drawing.Size(251, 35);
            this.txtSenderEmail.TabIndex = 45;
            this.txtSenderEmail.Texts = "";
            this.txtSenderEmail.UnderlinedStyle = false;
            // 
            // txtSenderPassword
            // 
            this.txtSenderPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSenderPassword.BorderColor = System.Drawing.Color.DarkGray;
            this.txtSenderPassword.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtSenderPassword.BorderRadius = 0;
            this.txtSenderPassword.BorderSize = 2;
            this.txtSenderPassword.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtSenderPassword.Location = new System.Drawing.Point(31, 308);
            this.txtSenderPassword.Multiline = false;
            this.txtSenderPassword.Name = "txtSenderPassword";
            this.txtSenderPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSenderPassword.PasswordChar = true;
            this.txtSenderPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSenderPassword.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderPassword.PlaceholderText = "Enter Password...";
            this.txtSenderPassword.Size = new System.Drawing.Size(251, 35);
            this.txtSenderPassword.TabIndex = 46;
            this.txtSenderPassword.Texts = "";
            this.txtSenderPassword.UnderlinedStyle = false;
            // 
            // chkShowHidePassword
            // 
            this.chkShowHidePassword.AutoSize = true;
            this.chkShowHidePassword.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowHidePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.chkShowHidePassword.Location = new System.Drawing.Point(31, 349);
            this.chkShowHidePassword.Name = "chkShowHidePassword";
            this.chkShowHidePassword.Size = new System.Drawing.Size(110, 20);
            this.chkShowHidePassword.TabIndex = 58;
            this.chkShowHidePassword.Text = "Show Password";
            this.chkShowHidePassword.UseVisualStyleBackColor = true;
            this.chkShowHidePassword.CheckedChanged += new System.EventHandler(this.chkShowHidePassword_CheckedChanged);
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(313, 440);
            this.ControlBox = false;
            this.Controls.Add(this.chkShowHidePassword);
            this.Controls.Add(this.txtSenderPassword);
            this.Controls.Add(this.txtSenderEmail);
            this.Controls.Add(this.txtStudentEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSendEmail);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.formBorder);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmailForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSendEmail;
        private CustomButtons closeButton;
        private System.Windows.Forms.Panel formBorder;
        private CustomButtons btnSend;
        private System.Windows.Forms.PictureBox pbGmailIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomTextBox txtStudentEmail;
        private CustomTextBox txtSenderEmail;
        private CustomTextBox txtSenderPassword;
        private System.Windows.Forms.CheckBox chkShowHidePassword;
    }
}