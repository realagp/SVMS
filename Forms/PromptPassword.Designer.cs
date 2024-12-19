
namespace SVMS.Forms
{
    partial class PromptPassword
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
            this.txtPassword = new SVMS.CustomTextBox();
            this.lblOperationType = new System.Windows.Forms.Label();
            this.btnCancel = new SVMS.CustomButtons();
            this.btnConfirm = new SVMS.CustomButtons();
            this.topBorder = new System.Windows.Forms.Panel();
            this.chkShowHidePassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.BorderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtPassword.BorderRadius = 0;
            this.txtPassword.BorderSize = 2;
            this.txtPassword.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(88, 55);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtPassword.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.PlaceholderText = "Enter Password...";
            this.txtPassword.Size = new System.Drawing.Size(186, 35);
            this.txtPassword.TabIndex = 37;
            this.txtPassword.Texts = "";
            this.txtPassword.UnderlinedStyle = false;
            // 
            // lblOperationType
            // 
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationType.Location = new System.Drawing.Point(14, 18);
            this.lblOperationType.Name = "lblOperationType";
            this.lblOperationType.Size = new System.Drawing.Size(100, 20);
            this.lblOperationType.TabIndex = 36;
            this.lblOperationType.Text = "OperationType";
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
            this.btnCancel.Location = new System.Drawing.Point(188, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirm.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnConfirm.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnConfirm.BorderRadius = 0;
            this.btnConfirm.BorderSize = 1;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(72, 132);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 35);
            this.btnConfirm.TabIndex = 33;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.TextColor = System.Drawing.Color.White;
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // topBorder
            // 
            this.topBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.topBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBorder.Location = new System.Drawing.Point(0, 0);
            this.topBorder.Name = "topBorder";
            this.topBorder.Size = new System.Drawing.Size(356, 5);
            this.topBorder.TabIndex = 32;
            // 
            // chkShowHidePassword
            // 
            this.chkShowHidePassword.AutoSize = true;
            this.chkShowHidePassword.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowHidePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.chkShowHidePassword.Location = new System.Drawing.Point(88, 96);
            this.chkShowHidePassword.Name = "chkShowHidePassword";
            this.chkShowHidePassword.Size = new System.Drawing.Size(110, 20);
            this.chkShowHidePassword.TabIndex = 61;
            this.chkShowHidePassword.Text = "Show Password";
            this.chkShowHidePassword.UseVisualStyleBackColor = true;
            this.chkShowHidePassword.CheckedChanged += new System.EventHandler(this.chkShowHidePassword_CheckedChanged);
            // 
            // PromptPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 187);
            this.ControlBox = false;
            this.Controls.Add(this.chkShowHidePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblOperationType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.topBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PromptPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PromptPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOperationType;
        private CustomButtons btnCancel;
        private CustomButtons btnConfirm;
        private System.Windows.Forms.Panel topBorder;
        private CustomTextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowHidePassword;
    }
}