using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class AlumnoDTO
    {
        #region Propiedades

        public int Id { get; set; }

        [Required(ErrorMessage="oli?")]
        [StringLength(10)]
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        #endregion

        #region Propiedades de Navegación

        public virtual ICollection<AsignaturaDTO> Asignaturas { get; set; }

        public virtual ICollection<NotaDTO> Notas { get; set; }

        #endregion
    }
}
