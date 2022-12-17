using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;

namespace ProjectManagementSystem.View
{
    public partial class ProjectViewForm : Form
    {
        private readonly BugController _bugController = new BugController();
        private readonly ProjectController _projectController = new ProjectController();
        private readonly int _projectId;
        private readonly TaskController _taskController = new TaskController();

        public ProjectViewForm()
        {
            InitializeComponent();
        }

        public ProjectViewForm(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;

            var bugsResult = _projectController.GetProjectBugs(projectId);
            if (bugsResult.IsSuccess)
            {
                bugsGridView.AutoGenerateColumns = true;
                bugsGridView.DataSource = bugsResult.Value;
            }
            else
            {
                MessageBox.Show(bugsResult.Error);
            }

            var tasksResult = _projectController.GetProjectTasks(projectId);
            if (tasksResult.IsSuccess)
            {
                tasksGridView.AutoGenerateColumns = true;
                tasksGridView.DataSource = tasksResult.Value;
            }
            else
            {
                MessageBox.Show(tasksResult.Error);
            }
        }

        private void bugsGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // To be implemented
            throw new NotImplementedException();
        }

        private void tasksGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // To be implemented
            throw new NotImplementedException();
        }

        private void addBugToolStripButton_Click(object sender, EventArgs e)
        {
            var addUpdateBugForm = new AddUpdateBugForm(_projectId);
            addUpdateBugForm.Show();
        }

        private void editBugToolStripButton_Click(object sender, EventArgs e)
        {
            var index = (int)bugsGridView.CurrentRow.Cells[0].Value;
            if (index > 0)
            {
                var addUpdateBugForm = new AddUpdateBugForm(_projectId, index, true);
                addUpdateBugForm.Show();
            }
            else
            {
                MessageBox.Show("Please, select a bug to edit");
            }
        }

        private void deleteBugToolStripButton_Click(object sender, EventArgs e)
        {
            var index = (int)bugsGridView.CurrentRow.Cells[0].Value;
            if (index > 0)
            {
                var result = _bugController.Delete(index);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Bug has been deleted successfully");
                    refreshBugList(_projectId);
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please, select a bug");
            }
        }

        private void addTaskToolStripButton_Click(object sender, EventArgs e)
        {
            var addUpdateTaskForm = new AddUpdateTaskForm(_projectId);
            addUpdateTaskForm.Show();
        }

        private void editTaskToolStripButton_Click(object sender, EventArgs e)
        {
            var index = (int)tasksGridView.CurrentRow.Cells[0].Value;
            if (index > 0)
            {
                var addUpdateTaskForm = new AddUpdateTaskForm(_projectId, index, true);
                addUpdateTaskForm.Show();
            }
            else
            {
                MessageBox.Show("Please, select a task to edit");
            }
        }

        private void deleteTaskToolStripButton_Click(object sender, EventArgs e)
        {
            var index = (int)tasksGridView.CurrentRow.Cells[0].Value;
            if (index > 0)
            {
                var result = _taskController.Delete(index);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Task has been deleted successfully");
                    refreshTaskList(_projectId);
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please, select a _task");
            }
        }

        private void refreshBugList(int projectId)
        {
            var result = _projectController.GetProjectBugs(projectId);
            if (result.IsSuccess)
                bugsGridView.DataSource = result.Value;
            else
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK);
        }

        private void refreshTaskList(int projectId)
        {
            var result = _projectController.GetProjectTasks(projectId);
            if (result.IsSuccess)
                tasksGridView.DataSource = result.Value;
            else
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK);
        }

        private void refreshBugsToolStripButton_Click(object sender, EventArgs e)
        {
            refreshBugList(_projectId);
        }

        private void refreshTasksToolStripButton_Click(object sender, EventArgs e)
        {
            refreshTaskList(_projectId);
        }
    }
}