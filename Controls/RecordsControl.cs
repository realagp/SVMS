using System;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace SVMS.Controls
{
    public partial class RecordsControl : UserControl
    {
        private string DbConn;

        private ToolTip toolTip = new ToolTip();
        public RecordsControl()
        {
            InitializeComponent();
            DbConn = GetDbConnectionString();
            toolTip.SetToolTip(btnReloadDB, "Reload Violation Records");
            toolTip.SetToolTip(btnToPDF, "Generate PDF Report");
            toolTip.SetToolTip(btnToExcel, "Generate Excel File");
            cbFilter.DropDownHeight = 72;
            cbFilter.IntegralHeight = false;
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }
        public async Task RefreshDataAsync()
        {
            await LoadStudentViolationCountsAsync();
            await LoadViolationDetailsAsync();
            await LoadAYCodesAsync();
        }

        private async Task<bool> LoadStudentViolationCountsAsync(string selectedAYCode = null, string studentId = null)
        {
            string qRecords = @"
        SELECT 
            tblViolations.[AY-Code], 
            tblViolations.[Student ID], 
            tblStudents.[Last Name], 
            tblStudents.[First Name],
            MAX(tblViolations.[Date]) AS [MaxOfDate],
            COUNT(tblViolations.[Violation ID]) AS [Violation Count(s)]
        FROM 
            tblStudents
        INNER JOIN 
            tblViolations ON tblStudents.[Student ID] = tblViolations.[Student ID]
        WHERE
            tblViolations.[IsDeleted] = False";  // Add IsDeleted = False condition here

            List<string> filters = new List<string>();

            // Use the active AY-Code if selectedAYCode is null and cbFilter has an active one
            if (string.IsNullOrEmpty(selectedAYCode) && cbFilter.SelectedItem != null)
            {
                selectedAYCode = cbFilter.SelectedItem.ToString();
            }

            // Filter by AY-Code if "Show All" is not selected
            if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
            {
                filters.Add("tblViolations.[AY-Code] = @AYCode");
            }

            // Filter by Student ID if provided
            if (!string.IsNullOrEmpty(studentId))
            {
                filters.Add("tblViolations.[Student ID] = @StudentId");
            }

            // Apply the filters in the query if any
            if (filters.Count > 0)
            {
                qRecords += " AND " + string.Join(" AND ", filters);
            }

            qRecords += @" GROUP BY 
    tblViolations.[AY-Code], 
    tblViolations.[Student ID],
    tblStudents.[Last Name], 
    tblStudents.[First Name]
    ORDER BY MAX(tblViolations.[Date]) DESC;";  // Use MAX(Date) for ordering by the latest date

            DataTable dT = new DataTable();
            bool hasRecords = false;

            // Run the query asynchronously
            await Task.Run(() =>
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    OleDbCommand command = new OleDbCommand(qRecords, connection);

                    // Pass the AY-Code parameter if needed
                    if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
                    {
                        command.Parameters.AddWithValue("@AYCode", selectedAYCode);
                    }

                    // Pass the Student ID parameter if needed
                    if (!string.IsNullOrEmpty(studentId))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    try
                    {
                        connection.Open();
                        adapter.Fill(dT);

                        if (dT.Rows.Count > 0)
                        {
                            hasRecords = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Error: " + ex.Message);
                    }
                }
            });

            // Update the DataGridView with the data
            this.Invoke(new Action(() =>
            {
                recordsDGV.DataSource = dT;

                // Add View button if not already present
                if (!recordsDGV.Columns.Contains("btnView"))
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "View",
                        Name = "btnView",
                        UseColumnTextForButtonValue = true
                    };
                    recordsDGV.Columns.Add(btnAction);
                }

                // Optionally hide the MaxOfDate column
                if (recordsDGV.Columns["MaxOfDate"] != null)
                {
                    recordsDGV.Columns["MaxOfDate"].Visible = false;
                }

                recordsDGV.Refresh();
            }));

            return hasRecords;
        }

        private async Task LoadViolationDetailsAsync(string selectedAYCode = null, string studentId = null)
        {
            // Base query with the IsDeleted = False condition already included
            string qViolationDetails = @"
    SELECT
        tblViolations.[AY-Code],
        tblViolations.[Date], 
        tblViolations.[Student ID], 
        tblStudents.[Last Name],
        tblStudents.[First Name],
        tblViolations.[Course], 
        tblViolations.[Violation],
        tblViolations.[Offense Type],
        tblViolations.[Sanction]
    FROM 
        tblStudents
    INNER JOIN 
        tblViolations ON tblStudents.[Student ID] = tblViolations.[Student ID]
    WHERE
        tblViolations.[IsDeleted] = False";

            List<string> filters = new List<string>();

            // Use the active AY-Code if selectedAYCode is null and cbFilter has an active one
            if (string.IsNullOrEmpty(selectedAYCode) && cbFilter.SelectedItem != null)
            {
                selectedAYCode = cbFilter.SelectedItem.ToString();
            }

            // Add filters based on the AY-Code if "Show All" is not selected
            if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
            {
                filters.Add("tblViolations.[AY-Code] = @AYCode");
            }

            // Add filters based on the Student ID if provided
            if (!string.IsNullOrEmpty(studentId))
            {
                filters.Add("tblViolations.[Student ID] = @StudentId");
            }

            // Apply filters if any exist
            if (filters.Count > 0)
            {
                qViolationDetails += " AND " + string.Join(" AND ", filters);
            }

            // Add ORDER BY clause to sort by Date descending
            qViolationDetails += " ORDER BY tblViolations.[Date] DESC";

            DataTable allViolationsTable = new DataTable();

            // Run the query asynchronously
            await Task.Run(() =>
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    OleDbCommand command = new OleDbCommand(qViolationDetails, connection);

                    // Pass AY-Code parameter if needed
                    if (!string.IsNullOrEmpty(selectedAYCode) && selectedAYCode != "Show All")
                    {
                        command.Parameters.AddWithValue("@AYCode", selectedAYCode);
                    }

                    // Pass Student ID parameter if needed
                    if (!string.IsNullOrEmpty(studentId))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    try
                    {
                        connection.Open();
                        adapter.Fill(allViolationsTable);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Error loading violations: " + ex.Message);
                    }
                }
            });

            // Update the DataGridView on the UI thread
            this.Invoke(new Action(() =>
            {
                viewRecordsDGV.DataSource = allViolationsTable;

                // Optionally hide the AY-Code column if it exists
                if (viewRecordsDGV.Columns["AY-Code"] != null)
                {
                    viewRecordsDGV.Columns["AY-Code"].Visible = false;
                }
            }));
        }

        private async Task LoadAYCodesAsync()
        {
            // Query to get all AY-Codes from tblViolations
            string violationsQuery = "SELECT DISTINCT [AY-Code] FROM tblViolations";

            // Query to get active AY-Code from qActiveAY
            string activeAYQuery = "SELECT [AY-Code], [Status] FROM qActiveAY";

            DataTable dtViolations = new DataTable();
            DataTable dtActiveAY = new DataTable();
            string activeAYCode = null;

            await Task.Run(() =>
            {
                using (OleDbConnection connection = new OleDbConnection(DbConn))
                {
                    try
                    {
                        connection.Open();

                        // Fetch all AY-Codes from tblViolations
                        using (OleDbCommand commandViolations = new OleDbCommand(violationsQuery, connection))
                        {
                            OleDbDataAdapter adapter = new OleDbDataAdapter(commandViolations);
                            adapter.Fill(dtViolations);
                        }

                        // Fetch active AY-Code from qActiveAY
                        using (OleDbCommand commandActiveAY = new OleDbCommand(activeAYQuery, connection))
                        {
                            OleDbDataAdapter adapter = new OleDbDataAdapter(commandActiveAY);
                            adapter.Fill(dtActiveAY);
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Error loading AY-Codes: " + ex.Message);
                    }
                }
            });

            cbFilter.DropDownStyle = ComboBoxStyle.DropDown;
            cbFilter.Items.Clear();
            cbFilter.Items.Add("Show All");

            // Get the active AY-Code from qActiveAY
            if (dtActiveAY.Rows.Count > 0)
            {
                DataRow activeRow = dtActiveAY.Rows[0];
                activeAYCode = activeRow["AY-Code"].ToString();
            }

            // Add distinct AY-Codes from tblViolations to the ComboBox
            foreach (DataRow row in dtViolations.Rows)
            {
                string ayCode = row["AY-Code"].ToString();
                cbFilter.Items.Add(ayCode);
            }

            // Set the active AY-Code if available, otherwise default to "Show All"
            if (!string.IsNullOrEmpty(activeAYCode))
            {
                cbFilter.SelectedItem = activeAYCode;  // Set the active AY-Code
            }
            else
            {
                cbFilter.SelectedIndex = 0;  // Default to "Show All"
            }
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAYCode = cbFilter.SelectedItem.ToString();

            if (selectedAYCode == "Show All")
            {
                await LoadStudentViolationCountsAsync();
                await LoadViolationDetailsAsync();
            }
            else
            {
                await LoadStudentViolationCountsAsync(selectedAYCode);
                await LoadViolationDetailsAsync(selectedAYCode);
            }
        }
        private void FormatRecordsDGV()
        {
            recordsDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            recordsDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            recordsDGV.EnableHeadersVisualStyles = false;

            recordsDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            recordsDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            recordsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            recordsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            recordsDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            recordsDGV.DefaultCellStyle.ForeColor = Color.Black;

            recordsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            recordsDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            recordsDGV.DefaultCellStyle.SelectionBackColor = recordsDGV.DefaultCellStyle.BackColor;
            recordsDGV.DefaultCellStyle.SelectionForeColor = recordsDGV.DefaultCellStyle.ForeColor;

            recordsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = recordsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            recordsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = recordsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            recordsDGV.GridColor = Color.FromArgb(180, 180, 180);

            recordsDGV.ColumnHeadersHeight = 40;
            recordsDGV.RowTemplate.Height = 30;

            recordsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            recordsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            recordsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            recordsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            recordsDGV.AllowUserToResizeColumns = false;
            recordsDGV.AllowUserToResizeRows = false;
            recordsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            recordsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            recordsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in recordsDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Violation Count(s)" || column.HeaderText == "View")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
        }

        private void FormatRecordDetailsDGV()
        {
            viewRecordsDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            viewRecordsDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            viewRecordsDGV.EnableHeadersVisualStyles = false;

            viewRecordsDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 37, 42);
            viewRecordsDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            viewRecordsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(229, 37, 42);
            viewRecordsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            viewRecordsDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            viewRecordsDGV.DefaultCellStyle.ForeColor = Color.Black;

            viewRecordsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 206, 207);
            viewRecordsDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            viewRecordsDGV.DefaultCellStyle.SelectionBackColor = viewRecordsDGV.DefaultCellStyle.BackColor;
            viewRecordsDGV.DefaultCellStyle.SelectionForeColor = viewRecordsDGV.DefaultCellStyle.ForeColor;

            viewRecordsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = viewRecordsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            viewRecordsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = viewRecordsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            viewRecordsDGV.GridColor = Color.FromArgb(237, 109, 113);

            viewRecordsDGV.ColumnHeadersHeight = 40;
            viewRecordsDGV.RowTemplate.Height = 30;

            viewRecordsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            viewRecordsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            viewRecordsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            viewRecordsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            viewRecordsDGV.DefaultCellStyle.SelectionBackColor = viewRecordsDGV.DefaultCellStyle.BackColor;
            viewRecordsDGV.DefaultCellStyle.SelectionForeColor = viewRecordsDGV.DefaultCellStyle.ForeColor;

            viewRecordsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = viewRecordsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            viewRecordsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = viewRecordsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            viewRecordsDGV.AllowUserToResizeColumns = false;
            viewRecordsDGV.AllowUserToResizeRows = false;
            viewRecordsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            viewRecordsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            viewRecordsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in viewRecordsDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.HeaderText == "Violation")
                {
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        private async void RecordsControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            loadingProgressBar.Visible = false;
            recordsDGV.DataBindingComplete += recordsDGV_DataBindingComplete;
            viewRecordsDGV.DataBindingComplete += viewRecordsDGV_DataBindingComplete;
            recordsDGV.CellPainting += recordsDGV_CellPainting;
            recordsDGV.CellClick += recordsDGV_CellClick;

            try
            {
                await Task.WhenAll(LoadStudentViolationCountsAsync(), LoadViolationDetailsAsync(), LoadAYCodesAsync());
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error loading data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await Task.Delay(500);
            btnReloadDB_Click(sender, e);
        }

        private void recordsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatRecordsDGV();
        }

        private void viewRecordsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatRecordDetailsDGV();
        }

        private void recordsDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == recordsDGV.Columns["btnView"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image actionIcon = Properties.Resources.ViewIcon;

                int iconSize = 20;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - iconSize) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var iconRect = new Rectangle(centerX, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(actionIcon, iconRect);

                recordsDGV.Rows[e.RowIndex].Tag = iconRect;

                e.Handled = true;
            }
        }
        private void recordsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == recordsDGV.Columns["btnView"].Index)
            {
                DataGridViewRow selectedRow = recordsDGV.Rows[e.RowIndex];

                string studentID = selectedRow.Cells["Student ID"].Value.ToString();
                string ayCode = selectedRow.Cells["AY-Code"].Value.ToString();

                FilterViolationDetails(studentID, ayCode);
            }
        }
        private void FilterViolationDetails(string studentID, string ayCode)
        {
            DataTable allViolationsTable;

            if (viewRecordsDGV.DataSource is DataView dataView)
            {
                allViolationsTable = dataView.Table;
            }
            else if (viewRecordsDGV.DataSource is DataTable dataTable)
            {
                allViolationsTable = dataTable;
            }
            else
            {
                CustomMessageBox.Show("Data source is not valid.");
                return;
            }

            DataView filteredView = new DataView(allViolationsTable)
            {
                RowFilter = $"[Student ID] = '{studentID}' AND [AY-Code] = '{ayCode}'"
            };

            viewRecordsDGV.DataSource = filteredView;
        }
        private async void txtSearchID__TextChanged(object sender, EventArgs e)
        {
            string searchInput = txtSearchID.TrimText();
            string selectedAyCode = cbFilter.SelectedItem?.ToString();

            if (txtSearchID.IsEmpty())
            {
                if (selectedAyCode == "Show All")
                {
                    await LoadStudentViolationCountsAsync();
                    await LoadViolationDetailsAsync();
                }
                else
                {
                    await LoadStudentViolationCountsAsync(selectedAYCode: selectedAyCode);
                    await LoadViolationDetailsAsync(selectedAYCode: selectedAyCode);
                }
            }
            else
            {
                if (selectedAyCode != "Show All")
                {
                    await RecordsDVGSearchAsync(searchInput, selectedAyCode);
                    await ViewRecordsDVGSearchAsync(searchInput, selectedAyCode);
                }
                else
                {
                    await RecordsDVGSearchAsync(searchInput);
                    await ViewRecordsDVGSearchAsync(searchInput);
                }
            }
        }

        private async Task RecordsDVGSearchAsync(string searchTerm, string selectedAycode = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
            {
                return;
            }

            StringBuilder qViolationRecords = new StringBuilder(@"
        SELECT 
            tblViolations.[AY-Code], 
            tblViolations.[Student ID], 
            tblStudents.[Last Name], 
            tblStudents.[First Name], 
            Count(tblViolations.[Violation ID]) AS [Violation Count(s)]
        FROM 
            tblViolations 
        INNER JOIN
            tblStudents ON tblViolations.[Student ID] = tblStudents.[Student ID]
        WHERE
            ([tblViolations].[Student ID] LIKE? OR [tblStudents].[Last Name] LIKE?)");

            if (!string.IsNullOrEmpty(selectedAycode))
            {
                qViolationRecords.Append(" AND tblViolations.[AY-Code] = ?");
            }

            qViolationRecords.Append(" GROUP BY tblViolations.[AY-Code], tblViolations.[Student ID], tblStudents.[Last Name], tblStudents.[First Name]");

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(qViolationRecords.ToString(), conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("?", "%" + searchTerm + "%"); // Student ID
                    adapter.SelectCommand.Parameters.AddWithValue("?", searchTerm + "%"); // Last Name

                    if (!string.IsNullOrEmpty(selectedAycode))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("?", selectedAycode); // AY-Code
                    }

                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    recordsDGV.DataSource = dt;
                }
            }

            // Adding the button column to the DataGridView
            if (recordsDGV.Columns.Contains("btnView"))
            {
                recordsDGV.Columns.Remove("btnView");
            }

            DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
            {
                HeaderText = "View",
                Name = "btnView",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };

            recordsDGV.Columns.Add(btnAction);
            int violationCountIndex = recordsDGV.Columns["Violation Count(s)"].Index;
            recordsDGV.Columns["btnView"].DisplayIndex = violationCountIndex + 1;

            recordsDGV.Refresh();
        }

        private async Task ViewRecordsDVGSearchAsync(string searchTerm, string selectedAycode = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
            {
                return;
            }

            StringBuilder allViolationsQuery = new StringBuilder(@"
            SELECT
                tblViolations.[AY-Code],
                tblViolations.[Date], 
                tblViolations.[Student ID], 
                [tblStudents].[First Name] & ' ' & [tblStudents].[Last Name] AS Name, 
                tblStudents.[Course], 
                tblViolations.[Violation],
                tblViolations.[Offense Type],
                tblViolations.[Sanction]
            FROM 
                tblViolations
            INNER JOIN
                tblStudents ON tblViolations.[Student ID] = tblStudents.[Student ID]
             WHERE
                ([tblViolations].[Student ID] LIKE? OR [tblStudents].[Last Name] LIKE?)");

            if (!string.IsNullOrEmpty(selectedAycode))
            {
                allViolationsQuery.Append(" AND tblViolations.[AY-Code] = ?");
            }

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(allViolationsQuery.ToString(), conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("?", "%" + searchTerm + "%"); // Student ID
                    adapter.SelectCommand.Parameters.AddWithValue("?", searchTerm + "%"); // Last Name

                    if (!string.IsNullOrEmpty(selectedAycode))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("?", selectedAycode); // AY-Code
                    }

                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    viewRecordsDGV.DataSource = dt;
                }
            }

            viewRecordsDGV.Refresh();
        }
        private void ExportDataGridViewToPDF(DataGridView dgv, string filePath)
        {
            XUnit margin = XUnit.FromInch(0.5);
            double headerHeight = 25;

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Exported Data";

            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Landscape;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 10, XFontStyleEx.Regular);
            XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
            XFont footerFont = new XFont("Arial", 8, XFontStyleEx.Italic);

            XSolidBrush headerBrush = new XSolidBrush(XColors.LightGray);
            XSolidBrush textBrush = new XSolidBrush(XColors.Black);
            XPen borderPen = new XPen(XColors.Black);

            double padding = 5;

            double yPos = margin.Point;

            double availableWidth = page.Width.Point - 2 * margin.Point;
            double colWidth = availableWidth / dgv.Columns.Count;

            DrawHeaderTitle(gfx, "SVMS: Violation Records Report", margin, availableWidth, headerFont);
            DrawExportDate(gfx, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), margin, availableWidth, footerFont);
            yPos += headerHeight;

            DrawHeaders(gfx, dgv, margin.Point, colWidth, headerBrush, headerFont, textBrush, ref yPos, headerHeight);

            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                if (!dgv.Rows[rowIndex].IsNewRow)
                {
                    double maxRowHeight = 0;

                    for (int colIndex = 0; colIndex < dgv.Columns.Count; colIndex++)
                    {
                        object cellValueObj = dgv.Rows[rowIndex].Cells[colIndex].Value;
                        string cellValue = cellValueObj?.ToString() ?? string.Empty;

                        if (cellValueObj is DateTime dateValue)
                        {
                            cellValue = dateValue.ToString("yyyy-MM-dd");
                        }

                        XRect cellRect = new XRect(
                            margin.Point + colIndex * colWidth + padding,
                            yPos + padding,
                            colWidth - 2 * padding,
                            double.MaxValue
                        );

                        double cellContentHeight = DrawStringVerticallyCentered(gfx, cellValue, font, textBrush, cellRect, true);

                        if (cellContentHeight > maxRowHeight)
                        {
                            maxRowHeight = cellContentHeight + 2 * padding;
                        }
                    }

                    for (int colIndex = 0; colIndex < dgv.Columns.Count; colIndex++)
                    {
                        object cellValueObj = dgv.Rows[rowIndex].Cells[colIndex].Value;
                        string cellValue = cellValueObj?.ToString() ?? string.Empty;

                        if (cellValueObj is DateTime dateValue)
                        {
                            cellValue = dateValue.ToString("yyyy-MM-dd");
                        }

                        XRect cellRect = new XRect(
                            margin.Point + colIndex * colWidth + padding,
                            yPos + padding,
                            colWidth - 2 * padding,
                            maxRowHeight - 2 * padding
                        );

                        DrawStringVerticallyCentered(gfx, cellValue, font, textBrush, cellRect, true);

                        gfx.DrawRectangle(borderPen, margin.Point + colIndex * colWidth, yPos, colWidth, maxRowHeight);
                    }

                    gfx.DrawRectangle(borderPen, margin.Point, yPos, availableWidth, maxRowHeight);

                    yPos += maxRowHeight;

                    if (yPos > page.Height.Point - margin.Point - maxRowHeight)
                    {
                        AddPageFooter(gfx, document.PageCount, footerFont, margin, availableWidth);

                        page = document.AddPage();
                        page.Size = PdfSharp.PageSize.A4;
                        page.Orientation = PdfSharp.PageOrientation.Landscape;
                        gfx = XGraphics.FromPdfPage(page);
                        yPos = margin.Point;

                        DrawHeaderTitle(gfx, "SVMS: Violation Records Report", margin, availableWidth, headerFont);
                        DrawExportDate(gfx, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), margin, availableWidth, footerFont);
                        yPos += headerHeight;

                        DrawHeaders(gfx, dgv, margin.Point, colWidth, headerBrush, headerFont, textBrush, ref yPos, headerHeight);
                    }
                }
            }

            AddPageFooter(gfx, document.PageCount, footerFont, margin, availableWidth);
            document.Save(filePath);
            document.Close();
        }
        private void DrawHeaderTitle(XGraphics gfx, string title, XUnit margin, double pageWidth, XFont headerFont)
        {
            gfx.DrawString(title, headerFont, XBrushes.Black, new XRect(margin.Point, margin.Point, pageWidth - 2 * margin.Point, 25), XStringFormats.TopLeft);
        }
        private void DrawExportDate(XGraphics gfx, string date, XUnit margin, double pageWidth, XFont footerFont)
        {
            gfx.DrawString(date, footerFont, XBrushes.Black, new XRect(pageWidth - margin.Point, margin.Point, margin.Point, 25), XStringFormats.TopRight);
        }
        private void AddPageFooter(XGraphics gfx, int pageNumber, XFont footerFont, XUnit margin, double pageWidth)
        {
            double footerOffset = 0;
            double footerYPosition = gfx.PdfPage.Height.Point - margin.Point - footerOffset;

            gfx.DrawString($"Page {pageNumber}", footerFont, XBrushes.Black, new XRect(margin.Point, footerYPosition, pageWidth - 2 * margin.Point, 25), XStringFormats.TopLeft);
        }
        private void DrawHeaders(XGraphics gfx, DataGridView dgv, double margin, double colWidth, XSolidBrush headerBrush, XFont headerFont, XBrush textBrush, ref double yPos, double headerHeight)
        {
            double padding = 5;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {

                string headerText = dgv.Columns[i].HeaderText;

                gfx.DrawRectangle(headerBrush, margin + i * colWidth, yPos, colWidth, headerHeight);

                XRect headerRect = new XRect(
                    margin + i * colWidth + padding,
                    yPos + padding,
                    colWidth - 2 * padding,
                    headerHeight - 2 * padding
                );

                gfx.DrawString(headerText, headerFont, textBrush, headerRect, XStringFormats.TopCenter);

                gfx.DrawRectangle(XPens.Black, margin + i * colWidth, yPos, colWidth, headerHeight);
            }

            yPos += headerHeight;
        }
        private double DrawStringVerticallyCentered(XGraphics gfx, string text, XFont font, XBrush brush, XRect rect, bool allowMultiline = true)
        {
            double lineHeight = gfx.MeasureString("A", font).Height;
            double currentY = rect.Y;
            double requiredHeight = lineHeight;

            if (allowMultiline)
            {
                double maxWidth = rect.Width;
                string[] words = text.Split(' ');
                string currentLine = "";

                foreach (string word in words)
                {
                    if (gfx.MeasureString(currentLine + word + " ", font).Width > maxWidth)
                    {
                        gfx.DrawString(currentLine.TrimEnd(), font, brush, new XRect(rect.X, currentY, rect.Width, lineHeight), XStringFormats.TopLeft);
                        currentY += lineHeight;
                        currentLine = word + " ";
                        requiredHeight += lineHeight;
                    }
                    else
                    {
                        currentLine += word + " ";
                    }
                }

                if (!string.IsNullOrEmpty(currentLine))
                {
                    gfx.DrawString(currentLine.TrimEnd(), font, brush, new XRect(rect.X, currentY, rect.Width, lineHeight), XStringFormats.TopLeft);
                    requiredHeight += lineHeight;
                }
            }
            else
            {
                XSize textSize = gfx.MeasureString(text, font);
                double yCenter = rect.Y + (rect.Height - textSize.Height) / 2;
                gfx.DrawString(text, font, brush, new XRect(rect.X, yCenter, rect.Width, textSize.Height), XStringFormats.TopLeft);
            }

            return requiredHeight;
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            DialogResult localResult = CustomMessageBox.Show(
                "Do you want to generate a PDF report for the selected data?",
                "Generate PDF Report",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save a PDF File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportDataGridViewToPDF(viewRecordsDGV, saveFileDialog.FileName);
                        CustomMessageBox.Show("The report has been successfully generated as a PDF. You can find it in the specified location.",
                                              "PDF Report Generated",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"An error occurred while generating the PDF report: {ex.Message}",
                                              "Error",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnReloadDB_Click(object sender, EventArgs e)
        {
            btnReloadDB.Visible = false;
            loadingProgressBar.Visible = true;

            string selectedAYCode = cbFilter.SelectedItem?.ToString() ?? "Show All";

            try
            {
                await Task.WhenAll(
                    LoadStudentViolationCountsAsync(selectedAYCode),
                    LoadViolationDetailsAsync(selectedAYCode)
                );
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingProgressBar.Visible = false;
                btnReloadDB.Visible = true;
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            DialogResult localResult = CustomMessageBox.Show(
                "Do you want to generate a Excel file for the selected data?",
                "Generate Excel File",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {
                ExportToExcel(viewRecordsDGV);
            } else
            {
                return;
            }
                
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            // Use NonCommercial if it's for non-commercial use
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(fileInfo);
                }
            }
        }
    }
}
