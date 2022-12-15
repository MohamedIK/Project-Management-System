using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class TaskController : IController<Task>
    {
        public Result<Unit> Add(Task task)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureTaskAdd", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", task.Title);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@State", task.State);
            command.Parameters.AddWithValue("@Priority", (int)task.Priority);
            command.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@ProjectId", task.ProjectId);

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

        public Result<Unit> Update(Task task)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var command = new SqlCommand("ProcedureTaskUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", task.Id);
            command.Parameters.AddWithValue("@Title", task.Title);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@State", task.State);
            command.Parameters.AddWithValue("@Priority", (int)task.Priority);
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

        public Result<Unit> Delete(int taskId)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureTaskDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", taskId);

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

        public Result<Unit> AssignTask(int taskId, int developerId)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = $"UPDATE Task SET DeveloperId={developerId} WHERE Id={taskId}";
            var command = new SqlCommand(sqlQuery, connection);

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
        
        public Result<Task> Get(int taskId)
        {
            var task = new Task();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = "SELECT * FROM Task WHERE Id=" + taskId;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    task.Id = Convert.ToInt32(reader["Id"]);
                    task.Title = Convert.ToString(reader["Title"]) ?? string.Empty;
                    task.Description = Convert.ToString(reader["Description"]) ?? string.Empty;
                    task.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                    task.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString());
                    task.State = Convert.ToBoolean(reader["State"]);
                    task.Priority = (TaskPriority)Convert.ToInt32(reader["Priority"]);
                    task.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                }
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Task>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Task>.Success(task);
        }
    }
}