using Aplicacion.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.IoC
{
    /// <summary>
    /// Clase que inicializa el mapeo de tipos para AutoMapper
    /// </summary>
    public sealed class MapperInitializer
    {
        /// <summary>
        /// Configura los mapeos a partir de la ejecución del Profile de AutoMapper
        /// </summary>
        public static void ConfigurarMapeos()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<MapperProfile>();
            });
        }
    }
}
