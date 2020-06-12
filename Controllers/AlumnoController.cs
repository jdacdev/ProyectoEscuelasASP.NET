using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
        ///
        /// visualizar Alumnos
        ///
        [Route("Alumno/Index/")]
        [Route("Alumno/Index/{id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                var alumno = from asig in _context.Alumnos
                                        where asig.Id == id
                                        select asig;

                return View(alumno.SingleOrDefault());
            }
            else
            {
                return View("MultipleAlumnos",_context.Alumnos);
            }

        }

        public IActionResult MultipleAlumnos()
        {
            return View(_context.Alumnos);
        }
    }
}