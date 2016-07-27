using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class Alumno
    {
        #region Propiedades

        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        #endregion

        #region Propiedades de Navegación

        public virtual ICollection<Asignatura> Asignaturas { get; set; }

        public virtual ICollection<Nota> Notas { get; set; }

        #endregion
    }
}
