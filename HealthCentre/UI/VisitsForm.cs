using HealthCentre.Models;
using System;
using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class VisitsForm : TemplateForm
    {
        public VisitsForm(Patient patient) : base($"История обращения к врачам{Environment.NewLine}" +
            $"пациента {patient.Name}")
        {
            foreach (var visit in patient.Visit)
            {
                var label = new Label()
                {
                    BackColor = Colors.SecondaryBackground,
                    Dock = DockStyle.Fill,
                    Text = $"{visit.Date.ToLongDateString()}{Environment.NewLine}" +
                    Environment.NewLine +
                    $"{visit.DoctorType.Name}",
                    Margin = new Padding(0, 5, 0, 5),
                    AutoSize = true
                };
                TableLayoutPanel.Controls.Add(label);
            }
        }

        protected override void ConfigureUI(string title)
        {
            InitializeComponent();
            base.ConfigureUI(title);
        }
    }
}
