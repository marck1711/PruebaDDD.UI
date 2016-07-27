using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Datos.Persistencia.Core
{
    public interface IEntityFrameworkUnidadDeTrabajo : IUnidadDeTrabajo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IDbSet<T> Set<T>() where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void Attach<T>(T item) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void SetModified<T>(T item) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
