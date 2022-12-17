using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.View;

namespace ProjectManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly DeveloperController _developerController = new DeveloperController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text.Trim();
            var password = passwordTextBox.Text;

            var result = _developerController.Login(email, password);

            if (result.IsSuccess)
            {
                var projectListForm = new ProjectsListForm();
                projectListForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(result.Error, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            Hide();
        }
    }
}