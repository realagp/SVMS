using System;
using System.Drawing;
using System.Data.OleDb;
using System.IO;
using SVMS.Controls;
using FontAwesome.Sharp;
using System.Windows.Forms;
using SVMS.Forms;
using System.Diagnostics;
using System.Reflection;

namespace SVMS
{
    public partial class Form1 : DropShadow
    {
        private string DbConn;
        private string userRole;
        private string userName;
        private int userId;
        private ToolTip toolTip = new ToolTip();

        private IconButton currentBtn;
        private IconButton updateBtn;
        private Panel leftBorderBtn;

        private Rectangle normalBounds;
        private bool isMaximized = false;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private Panel panelContainer;
        private DashboardControl dashboard;
        private StdEntryControl studentEntry;
        private VioEntryControl violationEntry;
        private RecordsControl records;
        private ArchivesControl archives;
        private YearControl year;
        private DatabaseManager dbManager;
        private OffensesControl offenses;
        private UserAccountControl usersAccount;
        private StdTempDeleted deletedStudent;
        private VioTempDeleted deletedViolation;
        private ArchiveTempDeleted deletedArchive;

        private bool isStudent;
        private bool isViolation;
        private bool isArchive;

        private struct RGBColors
        {
            public static Color activeSubMenu = Color.FromArgb(38, 40, 44);
            public static Color activeMenu = Color.FromArgb(30, 212, 133);
        }

        public Form1(string role, string username, int userId)
        {
            InitializeComponent();
            InitializeToolTips();
            userRole = role;
            userName = username;
            this.userId = userId;
            ConfigureUIBasedOnRole();

            DbConn = GetDbConnectionString();

            // Initial size
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            int initialWidth = Math.Min(1200, screenBounds.Width);
            int initialHeight = Math.Min(675, screenBounds.Height);
            this.Size = new Size(initialWidth, initialHeight);
            this.MinimumSize = new Size(800, 450);

            restoreButton.Visible = false;
            btnRecycleBin.Visible = false;

            panelContainer = new Panel
            {
                Location = new Point(200, 35),
                Size = new Size(1000, 640),
            };

            this.Controls.Add(panelContainer);
            panelContainer.BackColor = Color.WhiteSmoke;
            panelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dashboard = new DashboardControl(userRole);
            studentEntry = new StdEntryControl(userRole, userName);
            violationEntry = new VioEntryControl(userRole, userName);
            records = new RecordsControl();
            archives = new ArchivesControl(userRole, userName);
            year = new YearControl(userRole, userName);
            offenses = new OffensesControl(violationEntry, dashboard, userRole, userName);
            usersAccount = new UserAccountControl(dashboard, userName);
            deletedStudent = new StdTempDeleted(userRole);
            deletedViolation = new VioTempDeleted(userRole);
            deletedArchive = new ArchiveTempDeleted(userName);
            dbManager = new DatabaseManager(studentEntry, dashboard, userRole, userName);

            panelContainer.Controls.Add(dashboard);
            panelContainer.Controls.Add(studentEntry);
            panelContainer.Controls.Add(violationEntry);
            panelContainer.Controls.Add(records);
            panelContainer.Controls.Add(archives);
            panelContainer.Controls.Add(year);
            panelContainer.Controls.Add(offenses);
            panelContainer.Controls.Add(usersAccount);
            panelContainer.Controls.Add(deletedStudent);
            panelContainer.Controls.Add(deletedViolation);
            panelContainer.Controls.Add(deletedArchive);

            leftBorderBtn = new Panel
            {
                Size = new Size(5, 50)
            };
            SideBar.Controls.Add(leftBorderBtn);

            ActivateButton(btnDashboard, RGBColors.activeMenu);
            ShowControl(dashboard);
            panelUserUpdate.Visible = false;

            year.OnDataChanged += RefreshDashboard;
            year.OnDataChanged += RefreshViolations;
            year.OnDataChanged += RefreshStudents;

            violationEntry.OnDataChanged += RefreshDashboard;
            violationEntry.OnDataChanged += RefreshArchives;
            violationEntry.OnDataChanged += RefreshDeletedViolations;
            violationEntry.OnDataChanged += RefreshDeletedArchives;

            deletedViolation.OnDataChanged += RefreshViolations;
            deletedViolation.OnDataChanged += RefreshArchives;

            studentEntry.OnDataChanged += RefreshDashboard;
            studentEntry.OnDataChanged += RefreshViolations;
            studentEntry.OnDataChanged += RefreshDeletedStudents;

            deletedStudent.OnDataChanged += RefreshStudents;
            deletedStudent.OnDataChanged += RefreshViolations;
            deletedStudent.OnDataChanged += RefreshArchives;

            archives.OnDataChanged += RefreshDeletedArchives;
            archives.OnDataChanged += RefreshViolations;
            archives.OnDataChanged += RefreshDeletedViolations;

            deletedArchive.OnDataChanged += RefreshArchives;
            deletedArchive.OnDataChanged += RefreshViolations;
            deletedArchive.OnDataChanged += RefreshDeletedViolations;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            if (this.Width > screenBounds.Width || this.Height > screenBounds.Height)
            {
                this.Width = Math.Min(this.Width, screenBounds.Width);
                this.Height = Math.Min(this.Height, screenBounds.Height);
            }

            circularPictureBox1.DefaultImage = Properties.Resources.profile;

            LoadUserData(userId);
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }
        private void RefreshDashboard()
        {
            dashboard.RefreshData();
        }

        private void RefreshStudents()
        {
            studentEntry.RefreshData();
        }

        private async void RefreshViolations()
        {
            await violationEntry.RefreshDataAsync();
        }

        private void RefreshArchives()
        {
            archives.RefreshData();
        }
        private void RefreshDeletedStudents()
        {
            deletedStudent.RefreshData();
        }

        private void RefreshDeletedViolations()
        {
            deletedViolation.RefreshData();
        }

        private void RefreshDeletedArchives()
        {
            deletedArchive.RefreshData();
        }

        public void RefreshUserData()
        {
            LoadUserData(userId);
        }

        public void disabledBtn()
        {
            InactiveSettingsSubMenu();
        }

        private void InitializeToolTips()
        {
            toolTip.SetToolTip(btnClear, "Remove profile photo");
            toolTip.SetToolTip(circularPictureBox1, "Update profile photo");
            toolTip.SetToolTip(btnAbout, "About SVMS");
            toolTip.SetToolTip(btnRecycleBin, "Trash");
        }

        private void ConfigureUIBasedOnRole()
        {
            if (userRole == "Authorized User")
            {
                circularPictureBox1.Enabled = false;
                btnClear.Enabled = false;
                btnRecycleBin.Visible = false;
                btnAcads.Visible = false;
                btnSettings.Visible = false;
            } else if (userRole == "Sub-Admin")
            {
                btnAcads.Visible = false;
                btnSettings.Visible = false;
            }
        }

        private void ShowControl(Control control)
        {
            foreach (Control c in panelContainer.Controls)
            {
                if (c is UserControl)
                {
                    c.Visible = false;
                }
            }

            control.Visible = true;
            control.Dock = DockStyle.Fill;
            control.BringToFront();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(38, 40, 44);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.Padding = new Padding(0, 0, 10, 0);
                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(38, 40, 44);
                currentBtn.ForeColor = Color.FromArgb(218, 221, 228);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(218, 221, 228);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.Padding = new Padding(10, 0, 0, 0);
                leftBorderBtn.Visible = false;
            }
        }
        private void ActiveSettingsSubMenu(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                InactiveSettingsSubMenu();
                updateBtn = (IconButton)senderBtn;
                updateBtn.BackColor = Color.FromArgb(45, 48, 52);
                updateBtn.ForeColor = Color.FromArgb(30, 212, 133);
            }
        }
        private void InactiveSettingsSubMenu()
        {
            if (updateBtn != null)
            {
                updateBtn.BackColor = Color.FromArgb(38, 40, 44);
                updateBtn.ForeColor = RGBColors.activeMenu;

            }
        }

        private void LoadUserData(int userId)
        {
            using (var connection = new OleDbConnection(DbConn))
            {
                connection.Open();

                // Modify the query to fetch data based on the logged-in user ID
                var command = new OleDbCommand("SELECT [Role], [Name], [Photo] FROM tblUser WHERE [User ID] = @userId", connection);
                command.Parameters.AddWithValue("@userId", userId);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Update the labels and picture box with the user's information
                    AdjustLabelFromCenter(txtName, reader["Name"].ToString());
                    AdjustLabelFromCenter(txtRole, reader["Role"].ToString());

                    // If the user has a photo, load it; otherwise, set the default image
                    if (!reader.IsDBNull(reader.GetOrdinal("Photo")))
                    {
                        byte[] photo = (byte[])reader["Photo"];
                        using (var ms = new MemoryStream(photo))
                        {
                            circularPictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        circularPictureBox1.Image = circularPictureBox1.DefaultImage;
                    }
                }
            }
        }

        private void circularPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(ofd.FileName);
                circularPictureBox1.UpdateProfilePhoto(image, DbConn, 1);
            }
        }
        private void AdjustLabelFromCenter(Label label, string newText)
        {
            int originalCenterX = label.Left + (label.Width / 2);
            label.Text = newText;

            using (Graphics g = label.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(newText, label.Font);
                label.Width = (int)textSize.Width;
            }

            label.Left = originalCenterX - (label.Width / 2);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            circularPictureBox1.RemoveProfilePhoto(DbConn, 1);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelUserUpdate.Visible = false;
            btnRecycleBin.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeMenu);
            ShowControl(dashboard);
        }

        private void btnStdEntry_Click(object sender, EventArgs e)
        {
            if (userRole == "Authorized User")
            {
                panelUserUpdate.Visible = false;
                btnRecycleBin.Visible = false;
                InactiveSettingsSubMenu();
                ActivateButton(sender, RGBColors.activeMenu);
                ShowControl(studentEntry);
            }
            else
            {
                panelUserUpdate.Visible = false;
                btnRecycleBin.Visible = true;
                isStudent = true;
                isViolation = false;
                isArchive = false;
                InactiveSettingsSubMenu();
                ActivateButton(sender, RGBColors.activeMenu);
                ShowControl(studentEntry);
            }
        }

        private void btnVioEntry_Click(object sender, EventArgs e)
        {
            if (userRole == "Authorized User")
            {
                panelUserUpdate.Visible = false;
                btnRecycleBin.Visible = false;
                InactiveSettingsSubMenu();
                ActivateButton(sender, RGBColors.activeMenu);
                ShowControl(violationEntry);
            } else
            {
                panelUserUpdate.Visible = false;
                btnRecycleBin.Visible = true;
                isViolation = true;
                isStudent = false;
                isArchive = false;
                InactiveSettingsSubMenu();
                ActivateButton(sender, RGBColors.activeMenu);
                ShowControl(violationEntry);
            }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            if (userRole == "Authorized User")
            {
                panelUserUpdate.Visible = false;
                btnRecycleBin.Visible = false;
                InactiveSettingsSubMenu();
                ActivateButton(sender, RGBColors.activeMenu);
                ShowControl(archives);
            }
            else
            {
                panelUserUpdate.Visible = false;
                btnRecycleBin.Visible = true;
                isArchive = true;
                isViolation = false;
                isStudent = false;
                InactiveSettingsSubMenu();
                ActivateButton(sender, RGBColors.activeMenu);
                ShowControl(archives);
            }
        }

        private void btnAcads_Click(object sender, EventArgs e)
        {
            panelUserUpdate.Visible = false;
            btnRecycleBin.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeMenu);
            ShowControl(year);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (userRole == "Authorized User" || userRole == "Sub-Admin")
            {
                CustomMessageBox.Show("You do not have permission to modify settings.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ActivateButton(sender, RGBColors.activeMenu);
                panelUserUpdate.Visible = true;
                btnRecycleBin.Visible = false;
            }
            
        }

        private void btnManageAccount_Click(object sender, EventArgs e)
        {
            ActiveSettingsSubMenu(sender, RGBColors.activeSubMenu);
            using (SelectUserForm selectAccount = new SelectUserForm())
            {
                if (selectAccount.ShowDialog() == DialogResult.OK)
                {
                    if (selectAccount.SelectedAccount == SelectUserForm.accountType.Admin)
                    {
                        UpdateAccounts accounts = new UpdateAccounts(dashboard, userRole, userName);
                        accounts.ShowDialog();
                    }
                    else if (selectAccount.SelectedAccount == SelectUserForm.accountType.AuthorizedUser)
                    {
                        ShowControl(usersAccount);
                    }
                }
            }
        }

        private void btnManageDatabase_Click(object sender, EventArgs e)
        {
            ActiveSettingsSubMenu(sender, RGBColors.activeSubMenu);
            DatabaseManager manager = new DatabaseManager(studentEntry, dashboard, userRole, userName);
            manager.ShowDialog();
        }

        private void btnManageOffenses_Click(object sender, EventArgs e)
        {
            ActiveSettingsSubMenu(sender, RGBColors.activeSubMenu);
            ShowControl(offenses);
        }

        private void btnUserManual_Click(object sender, EventArgs e)
        {
            OpenUserManual();
        }

        private void OpenUserManual()
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "manual.pdf");

            // Extract the PDF from resources if it does not exist
            if (!File.Exists(tempFilePath))
            {
                // Extract the PDF from resources
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SVMS.manual.pdf"))
                using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                {
                    resourceStream.CopyTo(fileStream);
                }
            }

            // After extraction, check if the file now exists
            if (File.Exists(tempFilePath))
            {
                // Open the PDF using the default PDF viewer
                Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            }
            else
            {
                // If the file still does not exist, show an error message
                MessageBox.Show("The manual PDF could not be found in the temporary folder. Please locate your saved copy.",
                                "Manual Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Allow the user to locate the saved copy
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                    openFileDialog.Title = "Select User Manual";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Process.Start(new ProcessStartInfo(openFileDialog.FileName) { UseShellExecute = true });
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Log Out";

            if (userRole == "Administrator")
            {
                message = "You're about to log out as Administrator. If you've made any changes, it's best to back them up first. Are you sure you want to log out?";
            }
            else
            {
                message = "Are you sure you want to log out?";
            }

            DialogResult localResult = CustomMessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                
                this.Hide();
                LoginUI loginForm = new LoginUI();
                loginForm.Show();
            }
            else
            {
                return;
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        public void LogActivity(string action, string description, string username)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    string query = @"
                        INSERT INTO tblActivityLog ([Date/Time], [Action], [Description], [Username]) 
                        VALUES (?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Add parameters with their respective values
                        cmd.Parameters.Add("@Date", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Username", username);

                        // Open the connection and execute the query
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error logging activity: " + ex.Message);
            }
        }

        #region -> DRAGGABLE MAIN FORM USING HEADER
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && e.Button == MouseButtons.Left) // Only drag when the left mouse button is held
            {
                if (isMaximized)
                {
                    // Restore to normal state before dragging
                    this.WindowState = FormWindowState.Normal;
                    this.Bounds = normalBounds;
                    isMaximized = false;
                    restoreButton.Visible = false;
                    maximizeButton.Visible = true;
                }

                // Perform the dragging movement
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

        #region -> CUSTOM CONTROL BOX
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                normalBounds = this.Bounds;
                this.WindowState = FormWindowState.Normal;
                this.Bounds = Screen.FromControl(this).WorkingArea;
                isMaximized = true;
            }

            maximizeButton.Visible = false;
            restoreButton.Visible = true;
        }
        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (isMaximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Bounds = normalBounds;
                isMaximized = false;

            }

            restoreButton.Visible = false;
            maximizeButton.Visible = true;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            string exitMessage;
            string exitTitle = "Exit Application";

            if (userRole == "Authorized User")
            {
                exitMessage = "You are about to exit. Please make sure to log out properly. Are you sure you want to close the application?";
            }
            else // Default for Administrator or other roles
            {
                exitMessage = "You're about to close the application. If you've made any changes, it's best to back them up first. Do you really want to exit?";
            }

            DialogResult localResult = CustomMessageBox.Show(
                exitMessage,
                exitTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                LogActivity("Close", $"Session has ended. The application was closed without logging out.", userName);
                
                Application.Exit();
            }
            else
            {
                return;
            }
        }
        #endregion

        private void btnRecycleBin_Click(object sender, EventArgs e)
        {
            if (isStudent)
            {
                ShowControl(deletedStudent);
                DisableButton();
            } else if (isViolation)
            {
                ShowControl(deletedViolation);
                DisableButton();
            } else if (isArchive)
            {
                ShowControl(deletedArchive);
                DisableButton();
            }
        }
    }
}
