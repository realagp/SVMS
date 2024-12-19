using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SVMS
{
    [DefaultEvent("SelectedIndexChanged")]
    class CustomComboBox : UserControl
    {
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;

        private int borderSize = 2;
        private int borderRadius = 0;
        private bool isFocused = false;

        private string placeholderText = "";
        private Font placeholderFont = new Font("Arrial Narrow", 10F, FontStyle.Italic);
        private Color placeholderColor = Color.DarkGray;
        private bool isPlaceholder = false;

        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        private int maxDropDownItems = 10;

        [Category("SVMS ComboBox")]
        public ComboBoxStyle DropDownStyle
        {
            get { return cmbList.DropDownStyle; }
            set
            {
                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                {
                    cmbList.DropDownStyle = value;
                    cmbList.MaxDropDownItems = maxDropDownItems;
                }
            }
        }

        [Category("SVMS ComboBox")]
        public int DropDownHeight
        {
            get { return cmbList.DropDownHeight; }
            set
            {
                cmbList.DropDownHeight = value;
                UpdateMaxDropDownItems();
            }
        }

        [Category("SVMS ComboBox")]
        public bool IntegralHeight
        {
            get { return cmbList.IntegralHeight; }
            set
            {
                cmbList.IntegralHeight = value;
                UpdateMaxDropDownItems();
            }
        }

        private void UpdateMaxDropDownItems()
        {
            if (cmbList.IntegralHeight)
            {
                // Assuming a standard item height of 22 for ComboBox items
                cmbList.MaxDropDownItems = DropDownHeight / 22;
            }
            else
            {
                cmbList.MaxDropDownItems = DropDownHeight / cmbList.ItemHeight;
            }
        }

        [Category("SVMS ComboBox")]
        public int MaxDropDownItems
        {
            get { return maxDropDownItems; }
            set
            {
                maxDropDownItems = value;
                cmbList.MaxDropDownItems = maxDropDownItems;
            }
        }

        [Category("SVMS ComboBox")]
        public new Color BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }
        [Category("SVMS ComboBox")]
        public Color IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                btnIcon.Invalidate(); //Redraw icon
            }
        }

        [Category("SVMS ComboBox")]
        public Color ListBackColor
        {
            get { return listBackColor; }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("SVMS ComboBox")]
        public Color ListTextColor
        {
            get { return listTextColor; }
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("SVMS ComboBox")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                base.BackColor = borderColor; //Border Color
            }
        }

        [Category("SVMS ComboBox")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize); //Border Size 
                AdjustComboBoxDimensions();
            }
        }

        [Category("SVMS ComboBox")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("SVMS ComboBox")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                if (!isPlaceholder)
                    lblText.ForeColor = value;
            }
        }

        [Category("SVMS ComboBox")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;
            }
        }

        [Category("SVMS ComboBox")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return lblText.Text;
            }
            set
            {
                lblText.Text = value;
                isPlaceholder = string.IsNullOrWhiteSpace(value);

                if (isPlaceholder)
                {
                    SetPlaceholder();
                }
                else
                {
                    RemovePlaceholder();
                    lblText.ForeColor = this.ForeColor;
                    lblText.Font = this.Font;
                }
            }
        }

        [Category("SVMS ComboBox")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    lblText.ForeColor = value;
            }
        }

        [Category("SVMS ComboBox")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                lblText.Text = "";
                SetPlaceholder();
            }
        }

        [Category("SVMS ComboBox")]
        public Font PlaceholderFont
        {
            get { return placeholderFont; }
            set
            {
                placeholderFont = value;
                if (isPlaceholder)
                    lblText.Font = value;
            }
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(lblText.Text) && !string.IsNullOrEmpty(placeholderText))
            {
                isPlaceholder = true;
                lblText.Text = placeholderText;
                lblText.ForeColor = placeholderColor;
                lblText.Font = placeholderFont;
            }
        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && !string.IsNullOrEmpty(placeholderText))
            {
                isPlaceholder = false;
                lblText.Text = "";
                lblText.ForeColor = this.ForeColor;
                lblText.Font = this.Font;
            }
        }
        public void ClearSelection()
        {
            cmbList.SelectedIndex = -1;
            SetPlaceholder();
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(lblText.Text) || lblText.Text == placeholderText;
        }

        public string TrimText()
        {
            return lblText.Text.Trim();
        }

        public void RemoveItem(object item)
        {
            if (this.Items.Contains(item))
            {
                this.Items.Remove(item);
            }
        }

        public void AddItem(object item)
        {
            if (!this.Items.Contains(item))
            {
                this.Items.Add(item);
            }
        }

        //Properties
        //-> Data
        [Category("CustomComboBox - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return cmbList.Items; }
        }

        [Category("CustomComboBox - Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get { return cmbList.DataSource; }
            set { cmbList.DataSource = value; }
        }

        [Category("CustomComboBox - Data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return cmbList.AutoCompleteCustomSource; }
            set { cmbList.AutoCompleteCustomSource = value; }
        }

        [Category("CustomComboBox - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return cmbList.AutoCompleteSource; }
            set { cmbList.AutoCompleteSource = value; }
        }

        [Category("CustomComboBox - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return cmbList.AutoCompleteMode; }
            set { cmbList.AutoCompleteMode = value; }
        }

        [Category("CustomComboBox - Data")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return cmbList.SelectedItem; }
            set { cmbList.SelectedItem = value; }
        }

        [Category("CustomComboBox - Data")]
        public string SelectedItemText
        {
            get
            {
                return SelectedItem?.ToString() ?? string.Empty;
            }
        }

        [Category("CustomComboBox - Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return cmbList.SelectedIndex; }
            set { cmbList.SelectedIndex = value; }
        }

        [Category("CustomComboBox - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return cmbList.DisplayMember; }
            set { cmbList.DisplayMember = value; }
        }

        [Category("CustomComboBox - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return cmbList.ValueMember; }
            set { cmbList.ValueMember = value; }
        }

        public event EventHandler SelectedIndexChanged;
        //Constructor
        public CustomComboBox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            //ComboBox: Dropdown list
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.MaxDropDownItems = maxDropDownItems;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Default event
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);//Refresh text
            cmbList.Enter += new EventHandler(ComboBox_Enter);
            cmbList.Leave += new EventHandler(ComboBox_Leave);

            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);//Open dropdown list
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);//Draw icon

            //Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10F);

            //->Attach label events to user control event
            lblText.Click += new EventHandler(Surface_Click);//Select combo box
            lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
            lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

            //User Control
            this.Controls.Add(lblText);//2
            this.Controls.Add(btnIcon);//1
            this.Controls.Add(cmbList);//0

            //this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);//Border Size
            this.Font = new Font(this.Font.Name, 10F);
            base.BackColor = borderColor; //Border Color
            this.ResumeLayout();
            AdjustComboBoxDimensions();

            DropDownHeight = 72;
            IntegralHeight = false;
        }

        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                    graph.DrawPath(penBorder, pathBorder);
                }
            }
            else //Square/Normal TextBox
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            pathTxt = GetFigurePath(cmbList.ClientRectangle, borderSize * 2);
            cmbList.Region = new Region(pathTxt);
            pathTxt.Dispose();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged.Invoke(sender, e);
            lblText.Text = cmbList.Text;
        }
        private void ComboBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }

        private void ComboBox_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }
        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;
        }
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
