using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

namespace Utilitarios.Base
{
    /// <summary>
    /// Clase contenedora de aplicativos funcionales de carácter utilitario
    /// </summary>
    public static class Utilitario
    {
        #region Miembros

        /// <summary>
        /// Define culturización para aplicar utilidades
        /// </summary>
        private static readonly CultureInfo Cultura = new CultureInfo("es-CL");

        #endregion

        #region Métodos

        #region Métodos Públicos

        #region Rut

        /// <summary>
        /// Valida Rut Chileno
        /// </summary>
        /// <param name="rut">Rut a validar</param>
        /// <returns>Indicador de validez de Rut</returns>
        public static bool EsValidoRut(string rut)
        {
            try
            {
                EliminaCeros(ref rut);
                rut = rut.Replace(".", "").Replace("-", "");
                string digitoVerificador = rut.Substring(rut.Length - 1, 1);
                int rutAValidar = Convert.ToInt32(rut.Substring(0, rut.Length - 1));

                if (ObtenerDigitoVerificador(rutAValidar).Equals(digitoVerificador))
                    return true;
                return false;
            }
            catch
            {
                throw new Exception("No es posible validar como Rut la cadena evaluada");
            }
        }

        /// <summary>
        /// Formatea Rut agregándole puntos y guión
        /// </summary>
        /// <param name="rut">Rut a formatear</param>
        /// <returns>Rut formateado</returns>
        public static string FormatearRut(string rut)
        {
            string rutFormateado = string.Empty;

            if (EsValidoRut(rut))
            {
                EliminaCeros(ref rut);

                if (rut.Length > 1 && rut.Length <= 12)
                {
                    string ultimoDigito = rut.Substring(rut.Length - 1, 1);
                    bool terminaEnK = (ultimoDigito.ToUpper().Equals("K"));
                    rut = rut.Replace(".", "").Replace("-", "");
                    string digitoVerificador = ultimoDigito;

                    if (!terminaEnK)
                        rut = rut.Substring(0, rut.Length - 1);
                    else
                        digitoVerificador = "K";

                    rutFormateado = (string.Format("{0}-{1}", FormatearMillones(rut), digitoVerificador));
                }
                else
                {
                    throw new FormatException("El formato del rut ingresado, no es válido");
                }
            }

            return rutFormateado;
        }

        /// <summary>
        /// Elimina los ceros al principio de la cadena
        /// </summary>
        /// <param name="cadena">Cadena para eliminación de ceros</param>
        /// <returns>Cadena sin ceros al principio</returns>
        public static void EliminaCeros(ref string cadena)
        {
            while (true)
            {
                cadena = cadena.Replace(".", "").Replace("-", "");
                if (!cadena.Substring(0, 1).Equals("0")) return;
                cadena = cadena.Substring(1, cadena.Length - 1);
            }
        }

        #endregion

        #region Correo Electrónico

        /// <summary>
        /// Envía correo electrónico con prioridad normal
        /// </summary>
        /// <param name="correoOrigen">Correo de quien envía el correo electrónico</param>
        /// <param name="destinatario">Destinatario único de correo electrónico</param>
        /// <param name="copia">Destinatario de copia de correo electrónico</param>
        /// <param name="asunto">Asunto del correo electrónico</param>
        /// <param name="indicadorFormatoHtml">Indica si el correo electrónico posee formato HTML</param>
        /// <param name="cuerpoCorreo">Cuerpo del correo electrónico</param>
        /// <param name="servidorCorreo">Nombre o IP del host del cliente correo electrónico a utilizar</param>
        /// <param name="puerto">Puerto del host (Cliente de correo electrónico)</param>
        public static void EnviarCorreoElectronico(string correoOrigen, string destinatario, string copia, string asunto, bool indicadorFormatoHtml, string cuerpoCorreo, string servidorCorreo, int puerto)
        {
            EnviarCorreoElectronico(correoOrigen, new[] { destinatario }, new[] { copia }, asunto, indicadorFormatoHtml, cuerpoCorreo, MailPriority.Normal, servidorCorreo, puerto, false, false, false, null);
        }

        /// <summary>
        /// Envía correo electrónico con prioridad normal
        /// </summary>
        /// <param name="correoOrigen">Correo de quien envía el correo electrónico</param>
        /// <param name="destinatario">Destinatario único de correo electrónico</param>
        /// <param name="asunto">Asunto del correo electrónico</param>
        /// <param name="cuerpoCorreo">Cuerpo del correo electrónico (Por defecto Formato: Text)</param>
        /// <param name="servidorCorreo">Nombre o IP del host del cliente correo electrónico a utilizar</param>
        /// <param name="puerto">Puerto del host (Cliente de correo electrónico)</param>
        public static void EnviarCorreoElectronico(string correoOrigen, string destinatario, string asunto, string cuerpoCorreo, string servidorCorreo, int puerto)
        {
            EnviarCorreoElectronico(correoOrigen, new[] { destinatario }, new string[] { }, asunto, false, cuerpoCorreo, MailPriority.Normal, servidorCorreo, puerto, false, false, false, null);
        }

        /// <summary>
        /// Envía correo electrónico con prioridad normal
        /// </summary>
        /// <param name="correoOrigen">Correo de quien envía el correo electrónico</param>
        /// <param name="destinatarios">Arreglo contenedor de correos de destinatarios</param>
        /// <param name="copias">Arreglo de copias de correos de destinatarios</param>
        /// <param name="asunto">Asunto del correo electrónico</param>
        /// <param name="indicadorFormatoHtml">Indica si el correo electrónico posee formato HTML</param>
        /// <param name="cuerpoCorreo">Cuerpo del correo electrónico</param>
        /// <param name="servidorCorreo">Nombre o IP del host del cliente correo electrónico a utilizar</param>
        /// <param name="puerto">Puerto del host (Cliente de correo electrónico)</param>
        public static void EnviarCorreoElectronico(string correoOrigen, string[] destinatarios, string[] copias,
                                            string asunto, bool indicadorFormatoHtml, string cuerpoCorreo,
                                            string servidorCorreo, int puerto)
        {
            EnviarCorreoElectronico(correoOrigen, destinatarios, copias, asunto, indicadorFormatoHtml, cuerpoCorreo, MailPriority.Normal, servidorCorreo, puerto, false, false, false, null);
        }

        /// <summary>
        /// Envía correo electrónico
        /// </summary>
        /// <param name="correoOrigen">Correo de quien envía el correo electrónico</param>
        /// <param name="destinatarios">Arreglo contenedor de correos de destinatarios</param>
        /// <param name="copias">Arreglo de copias de correos de destinatarios</param>
        /// <param name="asunto">Asunto del correo electrónico</param>
        /// <param name="indicadorFormatoHtml">Indica si el correo electrónico posee formato HTML</param>
        /// <param name="cuerpoCorreo">Cuerpo del correo electrónico</param>
        /// <param name="prioridad">Prioridad de envío del correo electrónico</param>
        /// <param name="servidorCorreo">Nombre o IP del host del cliente correo electrónico a utilizar</param>
        /// <param name="puerto">Puerto del host (Cliente de correo electrónico)</param>
        /// <param name="habilitarSSL">Habilita protocolo de capa de conexión segura (El host cliente debe soportarlo)</param>
        /// <param name="requiereCredenciales">Indica si el envío de correo electrónico, requiere credenciales de autenticación</param>
        /// <param name="usarCredencialesPorDefecto">En caso de requerir credenciales, indica si utiliza las existentes por defecto</param>
        /// <param name="credenciales">Credenciales (Usuario y Contraseña) para acceder al host de envío de correo electrónico (En caso de no requerir, enviar null)</param>
        public static void EnviarCorreoElectronico(string correoOrigen, string[] destinatarios, string[] copias,
                                            string asunto, bool indicadorFormatoHtml, string cuerpoCorreo,
                                            MailPriority prioridad, string servidorCorreo, int puerto,
                                            bool habilitarSSL, bool requiereCredenciales, bool usarCredencialesPorDefecto,
                                            NetworkCredential credenciales)
        {
            MailMessage mensaje = null;
            SmtpClient cliente = null;

            try
            {
                if (!destinatarios.Any())
                    throw new IndexOutOfRangeException("Para enviar un correo electrónico, es necesario definir al menos un destinatario");

                mensaje = new MailMessage();
                cliente = new SmtpClient();

                foreach (var destinatario in destinatarios)
                {
                    mensaje.To.Add(new MailAddress(destinatario));
                }

                if (copias.Any())
                {
                    foreach (var copia in copias)
                    {
                        mensaje.CC.Add(new MailAddress(copia));
                    }
                }

                mensaje.From = new MailAddress(correoOrigen);
                mensaje.Subject = asunto;
                mensaje.IsBodyHtml = indicadorFormatoHtml;
                mensaje.Body = cuerpoCorreo;
                mensaje.Priority = prioridad;

                cliente.EnableSsl = habilitarSSL;
                cliente.Host = servidorCorreo;
                cliente.Port = puerto;

                if (requiereCredenciales)
                {
                    if (usarCredencialesPorDefecto)
                    {
                        cliente.UseDefaultCredentials = true;
                    }
                    else
                    {
                        cliente.UseDefaultCredentials = false;
                        cliente.Credentials = credenciales;
                    }
                }

                cliente.ServicePoint.MaxIdleTime = 1;
                cliente.Send(mensaje);
            }
            finally
            {
                if (mensaje != null) mensaje.Dispose();
                if (cliente != null) cliente.Dispose();
            }
        }

        /// <summary>
        /// Método que envía correo electrónico
        /// </summary>
        /// <param name="solicitud">Detalle de solicitud</param>
        /// <returns>Detalle de ejecución de envío de correo electrónico</returns>
        public static void EnviarEmail(PlantillaEmail email, bool habilitarSsl = false, bool poseeCuerpoHtml = false)
        {
            var mensaje = new MailMessage(
                email.De,
                email.Para,
                email.Asunto,
                email.CuerpoMensaje
                );

            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.IsBodyHtml = poseeCuerpoHtml;

            if (!string.IsNullOrEmpty(email.CopiaContacto))
            {
                mensaje.CC.Add(email.CopiaContacto);
            }

            if (!string.IsNullOrEmpty(email.CopiaContactoOculto))
            {
                mensaje.Bcc.Add(email.CopiaContactoOculto);
            }

            SmtpClient mailClient = new SmtpClient();

            try
            {
                mailClient.EnableSsl = habilitarSsl;
                mailClient.Send(mensaje);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Varios

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string ipEntry = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipEntry = ip.ToString();
                }
            }
            return ipEntry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valorEnumerador"></param>
        /// <returns></returns>
        public static string ObtenerDefinicionEnumerador(Enum valorEnumerador)
        {
            FieldInfo infoCampo = valorEnumerador.GetType().GetField(valorEnumerador.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])infoCampo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (atributos != null && atributos.Length > 0)
                return atributos[0].Description;
            else
                return valorEnumerador.ToString();
        }

        /// <summary>
        /// Genera un código único numérico, a partir de un Guid
        /// </summary>
        /// <param name="identificador">Guid a transformar</param>
        /// <returns></returns>
        public static long GenerarCodigoCorto(Guid identificador)
        {
            byte[] buffer = identificador.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        /// <summary>
        /// Genera password automático a partir de una longitud definida
        /// </summary>
        /// <param name="largo">8</param>
        /// <returns>Password generado</returns>
        public static string CrearContrasena(int largo)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string res = string.Empty;
            Random rnd = new Random();
            while (0 < largo--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }

        /// <summary>
        /// Obtiene el nombre del método actual de ejecución
        /// </summary>
        /// <returns>Nombre del método</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        #endregion

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Formatea Rut agregando puntos y guión
        /// </summary>
        /// <param name="rutAFormatear">Cadena contenedora de rut a formatear</param>
        /// <returns>Rut Formateado</returns>
        private static string FormatearMillones(string rutAFormatear)
        {
            string rut = string.Empty;
            for (int j = 0, i = rutAFormatear.Length - 1; i >= 0; i--, j++)
            {
                rut = rutAFormatear.Substring(i, 1) + ((j > 0) && (j % 3 == 0) ? "." : "") + rut;
            }
            return rut;
        }

        /// <summary>
        /// Obtiene dígito verificador de Rut Chileno
        /// </summary>
        /// <param name="rut">Rut a validar</param>
        /// <returns>Dígito verificar de Rut</returns>
        private static string ObtenerDigitoVerificador(int rut)
        {
            int contador = 2;
            int acumulador = 0;

            while (rut != 0)
            {
                int multiplo = (rut % 10) * contador;
                acumulador = acumulador + multiplo;
                rut = rut / 10;
                contador = contador + 1;
                if (contador == 8)
                {
                    contador = 2;
                }
            }

            int digito = 11 - (acumulador % 11);
            string rutDigito = digito.ToString(CultureInfo.InvariantCulture).Trim();

            if (digito == 10)
                rutDigito = "K";
            else if (digito == 11)
                rutDigito = "0";

            return rutDigito;
        }

        #endregion

        #endregion
    }
}
