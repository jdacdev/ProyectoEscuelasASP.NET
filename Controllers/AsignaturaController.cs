using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    { 
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
        ///
        /// visualizar asignatura por su ID
        ///
        [Route("Asignatura/Index/")]
        [Route("Asignatura/Index/{IdAsignatura}")]
        public IActionResult Index(string IdAsignatura)
        {
            if(!string.IsNullOrEmpty(IdAsignatura))
            {
                var asignatura = from asig in _context.Asignaturas
                                        where asig.Id == IdAsignatura
                                        select asig;

                return View(asignatura);
            }
            else
            {
                return View("MultipleAsignaturas",_context.Asignaturas);
            }

        }

        public IActionResult MultipleAsignaturas()
        {
            return View(_context.Asignaturas);
        }
    }
}