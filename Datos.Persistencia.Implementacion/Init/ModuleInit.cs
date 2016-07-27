using Datos.Persistencia.Core;
using Dominio.Contratos;
using System.ComponentModel.Composition;
using Utilitarios.IoC;

namespace Datos.Persistencia.Implementacion
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterType<IContextoUnidadDeTrabajo, ContextoPrincipal>();
            register.RegisterType<IAlumnoRepositorio, AlumnoRepositorio>();
        }
    }
}
