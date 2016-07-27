using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Base
{
    public class EnvioMail
    {
        #region Properties

        public Exception ExcepcionMail
        {
            get;
            set;
        }

        public bool Error
        {
            get { return this.ExcepcionMail != null; }
        }

        public System.Net.Mail.MailMessage Mensaje
        {
            get;
            internal set;
        }

        #endregion Properties
    }
}
