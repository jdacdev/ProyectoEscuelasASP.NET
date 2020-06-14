using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        /// visualizar asignaturas
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

                return View(asignatura.SingleOrDefault());
            }
            else
            {
                return View("MultipleAsignaturas",_context.Asignaturas);
            }

        }
        public IActionResult Create()
        {
            List<Curso> listaCursos= _context.Cursos.ToList();
            ViewBag.listaCursos = (new SelectList(listaCursos,"Id","Nombre"));
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                asignatura.Id = Guid.NewGuid().ToString();

                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();

                ViewBag.mensaje ="Asignatura Creada";
                return View("Index",asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.mensaje = "El Asignatura que intenta actualizar no existe";
                return View("MultipleAsignaturas",_context.Asignaturas);
            }
            Asignatura asignatura = _context.Asignaturas.Find(id);
            if (asignatura == null)
            {
                ViewBag.mensaje = "El Asignatura que intenta actualizar no existe";
                return View("MultipleAsignaturas",_context.Asignaturas);
            }

             List<Curso> listaCursos= _context.Cursos.ToList();
            ViewBag.listaCursos = (new SelectList(listaCursos,"Id","Nombre"));
            return View(asignatura);
        }

        [HttpPost]
        public IActionResult Edit(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Update(asignatura);
                _context.SaveChanges();

                ViewBag.mensaje ="Asignatura Actualizado";
                return View("Index",asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.mensaje = "El Asignatura que intenta eliminar no existe";
                return View("MultipleAsignaturas",_context.Asignaturas);
            }
            Asignatura asignatura = _context.Asignaturas.Find(id);
            if (asignatura == null)
            {
                ViewBag.mensaje = "El Asignatura que intenta eliminar no existe";
                return View("MultipleAsignaturas",_context.Asignaturas);
            }

            return View(asignatura);
        }

        [HttpPost]
        public IActionResult Delete(Asignatura asignatura)
        {
            Asignatura asignaturaDelete = _context.Asignaturas.Find(asignatura.Id);
            _context.Asignaturas.Remove(asignaturaDelete);
            _context.SaveChanges();

            ViewBag.mensaje = string.Format("Asignatura {0} Eliminado", asignatura.Nombre);
            return View("MultipleAsignaturas",_context.Asignaturas);
        }
    }
}