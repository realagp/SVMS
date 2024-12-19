using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;

namespace SVMS
{
    class CircularPictureBox : PictureBox
    {
        // Fields
        private int borderSize = 2;
        private Color borderColor = Color.RoyalBlue;
        private Image defaultImage; // Field for default image

        // Constructor
        public CircularPictureBox()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Properties

        [Category("Circular")]
        public Image DefaultImage
        {
            get { return defaultImage; }
            set { defaultImage = value; }
        }

        [Category("Circular")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Circular")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        // Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // Fields
            var graph = pe.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize);
            var smoothSize = borderSize > 0 ? borderSize * 3 : 1;

            using (var pathRegion = new GraphicsPath())
            using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (var penBorder = new Pen(borderColor, borderSize) { DashStyle = DashStyle.Solid, DashCap = DashCap.Flat })
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                pathRegion.AddEllipse(rectContourSmooth);
                // Set rounded region 
                this.Region = new Region(pathRegion);

                // Drawing
                graph.DrawEllipse(penSmooth, rectContourSmooth); // Draw contour smoothing
                if (borderSize > 0) // Draw border
                    graph.DrawEllipse(penBorder, rectBorder);
            }
        }

        // Method to update profile photo
        public void UpdateProfilePhoto(Image image, string connectionString, int adminID)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] photo = ms.ToArray();

                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    var command = new OleDbCommand("UPDATE tblUser SET [Photo] = ? WHERE [User ID] = ?", connection);
                    command.Parameters.AddWithValue("@Photo", photo);
                    command.Parameters.AddWithValue("@User ID", adminID);
                    command.ExecuteNonQuery();
                }
            }
            this.Image = image;
        }

        // Method to remove profile photo
        public void RemoveProfilePhoto(string connectionString, int adminID)
        {
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var command = new OleDbCommand("UPDATE tblUser SET [Photo] = NULL WHERE [User ID] = ?", connection);
                command.Parameters.AddWithValue("@User ID", adminID);
                command.ExecuteNonQuery();
            }
            // Set the PictureBox to the default image
            if (defaultImage != null)
            {
                this.Image = defaultImage;
            }
        }
    }
}
