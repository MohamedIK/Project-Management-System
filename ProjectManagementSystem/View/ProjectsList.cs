using ProjectManagementSystem.Controllers;
using ProjectManagementSystem.Models;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class ProjectsList : Form
    {
        private readonly ProjectController projectController = new ProjectController();

        public ProjectsList()
        {
            InitializeComponent();

            var projectsResult = projectController.GetAll();

            if (projectsResult.IsSuccess)
            {
                projectGridView.AutoGenerateColumns = true;
                projectGridView.DataSource = projectsResult.Value;
            }
            else
                MessageBox.Show(projectsResult.Error);
        }

        private void projectGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This opens a new form that shows the bugs and tasks of the chosen project.
        }
    }
}