using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Chapter4
{
    public class ConnectionStringClass
    {
        public void CreateConncetionStringWithSqlConnectionStringBuilder()
        {
            var sqlConnenction = new SqlConnectionStringBuilder();

            sqlConnenction.DataSource = @"(localdb)\v11.0";
            sqlConnenction.InitialCatalog = "NameDatabase";

            string connectionString = sqlConnenction.ToString();
        }

        public void UseConnectionFromExternalConfiguration()
        {
            string connectionString = "";//ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
        }

        public async Task SelectMultipleResultsSets()
        {
            string connectionString = "";//ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from people; select top 1 * from people order by lastaname", connection);

                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                await ReadQueryReTask(dataReader);
                await dataReader.NextResultAsync();
                await ReadQueryReTask(dataReader);

                dataReader.Close();
            }
        }

        private static async Task ReadQueryReTask(SqlDataReader dataReader)
        {
            while (await dataReader.ReadAsync())
            {
                var formatStringWithMiddleName = "Person ({0}) is named {1} {2} {3}";
                var formatStringWithoutMiddleName = "Person ({0}) is named {1} {2} {3}";

                if (dataReader["middlename"] == null)
                {
                    Console.WriteLine(formatStringWithMiddleName, dataReader["id"], dataReader["firstname"], dataReader["lastname"]);
                }
                else
                {
                    Console.WriteLine(formatStringWithoutMiddleName, dataReader["id"], dataReader["firstname"], dataReader["lastname"]);
                }

            }
        }

        public async Task UpdateRowsWithExecuteNonQuery()
        {
            string connectionString = "";//ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("update people set firstname = 'John'", connection);

                await connection.OpenAsync();
                int numberOfUpdateRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Update {numberOfUpdateRows} rows.");
            }
        }

        public async Task InsertRowWithParameterizedQuery()
        {
            string connectionString = "";//ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Insert into people ([FirstName],[LastName],[MiddleName]) values(@firstname, @lastname, @middlename)", connection);
                await connection.OpenAsync();

                command.Parameters.AddWithValue("@firstname", "John");
                command.Parameters.AddWithValue("@lastname", "Doe");
                command.Parameters.AddWithValue("@middlename", "Little");

                int numberOfInsetedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted {numberOfInsetedRows} rows");

            }
        }
    }
}
