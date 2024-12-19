
namespace SVMS.Controls
{
    partial class StdTempDeleted
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StdTempDeleted));
            this.deletedDGV = new System.Windows.Forms.DataGridView();
            this.lblDeleted = new System.Windows.Forms.Label();
            this.btnDeleteAll = new SVMS.CustomButtons();
            ((System.ComponentModel.ISupportInitialize)(this.deletedDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // deletedDGV
            // 
            this.deletedDGV.AllowUserToAddRows = false;
            this.deletedDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deletedDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.deletedDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deletedDGV.ColumnHeadersHeight = 30;
            this.deletedDGV.EnableHeadersVisualStyles = false;
            this.deletedDGV.Location = new System.Drawing.Point(11, 70);
            this.deletedDGV.Name = "deletedDGV";
            this.deletedDGV.ReadOnly = true;
            this.deletedDGV.RowHeadersVisible = false;
            this.deletedDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deletedDGV.Size = new System.Drawing.Size(980, 560);
            this.deletedDGV.TabIndex = 7;
            // 
            // lblDeleted
            // 
            this.lblDeleted.AutoSize = true;
            this.lblDeleted.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblDeleted.Location = new System.Drawing.Point(7, 23);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(250, 22);
            this.lblDeleted.TabIndex = 6;
            this.lblDeleted.Text = "RECENTLY DELETED STUDENTS";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteAll.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnDeleteAll.BorderColor = System.Drawing.Color.IndianRed;
            this.btnDeleteAll.BorderRadius = 5;
            this.btnDeleteAll.BorderSize = 1;
            this.btnDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteAll.Image")));
            this.btnDeleteAll.Location = new System.Drawing.Point(865, 14);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDeleteAll.Size = new System.Drawing.Size(126, 40);
            this.btnDeleteAll.TabIndex = 8;
            this.btnDeleteAll.Text = "DELETE ALL";
            this.btnDeleteAll.TextColor = System.Drawing.Color.White;
            this.btnDeleteAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // StdTempDeleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.deletedDGV);
            this.Controls.Add(this.lblDeleted);
            this.Name = "StdTempDeleted";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.StdTempDeleted_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deletedDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButtons btnDeleteAll;
        private System.Windows.Forms.DataGridView deletedDGV;
        private System.Windows.Forms.Label lblDeleted;
    }
}
