using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Core
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        /// <summary>
        /// Confirma todos los cambios existentes en el contenedor (Commit)
        /// </summary>
        ///<remarks>
        /// Commit sobre la base de datos
        /// Si la entidad posee propiedades reparadas y ocurre algún problema de persistencia optimista,  
        /// se levantará una excepción
        ///</remarks>
        void Confirmar();

        /// <summary>
        /// Confirma todos los cambios existentes en el contenedor (Commit)
        /// </summary>
        ///<remarks>
        /// Commit sobre la base de datos
        /// Si hay un problema de concurrencia "refrescará" los datos del cliente. Aproximación "Client wins"
        ///</remarks>
        void ConfirmarYRefrescarCambios();

        /// <summary>
        /// Rollback de los cambios que se han producido en la Unit of Work y que están siendo observados por ella
        /// </summary>
        void DeshacerCambios();
    }
}
