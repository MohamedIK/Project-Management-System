using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class BugController : IController<Bug>
    {
        public Result<Unit> Add(Bug bug)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureBugAdd", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", bug.Title);
            command.Parameters.AddWithValue("@Description", bug.Description);
            command.Parameters.AddWithValue("@Status", (int)bug.Status);
            command.Parameters.AddWithValue("@Priority", (int)bug.Priority);
            command.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@ProjectId", bug.ProjectId);

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

        public Result<Unit> Update(Bug bug)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var command = new SqlCommand("ProcedureBugUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", bug.Id);
            command.Parameters.AddWithValue("@Title", bug.Title);
            command.Parameters.AddWithValue("@Description", bug.Description);
            command.Parameters.AddWithValue("@Status", bug.Status);
            command.Parameters.AddWithValue("@Priority", (int)bug.Priority);
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

        public Result<Unit> Delete(int bugId)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureBugDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", bugId);

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

        public Result<Unit> AssignBug(int bugId, int developerId)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = $"UPDATE Bug SET DeveloperId={developerId} WHERE Id={bugId}";
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

        public Result<Bug> Get(int bugId)
        {
            var bug = new Bug();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = "SELECT * FROM Bug WHERE Id=" + bugId;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    bug.Id = Convert.ToInt32(reader["Id"]);
                    bug.Title = Convert.ToString(reader["Title"]) ?? string.Empty;
                    bug.Description = Convert.ToString(reader["Description"]) ?? string.Empty;
                    bug.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                    bug.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString());
                    bug.Status = (BugStatus)Convert.ToInt32(reader["Status"]);
                    bug.Priority = (BugPriority)Convert.ToInt32(reader["Priority"]);
                    bug.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                }
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Bug>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Bug>.Success(bug);
        }
    }
}