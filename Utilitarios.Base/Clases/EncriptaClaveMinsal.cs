using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Base
{
    public static class EncriptaClaveMinsal
    {
        #region Métodos Publicos        

        /// <summary>
        /// Método que revuelve la clave ingresada encriptada
        /// </summary>
        /// <param name="clave"></param>
        public static string EncriptaClave(string clave)
        {
            int i = 0;

            var claveEncriptar = clave.ToUpper();
            Encoding enc = Encoding.Default;

            byte[] byteArray = enc.GetBytes(claveEncriptar);     
            Byte[] passByteArr = new Byte[byteArray.Length];

            foreach (var code in byteArray) 
            {
                var bite = code + 15;

                passByteArr[i] = Convert.ToByte(bite);

                i++;
            }

            var pass = enc.GetString(passByteArr);            

            return pass;
        }        

        /// <summary>
        /// Método que revuelve la clave original desencriptada
        /// </summary>
        /// <param name="clave"></param>
        public static string DesencriptaClave(string passwordGenerado)
        {

            int i = 0;
            
            Encoding enc = Encoding.Default;

            byte[] byteArray = enc.GetBytes(passwordGenerado);
            Byte[] passByteArr = new Byte[byteArray.Length];

            foreach (var code in byteArray)
            {
                var bite = code - 15;

                passByteArr[i] = Convert.ToByte(bite);

                i++;
            }

            var pass = enc.GetString(passByteArr);

            var aa = pass.ToLower();

            return pass;
        }

        #endregion
    }
}
