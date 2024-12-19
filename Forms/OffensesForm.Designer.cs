
namespace SVMS.Forms
{
    partial class OffensesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OffensesForm));
            this.txtNewOffense = new SVMS.CustomTextBox();
            this.rbMinorOffense = new System.Windows.Forms.RadioButton();
            this.rbMajorOffense = new System.Windows.Forms.RadioButton();
            this.btnCancel = new SVMS.CustomButtons();
            this.btnSave = new SVMS.CustomButtons();
            this.lblStdDetails = new System.Windows.Forms.Label();
            this.topBorder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewOffense
            // 
            this.txtNewOffense.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNewOffense.BorderColor = System.Drawing.Color.DarkGray;
            this.txtNewOffense.BorderFocusColor = System.Drawing.Color.SeaGreen;
            this.txtNewOffense.BorderRadius = 0;
            this.txtNewOffense.BorderSize = 2;
            this.txtNewOffense.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewOffense.ForeColor = System.Drawing.Color.Black;
            this.txtNewOffense.Location = new System.Drawing.Point(16, 110);
            this.txtNewOffense.Multiline = false;
            this.txtNewOffense.Name = "txtNewOffense";
            this.txtNewOffense.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNewOffense.PasswordChar = false;
            this.txtNewOffense.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtNewOffense.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewOffense.PlaceholderText = "Enter Offense Name...";
            this.txtNewOffense.Size = new System.Drawing.Size(452, 35);
            this.txtNewOffense.TabIndex = 0;
            this.txtNewOffense.Texts = "";
            this.txtNewOffense.UnderlinedStyle = false;
            // 
            // rbMinorOffense
            // 
            this.rbMinorOffense.AutoSize = true;
            this.rbMinorOffense.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMinorOffense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.rbMinorOffense.Location = new System.Drawing.Point(122, 195);
            this.rbMinorOffense.Name = "rbMinorOffense";
            this.rbMinorOffense.Size = new System.Drawing.Size(118, 20);
            this.rbMinorOffense.TabIndex = 1;
            this.rbMinorOffense.TabStop = true;
            this.rbMinorOffense.Text = "MINOR OFFENSE";
            this.rbMinorOffense.UseVisualStyleBackColor = true;
            // 
            // rbMajorOffense
            // 
            this.rbMajorOffense.AutoSize = true;
            this.rbMajorOffense.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMajorOffense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.rbMajorOffense.Location = new System.Drawing.Point(254, 195);
            this.rbMajorOffense.Name = "rbMajorOffense";
            this.rbMajorOffense.Size = new System.Drawing.Size(119, 20);
            this.rbMajorOffense.TabIndex = 2;
            this.rbMajorOffense.TabStop = true;
            this.rbMajorOffense.Text = "MAJOR OFFENSE";
            this.rbMajorOffense.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(254, 231);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 43);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnSave.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnSave.BorderRadius = 0;
            this.btnSave.BorderSize = 1;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(122, 231);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 43);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStdDetails
            // 
            this.lblStdDetails.AutoSize = true;
            this.lblStdDetails.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblStdDetails.Location = new System.Drawing.Point(191, 81);
            this.lblStdDetails.Name = "lblStdDetails";
            this.lblStdDetails.Size = new System.Drawing.Size(104, 20);
            this.lblStdDetails.TabIndex = 52;
            this.lblStdDetails.Text = "NEW OFFENSE";
            // 
            // topBorder
            // 
            this.topBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.topBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBorder.Location = new System.Drawing.Point(0, 0);
            this.topBorder.Name = "topBorder";
            this.topBorder.Size = new System.Drawing.Size(484, 5);
            this.topBorder.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(118, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "OFFENSE TYPE:";
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(214, 13);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(60, 60);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 55;
            this.pbGmailIcon.TabStop = false;
            // 
            // OffensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 292);
            this.ControlBox = false;
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topBorder);
            this.Controls.Add(this.lblStdDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbMajorOffense);
            this.Controls.Add(this.rbMinorOffense);
            this.Controls.Add(this.txtNewOffense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OffensesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OffensesForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomTextBox txtNewOffense;
        private System.Windows.Forms.RadioButton rbMinorOffense;
        private System.Windows.Forms.RadioButton rbMajorOffense;
        private CustomButtons btnCancel;
        private CustomButtons btnSave;
        private System.Windows.Forms.Label lblStdDetails;
        private System.Windows.Forms.Panel topBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbGmailIcon;
    }
}