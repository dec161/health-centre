using HealthCentre.Enums;
using HealthCentre.Extensions;
using HealthCentre.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HealthCentre.UI
{
    public partial class MainForm : TemplateForm
    {
        public const string Title = "Главная страница";

        private readonly Gender AnyGender = new Gender() { Name = "Все" };
        private readonly Permissions Permissions;

        private Func<IQueryable<Patient>, IOrderedQueryable<Patient>> Order { get; set; } = null;

        public MainForm(Permissions permissions) : base(Title)
        {
            Permissions = permissions;
            ApplyPermissions(Permissions);

            using (var context = new HealthCentreModel())
            {
                var genders = context.Gender.AsNoTracking()
                    .Prepend(AnyGender).ToList();

                GenderComboBox.DataSource = genders;
                GenderComboBox.DisplayMember = nameof(Gender.Name);
                GenderComboBox.ValueMember = GenderComboBox.DisplayMember;
            }

            DisplayPatients();
        }

        public MainForm(Permissions permissions, string username) : base(Title, username)
        {
            Permissions = permissions;
            ApplyPermissions(Permissions);

            using (var context = new HealthCentreModel())
            {
                var genders = context.Gender.AsNoTracking()
                    .Prepend(AnyGender).ToList();

                GenderComboBox.DataSource = genders;
                GenderComboBox.DisplayMember = nameof(Gender.Name);
                GenderComboBox.ValueMember = GenderComboBox.DisplayMember;
            }

            DisplayPatients();
        }

        protected override void ConfigureUI(string title)
        {
            InitializeComponent();
            base.ConfigureUI(title);
            SortCheckBox.BackColor = Colors.Attention;
            AddPatientButton.BackColor = Colors.Attention;
        }

        private void ApplyPermissions(Permissions permissions)
        {
            var canViewPatients = permissions.HasFlag(Permissions.ViewPatients);

            SearchTextBox.Visible = canViewPatients;
            SortCheckBox.Visible = canViewPatients;
            GenderComboBox.Visible = canViewPatients;

            AddPatientButton.Visible = permissions.HasFlag(Permissions.EditPatients);
        }

        private void DisplayPatients()
        {
            PatientsTableLayoutPanel.Controls.Clear();

            using (var context = new HealthCentreModel())
            {
                var patients = context.Patient.AsNoTracking().AsQueryable();

                var searchText = SearchTextBox.Text.ToLower();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    patients = patients.Where(patient => patient.Name.ToLower().Contains(searchText)
                    || patient.InsuranceCertificate.ToLower().Contains(searchText));
                }

                var selectedGender = (string)GenderComboBox.SelectedValue;
                if (selectedGender != AnyGender.Name)
                {
                    patients = patients.Where(patient => patient.Gender.Name == selectedGender);
                }

                if (Order is null)
                {
                    patients = patients.OrderBy(patient => patient.Name);
                }
                else
                {
                    patients = Order(patients)
                        .ThenBy(patient => patient.Name);
                }

                foreach (var patient in patients)
                {
                    DisplayPatient(patient);
                }
            }
        }

        private void DisplayPatient(Patient patient)
        {
            var patientControl = new PatientUserControl(patient)
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                BackColor = Colors.SecondaryBackground,
                Margin = new Padding(0, 3, 0, 3)
            };

            if (Permissions.HasFlag(Permissions.EditPatients))
            {
                patientControl.Label.Click += PatientLabel_Click;

                patientControl.FlowLayoutPanel.Click += PatientFlowLayoutPanel_Click;
                if (patientControl.FlowLayoutPanel.HasChildren)
                {
                    foreach (Control control in patientControl.FlowLayoutPanel.Controls)
                    {
                        control.Click += PatientFlowLayoutPanel_Click;
                    }
                }

                patientControl.PictureBox.Click += PatientPictureBox_Click;
            }

            PatientsTableLayoutPanel.Controls.Add(patientControl);

            var button = new Button()
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Colors.Attention,
                Text = "История"
            };

            button.Click += ViewVisits(patientControl.PatientId);

            PatientsTableLayoutPanel.Controls.Add(button);
        }

        private EventHandler ViewVisits(int patientId)
        {
            void ViewVisitsButton_Click(object sender, EventArgs e)
            {
                using (var context = new HealthCentreModel())
                {
                    var patient = GetPatient(context, patientId);
                    if (patient is null)
                    {
                        return;
                    }

                    var form = new VisitsForm(patient);
                    form.ShowDialog(this);
                }
            }

            return ViewVisitsButton_Click;
        }

        private void PatientLabel_Click(object sender, EventArgs e)
        {
            var patientId = GetPatientId((Control)sender);

            using (var context = new HealthCentreModel())
            {
                var patient = GetPatient(context, patientId);
                if (patient is null)
                {
                    return;
                }

                var form = new EditPatientInfoForm(context, patient);
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                context.SaveChanges();
            }

            DisplayPatients();
        }

        private void PatientFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            var patientId = GetPatientId((Control)sender);

            using (var context = new HealthCentreModel())
            {
                var patient = GetPatient(context, patientId);
                if (patient is null)
                {
                    return;
                }

                var form = new EditPatientDatesForm(patient);
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                context.SaveChanges();
            }

            DisplayPatients();
        }

        private void PatientPictureBox_Click(object sender, EventArgs e)
        {
            var patientId = GetPatientId((Control)sender);

            var dialog = new OpenFileDialog();
            var photo = GetPhoto(patientId) ?? new Photo()
            {
                RelativePath = patientId.GetHashCode().ToString()
            };

            void Dialog_FileOK(object _, EventArgs __)
            {
                SetPhoto(patientId, photo);

                using (var file = File.Open(photo.GetStoragePath(), FileMode.Create))
                {
                    dialog.OpenFile().CopyTo(file);
                }

                DisplayPatients();
            }

            dialog.FileOk += Dialog_FileOK;
            dialog.ShowDialog(this);
        }

        private int GetPatientId(Control control)
        {
            while (!(control is PatientUserControl))
            {
                control = control.Parent;
            }

            return (control as PatientUserControl).PatientId;
        }

        private Patient GetPatient(HealthCentreModel context, int patientId)
        {
            return context.Patient
                .Where(patient => patient.Id == patientId)
                .FirstOrDefault();
        }

        private Photo GetPhoto(int patientId)
        {
            using (var context = new HealthCentreModel())
            {
                return context.Patient
                    .Where(patient => patient.Id == patientId)
                    .FirstOrDefault()?.Photo;
            }
        }

        private void SetPhoto(int patientId, Photo photo)
        {
            using (var context = new HealthCentreModel())
            {
                var currentPatient = context.Patient
                    .Where(patient => patient.Id == patientId)
                    .FirstOrDefault();

                if (!(currentPatient is null) && currentPatient.Photo is null)
                {
                    currentPatient.Photo = photo;
                    context.SaveChanges();
                }
            }
        }

        private void SetSortDisplaySymbol(char symbol)
        {
            SortCheckBox.Text = $"{symbol} Дата рождения";
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            DisplayPatients();
        }

        private void SortCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            switch (SortCheckBox.CheckState)
            {
                case CheckState.Unchecked:
                    Order = null;
                    SetSortDisplaySymbol('–');
                    break;

                case CheckState.Checked:
                    Order = patients => patients.OrderBy(patient => patient.BirthDate);
                    SetSortDisplaySymbol('▲');
                    break;

                case CheckState.Indeterminate:
                    Order = patients => patients.OrderByDescending(patient => patient.BirthDate);
                    SetSortDisplaySymbol('▼');
                    break;
            }

            DisplayPatients();
        }

        private void AddPatientButton_Click(object sender, EventArgs e)
        {
            var form = new AddPatientForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                DisplayPatients();
            }
        }
    }
}
