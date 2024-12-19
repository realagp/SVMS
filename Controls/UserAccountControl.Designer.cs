
namespace SVMS.Controls
{
    partial class UserAccountControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountControl));
            this.usersDGV = new System.Windows.Forms.DataGridView();
            this.lblVioEntry = new System.Windows.Forms.Label();
            this.btnAddUser = new SVMS.CustomButtons();
            ((System.ComponentModel.ISupportInitialize)(this.usersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // usersDGV
            // 
            this.usersDGV.AllowUserToAddRows = false;
            this.usersDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.usersDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersDGV.ColumnHeadersHeight = 30;
            this.usersDGV.EnableHeadersVisualStyles = false;
            this.usersDGV.Location = new System.Drawing.Point(12, 68);
            this.usersDGV.Name = "usersDGV";
            this.usersDGV.ReadOnly = true;
            this.usersDGV.RowHeadersVisible = false;
            this.usersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDGV.Size = new System.Drawing.Size(980, 560);
            this.usersDGV.TabIndex = 10;
            // 
            // lblVioEntry
            // 
            this.lblVioEntry.AutoSize = true;
            this.lblVioEntry.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVioEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblVioEntry.Location = new System.Drawing.Point(8, 21);
            this.lblVioEntry.Name = "lblVioEntry";
            this.lblVioEntry.Size = new System.Drawing.Size(165, 22);
            this.lblVioEntry.TabIndex = 8;
            this.lblVioEntry.Text = "AUTHORIZED USERS";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddUser.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnAddUser.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAddUser.BorderRadius = 5;
            this.btnAddUser.BorderSize = 1;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.Location = new System.Drawing.Point(911, 14);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAddUser.Size = new System.Drawing.Size(80, 40);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.Text = "ADD";
            this.btnAddUser.TextColor = System.Drawing.Color.White;
            this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // UserAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.usersDGV);
            this.Controls.Add(this.lblVioEntry);
            this.Name = "UserAccountControl";
            this.Size = new System.Drawing.Size(1000, 640);
            this.Load += new System.EventHandler(this.UserAccountControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usersDGV;
        private System.Windows.Forms.Label lblVioEntry;
        private CustomButtons btnAddUser;
    }
}
