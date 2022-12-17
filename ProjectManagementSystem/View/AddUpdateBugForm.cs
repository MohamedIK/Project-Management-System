using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.View
{
    public partial class AddUpdateBugForm : Form
    {
        private readonly Bug _bug;
        private readonly BugController _bugController = new BugController();
        private readonly int _bugId;
        private readonly bool _isUpdate;
        private readonly int _projectId;

        public AddUpdateBugForm(int projectId, int bugId = -1, bool isUpdate = false)
        {
            InitializeComponent();

            _projectId = projectId;
            _bugId = bugId;
            _isUpdate = isUpdate;

            if (isUpdate)
            {
                Text = "Update Bug";
                addButton.Text = "Update";

                var result = _bugController.Get(_bugId);
                if (result.IsSuccess)
                {
                    _bug = result.Value;
                    titleTextBox.Text = _bug.Title;
                    descriptionTextBox.Text = _bug.Description;
                    priorityComboBox.SelectedIndex = (int)_bug.Priority;
                    statusComboBox.SelectedIndex = (int)_bug.Status;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please, enter a title");
                return;
            }

            if (priorityComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please, choose a priority");
                return;
            }

            if (statusComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please, choose a bug status");
                return;
            }

            if (_isUpdate)
            {
                var bug = new Bug
                {
                    Id = _bug.Id,
                    Title = titleTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    Priority = (BugPriority)priorityComboBox.SelectedIndex,
                    Status = (BugStatus)statusComboBox.SelectedIndex,
                    ProjectId = _projectId,
                    CreatedOn = _bug.CreatedOn,
                    UpdatedOn = DateTime.Now
                };
                var result = _bugController.Update(bug);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Task has been updated successfully!");
                    Hide();
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var bug = new Bug
                {
                    Title = titleTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    Priority = (BugPriority)priorityComboBox.SelectedIndex,
                    Status = (BugStatus)statusComboBox.SelectedIndex,
                    ProjectId = _projectId
                };

                var result = _bugController.Add(bug);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Bug has been added successfully!");
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