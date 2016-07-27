using Dominio.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Datos.Persistencia.Core
{
    public class ContextoPrincipal : DbContext, IContextoUnidadDeTrabajo
    {
        #region Constructor

        /// <summary>
        /// Genera instancia de Contexto Principal
        /// </summary>
        public ContextoPrincipal() : base("DefaultConnection") 
        {
        }

        #endregion

        #region Implementacion de Interfaz Unidad de Trabajo

        #region Miembros

        /// <summary>
        /// Aplicación
        /// </summary>
        IDbSet<Alumno> alumnos;
        IDbSet<Asignatura> asignaturas;
        IDbSet<Nota> notas;

        #endregion

        #region Atributos y Definiciones de Tablas

        #region Auditoría

        /// <summary>
        /// 
        /// </summary>
        public IDbSet<Alumno> Alumnos
        {
            get { return alumnos ?? (alumnos = base.Set<Alumno>()); }
        }

        public IDbSet<Asignatura> Asignaturas
        {
            get { return asignaturas ?? (asignaturas = base.Set<Asignatura>()); }
        }

        public IDbSet<Nota> Notas
        {
            get { return notas ?? (notas = base.Set<Nota>()); }
        }

        #endregion

        #endregion

        #region Métodos Base

        /// <summary>
        /// Setea ingreso de entidad a contexto
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <returns>Nueva instancia de contexto para entidad T</returns>
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        /// <summary>
        /// Adjunta a contexto entidad asociada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="item">Item a adjuntar</param>
        public void Attach<T>(T item) where T : class
        {
            if (Entry(item).State == EntityState.Detached)
            {
                base.Set<T>().Attach(item);
            }
        }

        /// <summary>
        /// Configura estado de la entidad como "Modificado"
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="item">Item a modificar</param>
        public void SetModified<T>(T item) where T : class
        {
            //var objeto = Entry(item);//Entry(item);
            Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Ejecuta consulta en base de datos
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="sqlQuery">Consulta SQL</param>
        /// <param name="parameters">Parámetros asociados a consulta SQL</param>
        /// <returns>Lista de resultados de consulta sql</returns>
        public IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<T>(sqlQuery, parameters);
        }

        /// <summary>
        /// Ejecuta comando SQL en base de datos
        /// </summary>
        /// <param name="sqlCommand">Comando SQL a ejecutar</param>
        /// <param name="parameters">Parámetros asociados a comando SQL</param>
        /// <returns>Indicador de operación</returns>
        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        /// <summary>
        /// Confirma todos los cambios existentes en el contenedor (Commit)
        /// </summary>
        ///<remarks>
        /// Commit sobre la base de datos
        /// Si la entidad posee propiedades reparadas y ocurre algún problema de persistencia optimista,  
        /// se levantará una excepción
        ///</remarks>
        public void Confirmar()
        {
            base.SaveChanges();
        }

        /// <summary>
        /// Confirma todos los cambios existentes en el contenedor (Commit)
        /// </summary>
        ///<remarks>
        /// Commit sobre la base de datos
        /// Si hay un problema de concurrencia "refrescará" los datos del cliente. Aproximación "Client wins"
        ///</remarks>
        public void ConfirmarYRefrescarCambios()
        {
            bool saveFailed;

            do
            {
                try
                {
                    base.SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry => entry.OriginalValues.SetValues(entry.GetDatabaseValues()));
                }
            } while (saveFailed);
        }

        /// <summary>
        /// Rollback de los cambios que se han producido en la Unit of Work y que están siendo observados por ella
        /// </summary>
        public void DeshacerCambios()
        {
            ChangeTracker.Entries()
                        .ToList()
                        .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #endregion

        #region Extensiones

        ///// <summary>
        ///// Extiende Contexto desde DBContext a ObjectContext
        ///// </summary>
        ///// <returns>ObjectContext de contexto</returns>
        //public ObjectContext ObjectContext()
        //{
        //    return (this as IObjectContextAdapter).ObjectContext;
        //}

        /// <summary>
        /// Gatilla eventos al momento de crear el modelo
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelo de entidades</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuration.LazyLoadingEnabled = false;

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #endregion
    }
}
