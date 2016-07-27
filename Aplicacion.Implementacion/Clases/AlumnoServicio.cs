using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Implementacion
{
    public class AlumnoServicio : IAlumnoServicio
    {
        #region Miembros

        /// <summary>
        /// 
        /// </summary>
        private IAlumnoRepositorio alumnoRepositorio;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_alumnoRepositorio"></param>
        public AlumnoServicio(IAlumnoRepositorio _alumnoRepositorio)
        {
            this.alumnoRepositorio = _alumnoRepositorio;
        }

        #endregion

        #region Métodos Base

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadACrear"></param>
        /// <returns></returns>
        public Core.AlumnoDTO Crear(Core.AlumnoDTO entidadACrear)
        {
            var alumno = AutoMapper.Mapper.Map<AlumnoDTO, Alumno>(entidadACrear);

            var alumnoGuardado = this.alumnoRepositorio.Crear(alumno);
            this.alumnoRepositorio.UnidadDeTrabajo.Confirmar();

            return AutoMapper.Mapper.Map<Alumno, AlumnoDTO>(alumnoGuardado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAEliminar"></param>
        public void Eliminar(int idAEliminar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadAActualizar"></param>
        public void Actualizar(Core.AlumnoDTO entidadAActualizar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="AlumnoDTO"></typeparam>
        /// <returns></returns>
        public List<AlumnoDTO> Listar()
        {
            var lista = this.alumnoRepositorio.ObtenerTodos();
            return Mapper.Map<IEnumerable<AlumnoDTO>>(lista).ToList();
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Destructor de la clase
        /// </summary>
        ~AlumnoServicio()
        {

        }

        /// <summary>
        /// Implementación de método dispose 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Liberación de recursos manejados, no manejados y nativos 
        /// </summary>
        /// <param name="disposing">Flag indicador de llamado a método dispose a partir del destructor de la clase (false)</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.alumnoRepositorio != null)
                {
                    this.alumnoRepositorio.Dispose();
                    this.alumnoRepositorio = null;
                }
            }
        }

        #endregion
    }
}
