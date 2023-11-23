using System.Data.SqlClient;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService()
        {
            _connectionString = "Data Source=(local);Initial Catalog=EmployeesDB;Integrated Security=true;";
        }

        public EmployeeResponseModel GetEmployeeById(int id)
        {
            var response = new EmployeeResponseModel();

            var queryString = "SELECT Id, Name, ManagerId " +
                              "FROM Employees " +
                              "WHERE Id = @idValue AND Enabled = 1; " +
                              "SELECT Id, Name, ManagerId " +
                              "FROM Employees " +
                              "WHERE Id != @idValue AND Enabled = 1";

            using (var connection =
                new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idValue", id);

                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        response.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        response.Name = reader.GetString(reader.GetOrdinal("Name"));
                        response.ManagerId = ConvertReaderResultToNullableInt(reader["ManagerId"]);
                    }

                    while (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            response.Employees.Add(new EmployeeResponseModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                ManagerId = ConvertReaderResultToNullableInt(reader["ManagerId"])
                            });
                        }
                    }

                    reader.Close();

                    return response;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void SwitchEmployeesEnabled(int id, bool enabled)
        {
            var queryString = "UPDATE Employees " +
                              "SET Enabled = @enabledValue " +
                              "WHERE Id = @idValue";

            using (var connection =
                new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idValue", id);
                command.Parameters.AddWithValue("enabledValue", enabled);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private static int? ConvertReaderResultToNullableInt(object dataReaderResult) =>
            Convert.IsDBNull(dataReaderResult) ?
            null :
            Convert.ToInt32(dataReaderResult);
    }
}
