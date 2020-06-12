using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
        ///
        /// visualizar Cursos
        ///
        [Route("Curso/Index/")]
        [Route("Curso/Index/{id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                var Curso = from asig in _context.Cursos
                                        where asig.Id == id
                                        select asig;

                return View(Curso.SingleOrDefault());
            }
            else
            {
                return View("MultipleCursos",_context.Cursos);
            }

        }

        public IActionResult MultipleCursos()
        {
            return View(_context.Cursos);
        }
    }
}