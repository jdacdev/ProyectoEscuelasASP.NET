using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            var escuelaTemp = _context.Escuelas.FirstOrDefault();
            ViewBag.FechaActual = System.DateTime.Today;

            // Por convension ...
            // si no se le especifica una vista el metodo retornara la vista que corresponda con su nombre en las views de Escuela
            return View(escuelaTemp);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}