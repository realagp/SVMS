
namespace SVMS.Controls
{
    partial class YearControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearControl));
            this.lblAcadYear = new System.Windows.Forms.Label();
            this.acadyearDGV = new System.Windows.Forms.DataGridView();
            this.loadingProgressBar = new System.Windows.Forms.PictureBox();
            this.btnReloadDB = new SVMS.CustomButtons();
            this.btnAddYear = new SVMS.CustomButtons();
            ((System.ComponentModel.ISupportInitialize)(this.acadyearDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAcadYear
            // 
            this.lblAcadYear.AutoSize = true;
            this.lblAcadYear.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcadYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblAcadYear.Location = new System.Drawing.Point(7, 23);
            this.lblAcadYear.Name = "lblAcadYear";
            this.lblAcadYear.Size = new System.Drawing.Size(138, 22);
            this.lblAcadYear.TabIndex = 0;
            this.lblAcadYear.Text = "ACADEMIC YEAR";
            // 
            // acadyearDGV
            // 
            this.acadyearDGV.AllowUserToAddRows = false;
            this.acadyearDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acadyearDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.acadyearDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.acadyearDGV.ColumnHeadersHeight = 30;
            this.acadyearDGV.EnableHeadersVisualStyles = false;
            this.acadyearDGV.Location = new System.Drawing.Point(11, 70);
            this.acadyearDGV.Name = "acadyearDGV";
            this.acadyearDGV.ReadOnly = true;
            this.acadyearDGV.RowHeadersVisible = false;
            this.acadyearDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.acadyearDGV.Size = new System.Drawing.Size(980, 560);
            this.acadyearDGV.TabIndex = 4;
            this.acadyearDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.acadyearDGV_DataBindingComplete);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Image = ((System.Drawing.Image)(resources.GetObject("loadingProgressBar.Image")));
            this.loadingProgressBar.Location = new System.Drawing.Point(862, 14);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(39, 39);
            this.loadingProgressBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingProgressBar.TabIndex = 21;
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
            this.btnReloadDB.FlatAppearance.BorderSize = 0;
            this.btnReloadDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadDB.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadDB.ForeColor = System.Drawing.Color.White;
            this.btnReloadDB.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadDB.Image")));
            this.btnReloadDB.Location = new System.Drawing.Point(862, 14);
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.Size = new System.Drawing.Size(40, 40);
            this.btnReloadDB.TabIndex = 20;
            this.btnReloadDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadDB.TextColor = System.Drawing.Color.White;
            this.btnReloadDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReloadDB.UseVisualStyleBackColor = false;
            this.btnReloadDB.Click += new System.EventHandler(this.btnReloadDB_Click);
            // 
            // btnAddYear
            // 
            this.btnAddYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddYear.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddYear.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnAddYear.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAddYear.BorderRadius = 5;
            this.btnAddYear.BorderSize = 1;
            this.btnAddYear.FlatAppearance.BorderSize = 0;
            this.btnAddYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddYear.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddYear.ForeColor = System.Drawing.Color.White;
            this.btnAddYear.Image = ((System.Drawing.Image)(resources.GetObject("btnAddYear.Image")));
            this.btnAddYear.Location = new System.Drawing.Point(911, 14);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAddYear.Size = new System.Drawing.Size(80, 40);
            this.btnAddYear.TabIndex = 5;
            this.btnAddYear.Text = "ADD";
            this.btnAddYear.TextColor = System.Drawing.Color.White;
            this.btnAddYear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddYear.UseVisualStyleBackColor = false;
            this.btnAddYear.Click += new System.EventHandler(this.btnAddYear_Click);
            // 
            // YearControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.btnReloadDB);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.acadyearDGV);
            this.Controls.Add(this.lblAcadYear);
            this.Name = "YearControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.YearControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.acadyearDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAcadYear;
        private CustomButtons btnAddYear;
        private System.Windows.Forms.DataGridView acadyearDGV;
        private System.Windows.Forms.PictureBox loadingProgressBar;
        private CustomButtons btnReloadDB;
    }
}
