
namespace SVMS.Forms
{
    partial class VioEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VioEntryForm));
            this.btnCancel = new SVMS.CustomButtons();
            this.btnSave = new SVMS.CustomButtons();
            this.topBorder = new System.Windows.Forms.Panel();
            this.lblStdDetails = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblAyCode = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblProgramSection = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lvlViolation = new System.Windows.Forms.Label();
            this.lblSanction = new System.Windows.Forms.Label();
            this.txtAYCode = new SVMS.CustomTextBox();
            this.txtStudentID = new SVMS.CustomTextBox();
            this.txtCourse = new SVMS.CustomTextBox();
            this.txtLastName = new SVMS.CustomTextBox();
            this.txtFirstName = new SVMS.CustomTextBox();
            this.txtSearchID = new SVMS.CustomTextBox();
            this.cbOffenseType = new SVMS.CustomComboBox();
            this.pbGmailIcon = new System.Windows.Forms.PictureBox();
            this.cbSanction = new SVMS.CustomComboBox();
            this.cbViolation = new SVMS.CustomComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).BeginInit();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(276, 489);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 43);
            this.btnCancel.TabIndex = 40;
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
            this.btnSave.Location = new System.Drawing.Point(144, 489);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 43);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // topBorder
            // 
            this.topBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.topBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBorder.Location = new System.Drawing.Point(0, 0);
            this.topBorder.Name = "topBorder";
            this.topBorder.Size = new System.Drawing.Size(416, 5);
            this.topBorder.TabIndex = 50;
            // 
            // lblStdDetails
            // 
            this.lblStdDetails.AutoSize = true;
            this.lblStdDetails.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblStdDetails.Location = new System.Drawing.Point(140, 93);
            this.lblStdDetails.Name = "lblStdDetails";
            this.lblStdDetails.Size = new System.Drawing.Size(140, 20);
            this.lblStdDetails.TabIndex = 51;
            this.lblStdDetails.Text = "VIOLATION DETAILS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(21, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "SEARCH STUDENT ID: ";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblStudentID.Location = new System.Drawing.Point(21, 184);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(72, 16);
            this.lblStudentID.TabIndex = 54;
            this.lblStudentID.Text = "STUDENT ID:";
            // 
            // lblAyCode
            // 
            this.lblAyCode.AutoSize = true;
            this.lblAyCode.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblAyCode.Location = new System.Drawing.Point(210, 127);
            this.lblAyCode.Name = "lblAyCode";
            this.lblAyCode.Size = new System.Drawing.Size(93, 16);
            this.lblAyCode.TabIndex = 55;
            this.lblAyCode.Text = "ACADEMIC YEAR:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblLastName.Location = new System.Drawing.Point(21, 241);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(69, 16);
            this.lblLastName.TabIndex = 56;
            this.lblLastName.Text = "LAST NAME:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblFirstName.Location = new System.Drawing.Point(210, 241);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(72, 16);
            this.lblFirstName.TabIndex = 57;
            this.lblFirstName.Text = "FIRST NAME:";
            // 
            // lblProgramSection
            // 
            this.lblProgramSection.AutoSize = true;
            this.lblProgramSection.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblProgramSection.Location = new System.Drawing.Point(210, 184);
            this.lblProgramSection.Name = "lblProgramSection";
            this.lblProgramSection.Size = new System.Drawing.Size(53, 16);
            this.lblProgramSection.TabIndex = 58;
            this.lblProgramSection.Text = "COURSE:";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblAction.Location = new System.Drawing.Point(21, 298);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(87, 16);
            this.lblAction.TabIndex = 60;
            this.lblAction.Text = "OFFENSE TYPE:";
            // 
            // lvlViolation
            // 
            this.lvlViolation.AutoSize = true;
            this.lvlViolation.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlViolation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lvlViolation.Location = new System.Drawing.Point(21, 354);
            this.lvlViolation.Name = "lvlViolation";
            this.lvlViolation.Size = new System.Drawing.Size(67, 16);
            this.lvlViolation.TabIndex = 59;
            this.lvlViolation.Text = "VIOLATION:";
            // 
            // lblSanction
            // 
            this.lblSanction.AutoSize = true;
            this.lblSanction.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSanction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.lblSanction.Location = new System.Drawing.Point(21, 411);
            this.lblSanction.Name = "lblSanction";
            this.lblSanction.Size = new System.Drawing.Size(64, 16);
            this.lblSanction.TabIndex = 61;
            this.lblSanction.Text = "SANCTION:";
            // 
            // txtAYCode
            // 
            this.txtAYCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAYCode.BorderColor = System.Drawing.Color.DarkGray;
            this.txtAYCode.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtAYCode.BorderRadius = 0;
            this.txtAYCode.BorderSize = 2;
            this.txtAYCode.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAYCode.ForeColor = System.Drawing.Color.Black;
            this.txtAYCode.Location = new System.Drawing.Point(213, 146);
            this.txtAYCode.Multiline = false;
            this.txtAYCode.Name = "txtAYCode";
            this.txtAYCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAYCode.PasswordChar = false;
            this.txtAYCode.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtAYCode.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAYCode.PlaceholderText = "Auto Pupulate...";
            this.txtAYCode.Size = new System.Drawing.Size(180, 35);
            this.txtAYCode.TabIndex = 67;
            this.txtAYCode.Texts = "";
            this.txtAYCode.UnderlinedStyle = false;
            // 
            // txtStudentID
            // 
            this.txtStudentID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStudentID.BorderColor = System.Drawing.Color.DarkGray;
            this.txtStudentID.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtStudentID.BorderRadius = 0;
            this.txtStudentID.BorderSize = 2;
            this.txtStudentID.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.ForeColor = System.Drawing.Color.Black;
            this.txtStudentID.Location = new System.Drawing.Point(24, 203);
            this.txtStudentID.Multiline = false;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtStudentID.PasswordChar = false;
            this.txtStudentID.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtStudentID.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.PlaceholderText = "Auto Populate...";
            this.txtStudentID.Size = new System.Drawing.Size(180, 35);
            this.txtStudentID.TabIndex = 68;
            this.txtStudentID.Texts = "";
            this.txtStudentID.UnderlinedStyle = false;
            // 
            // txtCourse
            // 
            this.txtCourse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCourse.BorderColor = System.Drawing.Color.DarkGray;
            this.txtCourse.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtCourse.BorderRadius = 0;
            this.txtCourse.BorderSize = 2;
            this.txtCourse.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourse.ForeColor = System.Drawing.Color.Black;
            this.txtCourse.Location = new System.Drawing.Point(213, 203);
            this.txtCourse.Multiline = false;
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCourse.PasswordChar = false;
            this.txtCourse.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtCourse.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourse.PlaceholderText = "Auto Populate...";
            this.txtCourse.Size = new System.Drawing.Size(180, 35);
            this.txtCourse.TabIndex = 69;
            this.txtCourse.Texts = "";
            this.txtCourse.UnderlinedStyle = false;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.BorderColor = System.Drawing.Color.DarkGray;
            this.txtLastName.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtLastName.BorderRadius = 0;
            this.txtLastName.BorderSize = 2;
            this.txtLastName.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Location = new System.Drawing.Point(24, 260);
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtLastName.PasswordChar = false;
            this.txtLastName.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtLastName.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.PlaceholderText = "Auto Populate...";
            this.txtLastName.Size = new System.Drawing.Size(180, 35);
            this.txtLastName.TabIndex = 70;
            this.txtLastName.Texts = "";
            this.txtLastName.UnderlinedStyle = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFirstName.BorderColor = System.Drawing.Color.DarkGray;
            this.txtFirstName.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtFirstName.BorderRadius = 0;
            this.txtFirstName.BorderSize = 2;
            this.txtFirstName.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Location = new System.Drawing.Point(213, 260);
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFirstName.PasswordChar = false;
            this.txtFirstName.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtFirstName.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.PlaceholderText = "Auto Populate...";
            this.txtFirstName.Size = new System.Drawing.Size(180, 35);
            this.txtFirstName.TabIndex = 71;
            this.txtFirstName.Texts = "";
            this.txtFirstName.UnderlinedStyle = false;
            // 
            // txtSearchID
            // 
            this.txtSearchID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearchID.BorderColor = System.Drawing.Color.IndianRed;
            this.txtSearchID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtSearchID.BorderRadius = 5;
            this.txtSearchID.BorderSize = 2;
            this.txtSearchID.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchID.ForeColor = System.Drawing.Color.IndianRed;
            this.txtSearchID.Location = new System.Drawing.Point(24, 146);
            this.txtSearchID.Multiline = false;
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearchID.PasswordChar = false;
            this.txtSearchID.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtSearchID.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchID.PlaceholderText = "Search Student ID...";
            this.txtSearchID.Size = new System.Drawing.Size(180, 35);
            this.txtSearchID.TabIndex = 75;
            this.txtSearchID.Texts = "";
            this.txtSearchID.UnderlinedStyle = false;
            this.txtSearchID._KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchID_KeyDown);
            this.txtSearchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchID_KeyDown);
            // 
            // cbOffenseType
            // 
            this.cbOffenseType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbOffenseType.BorderColor = System.Drawing.Color.DarkGray;
            this.cbOffenseType.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.cbOffenseType.BorderSize = 2;
            this.cbOffenseType.DropDownHeight = 72;
            this.cbOffenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOffenseType.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOffenseType.ForeColor = System.Drawing.Color.Black;
            this.cbOffenseType.IconColor = System.Drawing.Color.DarkGray;
            this.cbOffenseType.IntegralHeight = true;
            this.cbOffenseType.Items.AddRange(new object[] {
            "Minor",
            "Major"});
            this.cbOffenseType.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbOffenseType.ListTextColor = System.Drawing.Color.Black;
            this.cbOffenseType.Location = new System.Drawing.Point(24, 316);
            this.cbOffenseType.MaxDropDownItems = 10;
            this.cbOffenseType.Name = "cbOffenseType";
            this.cbOffenseType.Padding = new System.Windows.Forms.Padding(2);
            this.cbOffenseType.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cbOffenseType.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOffenseType.PlaceholderText = "Select Offense Type...";
            this.cbOffenseType.Size = new System.Drawing.Size(369, 35);
            this.cbOffenseType.TabIndex = 79;
            this.cbOffenseType.Texts = "";
            this.cbOffenseType.SelectedIndexChanged += new System.EventHandler(this.cbOffenseType_SelectedIndexChanged);
            // 
            // pbGmailIcon
            // 
            this.pbGmailIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbGmailIcon.Image")));
            this.pbGmailIcon.Location = new System.Drawing.Point(183, 27);
            this.pbGmailIcon.Name = "pbGmailIcon";
            this.pbGmailIcon.Size = new System.Drawing.Size(50, 50);
            this.pbGmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGmailIcon.TabIndex = 62;
            this.pbGmailIcon.TabStop = false;
            // 
            // cbSanction
            // 
            this.cbSanction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSanction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSanction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbSanction.BorderColor = System.Drawing.Color.DarkGray;
            this.cbSanction.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.cbSanction.BorderSize = 2;
            this.cbSanction.DropDownHeight = 72;
            this.cbSanction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanction.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanction.ForeColor = System.Drawing.Color.Black;
            this.cbSanction.IconColor = System.Drawing.Color.DarkGray;
            this.cbSanction.IntegralHeight = true;
            this.cbSanction.Items.AddRange(new object[] {
            "Reprimand",
            "Suspension",
            "Dismissal"});
            this.cbSanction.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbSanction.ListTextColor = System.Drawing.Color.Black;
            this.cbSanction.Location = new System.Drawing.Point(24, 430);
            this.cbSanction.MaxDropDownItems = 10;
            this.cbSanction.Name = "cbSanction";
            this.cbSanction.Padding = new System.Windows.Forms.Padding(2);
            this.cbSanction.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cbSanction.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanction.PlaceholderText = "Select Sanction...";
            this.cbSanction.Size = new System.Drawing.Size(369, 35);
            this.cbSanction.TabIndex = 80;
            this.cbSanction.Texts = "";
            // 
            // cbViolation
            // 
            this.cbViolation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbViolation.BorderColor = System.Drawing.Color.DarkGray;
            this.cbViolation.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.cbViolation.BorderSize = 2;
            this.cbViolation.DropDownHeight = 72;
            this.cbViolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViolation.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViolation.ForeColor = System.Drawing.Color.Black;
            this.cbViolation.IconColor = System.Drawing.Color.DarkGray;
            this.cbViolation.IntegralHeight = true;
            this.cbViolation.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbViolation.ListTextColor = System.Drawing.Color.Black;
            this.cbViolation.Location = new System.Drawing.Point(24, 373);
            this.cbViolation.MaxDropDownItems = 10;
            this.cbViolation.Name = "cbViolation";
            this.cbViolation.Padding = new System.Windows.Forms.Padding(2);
            this.cbViolation.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cbViolation.PlaceholderFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViolation.PlaceholderText = "Select Violation...";
            this.cbViolation.Size = new System.Drawing.Size(369, 33);
            this.cbViolation.TabIndex = 81;
            this.cbViolation.Texts = "";
            // 
            // VioEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(416, 553);
            this.ControlBox = false;
            this.Controls.Add(this.cbViolation);
            this.Controls.Add(this.cbSanction);
            this.Controls.Add(this.cbOffenseType);
            this.Controls.Add(this.txtSearchID);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtAYCode);
            this.Controls.Add(this.pbGmailIcon);
            this.Controls.Add(this.lblSanction);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lvlViolation);
            this.Controls.Add(this.lblProgramSection);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblAyCode);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStdDetails);
            this.Controls.Add(this.topBorder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VioEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VioEntryForm";
            this.Load += new System.EventHandler(this.VioEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGmailIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtons btnCancel;
        private CustomButtons btnSave;
        private System.Windows.Forms.Panel topBorder;
        private System.Windows.Forms.Label lblStdDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblAyCode;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblProgramSection;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lvlViolation;
        private System.Windows.Forms.Label lblSanction;
        private CustomTextBox txtAYCode;
        private CustomTextBox txtStudentID;
        private CustomTextBox txtCourse;
        private CustomTextBox txtLastName;
        private CustomTextBox txtFirstName;
        private CustomTextBox txtSearchID;
        private CustomComboBox cbOffenseType;
        private System.Windows.Forms.PictureBox pbGmailIcon;
        private CustomComboBox cbSanction;
        private CustomComboBox cbViolation;
    }
}