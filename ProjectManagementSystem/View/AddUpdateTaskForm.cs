using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.View
{
    public partial class AddUpdateTaskForm : Form
    {
        private readonly bool _isUpdate;
        private readonly int _projectId;
        private readonly Task _task;
        private readonly TaskController _taskController = new TaskController();
        private readonly int _taskId = -1;

        public AddUpdateTaskForm(int projectId, int taskId = -1, bool isUpdate = false)
        {
            InitializeComponent();

            _projectId = projectId;
            _taskId = taskId;
            _isUpdate = isUpdate;

            if (isUpdate)
            {
                Text = "Update Task";
                addButton.Text = "Update";

                var result = _taskController.Get(_taskId);
                if (result.IsSuccess)
                {
                    _task = result.Value;
                    titleTextBox.Text = _task.Title;
                    descriptionTextBox.Text = _task.Description;
                    priorityComboBox.SelectedIndex = (int)_task.Priority;
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

            if (_isUpdate)
            {
                var task = new Task
                {
                    Id = _task.Id,
                    Title = titleTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    Priority = (TaskPriority)priorityComboBox.SelectedIndex,
                    ProjectId = _projectId,
                    CreatedOn = _task.CreatedOn,
                    UpdatedOn = DateTime.Now
                };
                var result = _taskController.Update(task);
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
                var task = new Task
                {
                    Title = titleTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    Priority = (TaskPriority)priorityComboBox.SelectedIndex,
                    ProjectId = _projectId
                };

                var result = _taskController.Add(task);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Task has been added successfully!");
                    Hide();
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void priorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}