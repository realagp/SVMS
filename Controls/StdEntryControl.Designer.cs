
namespace SVMS.Controls
{
    partial class StdEntryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StdEntryControl));
            this.studentsDGV = new System.Windows.Forms.DataGridView();
            this.lblStdEntry = new System.Windows.Forms.Label();
            this.loadingProgressBar = new System.Windows.Forms.PictureBox();
            this.cbFilter = new SVMS.CustomComboBox();
            this.txtSearchID = new SVMS.CustomTextBox();
            this.btnReloadDB = new SVMS.CustomButtons();
            this.btnAddStudent = new SVMS.CustomButtons();
            this.txtActiveAYCode = new SVMS.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // studentsDGV
            // 
            this.studentsDGV.AllowUserToAddRows = false;
            this.studentsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.studentsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studentsDGV.ColumnHeadersHeight = 30;
            this.studentsDGV.EnableHeadersVisualStyles = false;
            this.studentsDGV.Location = new System.Drawing.Point(11, 70);
            this.studentsDGV.Name = "studentsDGV";
            this.studentsDGV.ReadOnly = true;
            this.studentsDGV.RowHeadersVisible = false;
            this.studentsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentsDGV.Size = new System.Drawing.Size(980, 560);
            this.studentsDGV.TabIndex = 4;
            // 
            // lblStdEntry
            // 
            this.lblStdEntry.AutoSize = true;
            this.lblStdEntry.BackColor = System.Drawing.Color.Transparent;
            this.lblStdEntry.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblStdEntry.Location = new System.Drawing.Point(7, 23);
            this.lblStdEntry.Name = "lblStdEntry";
            this.lblStdEntry.Size = new System.Drawing.Size(192, 22);
            this.lblStdEntry.TabIndex = 0;
            this.lblStdEntry.Text = "STUDENT INFORMATION";
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Image = ((System.Drawing.Image)(resources.GetObject("loadingProgressBar.Image")));
            this.loadingProgressBar.Location = new System.Drawing.Point(862, 14);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(39, 39);
            this.loadingProgressBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingProgressBar.TabIndex = 15;
            this.loadingProgressBar.TabStop = false;
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
            this.cbFilter.Location = new System.Drawing.Point(224, 19);
            this.cbFilter.MaxDropDownItems = 10;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Padding = new System.Windows.Forms.Padding(2);
            this.cbFilter.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cbFilter.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.PlaceholderText = "Select...";
            this.cbFilter.Size = new System.Drawing.Size(191, 35);
            this.cbFilter.TabIndex = 62;
            this.cbFilter.Texts = "";
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSearchID
            // 
            this.txtSearchID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearchID.BackColor = System.Drawing.Color.White;
            this.txtSearchID.BorderColor = System.Drawing.Color.DarkGray;
            this.txtSearchID.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtSearchID.BorderRadius = 0;
            this.txtSearchID.BorderSize = 2;
            this.txtSearchID.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchID.ForeColor = System.Drawing.Color.Black;
            this.txtSearchID.Location = new System.Drawing.Point(431, 19);
            this.txtSearchID.Multiline = false;
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearchID.PasswordChar = false;
            this.txtSearchID.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSearchID.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchID.PlaceholderText = "Search Student ID or Last Name...";
            this.txtSearchID.Size = new System.Drawing.Size(213, 35);
            this.txtSearchID.TabIndex = 61;
            this.txtSearchID.Texts = "";
            this.txtSearchID.UnderlinedStyle = false;
            this.txtSearchID._TextChanged += new System.EventHandler(this.txtSearchID__TextChanged);
            // 
            // btnReloadDB
            // 
            this.btnReloadDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnReloadDB.Location = new System.Drawing.Point(862, 14);
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.Size = new System.Drawing.Size(40, 40);
            this.btnReloadDB.TabIndex = 14;
            this.btnReloadDB.TextColor = System.Drawing.Color.White;
            this.btnReloadDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReloadDB.UseVisualStyleBackColor = false;
            this.btnReloadDB.Click += new System.EventHandler(this.btnReloadDB_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddStudent.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddStudent.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnAddStudent.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAddStudent.BorderRadius = 5;
            this.btnAddStudent.BorderSize = 1;
            this.btnAddStudent.FlatAppearance.BorderSize = 0;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStudent.Image")));
            this.btnAddStudent.Location = new System.Drawing.Point(911, 14);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAddStudent.Size = new System.Drawing.Size(80, 40);
            this.btnAddStudent.TabIndex = 5;
            this.btnAddStudent.Text = "ADD";
            this.btnAddStudent.TextColor = System.Drawing.Color.White;
            this.btnAddStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // txtActiveAYCode
            // 
            this.txtActiveAYCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActiveAYCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtActiveAYCode.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtActiveAYCode.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtActiveAYCode.BorderRadius = 5;
            this.txtActiveAYCode.BorderSize = 2;
            this.txtActiveAYCode.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActiveAYCode.ForeColor = System.Drawing.Color.DimGray;
            this.txtActiveAYCode.Location = new System.Drawing.Point(674, 19);
            this.txtActiveAYCode.Multiline = false;
            this.txtActiveAYCode.Name = "txtActiveAYCode";
            this.txtActiveAYCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtActiveAYCode.PasswordChar = false;
            this.txtActiveAYCode.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtActiveAYCode.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActiveAYCode.PlaceholderText = "Active AY-Code";
            this.txtActiveAYCode.Size = new System.Drawing.Size(162, 35);
            this.txtActiveAYCode.TabIndex = 63;
            this.txtActiveAYCode.Texts = "";
            this.txtActiveAYCode.UnderlinedStyle = false;
            // 
            // StdEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.txtActiveAYCode);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearchID);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.btnReloadDB);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.lblStdEntry);
            this.Controls.Add(this.studentsDGV);
            this.Name = "StdEntryControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.StdEntryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView studentsDGV;
        private System.Windows.Forms.Label lblStdEntry;
        private CustomButtons btnAddStudent;
        private CustomButtons btnReloadDB;
        private System.Windows.Forms.PictureBox loadingProgressBar;
        private CustomTextBox txtSearchID;
        private CustomComboBox cbFilter;
        private CustomTextBox txtActiveAYCode;
    }
}
