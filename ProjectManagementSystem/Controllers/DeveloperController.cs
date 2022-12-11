using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class DeveloperController : IController<Developer>
    {
        public Result<Unit> Add(Developer developer)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureDeveloperAdd", connection);
            command.CommandType = CommandType.StoredProcedure;

            using var hmac = new HMACSHA512();
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(developer.Password));
            var passwordSalt = hmac.Key;

            command.Parameters.AddWithValue("@FullName", developer.FullName);
            command.Parameters.AddWithValue("@Email", developer.Email);
            command.Parameters.AddWithValue("@Username", developer.Username);
            command.Parameters.AddWithValue("@PasswordHash", passwordHash);
            command.Parameters.AddWithValue("@PasswordSalt", passwordSalt);
            command.Parameters.AddWithValue("@Role", developer.Role);

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

        public Result<Unit> Update(Developer developer)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var command = new SqlCommand("ProcedureDeveloperUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", developer.Id);
            command.Parameters.AddWithValue("@FullName", developer.FullName);
            command.Parameters.AddWithValue("@Username", developer.Username);
            command.Parameters.AddWithValue("@Role", developer.Role);

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

        public Result<Unit> Delete(int developerId)
        {
            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var command = new SqlCommand("ProcedureDeveloperDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", developerId);

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

        public Result<IEnumerable<Developer>> GetAll()
        {
            var list = new List<Developer>();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            const string sqlQuery = "SELECT Name, Email, Username, Role FROM Developer";
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var developer = new Developer
                    {
                        FullName = Convert.ToString(reader["FullName"]),
                        Email = Convert.ToString(reader["Email"]),
                        Username = Convert.ToString(reader["Username"]),
                        Role = (Role)Convert.ToInt32(reader["Role"])
                    };
                    list.Add(developer);
                }
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<IEnumerable<Developer>>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<IEnumerable<Developer>>.Success(list);
        }

        public Result<IEnumerable<Bug>> GetAssignedBugs(int developerId)
        {
            var list = new List<Bug>();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery =
                "SELECT Title, Description, Status, Priority, CreatedOn, UpdatedOn FROM Bug WHERE DeveloperId=" +
                developerId;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var bug = new Bug
                    {
                        Title = Convert.ToString(reader["Title"]),
                        Description = Convert.ToString(reader["Description"]),
                        Status = (BugStatus)Convert.ToInt32(reader["Status"]),
                        Priority = (BugPriority)Convert.ToInt32(reader["Priority"]),
                        CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                        UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"])
                    };
                    list.Add(bug);
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

            return Result<IEnumerable<Bug>>.Success(list);
        }

        public Result<Developer> Login(string email, string password)
        {
            var developer = new Developer();

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var sqlQuery = "SELECT * FROM Developer WHERE [Email]=" + email;
            var command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    developer.Id = Convert.ToInt32(reader["Id"]);
                    developer.FullName = Convert.ToString(reader["FullName"]);
                    developer.Email = Convert.ToString(reader["Email"]);
                    var passwordHash = Encoding.UTF8.GetBytes(Convert.ToString(reader["PasswordHash"]) ?? string.Empty);
                    var passwordSalt = Encoding.UTF8.GetBytes(Convert.ToString(reader["passwordSalt"]) ?? string.Empty);
                    developer.Role = (Role)Convert.ToInt32(reader["Role"]);
                    developer.Password = string.Empty;

                    using var hmac = new HMACSHA512(passwordSalt);
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(developer.Password ?? string.Empty));

                    for (var i = 0; i < computedHash.Length; i++)
                        if (computedHash[i] != passwordHash[i])
                            return Result<Developer>.Failure("Invalid password");
                }
            }
            catch (Exception ex)
            {
                command.Dispose();
                connection.Close();
                return Result<Developer>.Failure(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }

            return Result<Developer>.Success(developer);
        }
    }
}