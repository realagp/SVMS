
namespace SVMS
{
    partial class LoginUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUI));
            this.transBackground = new System.Windows.Forms.Panel();
            this.chkShowHidePassword = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnForgotPassword = new System.Windows.Forms.Label();
            this.svmsLogo = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new SVMS.CustomButtons();
            this.txtUsername = new SVMS.CustomTextBox();
            this.txtPassword = new SVMS.CustomTextBox();
            this.bpcLogo = new System.Windows.Forms.PictureBox();
            this.closeButton = new SVMS.CustomButtons();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.transBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svmsLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpcLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // transBackground
            // 
            this.transBackground.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.transBackground.Controls.Add(this.chkShowHidePassword);
            this.transBackground.Controls.Add(this.label2);
            this.transBackground.Controls.Add(this.label1);
            this.transBackground.Controls.Add(this.btnForgotPassword);
            this.transBackground.Controls.Add(this.svmsLogo);
            this.transBackground.Controls.Add(this.label6);
            this.transBackground.Controls.Add(this.label3);
            this.transBackground.Controls.Add(this.btnLogin);
            this.transBackground.Controls.Add(this.txtUsername);
            this.transBackground.Controls.Add(this.txtPassword);
            this.transBackground.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transBackground.Location = new System.Drawing.Point(160, 22);
            this.transBackground.Name = "transBackground";
            this.transBackground.Size = new System.Drawing.Size(276, 407);
            this.transBackground.TabIndex = 0;
            // 
            // chkShowHidePassword
            // 
            this.chkShowHidePassword.AutoSize = true;
            this.chkShowHidePassword.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowHidePassword.ForeColor = System.Drawing.Color.White;
            this.chkShowHidePassword.Location = new System.Drawing.Point(22, 300);
            this.chkShowHidePassword.Name = "chkShowHidePassword";
            this.chkShowHidePassword.Size = new System.Drawing.Size(110, 20);
            this.chkShowHidePassword.TabIndex = 25;
            this.chkShowHidePassword.Text = "Show Password";
            this.chkShowHidePassword.UseVisualStyleBackColor = true;
            this.chkShowHidePassword.CheckedChanged += new System.EventHandler(this.chkShowHidePassword_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Student Violation Management System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Login into SVMS";
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.AutoSize = true;
            this.btnForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnForgotPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnForgotPassword.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotPassword.ForeColor = System.Drawing.Color.White;
            this.btnForgotPassword.Location = new System.Drawing.Point(154, 237);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(105, 16);
            this.btnForgotPassword.TabIndex = 18;
            this.btnForgotPassword.Text = "Forgot Password?";
            this.btnForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);
            // 
            // svmsLogo
            // 
            this.svmsLogo.BackColor = System.Drawing.Color.Transparent;
            this.svmsLogo.Image = ((System.Drawing.Image)(resources.GetObject("svmsLogo.Image")));
            this.svmsLogo.Location = new System.Drawing.Point(105, 55);
            this.svmsLogo.Name = "svmsLogo";
            this.svmsLogo.Size = new System.Drawing.Size(60, 60);
            this.svmsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.svmsLogo.TabIndex = 15;
            this.svmsLogo.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(19, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password:";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLogin.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 0;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(22, 337);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(233, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsername.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtUsername.BorderRadius = 0;
            this.txtUsername.BorderSize = 2;
            this.txtUsername.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(22, 187);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtUsername.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.PlaceholderText = "Enter Username...";
            this.txtUsername.Size = new System.Drawing.Size(233, 35);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Texts = "";
            this.txtUsername.UnderlinedStyle = false;
            this.txtUsername._KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtPassword.BorderRadius = 0;
            this.txtPassword.BorderSize = 2;
            this.txtPassword.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(22, 259);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtPassword.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.PlaceholderText = "Enter Password...";
            this.txtPassword.Size = new System.Drawing.Size(233, 35);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Texts = "";
            this.txtPassword.UnderlinedStyle = false;
            this.txtPassword._KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // bpcLogo
            // 
            this.bpcLogo.BackColor = System.Drawing.Color.Transparent;
            this.bpcLogo.Image = ((System.Drawing.Image)(resources.GetObject("bpcLogo.Image")));
            this.bpcLogo.Location = new System.Drawing.Point(498, 29);
            this.bpcLogo.Name = "bpcLogo";
            this.bpcLogo.Size = new System.Drawing.Size(80, 80);
            this.bpcLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bpcLogo.TabIndex = 14;
            this.bpcLogo.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.closeButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.closeButton.BorderRadius = 0;
            this.closeButton.BorderSize = 0;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(576, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 26);
            this.closeButton.TabIndex = 17;
            this.closeButton.TextColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.BackColor = System.Drawing.Color.Transparent;
            this.lblDeveloper.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloper.ForeColor = System.Drawing.Color.White;
            this.lblDeveloper.Location = new System.Drawing.Point(485, 420);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(104, 16);
            this.lblDeveloper.TabIndex = 20;
            this.lblDeveloper.Text = "Team Syntax Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(512, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Developed By";
            // 
            // LoginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.ControlBox = false;
            this.Controls.Add(this.lblDeveloper);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bpcLogo);
            this.Controls.Add(this.transBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginUI";
            this.Load += new System.EventHandler(this.LoginUI_Load);
            this.transBackground.ResumeLayout(false);
            this.transBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svmsLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpcLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel transBackground;
        private CustomButtons btnLogin;
        private CustomTextBox txtUsername;
        private CustomTextBox txtPassword;
        private System.Windows.Forms.PictureBox bpcLogo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private CustomButtons closeButton;
        private System.Windows.Forms.Label btnForgotPassword;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox svmsLogo;
        private System.Windows.Forms.CheckBox chkShowHidePassword;
    }
}