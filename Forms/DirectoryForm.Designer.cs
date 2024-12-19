
namespace SVMS.Forms
{
    partial class DirectoryForm
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
            this.lblBackupRestore = new System.Windows.Forms.Label();
            this.rbLocalDrive = new System.Windows.Forms.RadioButton();
            this.rbGoogleDrive = new System.Windows.Forms.RadioButton();
            this.btnCancel = new SVMS.CustomButtons();
            this.btnConfirm = new SVMS.CustomButtons();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblBackupRestore
            // 
            this.lblBackupRestore.AutoSize = true;
            this.lblBackupRestore.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblBackupRestore.Location = new System.Drawing.Point(12, 16);
            this.lblBackupRestore.Name = "lblBackupRestore";
            this.lblBackupRestore.Size = new System.Drawing.Size(377, 20);
            this.lblBackupRestore.TabIndex = 35;
            this.lblBackupRestore.Text = "Select a location to set a new directory for storing backups:";
            // 
            // rbLocalDrive
            // 
            this.rbLocalDrive.AutoSize = true;
            this.rbLocalDrive.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLocalDrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.rbLocalDrive.Location = new System.Drawing.Point(93, 48);
            this.rbLocalDrive.Name = "rbLocalDrive";
            this.rbLocalDrive.Size = new System.Drawing.Size(97, 24);
            this.rbLocalDrive.TabIndex = 36;
            this.rbLocalDrive.TabStop = true;
            this.rbLocalDrive.Text = "Local Drive";
            this.rbLocalDrive.UseVisualStyleBackColor = true;
            // 
            // rbGoogleDrive
            // 
            this.rbGoogleDrive.AutoSize = true;
            this.rbGoogleDrive.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGoogleDrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.rbGoogleDrive.Location = new System.Drawing.Point(209, 48);
            this.rbGoogleDrive.Name = "rbGoogleDrive";
            this.rbGoogleDrive.Size = new System.Drawing.Size(108, 24);
            this.rbGoogleDrive.TabIndex = 37;
            this.rbGoogleDrive.TabStop = true;
            this.rbGoogleDrive.Text = "Google Drive";
            this.rbGoogleDrive.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(209, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 40;
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
            this.btnConfirm.Location = new System.Drawing.Point(93, 91);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 35);
            this.btnConfirm.TabIndex = 39;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.TextColor = System.Drawing.Color.White;
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 5);
            this.panel1.TabIndex = 38;
            // 
            // DirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 146);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbGoogleDrive);
            this.Controls.Add(this.rbLocalDrive);
            this.Controls.Add(this.lblBackupRestore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DirectoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBackupRestore;
        private System.Windows.Forms.RadioButton rbLocalDrive;
        private System.Windows.Forms.RadioButton rbGoogleDrive;
        private CustomButtons btnCancel;
        private CustomButtons btnConfirm;
        private System.Windows.Forms.Panel panel1;
    }
}