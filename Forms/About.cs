using System.Configuration;
using System.Windows.Forms;

namespace SVMS.Forms
{
    public partial class About : DropShadow
    {
        public About()
        {
            InitializeComponent();
            LoadAboutDetails();
        }

        private void LoadAboutDetails()
        {
            string aboutTitle = ConfigurationManager.AppSettings["AboutTitle"];
            string aboutVersion = ConfigurationManager.AppSettings["AboutVersion"];
            string aboutDescription = $"SVMS is designed to streamline the process of logging, tracking,\n" +
                                      $"and managing student violations with ease and accuracy.";
            string aboutTechnologies = ConfigurationManager.AppSettings["AboutTechnologies"];
            string aboutCopyright = ConfigurationManager.AppSettings["AboutCopyright"];

            lblTitle.Text = aboutTitle;
            lblVersion.Text = "Version: " + aboutVersion;
            lblDescription.Text = aboutDescription;
            lblTechnologies.Text = aboutTechnologies;
            lblCopyright.Text = aboutCopyright;
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
