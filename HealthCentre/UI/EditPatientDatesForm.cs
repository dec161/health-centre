using HealthCentre.Models;
using System;
using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class EditPatientDatesForm : TemplateForm
    {
        private readonly Patient Patient;

        public EditPatientDatesForm(Patient patient) : base("Редактирование")
        {
            Patient = patient;

            var maxDate = DateTime.Now;
            FluorographyDateTimePicker.MaxDate = maxDate;
            HealthAssessmentDateTimePicker.MaxDate = maxDate;
            DisabilityGroupIDateTimePicker.MaxDate = maxDate;
            DisabilityGroupIIDateTimePicker.MaxDate = maxDate;
            DisabilityGroupIIIDateTimePicker.MaxDate = maxDate;

            SetPickerDate(FluorographyDateTimePicker, Patient.Fluorography);
            SetPickerDate(HealthAssessmentDateTimePicker, Patient.HealthAssessment);
            SetPickerDate(DisabilityGroupIDateTimePicker, Patient.DisabilityGroupI);
            SetPickerDate(DisabilityGroupIIDateTimePicker, Patient.DisabilityGroupII);
            SetPickerDate(DisabilityGroupIIIDateTimePicker, Patient.DisabilityGroupIII);

            FluorographyСheckBox.Checked = FluorographyDateTimePicker.Enabled;
            HealthAssessmentCheckBox.Checked = HealthAssessmentDateTimePicker.Enabled;
            DisabilityGroupICheckBox.Checked = DisabilityGroupIDateTimePicker.Enabled;
            DisabilityGroupIICheckBox.Checked = DisabilityGroupIIDateTimePicker.Enabled;
            DisabilityGroupIIICheckBox.Checked = DisabilityGroupIIIDateTimePicker.Enabled;
        }

        protected override void ConfigureUI(string title)
        {
            InitializeComponent();
            base.ConfigureUI(title);
            TableLayoutPanel.BackColor = Colors.SecondaryBackground;
            OkButton.BackColor = Colors.Attention;
            CancelEditButton.BackColor = Colors.Attention;
        }

        private void SetPickerDate(DateTimePicker dateTimePicker, DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                dateTimePicker.Enabled = false;
                return;
            }

            dateTimePicker.Value = dateTime.Value < dateTimePicker.MinDate
                ? dateTimePicker.MinDate
                : dateTime.Value;
        }

        private DateTime? GetPickerDate(DateTimePicker dateTimePicker)
        {
            if (dateTimePicker.Enabled)
            {
                return dateTimePicker.Value;
            }

            return null;
        }

        private void FluorographyСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FluorographyDateTimePicker.Enabled = FluorographyСheckBox.Checked;
        }

        private void HealthAssessmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            HealthAssessmentDateTimePicker.Enabled = HealthAssessmentCheckBox.Checked;
        }

        private void DisabilityGroupICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DisabilityGroupIDateTimePicker.Enabled = DisabilityGroupICheckBox.Checked;
        }

        private void DisabilityGroupIICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DisabilityGroupIIDateTimePicker.Enabled = DisabilityGroupIICheckBox.Checked;
        }

        private void DisabilityGroupIIICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DisabilityGroupIIIDateTimePicker.Enabled = DisabilityGroupIIICheckBox.Checked;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Patient.Fluorography = GetPickerDate(FluorographyDateTimePicker);
            Patient.HealthAssessment = GetPickerDate(HealthAssessmentDateTimePicker);
            Patient.DisabilityGroupI = GetPickerDate(DisabilityGroupIDateTimePicker);
            Patient.DisabilityGroupII = GetPickerDate(DisabilityGroupIIDateTimePicker);
            Patient.DisabilityGroupIII = GetPickerDate(DisabilityGroupIIIDateTimePicker);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
