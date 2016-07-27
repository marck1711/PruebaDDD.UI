using Aplicacion.Contratos;
using Aplicacion.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaDDD.UI.Controllers
{
    public class AlumnoController : Controller
    {
        #region Miembros

        private IAlumnoServicio alumnoServicio;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_alumnoServicio"></param>
        public AlumnoController(IAlumnoServicio _alumnoServicio)
        {
            this.alumnoServicio = _alumnoServicio;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(this.alumnoServicio.Listar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Crear()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Crear(AlumnoDTO alumno)
        {
            if (ModelState.IsValid)
            {
                this.alumnoServicio.Crear(alumno);

                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        #endregion
    }
}
