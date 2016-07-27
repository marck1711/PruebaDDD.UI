using Aplicacion.Contratos;
using System.ComponentModel.Composition;
using Utilitarios.IoC;

namespace Aplicacion.Implementacion
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterType<IAlumnoServicio, AlumnoServicio>();
        }
    }
}
