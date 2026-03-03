using HealthCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class EditPatientInfoForm : TemplateForm
    {
        public const string FieldCannotBeEmptyTemplate = "Поле {0} не должно быть пустым.";
        public const string FieldCannotBeZeroTemplate = "Поле {0} не должно содержать значение 0.";

        private readonly Patient Patient;

        public EditPatientInfoForm(HealthCentreModel context, Patient patient) : base("Редактирование")
        {
            Patient = patient;

            BirthDateTimePicker.MaxDate = DateTime.Now;

            var genders = context.Gender.ToList();
            GenderComboBox.DataSource = genders;
            GenderComboBox.ValueMember = nameof(Gender.Id);
            GenderComboBox.DisplayMember = nameof(Gender.Name);

            var name = Patient.Name?.Split();

            LastNameTextBox.Text = name?[0];
            FirstNameTextBox.Text = name?[1];
            NameTextBox.Text = name?[2];
            GenderComboBox.SelectedItem = Patient.Gender;
            BirthDateTimePicker.Value = Patient.BirthDate < BirthDateTimePicker.MinDate
                ? BirthDateTimePicker.MinDate
                : Patient.BirthDate;
            InsuranceCertificateTextBox.Text = Patient.InsuranceCertificate;
            HeightNumericUpDown.Value = Patient.Height;
            WeightNumericUpDown.Value = Patient.Weight;
        }

        protected override void ConfigureUI(string title)
        {
            InitializeComponent();
            base.ConfigureUI(title);
            TableLayoutPanel.BackColor = Colors.SecondaryBackground;
            OkButton.BackColor = Colors.Attention;
            CancelEditButton.BackColor = Colors.Attention;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var fullName = new List<string>()
            {
                LastNameTextBox.Text,
                FirstNameTextBox.Text,
                NameTextBox.Text
            };

            if (string.IsNullOrWhiteSpace(fullName[0]))
            {
                MessageBox.Show(string.Format(FieldCannotBeEmptyTemplate, "Фамилия"));
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName[1]))
            {
                MessageBox.Show(string.Format(FieldCannotBeEmptyTemplate, "Имя"));
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName[2]))
            {
                MessageBox.Show(string.Format(FieldCannotBeEmptyTemplate, "Отчество"));
                return;
            }

            var insuranceCertificate = InsuranceCertificateTextBox.Text;
            if (string.IsNullOrWhiteSpace(insuranceCertificate))
            {
                MessageBox.Show(string.Format(FieldCannotBeEmptyTemplate, "Страховой полис"));
                return;
            }

            var height = (int)HeightNumericUpDown.Value;
            if (height == 0)
            {
                MessageBox.Show(string.Format(FieldCannotBeZeroTemplate, "Рост"));
                return;
            }

            var weight = (int)WeightNumericUpDown.Value;
            if (weight == 0)
            {
                MessageBox.Show(string.Format(FieldCannotBeZeroTemplate, "Вес"));
                return;
            }

            Patient.Name = string.Format("{0} {1} {2}",
                fullName.Select(text => Regex.Replace(text, "\\s", string.Empty)).ToArray());
            Patient.Gender = (Gender)GenderComboBox.SelectedItem;
            Patient.BirthDate = BirthDateTimePicker.Value;
            Patient.InsuranceCertificate = insuranceCertificate.Trim();
            Patient.Height = (int)HeightNumericUpDown.Value;
            Patient.Weight = (int)WeightNumericUpDown.Value;

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
