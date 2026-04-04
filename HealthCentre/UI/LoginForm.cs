using System;
using System.Linq;
using System.Windows.Forms;
using HealthCentre.Enums;
using HealthCentre.Extensions;
using HealthCentre.Models;

namespace HealthCentre.UI
{
    public partial class LoginForm : TemplateForm
    {
        public LoginForm() : base("Авторизация") { }

        protected override void ConfigureUI(string title)
        {
            InitializeComponent();
            base.ConfigureUI(title);
            TableLayoutPanel.BackColor = Colors.SecondaryBackground;
            LoginButton.BackColor = Colors.Attention;
            GuestButton.BackColor = Colors.Attention;
        }

        private void Login(Group group)
        {
            var form = new MainForm(group.GetPermissions());

            Hide();
            form.ShowDialog(this);
            Show();
        }

        private void Login(User user)
        {
            var group = user.Role.ToGroup();
            var form = new MainForm(group.GetPermissions(), user.Login);

            Hide();
            form.ShowDialog(this);
            Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using (var context = new HealthCentreModel())
            {
                var currentUser = context.User.AsNoTracking()
                    .FirstOrDefault(user => user.Login == LoginTextBox.Text);

                if (currentUser is null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }

                if (currentUser.Password != PasswordTextBox.Text)
                {
                    MessageBox.Show("Введён неверный пароль");
                    return;
                }

                Login(currentUser);
            }
        }

        private void GuestButton_Click(object sender, EventArgs e)
        {
            Login(Group.Guest);
        }
    }
}
