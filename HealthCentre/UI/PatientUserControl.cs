using HealthCentre.Extensions;
using HealthCentre.Models;
using HealthCentre.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class PatientUserControl : UserControl
    {
        public const int PictogramSize = 50;

        private readonly Patient Patient;

        public int PatientId => Patient.Id;

        public PatientUserControl(Patient patient)
        {
            InitializeComponent();

            Patient = patient;

            Label.Text = string.Format(
                $"Фамилия: {{0}}{Environment.NewLine}" +
                $"Имя: {{1}}{Environment.NewLine}" +
                $"Отчество: {{2}}{Environment.NewLine}", Patient.Name.Split()) +
                $"Пол: {Patient.Gender.Name}{Environment.NewLine}" +
                Environment.NewLine +
                $"Страховой полис: {Patient.InsuranceCertificate}";

            if (Patient.HealthAssessment.HasValue && !IsOutdated(Patient.HealthAssessment.Value))
            {
                AddPictogram(Resources.dispanser);
            }

            if (Patient.DisabilityGroupI.HasValue
                || Patient.DisabilityGroupII.HasValue
                || Patient.DisabilityGroupIII.HasValue)
            {
                AddPictogram(Resources.handicaped);
            }

            if (Patient.Fluorography.HasValue && !IsOutdated(Patient.Fluorography.Value))
            {
                AddPictogram(Resources.fluorography);
            }

            if (!(Patient.Photo is null))
            {
                PictureBox.ImageLocation = Patient.Photo.GetStoragePath();
            }
        }

        private void AddPictogram(Bitmap image)
        {
            var pictureBox = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(PictogramSize, PictogramSize),
                Image = image
            };
            FlowLayoutPanel.Controls.Add(pictureBox);
        }

        private bool IsOutdated(DateTime dateTime)
        {
            return (DateTime.Now - dateTime).TotalDays > 365.0;
        }
    }
}
