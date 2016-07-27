using Dominio.Core;
using System;

namespace Dominio.Contratos
{
    public interface IAlumnoRepositorio : IRepositorioBase<Alumno>, IDisposable
    {
    }
}
