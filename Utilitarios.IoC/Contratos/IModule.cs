namespace Utilitarios.IoC
{
    /// <summary>
    /// Para registro de los tipos internos con Unity
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Inicializa el tipado de la inversión de control
        /// </summary>
        /// <param name="register"></param>
        void Initialize(IRegisterModules register);
    }
}
