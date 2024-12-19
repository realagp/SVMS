
namespace SVMS.Controls
{
    partial class ArchivesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivesControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingProgressBar = new System.Windows.Forms.PictureBox();
            this.btnReloadDB = new SVMS.CustomButtons();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.archivesDGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSelectedAYCode = new SVMS.CustomTextBox();
            this.btnToExcel = new System.Windows.Forms.PictureBox();
            this.lblExportAs = new System.Windows.Forms.Label();
            this.btnToPDF = new System.Windows.Forms.PictureBox();
            this.lblAssociatedRecords = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.recordsDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archivesDGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnToExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToPDF)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.loadingProgressBar);
            this.panel1.Controls.Add(this.btnReloadDB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 69);
            this.panel1.TabIndex = 10;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Image = ((System.Drawing.Image)(resources.GetObject("loadingProgressBar.Image")));
            this.loadingProgressBar.Location = new System.Drawing.Point(951, 14);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(39, 39);
            this.loadingProgressBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingProgressBar.TabIndex = 17;
            this.loadingProgressBar.TabStop = false;
            // 
            // btnReloadDB
            // 
            this.btnReloadDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadDB.BackColor = System.Drawing.Color.SeaGreen;
            this.btnReloadDB.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnReloadDB.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReloadDB.BorderRadius = 20;
            this.btnReloadDB.BorderSize = 0;
            this.btnReloadDB.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnReloadDB.FlatAppearance.BorderSize = 0;
            this.btnReloadDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadDB.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadDB.ForeColor = System.Drawing.Color.White;
            this.btnReloadDB.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDB.Image")));
            this.btnReloadDB.Location = new System.Drawing.Point(951, 14);
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.Size = new System.Drawing.Size(40, 40);
            this.btnReloadDB.TabIndex = 16;
            this.btnReloadDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadDB.TextColor = System.Drawing.Color.White;
            this.btnReloadDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReloadDB.UseVisualStyleBackColor = false;
            this.btnReloadDB.Click += new System.EventHandler(this.btnReloadDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "ARCHIVES";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel2.Controls.Add(this.archivesDGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 250);
            this.panel2.TabIndex = 11;
            // 
            // archivesDGV
            // 
            this.archivesDGV.AllowUserToAddRows = false;
            this.archivesDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.archivesDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.archivesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.archivesDGV.ColumnHeadersHeight = 30;
            this.archivesDGV.EnableHeadersVisualStyles = false;
            this.archivesDGV.Location = new System.Drawing.Point(11, 0);
            this.archivesDGV.Name = "archivesDGV";
            this.archivesDGV.ReadOnly = true;
            this.archivesDGV.RowHeadersVisible = false;
            this.archivesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.archivesDGV.Size = new System.Drawing.Size(980, 250);
            this.archivesDGV.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel3.Controls.Add(this.txtSelectedAYCode);
            this.panel3.Controls.Add(this.btnToExcel);
            this.panel3.Controls.Add(this.lblExportAs);
            this.panel3.Controls.Add(this.btnToPDF);
            this.panel3.Controls.Add(this.lblAssociatedRecords);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 319);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 69);
            this.panel3.TabIndex = 12;
            // 
            // txtSelectedAYCode
            // 
            this.txtSelectedAYCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSelectedAYCode.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtSelectedAYCode.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtSelectedAYCode.BorderRadius = 5;
            this.txtSelectedAYCode.BorderSize = 2;
            this.txtSelectedAYCode.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedAYCode.ForeColor = System.Drawing.Color.DimGray;
            this.txtSelectedAYCode.Location = new System.Drawing.Point(202, 17);
            this.txtSelectedAYCode.Multiline = false;
            this.txtSelectedAYCode.Name = "txtSelectedAYCode";
            this.txtSelectedAYCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSelectedAYCode.PasswordChar = false;
            this.txtSelectedAYCode.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtSelectedAYCode.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedAYCode.PlaceholderText = "Selected AY-Code";
            this.txtSelectedAYCode.Size = new System.Drawing.Size(162, 35);
            this.txtSelectedAYCode.TabIndex = 64;
            this.txtSelectedAYCode.Texts = "";
            this.txtSelectedAYCode.UnderlinedStyle = false;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnToExcel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnToExcel.Image")));
            this.btnToExcel.Location = new System.Drawing.Point(907, 14);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(38, 40);
            this.btnToExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnToExcel.TabIndex = 6;
            this.btnToExcel.TabStop = false;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // lblExportAs
            // 
            this.lblExportAs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblExportAs.AutoSize = true;
            this.lblExportAs.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportAs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblExportAs.Location = new System.Drawing.Point(826, 27);
            this.lblExportAs.Name = "lblExportAs";
            this.lblExportAs.Size = new System.Drawing.Size(75, 16);
            this.lblExportAs.TabIndex = 5;
            this.lblExportAs.Text = "EXPORT AS |";
            // 
            // btnToPDF
            // 
            this.btnToPDF.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnToPDF.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnToPDF.Image")));
            this.btnToPDF.Location = new System.Drawing.Point(951, 14);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(38, 40);
            this.btnToPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnToPDF.TabIndex = 4;
            this.btnToPDF.TabStop = false;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // lblAssociatedRecords
            // 
            this.lblAssociatedRecords.AutoSize = true;
            this.lblAssociatedRecords.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssociatedRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblAssociatedRecords.Location = new System.Drawing.Point(7, 23);
            this.lblAssociatedRecords.Name = "lblAssociatedRecords";
            this.lblAssociatedRecords.Size = new System.Drawing.Size(189, 22);
            this.lblAssociatedRecords.TabIndex = 1;
            this.lblAssociatedRecords.Text = "ASSOCIATED RECORDS";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel4.Controls.Add(this.recordsDGV);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 388);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 252);
            this.panel4.TabIndex = 13;
            // 
            // recordsDGV
            // 
            this.recordsDGV.AllowUserToAddRows = false;
            this.recordsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.recordsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recordsDGV.ColumnHeadersHeight = 30;
            this.recordsDGV.EnableHeadersVisualStyles = false;
            this.recordsDGV.Location = new System.Drawing.Point(10, 1);
            this.recordsDGV.Name = "recordsDGV";
            this.recordsDGV.ReadOnly = true;
            this.recordsDGV.RowHeadersVisible = false;
            this.recordsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recordsDGV.Size = new System.Drawing.Size(980, 240);
            this.recordsDGV.TabIndex = 9;
            // 
            // ArchivesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ArchivesControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.ArchivesControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.archivesDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnToExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToPDF)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox loadingProgressBar;
        private CustomButtons btnReloadDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView archivesDGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox btnToExcel;
        private System.Windows.Forms.Label lblExportAs;
        private System.Windows.Forms.PictureBox btnToPDF;
        private System.Windows.Forms.Label lblAssociatedRecords;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView recordsDGV;
        private CustomTextBox txtSelectedAYCode;
    }
}
