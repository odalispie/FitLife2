using Microsoft.Data.Sqlite;

namespace FitLife2.Database
{
    public class DatabaseConfig
    {
        private readonly string _connectionString = "Data Source=gym_fitlife.db";

        public SqliteConnection GetConnection() => new SqliteConnection(_connectionString);

        public void Initialize()
        {
            using var connection = GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Miembro (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nombre_completo TEXT NOT NULL,
                    cedula TEXT NOT NULL UNIQUE,
                    telefono TEXT NOT NULL
                );";
            command.ExecuteNonQuery();
        }
    }
}