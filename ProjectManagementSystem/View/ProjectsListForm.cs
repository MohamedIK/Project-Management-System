using System;
using System.Windows.Forms;
using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.View;

namespace ProjectManagementSystem
{
    public partial class ProjectsListForm : Form
    {
        private readonly ProjectController _projectController = new ProjectController();

        public ProjectsListForm()
        {
            InitializeComponent();

            var projectsResult = _projectController.GetAll();

            if (projectsResult.IsSuccess)
            {
                projectGridView.AutoGenerateColumns = true;
                projectGridView.DataSource = projectsResult.Value;
            }
            else
            {
                MessageBox.Show(projectsResult.Error);
            }
        }

        private void projectGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This opens a new form that shows the bugs and tasks of the chosen project.
            var index = (int)projectGridView.CurrentRow.Cells[0].Value;
            var projectViewForm = new ProjectViewForm(index);
            projectViewForm.Show();
        }

        private void addProjectToolStripButton_Click(object sender, EventArgs e)
        {
            var addUpdateProjectForm = new AddUpdateProjectForm();
            addUpdateProjectForm.Show();
        }

        private void editProjectToolStripButton_Click(object sender, EventArgs e)
        {
            var index = (int)projectGridView.CurrentRow.Cells[0].Value;
            if (index > 0)
            {
                var addUpdateProjectForm = new AddUpdateProjectForm(index, true);
                addUpdateProjectForm.Show();
            }
            else
            {
                MessageBox.Show("Please, select a project to edit");
            }
        }

        private void deleteProjectToolStripButton_Click(object sender, EventArgs e)
        {
            var index = (int)projectGridView.CurrentRow.Cells[0].Value;
            if (index > 0)
            {
                var result = _projectController.Delete(index);
                if (result.IsSuccess)
                {
                    MessageBox.Show("Project has been deleted successfully");
                    refresh();
                }
                else
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please, select a project");
            }
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            var result = _projectController.GetAll();
            if (result.IsSuccess)
                projectGridView.DataSource = result.Value;
            else
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK);
        }
    }
}