
namespace SVMS.Forms
{
    partial class UpdateAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAccounts));
            this.formBorder = new System.Windows.Forms.Panel();
            this.btnCancel = new SVMS.CustomButtons();
            this.btnSave = new SVMS.CustomButtons();
            this.chkShowHideAdminPass = new System.Windows.Forms.CheckBox();
            this.txtEmail = new SVMS.CustomTextBox();
            this.txtNewPassword = new SVMS.CustomTextBox();
            this.txtOldPassword = new SVMS.CustomTextBox();
            this.txtUsername = new SVMS.CustomTextBox();
            this.txtName = new SVMS.CustomTextBox();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // formBorder
            // 
            this.formBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.formBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBorder.Location = new System.Drawing.Point(0, 0);
            this.formBorder.Name = "formBorder";
            this.formBorder.Size = new System.Drawing.Size(288, 5);
            this.formBorder.TabIndex = 26;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.BorderSize = 1;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(152, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnSave.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnSave.BorderRadius = 0;
            this.btnSave.BorderSize = 1;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(36, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkShowHideAdminPass
            // 
            this.chkShowHideAdminPass.AutoSize = true;
            this.chkShowHideAdminPass.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowHideAdminPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.chkShowHideAdminPass.Location = new System.Drawing.Point(26, 399);
            this.chkShowHideAdminPass.Name = "chkShowHideAdminPass";
            this.chkShowHideAdminPass.Size = new System.Drawing.Size(110, 20);
            this.chkShowHideAdminPass.TabIndex = 75;
            this.chkShowHideAdminPass.Text = "Show Password";
            this.chkShowHideAdminPass.UseVisualStyleBackColor = true;
            this.chkShowHideAdminPass.CheckedChanged += new System.EventHandler(this.chkShowHideAdminPass_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.BorderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtEmail.BorderRadius = 0;
            this.txtEmail.BorderSize = 2;
            this.txtEmail.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(26, 358);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmail.PasswordChar = false;
            this.txtEmail.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtEmail.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.PlaceholderText = "Enter Email Address...";
            this.txtEmail.Size = new System.Drawing.Size(239, 35);
            this.txtEmail.TabIndex = 74;
            this.txtEmail.Texts = "";
            this.txtEmail.UnderlinedStyle = false;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNewPassword.BorderColor = System.Drawing.Color.DarkGray;
            this.txtNewPassword.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtNewPassword.BorderRadius = 0;
            this.txtNewPassword.BorderSize = 2;
            this.txtNewPassword.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.Black;
            this.txtNewPassword.Location = new System.Drawing.Point(26, 301);
            this.txtNewPassword.Multiline = false;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNewPassword.PasswordChar = true;
            this.txtNewPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtNewPassword.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.PlaceholderText = "Enter New Password...";
            this.txtNewPassword.Size = new System.Drawing.Size(239, 35);
            this.txtNewPassword.TabIndex = 73;
            this.txtNewPassword.Texts = "";
            this.txtNewPassword.UnderlinedStyle = false;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOldPassword.BorderColor = System.Drawing.Color.DarkGray;
            this.txtOldPassword.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtOldPassword.BorderRadius = 0;
            this.txtOldPassword.BorderSize = 2;
            this.txtOldPassword.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.ForeColor = System.Drawing.Color.Black;
            this.txtOldPassword.Location = new System.Drawing.Point(26, 244);
            this.txtOldPassword.Multiline = false;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtOldPassword.PasswordChar = true;
            this.txtOldPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtOldPassword.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.PlaceholderText = "Enter Current Password...";
            this.txtOldPassword.Size = new System.Drawing.Size(239, 35);
            this.txtOldPassword.TabIndex = 72;
            this.txtOldPassword.Texts = "";
            this.txtOldPassword.UnderlinedStyle = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsername.BorderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtUsername.BorderRadius = 0;
            this.txtUsername.BorderSize = 2;
            this.txtUsername.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(26, 187);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtUsername.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.PlaceholderText = "Enter Username...";
            this.txtUsername.Size = new System.Drawing.Size(239, 35);
            this.txtUsername.TabIndex = 71;
            this.txtUsername.Texts = "";
            this.txtUsername.UnderlinedStyle = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.BorderColor = System.Drawing.Color.DarkGray;
            this.txtName.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtName.BorderRadius = 0;
            this.txtName.BorderSize = 2;
            this.txtName.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(26, 130);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtName.PasswordChar = false;
            this.txtName.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtName.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.PlaceholderText = "Enter Name...";
            this.txtName.Size = new System.Drawing.Size(239, 35);
            this.txtName.TabIndex = 70;
            this.txtName.Texts = "";
            this.txtName.UnderlinedStyle = false;
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(115, 16);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(55, 55);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 69;
            this.pbGmailIcon.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblEmail.Location = new System.Drawing.Point(23, 339);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(103, 16);
            this.lblEmail.TabIndex = 68;
            this.lblEmail.Text = "EMAIL ADDRESS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label5.Location = new System.Drawing.Point(53, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 20);
            this.label5.TabIndex = 67;
            this.label5.Text = "ADMINISTRATOR ACCOUNT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label4.Location = new System.Drawing.Point(23, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 66;
            this.label4.Text = "NEW PASSWORD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label3.Location = new System.Drawing.Point(23, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "PASSWORD:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label2.Location = new System.Drawing.Point(23, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "USERNAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(23, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "NAME:";
            // 
            // UpdateAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(288, 500);
            this.ControlBox = false;
            this.Controls.Add(this.chkShowHideAdminPass);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.formBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateAccounts";
            this.Load += new System.EventHandler(this.UpdateAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel formBorder;
        private CustomButtons btnCancel;
        private CustomButtons btnSave;
        private System.Windows.Forms.CheckBox chkShowHideAdminPass;
        private CustomTextBox txtEmail;
        private CustomTextBox txtNewPassword;
        private CustomTextBox txtOldPassword;
        private CustomTextBox txtUsername;
        private CustomTextBox txtName;
        private System.Windows.Forms.PictureBox pbGmailIcon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}