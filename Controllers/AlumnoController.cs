using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Create()
        {
            List<Curso> listaCursos= _context.Cursos.ToList();
            ViewBag.listaCursos = (new SelectList(listaCursos,"Id","Nombre"));
            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                alumno.Id = Guid.NewGuid().ToString();

                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                ViewBag.mensaje ="Alumno Creada";
                return View("Index",alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.mensaje = "El Alumno que intenta actualizar no existe";
                return View("MultipleAlumnos",_context.Alumnos);
            }
            Alumno alumno = _context.Alumnos.Find(id);
            if (alumno == null)
            {
                ViewBag.mensaje = "El Alumno que intenta actualizar no existe";
                return View("MultipleAlumnos",_context.Alumnos);
            }

             List<Curso> listaCursos= _context.Cursos.ToList();
            ViewBag.listaCursos = (new SelectList(listaCursos,"Id","Nombre"));
            return View(alumno);
        }

        [HttpPost]
        public IActionResult Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Update(alumno);
                _context.SaveChanges();

                ViewBag.mensaje ="Alumno Actualizado";
                return View("Index",alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.mensaje = "El alumno que intenta eliminar no existe";
                return View("MultipleAlumnos",_context.Alumnos);
            }
            Alumno alumno = _context.Alumnos.Find(id);
            if (alumno == null)
            {
                ViewBag.mensaje = "El alumno que intenta eliminar no existe";
                return View("MultipleAlumnos",_context.Alumnos);
            }

            return View(alumno);
        }

        [HttpPost]
        public IActionResult Delete(Alumno alumno)
        {
            Alumno alumnoDelete = _context.Alumnos.Find(alumno.Id);
            _context.Alumnos.Remove(alumnoDelete);
            _context.SaveChanges();

            ViewBag.mensaje = string.Format("Alumno {0} Eliminado", alumno.Nombre);
            return View("MultipleAlumnos",_context.Alumnos);
        }
    }
}