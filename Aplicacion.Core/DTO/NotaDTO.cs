using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class NotaDTO
    {
        #region Propiedades

        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int AlumnoId { get; set; }

        public int AsignaturaId { get; set; }

        #endregion

        #region Propiedades de Navegación

        public virtual AlumnoDTO Alumno { get; set; }

        public virtual AsignaturaDTO Asignatura { get; set; }

        #endregion
    }
}
