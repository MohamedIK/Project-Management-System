using Project_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_Management_System.ORM
{
    public class ProjectORM : IORM<Project>
    {
        public Result<Unit> Add(Project project)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("Procedure_Project_Add", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", project.Name);
            command.Parameters.AddWithValue("@Description", project.Description);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", project.EndDate);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Unit>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Unit>.Success(Unit.Value);
        }

        public Result<Unit> Update(Project project)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var command = new SqlCommand("Procedure_Project_Update", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", project.Id);
            command.Parameters.AddWithValue("@Name", project.Name);
            command.Parameters.AddWithValue("@Description", project.Description);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", project.EndDate);
            command.Parameters.AddWithValue("@ManagerId", project.ManagerId);
            command.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Unit>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Unit>.Success(Unit.Value);
        }

        public Result<IEnumerable<Project>> GetAll()
        {
            var list = new List<Project>();

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("Procedure_Project_GetAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
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
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<IEnumerable<Project>>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<IEnumerable<Project>>.Success(list);
        }

        public Result<Project> Get(int id)
        {
            Project project = new Project();

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            string sqlQuery = "SELECT * FROM Project WHERE Id=" + id;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
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
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Project>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Project>.Success(project);
        }

        public Result<IEnumerable<Task>> GetProjectTasks(int id)
        {
            var tasks = new List<Task>();

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            string sqlQuery = "SELECT * FROM Task WHERE ProjectId=" + id;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var task = new Task()
                    {
                        Title = Convert.ToString(reader["Title"]),
                        Priority = (TaskPriority)Convert.ToInt32(reader["Priority"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString()),
                        Description = Convert.ToString(reader["Description"]),
                        State = Convert.ToBoolean(reader["State"]),
                    };
                    tasks.Add(task);
                }
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<IEnumerable<Task>>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<IEnumerable<Task>>.Success(tasks);
        }

        public Result<IEnumerable<Bug>> GetProjectBugs(int id)
        {
            var bugs = new List<Bug>();
            var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            string sqlQuery = "SELECT * FROM Bug WHERE ProjectId=" + id;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
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

            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<IEnumerable<Bug>>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<IEnumerable<Bug>>.Success(bugs);
        }

        public Result<Unit> Delete(int id)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("Procedure_Project_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Unit>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }


            return Result<Unit>.Success(Unit.Value);
        }
    }
}
