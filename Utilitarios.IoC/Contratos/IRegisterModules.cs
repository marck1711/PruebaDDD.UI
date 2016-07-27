namespace Utilitarios.IoC
{
    /// <summary>
    /// Permite registrar tipos en Unity para objetos que implementan IModulo
    /// </summary>
    public interface IRegisterModules
    {
        /// <summary>
        /// Registra tipos utilizando el contenedor de Unity
        /// </summary>
        /// <typeparam name="TFrom">Tipo de Origen</typeparam>
        /// <typeparam name="TTo">Tipo de Destino</typeparam>
        /// <param name="withInterception">Indicador si requiere intercepcion</param>
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        /// <summary>
        /// Registra tipos utilizando Unity y permite controlar el tiempo de vida de la ejecución del contenedor
        /// </summary>
        /// <typeparam name="TFrom">Tipo de Origen</typeparam>
        /// <typeparam name="TTo">Tipo de Destino</typeparam>
        /// <param name="withInterception">Indicador si requiere intercepcion</param>
        void RegisterTypeWithLifetime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}
