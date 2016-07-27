using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dominio.Core
{
    public interface IRepositorioBase<T> : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        /// <summary>
        /// 
        /// </summary>
        string Usuario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="ordenarPor"></param>
        /// <param name="propiedadesAIncluir"></param>
        /// <returns></returns>
        IEnumerable<T> Obtener(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor = null, string propiedadesAIncluir = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        IEnumerable<T> Obtener(Expression<Func<T, bool>> filtro);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ObtenerTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        T ObtenerPrimero(Expression<Func<T, bool>> filtro);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Encontrar(object id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadACrear"></param>
        T Crear(T entidadACrear);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Eliminar(object id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadAEliminar"></param>
        void Eliminar(T entidadAEliminar);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadAEliminar"></param>
        void EliminarLogico(T entidadAEliminar);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadAActualizar"></param>
        void Actualizar(T entidadAActualizar);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="indiceDePagina"></param>
        /// <param name="cantidadDePaginas"></param>
        /// <param name="ordenarPor"></param>
        /// <param name="ascendente"></param>
        /// <returns></returns>
        IEnumerable<T> ObtenerElementosPaginados<TKey>(int indiceDePagina, int cantidadDePaginas, Expression<Func<T, TKey>> ordenarPor, bool ascendente = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="indiceDePagina"></param>
        /// <param name="cantidadDePaginas"></param>
        /// <param name="ordenarPor"></param>
        /// <param name="ascendente"></param>
        /// <param name="propiedadesAIncluir"></param>
        /// <returns></returns>
        IEnumerable<T> ObtenerElementosPaginados<TKey>(int indiceDePagina, int cantidadDePaginas, Expression<Func<T, TKey>> ordenarPor, bool ascendente = true, string propiedadesAIncluir = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultaSQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        IEnumerable<T> ObtenerPorConsulta(string consultaSQL, params object[] parametros);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comandoSQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        int EjecutarConsulta(string comandoSQL, params object[] parametros);
    }
}
