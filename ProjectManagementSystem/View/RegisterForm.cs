using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.View
{
    public partial class RegisterForm : Form
    {
        private readonly DeveloperController _developerController = new DeveloperController();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!passwordTextBox.Text.Equals(confirmPasswordTextBox.Text))
            {
                MessageBox.Show("Passowrd doesn't match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fullName = fullnameTextBox.Text.Trim();
            var email = emailTextBox.Text.Trim();
            var username = usernameTextBox.Text.Trim();

            if (fullName == string.Empty)
            {
                MessageBox.Show("Please, enter your full name", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (email == string.Empty)
            {
                MessageBox.Show("Please, enter your email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username == string.Empty)
            {
                MessageBox.Show("Please, enter your username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var developer = new Developer
            {
                FullName = fullName,
                Email = email,
                Username = username,
                Password = passwordTextBox.Text,
                Role = Role.Developer
            };

            var result = _developerController.Add(developer);
            if (result.IsSuccess)
            {
                var projectsListForm = new ProjectsListForm();
                projectsListForm.Show();
                Close();
            }
            else
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}