using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Base
{
    public class PlantillaEmail
    {
        public string Asunto { get; set; }

        public string Para { get; set; }

        public string De { get; set; }

        public string CopiaContacto { get; set; }

        public string CopiaContactoOculto { get; set; }

        public string NombreUsuario { get; set; }

        public string TokenConfirmacion { get; set; }

        public string CuerpoMensaje { get; set; }

        public System.Net.Mail.MailPriority Prioridad { get; set; }
    }
}
