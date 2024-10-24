
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace Infrastruture.Database
{
    public class SqlDriver
    {
        private readonly string connectionString;
        public SqlDriver()
        {
            string conn = Environment.GetEnvironmentVariable("CONNECTION_STRING", EnvironmentVariableTarget.Process);
            if (string.IsNullOrEmpty(conn))
            {
                JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
                conn = jAppSettings["connLocal"].ToString();
            }

            this.connectionString = conn;
        }

        public async Task Save<T>(T obj)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            var queryString = MapTable.BuilderInsert(obj);
            SqlCommand command = new SqlCommand(queryString, connection);
            var parameters = MapTable.BuilderParameters(obj);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            command.Connection.Open();

            MapTable.SetIdOfEntity(obj, await command.ExecuteScalarAsync());
            await connection.CloseAsync();
        }
    }
}
