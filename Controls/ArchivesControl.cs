using OfficeOpenXml;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMS.Controls
{
    public partial class ArchivesControl : UserControl
    {
        private string DbConn;
        private string userRole;
        private string userName;

        public event Action OnDataChanged;
        public ArchivesControl(string role, string username)
        {
            InitializeComponent();
            userRole = role;
            userName = username;
            DbConn = GetDbConnectionString();

            txtSelectedAYCode.SetReadOnly(true);
        }

        private string GetDbConnectionString()
        {
            string sourcePath = Properties.Settings.Default.DatabasePath;
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath};";
        }

        public async void RefreshData()
        {
            await LoadViolationsWithAYCodeAsync();
            await LoadDataFromDatabaseAsync();
        }

        protected void NotifyDataChanged()
        {
            OnDataChanged?.Invoke();
        }

        private async void ArchivesControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DbConn))
            {
                DbConn = GetDbConnectionString();
            }

            loadingProgressBar.Visible = false;
            archivesDGV.CellPainting += archivesDGV_CellPainting;
            archivesDGV.CellClick += archivesDGV_CellClick;
            await LoadViolationsWithAYCodeAsync();
            await LoadDataFromDatabaseAsync();
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
            AND v.[IsDeleted] = False
            AND v.[IsArchive] = False) AS [CountOfViolations]
            FROM (
            SELECT DISTINCT [AY-Code], [Student ID]
            FROM tblViolations
            WHERE [IsDeleted] = False
            AND [IsArchive] = False
            ) AS DistinctStudents
            GROUP BY DistinctStudents.[AY-Code]
            ORDER BY DistinctStudents.[AY-Code] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        await Task.Run(() => adapter.Fill(dt));
                        archivesDGV.DataSource = dt;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading data: {ex.Message}");
                    }
                }

                FormatArchivesDGV();

                if (!archivesDGV.Columns.Contains("btnAction"))
                {
                    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn
                    {
                        HeaderText = "Manage",
                        Name = "btnAction",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    archivesDGV.Columns.Add(btnAction);

                    btnAction.DisplayIndex = archivesDGV.Columns.Count - 1;
                }

                archivesDGV.Columns["CountOfDistinctStudents"].HeaderText = "Students with Violations";
                archivesDGV.Columns["CountOfViolations"].HeaderText = "Recorded Violations";

                archivesDGV.Refresh();
            }
        }

        private void FormatArchivesDGV()
        {
            archivesDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 12, FontStyle.Bold); //FontStyle.Bold
            archivesDGV.DefaultCellStyle.Font = new Font("Arial Narrow", 12);

            archivesDGV.EnableHeadersVisualStyles = false;

            archivesDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            archivesDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            archivesDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            archivesDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            archivesDGV.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            archivesDGV.DefaultCellStyle.ForeColor = Color.Black;

            archivesDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            archivesDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            archivesDGV.DefaultCellStyle.SelectionBackColor = archivesDGV.DefaultCellStyle.BackColor;
            archivesDGV.DefaultCellStyle.SelectionForeColor = archivesDGV.DefaultCellStyle.ForeColor;

            archivesDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = archivesDGV.AlternatingRowsDefaultCellStyle.BackColor;
            archivesDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = archivesDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            archivesDGV.GridColor = Color.FromArgb(180, 180, 180);

            archivesDGV.ColumnHeadersHeight = 40;
            archivesDGV.RowTemplate.Height = 30;

            archivesDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            archivesDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            archivesDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            archivesDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            archivesDGV.DefaultCellStyle.SelectionBackColor = archivesDGV.DefaultCellStyle.BackColor;
            archivesDGV.DefaultCellStyle.SelectionForeColor = archivesDGV.DefaultCellStyle.ForeColor;

            archivesDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = archivesDGV.AlternatingRowsDefaultCellStyle.BackColor;
            archivesDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = archivesDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            archivesDGV.AllowUserToResizeColumns = false;
            archivesDGV.AllowUserToResizeRows = false;
            archivesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            archivesDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            archivesDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in archivesDGV.Columns)
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

        private void FormatRecordDGV()
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

            recordsDGV.DefaultCellStyle.SelectionBackColor = recordsDGV.DefaultCellStyle.BackColor;
            recordsDGV.DefaultCellStyle.SelectionForeColor = recordsDGV.DefaultCellStyle.ForeColor;

            recordsDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = recordsDGV.AlternatingRowsDefaultCellStyle.BackColor;
            recordsDGV.AlternatingRowsDefaultCellStyle.SelectionForeColor = recordsDGV.AlternatingRowsDefaultCellStyle.ForeColor;

            recordsDGV.AllowUserToResizeColumns = false;
            recordsDGV.AllowUserToResizeRows = false;
            recordsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            recordsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            recordsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in recordsDGV.Columns)
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

        private void archivesDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == archivesDGV.Columns["btnAction"].Index && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image viewIcon = Properties.Resources.ExpandIcon;
                Image deleteIcon = Properties.Resources.DeleteIcon;

                int iconSize = 20;
                int margin = 5;

                int totalWidth = (iconSize * 2) + margin;

                int centerX = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
                int centerY = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                var viewIconRect = new Rectangle(centerX, centerY, iconSize, iconSize);
                var deleteIconRect = new Rectangle(centerX + iconSize + margin, centerY, iconSize, iconSize);

                e.Graphics.DrawImage(viewIcon, viewIconRect);
                e.Graphics.DrawImage(deleteIcon, deleteIconRect);

                archivesDGV.Rows[e.RowIndex].Tag = new { UpdateIconRect = viewIconRect, DeleteIconRect = deleteIconRect };

                e.Handled = true;
            }
        }

        private void archivesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == archivesDGV.Columns["btnAction"].Index)
            {
                DataGridViewRow selectedRow = archivesDGV.Rows[e.RowIndex];

                var tag = selectedRow.Tag as dynamic;
                if (tag != null)
                {
                    Rectangle viewIconRect = tag.UpdateIconRect;
                    Rectangle deleteIconRect = tag.DeleteIconRect;

                    Point mousePosition = archivesDGV.PointToClient(Cursor.Position);

                    if (viewIconRect.Contains(mousePosition))
                    {
                        ViewRecord(selectedRow);
                    }
                    else if (deleteIconRect.Contains(mousePosition))
                    {
                        if (userRole == "Authorized User" || userRole == "Sub-Admin")
                        {
                            CustomMessageBox.Show("You don't have permission to delete records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MoveToTrash(selectedRow);
                        }
                    }
                }
            }
        }

        private async Task LoadDataFromDatabaseAsync()
        {
            string query = @"
            SELECT 
                v.[AY-Code], 
                v.[Date], 
                v.[Student ID], 
                s.[Last Name], 
                s.[First Name], 
                v.[Course], 
                v.[Violation], 
                v.[Offense Type], 
                v.[Sanction]
            FROM 
                tblViolations v
            INNER JOIN 
                tblStudents s ON v.[Student ID] = s.[Student ID]
            WHERE 
                v.[IsDeleted] = False
            ORDER BY 
                v.[Date] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    await conn.OpenAsync();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        await Task.Run(() => adapter.Fill(dt));

                        recordsDGV.DataSource = dt;

                        FormatRecordDGV();

                        recordsDGV.Columns["AY-Code"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        private async Task LoadViolationsByAYCodeAsync(string ayCode)
        {
            string query = @"
            SELECT  
                v.[Date], 
                v.[Student ID], 
                s.[Last Name], 
                s.[First Name], 
                v.[Course], 
                v.[Violation], 
                v.[Offense Type], 
                v.[Sanction]
            FROM 
                tblViolations v
            INNER JOIN 
                tblStudents s ON v.[Student ID] = s.[Student ID]
            WHERE 
                v.[IsDeleted] = False
            AND 
                v.[AY-Code] = ?
            ORDER BY 
                v.[Date] DESC";

            using (OleDbConnection conn = new OleDbConnection(DbConn))
            {
                try
                {
                    await conn.OpenAsync();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", ayCode);

                        DataTable dt = new DataTable();
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            await Task.Run(() => adapter.Fill(dt));
                        }

                        recordsDGV.DataSource = dt;

                        FormatRecordDGV();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        private async void ViewRecord(DataGridViewRow selectedRow)
        {
            string ayCode = selectedRow.Cells["AY-Code"]?.Value?.ToString();

            if (!string.IsNullOrEmpty(ayCode))
            {
                txtSelectedAYCode.Texts = ayCode;
                await LoadViolationsByAYCodeAsync(ayCode);
            }
            else
            {
                MessageBox.Show("The selected row does not contain a valid AY-Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MoveToTrash(DataGridViewRow row)
        {
            string ayCode = row.Cells["AY-Code"].Value.ToString();

            DialogResult result = CustomMessageBox.Show($"Are you sure you want to move this archive to the trash? It can be restored later if needed.", "Moving Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE tblViolations SET IsDeleted = True, IsArchive = True WHERE [AY-Code] = ?";

                    using (OleDbConnection conn = new OleDbConnection(DbConn))
                    {
                        await conn.OpenAsync();
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AYCode", ayCode);

                            await cmd.ExecuteNonQueryAsync();
                            LogActivity("Move", $"The records for AY-Code {ayCode} has been moved to the trash.", userName);
                            CustomMessageBox.Show($"The records for AY-Code {ayCode} has been moved to trash.", "Successfully Moved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("An error occurred while moving the AY-Code record to trash: " + ex.Message, "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            await Task.WhenAll(LoadViolationsWithAYCodeAsync(), LoadDataFromDatabaseAsync());
            NotifyDataChanged();
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
                        ExportDataGridViewToPDF(recordsDGV, saveFileDialog.FileName);
                        LogActivity("Export", $"PDF file successfully generated", userName);
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

        private async void btnReloadDB_Click(object sender, EventArgs e)
        {
            btnReloadDB.Visible = false;
            loadingProgressBar.Visible = true;

            try
            {
                await Task.WhenAll(LoadViolationsWithAYCodeAsync(), LoadDataFromDatabaseAsync());
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
                ExportToExcel(recordsDGV);
            }
            else
            {
                return;
            }
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

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
                    try
                    {
                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(fileInfo);
                        LogActivity("Export", $"Excel file successfully generated", userName);
                        CustomMessageBox.Show("The data has been successfully generated as a Excel. You can find it in the specified location.",
                                              "Excel File Generated",
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
    }
}
