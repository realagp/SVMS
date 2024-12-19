
namespace SVMS.Controls
{
    partial class DashboardControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardControl));
            this.lblDashboard = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.violationPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtTotalViolationsAY = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStudentsWithViolations = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtActiveAcademicYear = new System.Windows.Forms.Label();
            this.activityDGV = new System.Windows.Forms.DataGridView();
            this.panelActivity = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelTop3 = new System.Windows.Forms.Panel();
            this.StatsDGV = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteLogs = new SVMS.CustomButtons();
            this.panel3.SuspendLayout();
            this.violationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityDGV)).BeginInit();
            this.panelActivity.SuspendLayout();
            this.panelTop3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDashboard.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblDashboard.Location = new System.Drawing.Point(7, 23);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(109, 22);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "DASHBOARD";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.violationPanel);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(92, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(815, 129);
            this.panel3.TabIndex = 7;
            // 
            // violationPanel
            // 
            this.violationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.violationPanel.BackColor = System.Drawing.Color.IndianRed;
            this.violationPanel.Controls.Add(this.label2);
            this.violationPanel.Controls.Add(this.label1);
            this.violationPanel.Controls.Add(this.pictureBox3);
            this.violationPanel.Controls.Add(this.txtTotalViolationsAY);
            this.violationPanel.Location = new System.Drawing.Point(588, 0);
            this.violationPanel.Name = "violationPanel";
            this.violationPanel.Size = new System.Drawing.Size(227, 129);
            this.violationPanel.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "VIOLATIONS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "RECORDED";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(149, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // txtTotalViolationsAY
            // 
            this.txtTotalViolationsAY.AutoSize = true;
            this.txtTotalViolationsAY.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalViolationsAY.ForeColor = System.Drawing.Color.White;
            this.txtTotalViolationsAY.Location = new System.Drawing.Point(3, 67);
            this.txtTotalViolationsAY.Name = "txtTotalViolationsAY";
            this.txtTotalViolationsAY.Size = new System.Drawing.Size(47, 57);
            this.txtTotalViolationsAY.TabIndex = 2;
            this.txtTotalViolationsAY.Text = "0";
            this.txtTotalViolationsAY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(212)))), ((int)(((byte)(102)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtStudentsWithViolations);
            this.panel2.Location = new System.Drawing.Point(294, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 129);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(9, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "VIOLATIONS";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(154, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "STUDENTS WITH";
            // 
            // txtStudentsWithViolations
            // 
            this.txtStudentsWithViolations.AutoSize = true;
            this.txtStudentsWithViolations.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentsWithViolations.ForeColor = System.Drawing.SystemColors.Window;
            this.txtStudentsWithViolations.Location = new System.Drawing.Point(3, 67);
            this.txtStudentsWithViolations.Name = "txtStudentsWithViolations";
            this.txtStudentsWithViolations.Size = new System.Drawing.Size(47, 57);
            this.txtStudentsWithViolations.TabIndex = 1;
            this.txtStudentsWithViolations.Text = "0";
            this.txtStudentsWithViolations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtActiveAcademicYear);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 129);
            this.panel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "YEAR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(154, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "ACTIVE ACADEMIC";
            // 
            // txtActiveAcademicYear
            // 
            this.txtActiveAcademicYear.AutoSize = true;
            this.txtActiveAcademicYear.Font = new System.Drawing.Font("Arial Narrow", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActiveAcademicYear.ForeColor = System.Drawing.Color.White;
            this.txtActiveAcademicYear.Location = new System.Drawing.Point(3, 93);
            this.txtActiveAcademicYear.Name = "txtActiveAcademicYear";
            this.txtActiveAcademicYear.Size = new System.Drawing.Size(218, 27);
            this.txtActiveAcademicYear.TabIndex = 2;
            this.txtActiveAcademicYear.Text = "AY-2025/2026-1ST SEM";
            this.txtActiveAcademicYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // activityDGV
            // 
            this.activityDGV.AllowUserToAddRows = false;
            this.activityDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.activityDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.activityDGV.ColumnHeadersHeight = 30;
            this.activityDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activityDGV.EnableHeadersVisualStyles = false;
            this.activityDGV.Location = new System.Drawing.Point(0, 0);
            this.activityDGV.Name = "activityDGV";
            this.activityDGV.ReadOnly = true;
            this.activityDGV.RowHeadersVisible = false;
            this.activityDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.activityDGV.Size = new System.Drawing.Size(980, 197);
            this.activityDGV.TabIndex = 9;
            // 
            // panelActivity
            // 
            this.panelActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActivity.Controls.Add(this.activityDGV);
            this.panelActivity.Location = new System.Drawing.Point(11, 433);
            this.panelActivity.Name = "panelActivity";
            this.panelActivity.Size = new System.Drawing.Size(980, 197);
            this.panelActivity.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(7, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "      ACTIVITY LOGS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop3
            // 
            this.panelTop3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelTop3.Controls.Add(this.StatsDGV);
            this.panelTop3.Location = new System.Drawing.Point(11, 266);
            this.panelTop3.Name = "panelTop3";
            this.panelTop3.Size = new System.Drawing.Size(980, 124);
            this.panelTop3.TabIndex = 12;
            // 
            // StatsDGV
            // 
            this.StatsDGV.AllowUserToAddRows = false;
            this.StatsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.StatsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatsDGV.ColumnHeadersHeight = 30;
            this.StatsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatsDGV.EnableHeadersVisualStyles = false;
            this.StatsDGV.Location = new System.Drawing.Point(0, 0);
            this.StatsDGV.Name = "StatsDGV";
            this.StatsDGV.ReadOnly = true;
            this.StatsDGV.RowHeadersVisible = false;
            this.StatsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StatsDGV.Size = new System.Drawing.Size(980, 124);
            this.StatsDGV.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(7, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "      STATISTICS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFilter
            // 
            this.dtpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFilter.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(136, 400);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(95, 22);
            this.dtpFilter.TabIndex = 11;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // btnDeleteLogs
            // 
            this.btnDeleteLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteLogs.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDeleteLogs.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDeleteLogs.BorderRadius = 0;
            this.btnDeleteLogs.BorderSize = 0;
            this.btnDeleteLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteLogs.FlatAppearance.BorderSize = 0;
            this.btnDeleteLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLogs.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLogs.Image")));
            this.btnDeleteLogs.Location = new System.Drawing.Point(237, 398);
            this.btnDeleteLogs.Name = "btnDeleteLogs";
            this.btnDeleteLogs.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteLogs.TabIndex = 11;
            this.btnDeleteLogs.TextColor = System.Drawing.Color.White;
            this.btnDeleteLogs.UseVisualStyleBackColor = false;
            this.btnDeleteLogs.Click += new System.EventHandler(this.btnDeleteLogs_Click);
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.dtpFilter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panelTop3);
            this.Controls.Add(this.btnDeleteLogs);
            this.Controls.Add(this.panelActivity);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDashboard);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.panel3.ResumeLayout(false);
            this.violationPanel.ResumeLayout(false);
            this.violationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityDGV)).EndInit();
            this.panelActivity.ResumeLayout(false);
            this.panelTop3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel violationPanel;
        private System.Windows.Forms.Label txtTotalViolationsAY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtStudentsWithViolations;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtActiveAcademicYear;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView activityDGV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelActivity;
        private CustomButtons btnDeleteLogs;
        private System.Windows.Forms.Panel panelTop3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView StatsDGV;
        private System.Windows.Forms.DateTimePicker dtpFilter;
    }
}
