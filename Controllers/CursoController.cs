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

                ViewBag.mensaje ="Curso Creado";
                return View("Index",curso);
            }
            else
            {
                return View(curso);
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.mensaje = "El curso que intenta actualizar no existe";
                return View("MultipleCursos",_context.Cursos);
            }
            Curso curso = _context.Cursos.Find(id);
            if (curso == null)
            {
                ViewBag.mensaje = "El curso que intenta actualizar no existe";
                return View("MultipleCursos",_context.Cursos);
            }

            return View(curso);
        }

        [HttpPost]
        public IActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                _context.Update(curso);
                _context.SaveChanges();

                ViewBag.mensaje ="Curso Actualizado";
                return View("Index",curso);
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