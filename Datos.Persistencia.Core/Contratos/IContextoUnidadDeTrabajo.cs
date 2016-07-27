using Dominio.Core;
using System.Data.Entity;

namespace Datos.Persistencia.Core
{
    public interface IContextoUnidadDeTrabajo : IEntityFrameworkUnidadDeTrabajo
    {
        /// <summary>
        /// Entidades
        /// </summary>
        IDbSet<Alumno> Alumnos { get; }
        IDbSet<Asignatura> Asignaturas { get; }
        IDbSet<Nota> Notas { get; }
    }
}
