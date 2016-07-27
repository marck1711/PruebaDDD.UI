using Microsoft.Practices.Unity;

namespace Utilitarios.IoC
{
    /// <summary>
    /// Permite registrar los módulos que implementan el contrato IModulo
    /// </summary>
    internal class RegisterModules : IRegisterModules
    {
        /// <summary>
        /// Miembro que adoptará el comportamiento del contenedor de Unity
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Crea instancia de objeto que registra los modulos asociados a IoC
        /// </summary>
        /// <param name="container"></param>
        public RegisterModules(IUnityContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// Registra tipos utilizando el contenedor de Unity
        /// </summary>
        /// <typeparam name="TFrom">Tipo de Origen</typeparam>
        /// <typeparam name="TTo">Tipo de Destino</typeparam>
        /// <param name="withInterception">Indicador si requiere intercepcion</param>
        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (!withInterception)
            {
                this._container.RegisterType<TFrom, TTo>();
            }
        }

        /// <summary>
        /// Registra tipos utilizando Unity y permite controlar el tiempo de vida de la ejecución del contenedor
        /// </summary>
        /// <typeparam name="TFrom">Tipo de Origen</typeparam>
        /// <typeparam name="TTo">Tipo de Destino</typeparam>
        /// <param name="withInterception">Indicador si requiere intercepcion</param>
        public void RegisterTypeWithLifetime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this._container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
