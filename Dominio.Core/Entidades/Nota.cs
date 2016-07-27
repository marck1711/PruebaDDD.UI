using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class Nota
    {
        #region Propiedades

        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int AlumnoId { get; set; }

        public int AsignaturaId { get; set; }

        #endregion

        #region Propiedades de Navegación

        public virtual Alumno Alumno { get; set; }

        public virtual Asignatura Asignatura { get; set; }

        #endregion
    }
}
