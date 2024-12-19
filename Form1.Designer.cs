
namespace SVMS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SideBar = new System.Windows.Forms.Panel();
            this.btnRecycleBin = new System.Windows.Forms.PictureBox();
            this.btnLogout = new SVMS.CustomButtons();
            this.panelUserUpdate = new System.Windows.Forms.Panel();
            this.btnUserManual = new FontAwesome.Sharp.IconButton();
            this.btnManageOffenses = new FontAwesome.Sharp.IconButton();
            this.btnManageDatabase = new FontAwesome.Sharp.IconButton();
            this.btnManageAccount = new FontAwesome.Sharp.IconButton();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.btnAcads = new FontAwesome.Sharp.IconButton();
            this.btnRecords = new FontAwesome.Sharp.IconButton();
            this.btnVioEntry = new FontAwesome.Sharp.IconButton();
            this.btnStdEntry = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.PictureBox();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.circularPictureBox1 = new SVMS.CircularPictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.restoreButton = new SVMS.CustomButtons();
            this.minimizeButton = new SVMS.CustomButtons();
            this.maximizeButton = new SVMS.CustomButtons();
            this.closeButton = new SVMS.CustomButtons();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecycleBin)).BeginInit();
            this.panelUserUpdate.SuspendLayout();
            this.panelProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.SideBar.Controls.Add(this.btnRecycleBin);
            this.SideBar.Controls.Add(this.btnLogout);
            this.SideBar.Controls.Add(this.panelUserUpdate);
            this.SideBar.Controls.Add(this.btnSettings);
            this.SideBar.Controls.Add(this.btnAcads);
            this.SideBar.Controls.Add(this.btnRecords);
            this.SideBar.Controls.Add(this.btnVioEntry);
            this.SideBar.Controls.Add(this.btnStdEntry);
            this.SideBar.Controls.Add(this.btnDashboard);
            this.SideBar.Controls.Add(this.panelProfile);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(200, 675);
            this.SideBar.TabIndex = 0;
            // 
            // btnRecycleBin
            // 
            this.btnRecycleBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecycleBin.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRecycleBin.Image = ((System.Drawing.Image)(resources.GetObject("btnRecycleBin.Image")));
            this.btnRecycleBin.Location = new System.Drawing.Point(162, 633);
            this.btnRecycleBin.Name = "btnRecycleBin";
            this.btnRecycleBin.Size = new System.Drawing.Size(30, 30);
            this.btnRecycleBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRecycleBin.TabIndex = 6;
            this.btnRecycleBin.TabStop = false;
            this.btnRecycleBin.Click += new System.EventHandler(this.btnRecycleBin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnLogout.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnLogout.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogout.BorderRadius = 0;
            this.btnLogout.BorderSize = 0;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(8, 634);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(79, 32);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelUserUpdate
            // 
            this.panelUserUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.panelUserUpdate.Controls.Add(this.btnUserManual);
            this.panelUserUpdate.Controls.Add(this.btnManageOffenses);
            this.panelUserUpdate.Controls.Add(this.btnManageDatabase);
            this.panelUserUpdate.Controls.Add(this.btnManageAccount);
            this.panelUserUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserUpdate.Location = new System.Drawing.Point(0, 534);
            this.panelUserUpdate.Name = "panelUserUpdate";
            this.panelUserUpdate.Size = new System.Drawing.Size(200, 100);
            this.panelUserUpdate.TabIndex = 2;
            // 
            // btnUserManual
            // 
            this.btnUserManual.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnUserManual.FlatAppearance.BorderSize = 0;
            this.btnUserManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManual.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(212)))), ((int)(((byte)(133)))));
            this.btnUserManual.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUserManual.IconColor = System.Drawing.Color.Black;
            this.btnUserManual.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUserManual.Location = new System.Drawing.Point(0, 75);
            this.btnUserManual.Name = "btnUserManual";
            this.btnUserManual.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnUserManual.Size = new System.Drawing.Size(200, 25);
            this.btnUserManual.TabIndex = 8;
            this.btnUserManual.Text = "•   USER MANUAL";
            this.btnUserManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManual.UseVisualStyleBackColor = false;
            this.btnUserManual.Click += new System.EventHandler(this.btnUserManual_Click);
            // 
            // btnManageOffenses
            // 
            this.btnManageOffenses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageOffenses.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnManageOffenses.FlatAppearance.BorderSize = 0;
            this.btnManageOffenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageOffenses.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageOffenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(212)))), ((int)(((byte)(133)))));
            this.btnManageOffenses.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnManageOffenses.IconColor = System.Drawing.Color.Black;
            this.btnManageOffenses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnManageOffenses.Location = new System.Drawing.Point(0, 50);
            this.btnManageOffenses.Name = "btnManageOffenses";
            this.btnManageOffenses.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnManageOffenses.Size = new System.Drawing.Size(200, 25);
            this.btnManageOffenses.TabIndex = 7;
            this.btnManageOffenses.Text = "•   MANAGE OFFENSES";
            this.btnManageOffenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageOffenses.UseVisualStyleBackColor = false;
            this.btnManageOffenses.Click += new System.EventHandler(this.btnManageOffenses_Click);
            // 
            // btnManageDatabase
            // 
            this.btnManageDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageDatabase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnManageDatabase.FlatAppearance.BorderSize = 0;
            this.btnManageDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageDatabase.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(212)))), ((int)(((byte)(133)))));
            this.btnManageDatabase.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnManageDatabase.IconColor = System.Drawing.Color.Black;
            this.btnManageDatabase.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnManageDatabase.Location = new System.Drawing.Point(0, 25);
            this.btnManageDatabase.Name = "btnManageDatabase";
            this.btnManageDatabase.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnManageDatabase.Size = new System.Drawing.Size(200, 25);
            this.btnManageDatabase.TabIndex = 6;
            this.btnManageDatabase.Text = "•   MANAGE DATABASE";
            this.btnManageDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageDatabase.UseVisualStyleBackColor = false;
            this.btnManageDatabase.Click += new System.EventHandler(this.btnManageDatabase_Click);
            // 
            // btnManageAccount
            // 
            this.btnManageAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageAccount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnManageAccount.FlatAppearance.BorderSize = 0;
            this.btnManageAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAccount.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(212)))), ((int)(((byte)(133)))));
            this.btnManageAccount.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnManageAccount.IconColor = System.Drawing.Color.Black;
            this.btnManageAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnManageAccount.Location = new System.Drawing.Point(0, 0);
            this.btnManageAccount.Name = "btnManageAccount";
            this.btnManageAccount.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnManageAccount.Size = new System.Drawing.Size(200, 25);
            this.btnManageAccount.TabIndex = 5;
            this.btnManageAccount.Text = "•   MANAGE ACCOUNTS";
            this.btnManageAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageAccount.UseVisualStyleBackColor = false;
            this.btnManageAccount.Click += new System.EventHandler(this.btnManageAccount_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btnSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 30;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 484);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(200, 50);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAcads
            // 
            this.btnAcads.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcads.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnAcads.FlatAppearance.BorderSize = 0;
            this.btnAcads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcads.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcads.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnAcads.IconChar = FontAwesome.Sharp.IconChar.MortarBoard;
            this.btnAcads.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnAcads.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAcads.IconSize = 30;
            this.btnAcads.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcads.Location = new System.Drawing.Point(0, 434);
            this.btnAcads.Name = "btnAcads";
            this.btnAcads.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAcads.Size = new System.Drawing.Size(200, 50);
            this.btnAcads.TabIndex = 8;
            this.btnAcads.Text = "ACADEMIC YEAR";
            this.btnAcads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcads.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAcads.UseVisualStyleBackColor = true;
            this.btnAcads.Click += new System.EventHandler(this.btnAcads_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecords.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnRecords.FlatAppearance.BorderSize = 0;
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecords.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnRecords.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnRecords.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnRecords.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecords.IconSize = 30;
            this.btnRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.Location = new System.Drawing.Point(0, 384);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRecords.Size = new System.Drawing.Size(200, 50);
            this.btnRecords.TabIndex = 7;
            this.btnRecords.Text = "ARCHIVES";
            this.btnRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // btnVioEntry
            // 
            this.btnVioEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVioEntry.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnVioEntry.FlatAppearance.BorderSize = 0;
            this.btnVioEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVioEntry.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVioEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnVioEntry.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.btnVioEntry.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnVioEntry.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVioEntry.IconSize = 30;
            this.btnVioEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVioEntry.Location = new System.Drawing.Point(0, 334);
            this.btnVioEntry.Name = "btnVioEntry";
            this.btnVioEntry.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVioEntry.Size = new System.Drawing.Size(200, 50);
            this.btnVioEntry.TabIndex = 6;
            this.btnVioEntry.Text = "VIOLATION RECORDS";
            this.btnVioEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVioEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVioEntry.UseVisualStyleBackColor = true;
            this.btnVioEntry.Click += new System.EventHandler(this.btnVioEntry_Click);
            // 
            // btnStdEntry
            // 
            this.btnStdEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStdEntry.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnStdEntry.FlatAppearance.BorderSize = 0;
            this.btnStdEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStdEntry.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStdEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnStdEntry.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnStdEntry.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnStdEntry.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStdEntry.IconSize = 30;
            this.btnStdEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStdEntry.Location = new System.Drawing.Point(0, 284);
            this.btnStdEntry.Name = "btnStdEntry";
            this.btnStdEntry.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStdEntry.Size = new System.Drawing.Size(200, 50);
            this.btnStdEntry.TabIndex = 5;
            this.btnStdEntry.Text = "STUDENT INFO";
            this.btnStdEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStdEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStdEntry.UseVisualStyleBackColor = true;
            this.btnStdEntry.Click += new System.EventHandler(this.btnStdEntry_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.PieChart;
            this.btnDashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 30;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 234);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 50);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelProfile
            // 
            this.panelProfile.Controls.Add(this.btnAbout);
            this.panelProfile.Controls.Add(this.btnClear);
            this.panelProfile.Controls.Add(this.imgLogo);
            this.panelProfile.Controls.Add(this.label2);
            this.panelProfile.Controls.Add(this.txtRole);
            this.panelProfile.Controls.Add(this.txtName);
            this.panelProfile.Controls.Add(this.panel1);
            this.panelProfile.Controls.Add(this.circularPictureBox1);
            this.panelProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(82)))), ((int)(((byte)(77)))));
            this.panelProfile.Location = new System.Drawing.Point(0, 0);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(200, 234);
            this.panelProfile.TabIndex = 2;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.Location = new System.Drawing.Point(162, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(32, 32);
            this.btnAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAbout.TabIndex = 5;
            this.btnAbout.TabStop = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(135, 128);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(20, 20);
            this.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClear.TabIndex = 6;
            this.btnClear.TabStop = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(12, 12);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(40, 40);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 2;
            this.imgLogo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(212)))), ((int)(((byte)(133)))));
            this.label2.Location = new System.Drawing.Point(54, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "SVMS";
            // 
            // txtRole
            // 
            this.txtRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRole.AutoSize = true;
            this.txtRole.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.txtRole.Location = new System.Drawing.Point(100, 189);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(0, 16);
            this.txtRole.TabIndex = 5;
            this.txtRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Arial Narrow", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.txtName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Location = new System.Drawing.Point(100, 161);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 17);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(110)))), ((int)(((byte)(115)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 2);
            this.panel1.TabIndex = 2;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(228)))));
            this.circularPictureBox1.BorderSize = 2;
            this.circularPictureBox1.DefaultImage = null;
            this.circularPictureBox1.Location = new System.Drawing.Point(60, 68);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(80, 80);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 2;
            this.circularPictureBox1.TabStop = false;
            this.circularPictureBox1.Click += new System.EventHandler(this.circularPictureBox1_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panelHeader.Controls.Add(this.restoreButton);
            this.panelHeader.Controls.Add(this.minimizeButton);
            this.panelHeader.Controls.Add(this.maximizeButton);
            this.panelHeader.Controls.Add(this.closeButton);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(200, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 35);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            this.panelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseUp);
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.BackColor = System.Drawing.Color.Transparent;
            this.restoreButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.restoreButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.restoreButton.BorderRadius = 0;
            this.restoreButton.BorderSize = 0;
            this.restoreButton.FlatAppearance.BorderSize = 0;
            this.restoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreButton.ForeColor = System.Drawing.Color.White;
            this.restoreButton.Image = ((System.Drawing.Image)(resources.GetObject("restoreButton.Image")));
            this.restoreButton.Location = new System.Drawing.Point(930, 0);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(35, 35);
            this.restoreButton.TabIndex = 3;
            this.restoreButton.TextColor = System.Drawing.Color.White;
            this.restoreButton.UseVisualStyleBackColor = false;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.minimizeButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.minimizeButton.BorderRadius = 0;
            this.minimizeButton.BorderSize = 0;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.Location = new System.Drawing.Point(895, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(35, 35);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.TextColor = System.Drawing.Color.White;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.BackColor = System.Drawing.Color.Transparent;
            this.maximizeButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.maximizeButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.maximizeButton.BorderRadius = 0;
            this.maximizeButton.BorderSize = 0;
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.ForeColor = System.Drawing.Color.White;
            this.maximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("maximizeButton.Image")));
            this.maximizeButton.Location = new System.Drawing.Point(930, 0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(35, 35);
            this.maximizeButton.TabIndex = 1;
            this.maximizeButton.TextColor = System.Drawing.Color.White;
            this.maximizeButton.UseVisualStyleBackColor = false;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.closeButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.closeButton.BorderRadius = 0;
            this.closeButton.BorderSize = 0;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(965, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(35, 35);
            this.closeButton.TabIndex = 0;
            this.closeButton.TextColor = System.Drawing.Color.White;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.ControlBox = false;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.SideBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRecycleBin)).EndInit();
            this.panelUserUpdate.ResumeLayout(false);
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.Panel panelHeader;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CircularPictureBox circularPictureBox1;
        private System.Windows.Forms.Panel panelProfile;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnStdEntry;
        private FontAwesome.Sharp.IconButton btnVioEntry;
        private FontAwesome.Sharp.IconButton btnRecords;
        private FontAwesome.Sharp.IconButton btnAcads;
        private CustomButtons closeButton;
        private CustomButtons minimizeButton;
        private CustomButtons maximizeButton;
        private CustomButtons restoreButton;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnSettings;
        private System.Windows.Forms.Panel panelUserUpdate;
        private FontAwesome.Sharp.IconButton btnManageAccount;
        private System.Windows.Forms.PictureBox imgLogo;
        private FontAwesome.Sharp.IconButton btnManageDatabase;
        private System.Windows.Forms.Label txtRole;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnClear;
        private FontAwesome.Sharp.IconButton btnManageOffenses;
        private CustomButtons btnLogout;
        private System.Windows.Forms.PictureBox btnAbout;
        private System.Windows.Forms.PictureBox btnRecycleBin;
        private FontAwesome.Sharp.IconButton btnUserManual;
    }
}

