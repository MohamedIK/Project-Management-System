﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectController : IController<Project>
    {
        public Result<Unit> Add(Project project)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureProjectAdd", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", project.Name);
            command.Parameters.AddWithValue("@Description", project.Description);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", project.EndDate);
            command.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@ManagerId", project.ManagerId);

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
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var command = new SqlCommand("ProcedureProjectUpdate", connection);
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

        public Result<Unit> Delete(int projectId)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureProjectDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", projectId);

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

        public Result<int> Count()
        {
            int number;

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            const string sqlQuery = "SELECT COUNT(*) FROM Project";
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();
                number = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<int>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<int>.Success(number);
        }

        public Result<IEnumerable<Project>> GetAll()
        {
            var list = new List<Project>();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            const string sqlQuery =
                "SELECT Project.Id, Name, Description, StartDate, EndDate, ManagerId, CreatedOn, UpdatedOn, Developer.Id ,FullName FROM Project, Developer WHERE Developer.Id=Project.ManagerId";
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var project = new Project
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]) ?? string.Empty,
                        Description = Convert.ToString(reader["Description"]) ?? string.Empty,
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString()),
                        ManagerId = Convert.ToInt32(reader["ManagerId"]),
                        ManagerName = Convert.ToString(reader["FullName"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString())
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
            var project = new Project();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = "SELECT * FROM Project WHERE Id=" + id;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    project.Id = Convert.ToInt32(reader["Id"]);
                    project.Name = Convert.ToString(reader["Name"]) ?? string.Empty;
                    project.Description = Convert.ToString(reader["Description"]) ?? string.Empty;
                    project.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    project.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    project.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                    project.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                    project.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString());
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

        public Result<IEnumerable<Task>> GetProjectTasks(int projectId)
        {
            var tasks = new List<Task>();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = "SELECT * FROM Task WHERE ProjectId=" + projectId;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var task = new Task
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = Convert.ToString(reader["Title"]),
                        Priority = (TaskPriority)Convert.ToInt32(reader["Priority"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString()),
                        Description = Convert.ToString(reader["Description"]),
                        State = Convert.ToBoolean(Convert.ToInt32(reader["State"])),
                        ProjectId = Convert.ToInt32(reader["ProjectId"])
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

        public Result<IEnumerable<Bug>> GetProjectBugs(int projectId)
        {
            var bugs = new List<Bug>();
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = "SELECT * FROM Bug WHERE ProjectId=" + projectId;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var bug = new Bug
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = Convert.ToString(reader["Title"]),
                        Priority = (BugPriority)Convert.ToInt32(reader["Priority"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString()),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString()),
                        Description = Convert.ToString(reader["Description"]),
                        Status = (BugStatus)Convert.ToInt32(reader["Status"]),
                        ProjectId = Convert.ToInt32(reader["ProjectId"])
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
    }
}