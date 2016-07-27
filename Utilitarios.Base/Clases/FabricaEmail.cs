using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Utilitarios.Base
{
    public static class FabricaEmail
    {
        public static MailMessage ObtenerEmailParaEnvio(dynamic objetoCargaEmail,
                                                        string templateEmail,
                                                        string emailDestinatario,
                                                        string asuntoEmail,
                                                        string emailOrigen)
        {
            var rutaTemplate = ConfigurationManager.AppSettings[templateEmail];
            string correoOrigen = emailOrigen;

            var cuerpo = "cuerpo"/*IntegradorTemplate.ObtenerCuerpoMensaje(
                rutaTemplate,
                objetoCargaEmail)*/;

            return new MailMessage(
                    correoOrigen,
                    emailDestinatario,
                    asuntoEmail,
                    cuerpo);
        }

        /// <summary>
        /// Método que crea un email para enviar aviso de una operacion en procedimientos
        /// </summary>
        /// <param name="numeroFolio"></param>
        /// <param name="tipoProcedimiento"></param>
        /// <param name="fechaTermino"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacion(string numeroFolio,
                                                                                string tipoProcedimiento,
                                                                                DateTime fechaTermino,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = string.Format(asuntoEmail, tipoProcedimiento, numeroFolio);
            string cuerpo = string.Format(cuerpoMail, numeroFolio, tipoProcedimiento, fechaTermino);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que crea un email para enviar aviso de una respuesta a una solicitud
        /// </summary>
        /// <param name="numeroFolio"></param>
        /// <param name="tipoProcedimiento"></param>
        /// <param name="fechaTermino"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionSolicitud(string numeroFolio,
                                                                                string tipoProcedimiento,
                                                                                DateTime fechaTermino,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = string.Format(asuntoEmail, numeroFolio);
            string cuerpo = string.Format(cuerpoMail, numeroFolio, tipoProcedimiento, fechaTermino);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }


        /// <summary>
        /// Método que obtiene el mail de notificacion usuario creado
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="claveProvisoria"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionUsuarioCreado(string nombreUsuario,
                                                                                string claveProvisoria,                                                                                
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = string.Format(asuntoEmail);
            string cuerpo = string.Format(cuerpoMail, nombreUsuario, claveProvisoria);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificacion usuario creado
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="claveProvisoria"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionActuarioCreado(string folio,                                                                            
                                                                            string cuerpoMail,
                                                                            string emailDestinatario,
                                                                            string asuntoEmail,
                                                                            string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificacion usuario creado
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="claveProvisoria"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionFiscalInvestigadorInhabilitado(string folio,
                                                                        string tipoFiscalInvestigador,
                                                                        string rut,
                                                                        string nombre,
                                                                            string cuerpoMail,
                                                                            string emailDestinatario,
                                                                            string asuntoEmail,
                                                                            string emailOrigen)
        {
            string asunto = string.Format(asuntoEmail, tipoFiscalInvestigador);
            string cuerpo = string.Format(cuerpoMail, tipoFiscalInvestigador, folio, rut, nombre);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación de una ampliación ingresada
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="diasAmpliacion"></param>
        /// <param name="fechaTerminoPlazo"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionAmpliacionIngresada(string folio,
                                                                                short? diasAmpliacion,
                                                                                DateTime fechaTerminoPlazo,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = string.Format(asuntoEmail, folio);
            string cuerpo = string.Format(cuerpoMail, folio, diasAmpliacion, fechaTerminoPlazo.ToShortDateString());

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación de una ampliación editada
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="diasAmpliacion"></param>
        /// <param name="fechaTerminoPlazo"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionAmpliacionEditada(string folio,
                                                                                short? diasAmpliacion,
                                                                                DateTime fechaTerminoPlazo,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = string.Format(asuntoEmail, folio);
            string cuerpo = string.Format(cuerpoMail, folio, diasAmpliacion, fechaTerminoPlazo.ToShortDateString());

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación dias atraso
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="diasAmpliacion"></param>
        /// <param name="fechaTerminoPlazo"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionDiasAtraso(string folio,
                                                                    int diasAtraso,                                                                    
                                                                    string cuerpoMail,
                                                                    string emailDestinatario,
                                                                    string asuntoEmail,
                                                                    string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio, diasAtraso);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }


        /// <summary>
        /// Método que obtiene el mail de notificación de una nueva solicitud de ampliación
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionSolicitudAmpliacion(string folio,                                                                                                                                                                
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación de una nueva solicitud de prorroga
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionSolicitudProrroga(string folio,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación de una nueva solicitud de Apertura
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionSolicitudApertura(string folio,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación de una nueva solicitud de Sobreseimiento
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionSolicitudSobreseimiento(string folio,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

        /// <summary>
        /// Método que obtiene el mail de notificación de una nueva solicitud de absolución
        /// </summary>
        /// <param name="folio"></param>
        /// <param name="cuerpoMail"></param>
        /// <param name="emailDestinatario"></param>
        /// <param name="asuntoEmail"></param>
        /// <param name="emailOrigen"></param>
        /// <returns></returns>
        public static MailMessage ObtenerEmailNotificacionSolicitudAbsolucion(string folio,
                                                                                string cuerpoMail,
                                                                                string emailDestinatario,
                                                                                string asuntoEmail,
                                                                                string emailOrigen)
        {
            string asunto = asuntoEmail;
            string cuerpo = string.Format(cuerpoMail, folio);

            return new MailMessage(
                    emailOrigen,
                    emailDestinatario,
                    asunto,
                    cuerpo);
        }

    }
}
