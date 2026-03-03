using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class TemplateForm : Form
    {
        public TemplateForm(string title)
        {
            ConfigureUI(title);
        }

        protected virtual void ConfigureUI(string title)
        {
            InitializeComponent();
            BackColor = Colors.PrimaryBackground;
            ForeColor = Colors.Universal;
            TitleLabel.Text = title;
        }

        private TemplateForm() : this("Title") { }
    }
}
