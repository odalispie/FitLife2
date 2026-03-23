using FitLife2.Database;
using FitLife2.Models;
using Microsoft.Data.Sqlite;

namespace FitLife2.Repository
{
    public class MiembroRepository
    {
        private readonly DatabaseConfig _dbConfig;

        public MiembroRepository(DatabaseConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public void Add(Miembro miembro)
        {
            using var connection = _dbConfig.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Miembro (nombre_completo, cedula, telefono) VALUES ($nombre, $cedula, $tel)";
            command.Parameters.AddWithValue("$nombre", miembro.NombreCompleto);
            command.Parameters.AddWithValue("$cedula", miembro.Cedula);
            command.Parameters.AddWithValue("$tel", miembro.Telefono);
            command.ExecuteNonQuery();
        }

        public List<Miembro> GetAll()
        {
            var lista = new List<Miembro>();
            using var connection = _dbConfig.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT id, nombre_completo, cedula, telefono FROM Miembro";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Miembro
                {
                    Id = reader.GetInt32(0),
                    NombreCompleto = reader.GetString(1),
                    Cedula = reader.GetString(2),
                    Telefono = reader.GetString(3)
                });
            }
            return lista;
        }
    }
}