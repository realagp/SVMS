
namespace SVMS.Forms
{
    partial class PasswordRecoveryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordRecoveryForm));
            this.btnSend = new SVMS.CustomButtons();
            this.formBorder = new System.Windows.Forms.Panel();
            this.closeButton = new SVMS.CustomButtons();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            this.lblSendEmail = new System.Windows.Forms.Label();
            this.txtSenderPassword = new SVMS.CustomTextBox();
            this.txtSenderEmail = new SVMS.CustomTextBox();
            this.txtRecoveryEmail = new SVMS.CustomTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUsername = new SVMS.CustomTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkShowHidePassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.btnSend.Location = new System.Drawing.Point(31, 437);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(251, 35);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "SEND";
            this.btnSend.TextColor = System.Drawing.Color.White;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // formBorder
            // 
            this.formBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.formBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBorder.Location = new System.Drawing.Point(0, 0);
            this.formBorder.Name = "formBorder";
            this.formBorder.Size = new System.Drawing.Size(313, 5);
            this.formBorder.TabIndex = 26;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.BackgroundColor = System.Drawing.Color.White;
            this.closeButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.closeButton.BorderRadius = 0;
            this.closeButton.BorderSize = 0;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(289, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 26);
            this.closeButton.TabIndex = 28;
            this.closeButton.TextColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(124, 14);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(60, 60);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 42;
            this.pbGmailIcon.TabStop = false;
            // 
            // lblSendEmail
            // 
            this.lblSendEmail.AutoSize = true;
            this.lblSendEmail.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblSendEmail.Location = new System.Drawing.Point(45, 85);
            this.lblSendEmail.Name = "lblSendEmail";
            this.lblSendEmail.Size = new System.Drawing.Size(223, 20);
            this.lblSendEmail.TabIndex = 41;
            this.lblSendEmail.Text = "RECOVER PASSWORD VIA EMAIL";
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
            this.txtSenderPassword.Location = new System.Drawing.Point(31, 361);
            this.txtSenderPassword.Multiline = false;
            this.txtSenderPassword.Name = "txtSenderPassword";
            this.txtSenderPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSenderPassword.PasswordChar = true;
            this.txtSenderPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSenderPassword.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderPassword.PlaceholderText = "Enter Email Password...";
            this.txtSenderPassword.Size = new System.Drawing.Size(251, 35);
            this.txtSenderPassword.TabIndex = 54;
            this.txtSenderPassword.Texts = "";
            this.txtSenderPassword.UnderlinedStyle = false;
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
            this.txtSenderEmail.Location = new System.Drawing.Point(31, 304);
            this.txtSenderEmail.Multiline = false;
            this.txtSenderEmail.Name = "txtSenderEmail";
            this.txtSenderEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSenderEmail.PasswordChar = false;
            this.txtSenderEmail.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSenderEmail.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderEmail.PlaceholderText = "Enter Sender Email...";
            this.txtSenderEmail.Size = new System.Drawing.Size(251, 35);
            this.txtSenderEmail.TabIndex = 53;
            this.txtSenderEmail.Texts = "";
            this.txtSenderEmail.UnderlinedStyle = false;
            // 
            // txtRecoveryEmail
            // 
            this.txtRecoveryEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRecoveryEmail.BorderColor = System.Drawing.Color.DarkGray;
            this.txtRecoveryEmail.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtRecoveryEmail.BorderRadius = 0;
            this.txtRecoveryEmail.BorderSize = 2;
            this.txtRecoveryEmail.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtRecoveryEmail.Location = new System.Drawing.Point(31, 137);
            this.txtRecoveryEmail.Multiline = false;
            this.txtRecoveryEmail.Name = "txtRecoveryEmail";
            this.txtRecoveryEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtRecoveryEmail.PasswordChar = false;
            this.txtRecoveryEmail.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtRecoveryEmail.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryEmail.PlaceholderText = "Enter Recovery Email...";
            this.txtRecoveryEmail.Size = new System.Drawing.Size(251, 35);
            this.txtRecoveryEmail.TabIndex = 52;
            this.txtRecoveryEmail.Texts = "";
            this.txtRecoveryEmail.UnderlinedStyle = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(140, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(28, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "RECOVERY EMAIL:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblPassword.Location = new System.Drawing.Point(28, 342);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 16);
            this.lblPassword.TabIndex = 49;
            this.lblPassword.Text = "PASSWORD:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblEmail.Location = new System.Drawing.Point(28, 285);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 48;
            this.lblEmail.Text = "E-MAIL:";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsername.BorderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtUsername.BorderRadius = 0;
            this.txtUsername.BorderSize = 2;
            this.txtUsername.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsername.Location = new System.Drawing.Point(31, 247);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtUsername.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.PlaceholderText = "Enter Username...";
            this.txtUsername.Size = new System.Drawing.Size(251, 35);
            this.txtUsername.TabIndex = 56;
            this.txtUsername.Texts = "";
            this.txtUsername.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label2.Location = new System.Drawing.Point(28, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "USERNAME:";
            // 
            // chkShowHidePassword
            // 
            this.chkShowHidePassword.AutoSize = true;
            this.chkShowHidePassword.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowHidePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.chkShowHidePassword.Location = new System.Drawing.Point(31, 402);
            this.chkShowHidePassword.Name = "chkShowHidePassword";
            this.chkShowHidePassword.Size = new System.Drawing.Size(110, 20);
            this.chkShowHidePassword.TabIndex = 57;
            this.chkShowHidePassword.Text = "Show Password";
            this.chkShowHidePassword.UseVisualStyleBackColor = true;
            this.chkShowHidePassword.CheckedChanged += new System.EventHandler(this.chkShowHidePassword_CheckedChanged);
            // 
            // PasswordRecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(313, 492);
            this.ControlBox = false;
            this.Controls.Add(this.chkShowHidePassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSenderPassword);
            this.Controls.Add(this.txtSenderEmail);
            this.Controls.Add(this.txtRecoveryEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.lblSendEmail);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.formBorder);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordRecoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PasswordRecoveryForm";
            this.Load += new System.EventHandler(this.PasswordRecoveryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtons btnSend;
        private System.Windows.Forms.Panel formBorder;
        private CustomButtons closeButton;
        private System.Windows.Forms.PictureBox pbGmailIcon;
        private System.Windows.Forms.Label lblSendEmail;
        private CustomTextBox txtSenderPassword;
        private CustomTextBox txtSenderEmail;
        private CustomTextBox txtRecoveryEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private CustomTextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShowHidePassword;
    }
}