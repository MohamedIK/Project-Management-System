using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class CommentController
    {
        public Result<Comment> GetAll(int bugId)
        {
            var comment = new Comment();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery =
                $"SELECT Comment.*, FullName FROM Comment,Developer WHERE BugId={bugId} AND AuthorId=Developer.Id";
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    comment.Id = Convert.ToInt32(reader["Id"]);
                    comment.Content = Convert.ToString(reader["Content"]) ?? string.Empty;
                    comment.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                    comment.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                    comment.AuthorName = Convert.ToString(reader["FullName"]);
                }
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Comment>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Comment>.Success(comment);
        }

        public Result<Unit> Add(Comment comment)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureCommentAdd", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Content", comment.Content);
            command.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            command.Parameters.AddWithValue("@AuthorId", comment.AuthorId);

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

            var command = new SqlCommand("ProcedureCommentDelete", connection);
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
    }
}