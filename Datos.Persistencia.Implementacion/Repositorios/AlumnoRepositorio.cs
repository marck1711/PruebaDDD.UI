using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorios;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    public class AlumnoRepositorio : RepositorioBase<Alumno>, IAlumnoRepositorio
    {
        public AlumnoRepositorio(IContextoUnidadDeTrabajo unidadDeTrabajo)
            : base(unidadDeTrabajo)
        {

        }
    }
}
