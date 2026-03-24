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

        // --- ESTOS SON LOS QUE FALTABAN ---

        public Miembro BuscarPorCedula(string cedula)
        {
            return _repository.GetAll().FirstOrDefault(m => m.Cedula == cedula);
        }

        public void ActualizarTelefono(string cedula, string nuevoTel)
        {
            var miembro = BuscarPorCedula(cedula);
            if (miembro != null)
            {
                miembro.Telefono = nuevoTel;
                _repository.Update(miembro); 
            }
        }

        public void Eliminar(string cedula)
        {
            var miembro = BuscarPorCedula(cedula);
            if (miembro != null)
            {
                _repository.Delete(miembro.Id); 
            }
        }
    }
}
