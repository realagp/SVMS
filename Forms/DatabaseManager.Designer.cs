
namespace SVMS.Forms
{
    partial class DatabaseManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseManager));
            this.lblSections = new System.Windows.Forms.Label();
            this.formBorder = new System.Windows.Forms.Panel();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            this.btnSelect = new SVMS.CustomButtons();
            this.btnExportCSV = new SVMS.CustomButtons();
            this.btnImportCSV = new SVMS.CustomButtons();
            this.btnRestore = new SVMS.CustomButtons();
            this.btnBackupDatabase = new SVMS.CustomButtons();
            this.btnChangePath = new SVMS.CustomButtons();
            this.closeButton = new SVMS.CustomButtons();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSections
            // 
            this.lblSections.AutoSize = true;
            this.lblSections.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblSections.Location = new System.Drawing.Point(116, 81);
            this.lblSections.Name = "lblSections";
            this.lblSections.Size = new System.Drawing.Size(141, 20);
            this.lblSections.TabIndex = 26;
            this.lblSections.Text = "MANAGE DATABASE";
            // 
            // formBorder
            // 
            this.formBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.formBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBorder.Location = new System.Drawing.Point(0, 0);
            this.formBorder.Name = "formBorder";
            this.formBorder.Size = new System.Drawing.Size(375, 5);
            this.formBorder.TabIndex = 24;
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(160, 19);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(50, 50);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 41;
            this.pbGmailIcon.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelect.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelect.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.BorderRadius = 5;
            this.btnSelect.BorderSize = 1;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(192, 116);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSelect.Size = new System.Drawing.Size(160, 40);
            this.btnSelect.TabIndex = 43;
            this.btnSelect.Text = "Backup Directory";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportCSV.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportCSV.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportCSV.BorderRadius = 5;
            this.btnExportCSV.BorderSize = 1;
            this.btnExportCSV.FlatAppearance.BorderSize = 0;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnExportCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCSV.Image")));
            this.btnExportCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportCSV.Location = new System.Drawing.Point(192, 208);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExportCSV.Size = new System.Drawing.Size(160, 40);
            this.btnExportCSV.TabIndex = 42;
            this.btnExportCSV.Text = "Export CSV File";
            this.btnExportCSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportCSV.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnExportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportCSV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportCSV.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportCSV.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImportCSV.BorderRadius = 5;
            this.btnImportCSV.BorderSize = 1;
            this.btnImportCSV.FlatAppearance.BorderSize = 0;
            this.btnImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSV.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnImportCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnImportCSV.Image")));
            this.btnImportCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportCSV.Location = new System.Drawing.Point(22, 208);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnImportCSV.Size = new System.Drawing.Size(160, 40);
            this.btnImportCSV.TabIndex = 30;
            this.btnImportCSV.Text = "Import CSV File";
            this.btnImportCSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportCSV.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnImportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportCSV.UseVisualStyleBackColor = false;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestore.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestore.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRestore.BorderRadius = 5;
            this.btnRestore.BorderSize = 1;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Location = new System.Drawing.Point(192, 162);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRestore.Size = new System.Drawing.Size(160, 40);
            this.btnRestore.TabIndex = 28;
            this.btnRestore.Text = "Restore Backup";
            this.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackupDatabase
            // 
            this.btnBackupDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackupDatabase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBackupDatabase.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnBackupDatabase.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackupDatabase.BorderRadius = 5;
            this.btnBackupDatabase.BorderSize = 1;
            this.btnBackupDatabase.FlatAppearance.BorderSize = 0;
            this.btnBackupDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupDatabase.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnBackupDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupDatabase.Image")));
            this.btnBackupDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupDatabase.Location = new System.Drawing.Point(22, 162);
            this.btnBackupDatabase.Name = "btnBackupDatabase";
            this.btnBackupDatabase.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnBackupDatabase.Size = new System.Drawing.Size(160, 40);
            this.btnBackupDatabase.TabIndex = 7;
            this.btnBackupDatabase.Text = "Backup Database";
            this.btnBackupDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupDatabase.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnBackupDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackupDatabase.UseVisualStyleBackColor = false;
            this.btnBackupDatabase.Click += new System.EventHandler(this.btnBackupDatabase_Click);
            // 
            // btnChangePath
            // 
            this.btnChangePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChangePath.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnChangePath.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePath.BorderRadius = 5;
            this.btnChangePath.BorderSize = 1;
            this.btnChangePath.FlatAppearance.BorderSize = 0;
            this.btnChangePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePath.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnChangePath.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePath.Image")));
            this.btnChangePath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePath.Location = new System.Drawing.Point(22, 116);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnChangePath.Size = new System.Drawing.Size(160, 40);
            this.btnChangePath.TabIndex = 45;
            this.btnChangePath.Text = "Database Path";
            this.btnChangePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnChangePath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePath.UseVisualStyleBackColor = false;
            this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
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
            this.closeButton.Location = new System.Drawing.Point(351, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 26);
            this.closeButton.TabIndex = 46;
            this.closeButton.TextColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // DatabaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(375, 273);
            this.ControlBox = false;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.btnChangePath);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.lblSections);
            this.Controls.Add(this.btnBackupDatabase);
            this.Controls.Add(this.formBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DatabaseManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatabaseManager";
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel formBorder;
        private CustomButtons btnBackupDatabase;
        private System.Windows.Forms.Label lblSections;
        private CustomButtons btnImportCSV;
        private CustomButtons btnRestore;
        private System.Windows.Forms.PictureBox pbGmailIcon;
        private CustomButtons btnExportCSV;
        private CustomButtons btnSelect;
        private CustomButtons btnChangePath;
        private CustomButtons closeButton;
    }
}