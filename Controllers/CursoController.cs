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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                curso.Id = Guid.NewGuid().ToString();

                _context.Cursos.Add(curso);
                _context.SaveChanges();

                ViewBag.MensajeExra ="Curso Creado";
                return View("Index",_context.Cursos);
            }
            else
            {
                return View(curso);
            }
        }

        public IActionResult MultipleCursos()
        {
            return View(_context.Cursos);
        }
    }
}