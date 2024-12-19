
namespace SVMS.Controls
{
    partial class OffensesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OffensesControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingProgressBar = new System.Windows.Forms.PictureBox();
            this.btnAddOffense = new SVMS.CustomButtons();
            this.btnReloadDB = new SVMS.CustomButtons();
            this.lblMinor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.minorOffensesDGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMajor = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.majorOffensesDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minorOffensesDGV)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.majorOffensesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.loadingProgressBar);
            this.panel1.Controls.Add(this.btnAddOffense);
            this.panel1.Controls.Add(this.btnReloadDB);
            this.panel1.Controls.Add(this.lblMinor);
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
            this.loadingProgressBar.Location = new System.Drawing.Point(862, 14);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(39, 39);
            this.loadingProgressBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingProgressBar.TabIndex = 19;
            this.loadingProgressBar.TabStop = false;
            // 
            // btnAddOffense
            // 
            this.btnAddOffense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOffense.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddOffense.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnAddOffense.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAddOffense.BorderRadius = 5;
            this.btnAddOffense.BorderSize = 1;
            this.btnAddOffense.FlatAppearance.BorderSize = 0;
            this.btnAddOffense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOffense.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOffense.ForeColor = System.Drawing.Color.White;
            this.btnAddOffense.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOffense.Image")));
            this.btnAddOffense.Location = new System.Drawing.Point(911, 14);
            this.btnAddOffense.Name = "btnAddOffense";
            this.btnAddOffense.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAddOffense.Size = new System.Drawing.Size(80, 40);
            this.btnAddOffense.TabIndex = 18;
            this.btnAddOffense.Text = "ADD";
            this.btnAddOffense.TextColor = System.Drawing.Color.White;
            this.btnAddOffense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddOffense.UseVisualStyleBackColor = false;
            this.btnAddOffense.Click += new System.EventHandler(this.btnAddOffense_Click);
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
            this.btnReloadDB.Location = new System.Drawing.Point(862, 14);
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.Size = new System.Drawing.Size(40, 40);
            this.btnReloadDB.TabIndex = 16;
            this.btnReloadDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadDB.TextColor = System.Drawing.Color.White;
            this.btnReloadDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReloadDB.UseVisualStyleBackColor = false;
            this.btnReloadDB.Click += new System.EventHandler(this.btnReloadDB_Click);
            // 
            // lblMinor
            // 
            this.lblMinor.AutoSize = true;
            this.lblMinor.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblMinor.Location = new System.Drawing.Point(7, 23);
            this.lblMinor.Name = "lblMinor";
            this.lblMinor.Size = new System.Drawing.Size(182, 22);
            this.lblMinor.TabIndex = 0;
            this.lblMinor.Text = "MINOR OFFENSES LIST";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel2.Controls.Add(this.minorOffensesDGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 250);
            this.panel2.TabIndex = 11;
            // 
            // minorOffensesDGV
            // 
            this.minorOffensesDGV.AllowUserToAddRows = false;
            this.minorOffensesDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minorOffensesDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.minorOffensesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minorOffensesDGV.ColumnHeadersHeight = 30;
            this.minorOffensesDGV.EnableHeadersVisualStyles = false;
            this.minorOffensesDGV.Location = new System.Drawing.Point(11, 0);
            this.minorOffensesDGV.Name = "minorOffensesDGV";
            this.minorOffensesDGV.ReadOnly = true;
            this.minorOffensesDGV.RowHeadersVisible = false;
            this.minorOffensesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.minorOffensesDGV.Size = new System.Drawing.Size(980, 250);
            this.minorOffensesDGV.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel3.Controls.Add(this.lblMajor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 319);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 69);
            this.panel3.TabIndex = 12;
            // 
            // lblMajor
            // 
            this.lblMajor.AutoSize = true;
            this.lblMajor.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblMajor.Location = new System.Drawing.Point(7, 23);
            this.lblMajor.Name = "lblMajor";
            this.lblMajor.Size = new System.Drawing.Size(186, 22);
            this.lblMajor.TabIndex = 1;
            this.lblMajor.Text = "MAJOR OFFENSES LIST";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel4.Controls.Add(this.majorOffensesDGV);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 388);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 252);
            this.panel4.TabIndex = 13;
            // 
            // majorOffensesDGV
            // 
            this.majorOffensesDGV.AllowUserToAddRows = false;
            this.majorOffensesDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.majorOffensesDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.majorOffensesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.majorOffensesDGV.ColumnHeadersHeight = 30;
            this.majorOffensesDGV.EnableHeadersVisualStyles = false;
            this.majorOffensesDGV.Location = new System.Drawing.Point(10, 1);
            this.majorOffensesDGV.Name = "majorOffensesDGV";
            this.majorOffensesDGV.ReadOnly = true;
            this.majorOffensesDGV.RowHeadersVisible = false;
            this.majorOffensesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.majorOffensesDGV.Size = new System.Drawing.Size(980, 240);
            this.majorOffensesDGV.TabIndex = 9;
            // 
            // OffensesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OffensesControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.OffensesControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingProgressBar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minorOffensesDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.majorOffensesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomButtons btnReloadDB;
        private System.Windows.Forms.Label lblMinor;
        private CustomButtons btnAddOffense;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView minorOffensesDGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView majorOffensesDGV;
        private System.Windows.Forms.PictureBox loadingProgressBar;
    }
}
