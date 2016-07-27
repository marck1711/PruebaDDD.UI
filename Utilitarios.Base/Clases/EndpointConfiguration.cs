using System.Configuration;
using System.Linq;

namespace Utilitarios.Base
{
    public static class EndpointConfiguration
    {
        /// <summary>
        /// Método que obtiene el endpoint configuration del apps setting de configuración
        /// </summary>
        /// <param name="servicioId"></param>
        /// <returns></returns>
        public static string ObtenerEndpointConfiguration(int servicioId)
        {
            var appSettingVariable = string.Format("EndPoint_Servicio_{0}", servicioId);

            var appSettingKey = ConfigurationManager.AppSettings.AllKeys
                             .Where(key => key.StartsWith(appSettingVariable)).FirstOrDefault();

            var endPointConfiguration = ConfigurationManager.AppSettings[appSettingKey];

            return endPointConfiguration;                              
        }
    }
}
