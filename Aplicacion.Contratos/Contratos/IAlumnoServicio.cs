using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface IAlumnoServicio : IDisposable
    {
        AlumnoDTO Crear(AlumnoDTO entidadACrear);

        void Eliminar(int idAEliminar);

        void Actualizar(AlumnoDTO entidadAActualizar);

        List<AlumnoDTO> Listar();
    }
}
