using FitLife2.Models;
using FitLife2.Repository;

namespace FitLife2.Services
{
    public class MiembroService
    {
        private readonly MiembroRepository _repository;

        public MiembroService(MiembroRepository repository)
        {
            _repository = repository;
        }

        public void Registrar(string nombre, string cedula, string tel)
        {
            _repository.Add(new Miembro { NombreCompleto = nombre, Cedula = cedula, Telefono = tel });
        }

        public List<Miembro> ObtenerTodos() => _repository.GetAll();
    }
}