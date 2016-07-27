using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Base
{
    /// <summary>
    /// Estados de una solicitud
    /// </summary>
    public enum EstadoSolicitud
    {
        Ingresada,
        Aceptada,
        Rechazada,
        SinEfecto
    }

    /// <summary>
    /// Enum Tipo
    /// </summary>
    public enum TipoAccion
    {
        Ingreso,
        SinEfecto
    }

    /// <summary>
    /// Tablas de posibles cambio de estados de 
    /// </summary>
    public enum TipoTabla
    {
        SolicitudInhabilitacion,
        Cierre,
        SolicitudApertura,
        SolicitudAmpliacion,
        Reapertura
    }

    /// <summary>
    /// Tipo Etapa
    /// </summary>
    public enum TipoEtapa
    {
        Creacion,
        SolicitudInhabilitacion,
        FaseRegular,
        CerradoPorVistaFiscal,
        CerradoPorTerminoPlazo,
        SolicitudAmpliacion,
        EnProrroga,
        EnApertura,
        EnSobreseimiento,
        Reapertura,
        FaseReapertura
    }
}
