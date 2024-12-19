using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SVMS.Forms;

namespace SVMS.Controls
{
    public partial class UserAccountControl : UserControl
    {
        private string DbConn;

        private string userName;

        private readonly DashboardControl dashboard;
        public UserAccountControl(DashboardControl dbControl, string username)
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            dashboard = dbControl;
            userName = username;
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        protected void NotifyDataChanged()
        {
            dashboard?.RefreshData();
        }

        private async Task LoadDataFromDatabaseAsync()
        {
            // Adjusted query to include multiple roles
            string query = "SELECT [User ID], [Role], [Name], [Username], [Password] FROM tblUser WHERE [Role] IN ('Authorized User', 'Sub-Admin')";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    await conn.OpenAsync();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        await Task.Run(() => adapter.Fill(dt));

                        usersDGV.DataSource = dt;
                    }

                    // Add the Manage button column if it doesn't exist
                    if (!usersDGV.Columns.Contains("btnAction"))
                    {
                        DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                        {
                            HeaderText = "Manage",
                            Name = "btnAction",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        };
                        usersDGV.Columns.Add(btnAction);
                    }

                    if (usersDGV.Columns["User ID"] != null)
                    {
                        usersDGV.Columns["User ID"].Visible = false;
                    }

                    // Hide passwords dynamically
                    if (usersDGV.Columns.Contains("Password"))
                    {
                        usersDGV.CellFormatting += (sender, e) =>
                        {
                            if (usersDGV.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
                            {
                                e.Value = "Hidden";
                                e.FormattingApplied = true;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
                            }
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async void UserAccountControl_Load(object sender, EventArgs e)
        {
            FormatDataGridView();
            usersDGV.CellPainting += usersDGV_CellPainting;
            usersDGV.CellClick += usersDGV_CellClick;
            await LoadDataFromDatabaseAsync();
        }

        private void FormatDataGridView()
        {
            usersDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            usersDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            usersDGV.EnableHeadersVisualStyles = false;

            usersDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            usersDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            usersDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            usersDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            usersDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            usersDGV.DefaultCellStyle.ForeColor = Color.Black;

            usersDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            usersDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            usersDGV.DefaultCellStyle.SelectionBackColor = usersDGV.DefaultCellStyle.BackColor;
            usersDGV.DefaultCellStyle.SelectionForeColor = usersDGV.DefaultCellStyle.ForeColor;

            usersDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = usersDGV.AlternatingRowsDefaultCellStyle.BackColor;
            usersDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = usersDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            usersDGV.GridColor = Color.FromArgb(180, 180, 180);

            usersDGV.ColumnHeadersHeight = 40;
            usersDGV.RowTemplate.Height = 30;

            usersDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            usersDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            usersDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            usersDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            usersDGV.AllowUserToResizeColumns = false;
            usersDGV.AllowUserToResizeRows = false;
            usersDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            usersDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            usersDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            usersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn column in usersDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void usersDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (usersDGV.Columns["btnAction"] == null)
                return;

            if (e.ColumnIndex == usersDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image updateIcon = Properties.Resources.UpdateIcon;
                Image deleteIcon = Properties.Resources.DeleteIcon;

                int iconSize = 20;
                int margin = 5;

                int totalWidth = (iconSize * 2) + margin;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var updateIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);
                var deleteIconRect = new Rectangle(centerX + iconSize + margin, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(updateIcon, updateIconRect);
                e.Graphics.DrawImage(deleteIcon, deleteIconRect);

                usersDGV.Rows[e.RowIndex].Tag = new { UpdateIconRect = updateIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }
        private void usersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == usersDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = usersDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle updateIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;

                    Point mousePosition = usersDGV.PointToClient(Cursor.Position);

                    if (updateIconRect.Contains(mousePosition))
                    {
                        UpdateRecord(selectedRow);
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        DeleteRecord(selectedRow);
                    }
                }
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            using (AddUserForm addForm = new AddUserForm(AddUserForm.OperationType.Add, isUpdate: false))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string newRole = addForm.Role;
                        string newUser = addForm.accountName;
                        string newUsername = addForm.Username;
                        string newPassword = addForm.Password;

                        string query = "INSERT INTO tblUser ([Role], [Name], [Username], [Password]) VALUES (?, ?, ?, ?)";

                        using (OleDbConnection conn = new OleDbConnection(DbConn))
                        {
                            await conn.OpenAsync();
                            using (OleDbCommand cmd = new OleDbCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Role", newRole);
                                cmd.Parameters.AddWithValue("@Name", newUser);
                                cmd.Parameters.AddWithValue("@Username", newUsername);
                                cmd.Parameters.AddWithValue("@Password", newPassword);
                                await cmd.ExecuteNonQueryAsync();

                                LogActivity("Add", $"New {newRole} was successfully added to the system.", userName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("An error occurred while adding the account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    await LoadDataFromDatabaseAsync();
                }

                NotifyDataChanged();
            }
        }

        private async void UpdateRecord(DataGridViewRow row)
        {
            string userID = row.Cells["User ID"].Value.ToString();
            string role = row.Cells["Role"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();
            string username = row.Cells["Username"].Value.ToString();
            string password = row.Cells["Password"].Value.ToString();

            using (AddUserForm updateForm = new AddUserForm(AddUserForm.OperationType.Update, isUpdate: true, role, name, username, password))
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string updateRole = updateForm.Role;
                        string updateName = updateForm.accountName;
                        string updateUsername = updateForm.Username;
                        string updatePassword = updateForm.Password;

                        string query = "UPDATE tblUser SET [Role] = ?, [Name] = ?, [Username] = ?, [Password] = ? WHERE [User ID] = ?";

                        using (OleDbConnection conn = new OleDbConnection(DbConn))
                        {
                            await conn.OpenAsync();
                            using (OleDbCommand cmd = new OleDbCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Role", updateRole);
                                cmd.Parameters.AddWithValue("@Name", updateName);
                                cmd.Parameters.AddWithValue("@Username", updateUsername);
                                cmd.Parameters.AddWithValue("@Password", updatePassword);
                                cmd.Parameters.AddWithValue("@User", userID);
                                await cmd.ExecuteNonQueryAsync();

                                LogActivity("Update", $"Authorized user account details for {updateName} was successfully updated.", userName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("An error occurred while updating the account: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    await LoadDataFromDatabaseAsync();
                }

                NotifyDataChanged();
            }
        }

        private async void DeleteRecord(DataGridViewRow row)
        {
            string userID = row.Cells["User ID"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();

            if (CustomMessageBox.Show("Are you sure you want to delete this authorized user account?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM tblUser WHERE [User ID] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@USerID", userID);
                            await cmd.ExecuteNonQueryAsync();

                            CustomMessageBox.Show($"Authorized user {name} successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                } catch (Exception ex)
                {
                    CustomMessageBox.Show("An error occurred while deleting the account: " + ex.Message, "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                LogActivity("Delete", $"Authorized user {name} was successfully removed from the system.", userName);
                await LoadDataFromDatabaseAsync();
               
            }

            NotifyDataChanged();
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
                        cmd.Parameters.AddWithValue("@Usename", username);

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
    }
}
