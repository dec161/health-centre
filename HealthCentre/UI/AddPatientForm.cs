using HealthCentre.Extensions;
using HealthCentre.Models;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class AddPatientForm : TemplateForm
    {
        private readonly HealthCentreModel Context;
        private readonly DbContextTransaction Transaction;
        private readonly Patient Patient = new Patient()
        {
            Name = "НеУказано НеУказано НеУказано",
            BirthDate = DateTime.Now,
            InsuranceCertificate = "Не указан"
        };

        private string PhotoPath { get; set; } = null;

        private PatientUserControl PatientControl { get; set; }

        public AddPatientForm() : base("Добавление пациента")
        {
            Context = new HealthCentreModel();
            Transaction = Context.Database.BeginTransaction();

            Context.Patient.Add(Patient);
            Patient.Gender = Context.Gender.FirstOrDefault();
            Context.SaveChanges();

            DisplayPatient();
        }

        protected override void ConfigureUI(string title)
        {
            InitializeComponent();
            base.ConfigureUI(title);
        }

        private void PatientLabel_Click(object sender, EventArgs e)
        {
            var form = new EditPatientInfoForm(Context, Patient);
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Context.SaveChanges();

            DisplayPatient();
        }

        private void PatientFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            var form = new EditPatientDatesForm(Patient);
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Context.SaveChanges();

            DisplayPatient();
        }

        private void PatientPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog(this);
        }

        void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var photo = Patient.Photo ?? new Photo()
            {
                RelativePath = Patient.Id.GetHashCode().ToString()
            };

            if (Patient.Photo is null)
            {
                Patient.Photo = photo;
                Context.SaveChanges();
            }

            PhotoPath = OpenFileDialog.FileName;

            DisplayPatient();
        }

        private void DisplayPatient()
        {
            TableLayoutPanel.Controls.Remove(PatientControl);

            PatientControl = new PatientUserControl(Patient)
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                BackColor = Colors.SecondaryBackground,
                Margin = new Padding(0)
            };

            PatientControl.PictureBox.ImageLocation = PhotoPath;

            PatientControl.Label.Click += PatientLabel_Click;
            PatientControl.FlowLayoutPanel.Click += PatientFlowLayoutPanel_Click;
            if (PatientControl.FlowLayoutPanel.HasChildren)
            {
                foreach (Control control in PatientControl.FlowLayoutPanel.Controls)
                {
                    control.Click += PatientFlowLayoutPanel_Click;
                }
            }
            PatientControl.PictureBox.Click += PatientPictureBox_Click;

            TableLayoutPanel.Controls.Add(PatientControl);
        }

        private void Close(DialogResult dialogResult)
        {
            Transaction.Dispose();
            Context.Dispose();

            DialogResult = dialogResult;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Transaction.Commit();

            if (!(Patient.Photo is null))
            {
                using (var file = File.Open(Patient.Photo.GetStoragePath(), FileMode.Create))
                {
                    OpenFileDialog.OpenFile().CopyTo(file);
                }
            }

            Close(DialogResult.OK);
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            Transaction.Rollback();
            Close(DialogResult.Cancel);
        }
    }
}
