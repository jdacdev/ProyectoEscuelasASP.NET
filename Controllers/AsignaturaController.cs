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
        public IActionResult Index()
        {
            ViewBag.FechaActual = System.DateTime.Today;
            // Por convension ...
            // si no se le especifica una vista el metodo retornara la vista que corresponda con su nombre en las views de Asignatura
            return View(_context.Asignaturas.FirstOrDefault());
        }

        public IActionResult MultipleAsignaturas()
        {
            return View(_context.Asignaturas);
        }
    }
}