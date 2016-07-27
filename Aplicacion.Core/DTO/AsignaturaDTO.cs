using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class AsignaturaDTO
    {
        #region Propiedades

        public int Id { get; set; }

        public string Nombre { get; set; }

        #endregion

        #region Propiedades de Navegación

        public virtual ICollection<AlumnoDTO> Alumnos { get; set; }

        public virtual ICollection<NotaDTO> Notas { get; set; }

        #endregion
    }
}
