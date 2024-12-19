using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMS.Controls
{
    public partial class ArchiveTempDeleted : UserControl
    {
        private string DbConn;
        private string userName;

        public event Action OnDataChanged;
        public ArchiveTempDeleted(string username)
        {
            InitializeComponent();
            userName = username;
            DbConn = GetDbConnectionString();
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        protected void NotifyDataChanged()
        {
            OnDataChanged?.Invoke();
        }

        public async void RefreshData()
        {
            await LoadViolationsWithAYCodeAsync();
        }

        private async void ArchiveTempDeleted_Load(object sender, EventArgs e)
        {
            deletedDGV.CellPainting += deletedDGV_CellPainting;
            deletedDGV.CellClick += deletedDGV_CellClick;

            await LoadViolationsWithAYCodeAsync();
        }

        private async Task LoadViolationsWithAYCodeAsync()
        {
            string query = @"
        SELECT 
    DistinctStudents.[AY-Code], 
    COUNT(DistinctStudents.[Student ID]) AS [CountOfDistinctStudents],
    (SELECT COUNT([Violation ID]) 
     FROM tblViolations v 
     WHERE v.[AY-Code] = DistinctStudents.[AY-Code] 
     AND v.[IsDeleted] = True
     AND v.[IsArchive] = True) AS [CountOfViolations]
FROM (
    SELECT DISTINCT [AY-Code], [Student ID]
    FROM tblViolations
    WHERE [IsDeleted] = True
    AND [IsArchive] = True
) AS DistinctStudents
GROUP BY DistinctStudents.[AY-Code]
ORDER BY DistinctStudents.[AY-Code] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    await conn.OpenAsync();

                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        await Task.Run(() => adapter.Fill(dt));
                    }

                    deletedDGV.DataSource = dt;

                    FormatArchivesDGV();

                    if (!deletedDGV.Columns.Contains("btnAction"))
                    {
                        DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                        {
                            HeaderText = "Manage",
                            Name = "btnAction",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        };
                        deletedDGV.Columns.Add(btnAction);
                        btnAction.DisplayIndex = deletedDGV.Columns.Count - 1;
                    }

                    deletedDGV.Columns["CountOfDistinctStudents"].HeaderText = "Students with Violations";
                    deletedDGV.Columns["CountOfViolations"].HeaderText = "Recorded Violations";

                    deletedDGV.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormatArchivesDGV()
        {
            deletedDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            deletedDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            deletedDGV.EnableHeadersVisualStyles = false;

            deletedDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(106, 106, 106);
            deletedDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            deletedDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(106, 106, 106);
            deletedDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            deletedDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            deletedDGV.DefaultCellStyle.ForeColor = Color.Black;

            deletedDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            deletedDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            deletedDGV.DefaultCellStyle.SelectionBackColor = deletedDGV.DefaultCellStyle.BackColor;
            deletedDGV.DefaultCellStyle.SelectionForeColor = deletedDGV.DefaultCellStyle.ForeColor;

            deletedDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = deletedDGV.AlternatingRowsDefaultCellStyle.BackColor;
            deletedDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = deletedDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            deletedDGV.GridColor = Color.FromArgb(180, 180, 180);

            deletedDGV.ColumnHeadersHeight = 40;
            deletedDGV.RowTemplate.Height = 30;

            deletedDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            deletedDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            deletedDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            deletedDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            deletedDGV.DefaultCellStyle.SelectionBackColor = deletedDGV.DefaultCellStyle.BackColor;
            deletedDGV.DefaultCellStyle.SelectionForeColor = deletedDGV.DefaultCellStyle.ForeColor;

            deletedDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = deletedDGV.AlternatingRowsDefaultCellStyle.BackColor;
            deletedDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = deletedDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            deletedDGV.AllowUserToResizeColumns = false;
            deletedDGV.AllowUserToResizeRows = false;
            deletedDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            deletedDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            deletedDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in deletedDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Manage")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void deletedDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == deletedDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image restoreIcon = Properties.Resources.RestoreIcon;
                Image deleteIcon = Properties.Resources.DeleteIcon;

                int iconSize = 20;
                int margin = 5;

                int totalWidth = (iconSize * 2) + margin;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var restoreIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);
                var deleteIconRect = new Rectangle(centerX + iconSize + margin, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(restoreIcon, restoreIconRect);
                e.Graphics.DrawImage(deleteIcon, deleteIconRect);

                deletedDGV.Rows[e.RowIndex].Tag = new { UpdateIconRect = restoreIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }
        private void deletedDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == deletedDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = deletedDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle restoreIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;

                    Point mousePosition = deletedDGV.PointToClient(Cursor.Position);

                    if (restoreIconRect.Contains(mousePosition))
                    {
                        RestoreFromTrash(selectedRow);
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        DeleteFromTrash(selectedRow);
                    }
                }
            }
        }

        private async void RestoreFromTrash(DataGridViewRow row)
        {
            string ayCode = row.Cells["AY-Code"].Value.ToString();

            DialogResult result = CustomMessageBox.Show(
                $"Are you sure you want to restore all records associated with AY-Code {ayCode} from trash?",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = @"
            UPDATE tblViolations
            SET IsDeleted = False, IsArchive = False
            WHERE [AY-Code] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AYCode", ayCode);
                            await cmd.ExecuteNonQueryAsync();

                            LogActivity("Restore", $"Records associated with AY-Code {ayCode} have been restored from trash.", userName);

                            CustomMessageBox.Show(
                                $"Records associated with AY-Code {ayCode} have been restored from trash.",
                                "Successfully Restored",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(
                        "An error occurred while restoring the records: " + ex.Message,
                        "Restore Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            await LoadViolationsWithAYCodeAsync();

            NotifyDataChanged();
        }

        private async void DeleteFromTrash(DataGridViewRow row)
        {
            string ayCode = row.Cells["AY-Code"].Value.ToString();

            DialogResult result = CustomMessageBox.Show(
                $"Deleting will permanently remove all records associated with AY-Code {ayCode}. Are you sure you want to proceed?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM tblViolations WHERE [AY-Code] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AYCode", ayCode);
                            await cmd.ExecuteNonQueryAsync();

                            LogActivity("Delete", $"All records associated with AY-Code {ayCode} have been permanently deleted.", userName);
                            
                            CustomMessageBox.Show(
                                $"All records associated with AY-Code {ayCode} have been permanently deleted.",
                                "Successfully Deleted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(
                        "An error occurred while deleting the records: " + ex.Message,
                        "Deletion Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            await LoadViolationsWithAYCodeAsync();

            NotifyDataChanged();
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.Show(
        "Are you sure you want to permanently delete all academic year records and their associated violations from the Trash? This action cannot be undone.",
        "Confirm Empty Trash",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();

                        string deleteViolationsQuery = "DELETE FROM tblViolations WHERE [IsDeleted] = True";
                        using (OleDbCommand deleteViolationsCmd = new OleDbCommand(deleteViolationsQuery, conn))
                        {
                            await deleteViolationsCmd.ExecuteNonQueryAsync();
                        }

                        string deleteAYQuery = "DELETE FROM tblAcademicYears WHERE [IsDeleted] = True";
                        using (OleDbCommand deleteAYCmd = new OleDbCommand(deleteAYQuery, conn))
                        {
                            await deleteAYCmd.ExecuteNonQueryAsync();
                        }
                    }

                    LogActivity("Delete", $"Academic year records and their associated violations have been permanently deleted", userName);
                    CustomMessageBox.Show(
                        "Trash has been successfully emptied. All academic year records and their associated violations have been permanently deleted.",
                        "Trash Emptied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadViolationsWithAYCodeAsync();

                    NotifyDataChanged();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(
                        "An error occurred while emptying the recycle bin: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
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
                        cmd.Parameters.Add("@Date", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Username", username);

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
