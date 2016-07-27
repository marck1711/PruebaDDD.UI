using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class Asignatura
    {
        #region Propiedades

        public int Id { get; set; }

        public string Nombre { get; set; }

        #endregion

        #region Propiedades de Navegación

        public virtual ICollection<Alumno> Alumnos { get; set; }

        public virtual ICollection<Nota> Notas { get; set; }

        #endregion
    }
}
