using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utilitarios.IoC
{
    /// <summary>
    /// Carga los módulos decorados con el Export y que implementan el IModule
    /// </summary>
    public static class ModuleLoader
    {
        /// <summary>
        /// Realiza la carga del contenedor de Unity enviado desde el Bootstrapper
        /// </summary>
        /// <param name="container">Contenedor de Unity</param>
        /// <param name="path">Ruta desde la cual se obtendrán las dll</param>
        /// <param name="pattern">Patrón para buscar las componentes a cargar</param>
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var directoryCatalog = new DirectoryCatalog(path, pattern);
            var importDefinition = BuildImportDefinition();

            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(directoryCatalog);
                    
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDefinition);
                        IEnumerable<IModule> modules = exports.Select(export => export.Value as IModule).Where(m => m != null);

                        var register = new RegisterModules(container);

                        foreach (IModule module in modules)
                        {
                            module.Initialize(register);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();

                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        /// <summary>
        /// Construye la definición del tipo importado
        /// </summary>
        /// <returns>Definición generada</returns>
        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }   
}
