
namespace SVMS.Controls
{
    partial class VioEntryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VioEntryControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVioEntry = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.recordsDGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadingProgressBar = new System.Windows.Forms.PictureBox();
            this.lblExportAs = new System.Windows.Forms.Label();
            this.btnToPDF = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.violationsDGV = new System.Windows.Forms.DataGridView();
            this.btnReloadDB = new SVMS.CustomButtons();
            this.btnAddViolation = new SVMS.CustomButtons();
            this.cbFilter = new SVMS.CustomComboBox();
            this.txtSeachRecord = new SVMS.CustomTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToPDF)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violationsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.cbFilter);
            this.panel1.Controls.Add(this.loadingProgressBar);
            this.panel1.Controls.Add(this.btnReloadDB);
            this.panel1.Controls.Add(this.txtSeachRecord);
            this.panel1.Controls.Add(this.lblVioEntry);
            this.panel1.Controls.Add(this.btnAddViolation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 69);
            this.panel1.TabIndex = 68;
            // 
            // lblVioEntry
            // 
            this.lblVioEntry.AutoSize = true;
            this.lblVioEntry.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVioEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblVioEntry.Location = new System.Drawing.Point(14, 22);
            this.lblVioEntry.Name = "lblVioEntry";
            this.lblVioEntry.Size = new System.Drawing.Size(172, 22);
            this.lblVioEntry.TabIndex = 70;
            this.lblVioEntry.Text = "VIOLATION RECORDS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel2.Controls.Add(this.recordsDGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 250);
            this.panel2.TabIndex = 69;
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
            this.recordsDGV.Location = new System.Drawing.Point(11, 0);
            this.recordsDGV.Name = "recordsDGV";
            this.recordsDGV.ReadOnly = true;
            this.recordsDGV.RowHeadersVisible = false;
            this.recordsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recordsDGV.Size = new System.Drawing.Size(980, 250);
            this.recordsDGV.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel3.Controls.Add(this.lblExportAs);
            this.panel3.Controls.Add(this.btnToPDF);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 319);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 69);
            this.panel3.TabIndex = 70;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.loadingProgressBar.Image = ((System.Drawing.Image)(resources.GetObject("loadingProgressBar.Image")));
            this.loadingProgressBar.Location = new System.Drawing.Point(862, 13);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(39, 39);
            this.loadingProgressBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingProgressBar.TabIndex = 71;
            this.loadingProgressBar.TabStop = false;
            // 
            // lblExportAs
            // 
            this.lblExportAs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblExportAs.AutoSize = true;
            this.lblExportAs.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportAs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblExportAs.Location = new System.Drawing.Point(871, 27);
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
            this.btnToPDF.Location = new System.Drawing.Point(952, 14);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(38, 40);
            this.btnToPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnToPDF.TabIndex = 4;
            this.btnToPDF.TabStop = false;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "VIOLATION DETAILS";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel4.Controls.Add(this.violationsDGV);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 388);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 252);
            this.panel4.TabIndex = 71;
            // 
            // violationsDGV
            // 
            this.violationsDGV.AllowUserToAddRows = false;
            this.violationsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.violationsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.violationsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.violationsDGV.ColumnHeadersHeight = 30;
            this.violationsDGV.EnableHeadersVisualStyles = false;
            this.violationsDGV.Location = new System.Drawing.Point(10, 1);
            this.violationsDGV.Name = "violationsDGV";
            this.violationsDGV.ReadOnly = true;
            this.violationsDGV.RowHeadersVisible = false;
            this.violationsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.violationsDGV.Size = new System.Drawing.Size(980, 240);
            this.violationsDGV.TabIndex = 9;
            // 
            // btnReloadDB
            // 
            this.btnReloadDB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReloadDB.BackColor = System.Drawing.Color.SeaGreen;
            this.btnReloadDB.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnReloadDB.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReloadDB.BorderRadius = 20;
            this.btnReloadDB.BorderSize = 0;
            this.btnReloadDB.FlatAppearance.BorderSize = 0;
            this.btnReloadDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadDB.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadDB.ForeColor = System.Drawing.Color.White;
            this.btnReloadDB.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDB.Image")));
            this.btnReloadDB.Location = new System.Drawing.Point(862, 13);
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.Size = new System.Drawing.Size(40, 40);
            this.btnReloadDB.TabIndex = 72;
            this.btnReloadDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadDB.TextColor = System.Drawing.Color.White;
            this.btnReloadDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReloadDB.UseVisualStyleBackColor = false;
            this.btnReloadDB.Click += new System.EventHandler(this.btnReloadDB_Click);
            // 
            // btnAddViolation
            // 
            this.btnAddViolation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddViolation.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddViolation.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnAddViolation.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAddViolation.BorderRadius = 5;
            this.btnAddViolation.BorderSize = 1;
            this.btnAddViolation.FlatAppearance.BorderSize = 0;
            this.btnAddViolation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddViolation.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddViolation.ForeColor = System.Drawing.Color.White;
            this.btnAddViolation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddViolation.Image")));
            this.btnAddViolation.Location = new System.Drawing.Point(911, 13);
            this.btnAddViolation.Name = "btnAddViolation";
            this.btnAddViolation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAddViolation.Size = new System.Drawing.Size(80, 40);
            this.btnAddViolation.TabIndex = 70;
            this.btnAddViolation.Text = "ADD";
            this.btnAddViolation.TextColor = System.Drawing.Color.White;
            this.btnAddViolation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddViolation.UseVisualStyleBackColor = false;
            this.btnAddViolation.Click += new System.EventHandler(this.btnAddViolation_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbFilter.BackColor = System.Drawing.Color.White;
            this.cbFilter.BorderColor = System.Drawing.Color.DarkGray;
            this.cbFilter.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.cbFilter.BorderSize = 2;
            this.cbFilter.DropDownHeight = 72;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbFilter.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.IconColor = System.Drawing.Color.DarkGray;
            this.cbFilter.IntegralHeight = false;
            this.cbFilter.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbFilter.ListTextColor = System.Drawing.Color.DimGray;
            this.cbFilter.Location = new System.Drawing.Point(295, 17);
            this.cbFilter.MaxDropDownItems = 10;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Padding = new System.Windows.Forms.Padding(2);
            this.cbFilter.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cbFilter.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.PlaceholderText = "Select...";
            this.cbFilter.Size = new System.Drawing.Size(191, 35);
            this.cbFilter.TabIndex = 72;
            this.cbFilter.Texts = "";
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSeachRecord
            // 
            this.txtSeachRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSeachRecord.BackColor = System.Drawing.Color.White;
            this.txtSeachRecord.BorderColor = System.Drawing.Color.DarkGray;
            this.txtSeachRecord.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtSeachRecord.BorderRadius = 0;
            this.txtSeachRecord.BorderSize = 2;
            this.txtSeachRecord.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeachRecord.ForeColor = System.Drawing.Color.Black;
            this.txtSeachRecord.Location = new System.Drawing.Point(492, 17);
            this.txtSeachRecord.Multiline = false;
            this.txtSeachRecord.Name = "txtSeachRecord";
            this.txtSeachRecord.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSeachRecord.PasswordChar = false;
            this.txtSeachRecord.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSeachRecord.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeachRecord.PlaceholderText = "Search Student ID or Last Name...";
            this.txtSeachRecord.Size = new System.Drawing.Size(213, 35);
            this.txtSeachRecord.TabIndex = 71;
            this.txtSeachRecord.Texts = "";
            this.txtSeachRecord.UnderlinedStyle = false;
            this.txtSeachRecord._TextChanged += new System.EventHandler(this.txtSearchRecord__TextChanged);
            // 
            // VioEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 20);
            this.Name = "VioEntryControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.VioEntryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordsDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToPDF)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.violationsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVioEntry;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView recordsDGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView violationsDGV;
        private CustomButtons btnReloadDB;
        private System.Windows.Forms.PictureBox loadingProgressBar;
        private CustomButtons btnAddViolation;
        private System.Windows.Forms.Label lblExportAs;
        private System.Windows.Forms.PictureBox btnToPDF;
        private CustomComboBox cbFilter;
        private CustomTextBox txtSeachRecord;
    }
}
