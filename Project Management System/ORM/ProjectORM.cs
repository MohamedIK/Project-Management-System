using Project_Management_System.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

#nullable disable

namespace Project_Management_System.ORM
{
    public class ProjectORM : IORM<Project>
    {
        public void Add(Project project)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using var command = new SqlCommand("Procedure_Project_Add", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@Description", project.Description);
                command.Parameters.AddWithValue("@StartDate", project.StartDate);
                command.Parameters.AddWithValue("@EndDate", project.EndDate);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Project project)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using var command = new SqlCommand("Procedure_Project_Update", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", project.Id);
                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@Description", project.Description);
                command.Parameters.AddWithValue("@StartDate", project.StartDate);
                command.Parameters.AddWithValue("@EndDate", project.EndDate);
                command.Parameters.AddWithValue("@ManagerId", project.ManagerId);
                command.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<Project> GetAll()
        {
            var list = new List<Project>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using var command = new SqlCommand("Procedure_Project_GetAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var project = new Project()
                    {
                        // Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString()),
                        ManagerId = Convert.ToInt32(reader["ManagerId"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString()),
                    };
                    list.Add(project);
                }
                connection.Close();
            }
            return list;
        }

        public Project Get(int id)
        {
            Project project = new Project();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string sqlQuery = "SELECT * FROM Project WHERE Id=" + id;
                using var command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    project.Id = Convert.ToInt32(reader["Id"]);
                    project.Name = Convert.ToString(reader["Name"]);
                    project.Description = Convert.ToString(reader["Description"]);
                    project.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    project.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    project.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                    project.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                    project.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString());
                    project.State = Convert.ToBoolean(reader["State"]);
                }

                connection.Close();
            }
            return project;
        }

        public IEnumerable<Models.Task> GetProjectTasks(int id)
        {
            var tasks = new List<Models.Task>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string sqlQuery = "SELECT * FROM Task WHERE ProjectId=" + id;
                using var command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var task = new Models.Task()
                    {
                        Title = Convert.ToString(reader["Title"]),
                        Priority = (Models.TaskPriority)Convert.ToInt32(reader["Priority"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString()),
                        Description = Convert.ToString(reader["Description"]),
                        State = Convert.ToBoolean(reader["State"]),
                    };
                    tasks.Add(task);
                }

                connection.Close();
            }
            return tasks;
        }

        public IEnumerable<Bug> GetProjectBugs(int id)
        {
            var bugs = new List<Bug>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string sqlQuery = "SELECT * FROM Bug WHERE ProjectId=" + id;
                using var command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var bug = new Bug()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = Convert.ToString(reader["Title"]),
                        Priority = (BugPriority)Convert.ToInt32(reader["Priority"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString()),
                        Description = Convert.ToString(reader["Description"]),
                        Status = (BugStatus)Convert.ToInt32(reader["Status"]),
                    };
                    bugs.Add(bug);
                }

                connection.Close();
            }
            return bugs;
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using var command = new SqlCommand("Procedure_Project_Delete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
