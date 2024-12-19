
namespace SVMS.Forms
{
    partial class YearForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearForm));
            this.formBorder = new System.Windows.Forms.Panel();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblFromYear = new System.Windows.Forms.Label();
            this.lblAyCode = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblToYear = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkActive = new SVMS.ToggleButton();
            this.btnCancel = new SVMS.CustomButtons();
            this.btnSave = new SVMS.CustomButtons();
            this.txtAyCode = new System.Windows.Forms.Label();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            this.txtFromYear = new SVMS.CustomTextBox();
            this.txtToYear = new SVMS.CustomTextBox();
            this.cbSemester = new SVMS.CustomComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // formBorder
            // 
            this.formBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.formBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBorder.Location = new System.Drawing.Point(0, 0);
            this.formBorder.Name = "formBorder";
            this.formBorder.Size = new System.Drawing.Size(266, 5);
            this.formBorder.TabIndex = 19;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblYear.Location = new System.Drawing.Point(45, 89);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(177, 20);
            this.lblYear.TabIndex = 18;
            this.lblYear.Text = "ACADEMIC YEAR DETAILS";
            // 
            // lblFromYear
            // 
            this.lblFromYear.AutoSize = true;
            this.lblFromYear.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblFromYear.Location = new System.Drawing.Point(23, 148);
            this.lblFromYear.Name = "lblFromYear";
            this.lblFromYear.Size = new System.Drawing.Size(73, 16);
            this.lblFromYear.TabIndex = 16;
            this.lblFromYear.Text = "FROM YEAR :";
            // 
            // lblAyCode
            // 
            this.lblAyCode.AutoSize = true;
            this.lblAyCode.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblAyCode.Location = new System.Drawing.Point(23, 125);
            this.lblAyCode.Name = "lblAyCode";
            this.lblAyCode.Size = new System.Drawing.Size(59, 16);
            this.lblAyCode.TabIndex = 15;
            this.lblAyCode.Text = "AY-CODE :";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.ForeColor = System.Drawing.Color.White;
            this.lblSemester.Location = new System.Drawing.Point(67, 209);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(0, 13);
            this.lblSemester.TabIndex = 23;
            // 
            // lblToYear
            // 
            this.lblToYear.AutoSize = true;
            this.lblToYear.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblToYear.Location = new System.Drawing.Point(23, 205);
            this.lblToYear.Name = "lblToYear";
            this.lblToYear.Size = new System.Drawing.Size(59, 16);
            this.lblToYear.TabIndex = 25;
            this.lblToYear.Text = "TO YEAR :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblStatus.Location = new System.Drawing.Point(23, 324);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 16);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "STATUS :";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(81, 322);
            this.chkActive.MinimumSize = new System.Drawing.Size(45, 22);
            this.chkActive.Name = "chkActive";
            this.chkActive.OffBackColor = System.Drawing.Color.Gray;
            this.chkActive.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.chkActive.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(212)))), ((int)(((byte)(133)))));
            this.chkActive.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.chkActive.Size = new System.Drawing.Size(45, 22);
            this.chkActive.TabIndex = 27;
            this.chkActive.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(141, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 21;
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
            this.btnSave.Location = new System.Drawing.Point(26, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAyCode
            // 
            this.txtAyCode.AutoSize = true;
            this.txtAyCode.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAyCode.ForeColor = System.Drawing.Color.DimGray;
            this.txtAyCode.Location = new System.Drawing.Point(82, 125);
            this.txtAyCode.Name = "txtAyCode";
            this.txtAyCode.Size = new System.Drawing.Size(98, 16);
            this.txtAyCode.TabIndex = 29;
            this.txtAyCode.Text = "AUTO GENERATE";
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(111, 26);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(50, 50);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 43;
            this.pbGmailIcon.TabStop = false;
            // 
            // txtFromYear
            // 
            this.txtFromYear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFromYear.BorderColor = System.Drawing.Color.DarkGray;
            this.txtFromYear.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtFromYear.BorderRadius = 0;
            this.txtFromYear.BorderSize = 2;
            this.txtFromYear.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromYear.ForeColor = System.Drawing.Color.Black;
            this.txtFromYear.Location = new System.Drawing.Point(26, 167);
            this.txtFromYear.Multiline = false;
            this.txtFromYear.Name = "txtFromYear";
            this.txtFromYear.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFromYear.PasswordChar = false;
            this.txtFromYear.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtFromYear.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromYear.PlaceholderText = "Write Year...";
            this.txtFromYear.Size = new System.Drawing.Size(215, 35);
            this.txtFromYear.TabIndex = 44;
            this.txtFromYear.Texts = "";
            this.txtFromYear.UnderlinedStyle = false;
            // 
            // txtToYear
            // 
            this.txtToYear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtToYear.BorderColor = System.Drawing.Color.DarkGray;
            this.txtToYear.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtToYear.BorderRadius = 0;
            this.txtToYear.BorderSize = 2;
            this.txtToYear.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToYear.ForeColor = System.Drawing.Color.Black;
            this.txtToYear.Location = new System.Drawing.Point(26, 224);
            this.txtToYear.Multiline = false;
            this.txtToYear.Name = "txtToYear";
            this.txtToYear.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtToYear.PasswordChar = false;
            this.txtToYear.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtToYear.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToYear.PlaceholderText = "Write Year...";
            this.txtToYear.Size = new System.Drawing.Size(215, 35);
            this.txtToYear.TabIndex = 45;
            this.txtToYear.Texts = "";
            this.txtToYear.UnderlinedStyle = false;
            // 
            // cbSemester
            // 
            this.cbSemester.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbSemester.BorderColor = System.Drawing.Color.DarkGray;
            this.cbSemester.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.cbSemester.BorderSize = 2;
            this.cbSemester.DropDownHeight = 72;
            this.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbSemester.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemester.ForeColor = System.Drawing.Color.Black;
            this.cbSemester.IconColor = System.Drawing.Color.DarkGray;
            this.cbSemester.IntegralHeight = false;
            this.cbSemester.Items.AddRange(new object[] {
            "1st SEM",
            "2nd SEM"});
            this.cbSemester.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbSemester.ListTextColor = System.Drawing.Color.Black;
            this.cbSemester.Location = new System.Drawing.Point(26, 281);
            this.cbSemester.MaxDropDownItems = 10;
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Padding = new System.Windows.Forms.Padding(2);
            this.cbSemester.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cbSemester.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemester.PlaceholderText = "Select Semester...";
            this.cbSemester.Size = new System.Drawing.Size(215, 35);
            this.cbSemester.TabIndex = 46;
            this.cbSemester.Texts = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(23, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "SEMESTER :";
            // 
            // YearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(266, 428);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.txtToYear);
            this.Controls.Add(this.txtFromYear);
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.txtAyCode);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.lblToYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.formBorder);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblFromYear);
            this.Controls.Add(this.lblAyCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YearForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YearForm";
            this.Load += new System.EventHandler(this.YearForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButtons btnCancel;
        private CustomButtons btnSave;
        private System.Windows.Forms.Panel formBorder;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblFromYear;
        private System.Windows.Forms.Label lblAyCode;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblToYear;
        private ToggleButton chkActive;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtAyCode;
        private System.Windows.Forms.PictureBox pbGmailIcon;
        private CustomTextBox txtFromYear;
        private CustomTextBox txtToYear;
        private CustomComboBox cbSemester;
        private System.Windows.Forms.Label label1;
    }
}