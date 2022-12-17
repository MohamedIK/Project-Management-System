using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.View
{
    public partial class AddUpdateProjectForm : Form
    {
        private readonly DeveloperController _developerController = new DeveloperController();
        private readonly bool _isUpdate;
        private readonly Project _project;
        private readonly ProjectController _projectController = new ProjectController();
        private readonly int _projectId = -1;

        public AddUpdateProjectForm(int projectId = -1, bool isUpdate = false)
        {
            InitializeComponent();
            _projectId = projectId;
            _isUpdate = isUpdate;

            var allDeveloperResult = _developerController.GetAll();
            if (allDeveloperResult.IsSuccess)
                foreach (var item in allDeveloperResult.Value)
                    managerComboBox.Items.Add(item.FullName);
            else
                MessageBox.Show(allDeveloperResult.Error);

            if (_isUpdate)
            {
                Text = "Update Project";
                addButton.Text = "Update";

                var projectResult = _projectController.Get(_projectId);
                if (projectResult.IsSuccess)
                {
                    _project = projectResult.Value;
                    nameTextBox.Text = _project.Name;
                    descriptionTextBox.Text = _project.Description;
                    dateTimePicker1.Value = _project.StartDate.Date;
                    dateTimePicker2.Value = _project.EndDate.Date;
                    managerComboBox.SelectedIndex = Convert.ToInt32(_project.ManagerId) - 1;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please, enter a project name");
                return;
            }

            if (managerComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please, choose a manager");
                return;
            }

            if (_isUpdate)
            {
                var project = new Project
                {
                    Id = _project.Id,
                    Name = nameTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    StartDate = dateTimePicker1.Value.Date,
                    EndDate = dateTimePicker2.Value.Date,
                    CreatedOn = _project.CreatedOn,
                    UpdatedOn = DateTime.Now,
                    ManagerId = managerComboBox.SelectedIndex + 1
                };
                var result = _projectController.Update(project);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Project has been updated successfully!");
                    Hide();
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var project = new Project
                {
                    Name = nameTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    StartDate = dateTimePicker1.Value,
                    EndDate = dateTimePicker1.Value,
                    ManagerId = managerComboBox.SelectedIndex + 1
                };

                var result = _projectController.Add(project);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Project has been added successfully!");
                    Hide();
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}