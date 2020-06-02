using System;
using System.Collections.Generic;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            #region  set Asignatura
            var Asignatura = new Asignatura();
            Asignatura.Nombre = "Ingles";
            #endregion  set Asignatura

            ViewBag.FechaActual = System.DateTime.Today;
            // Por convension ...
            // si no se le especifica una vista el metodo retornara la vista que corresponda con su nombre en las views de Asignatura
            return View(Asignatura);
        }

        public IActionResult MultipleAsignaturas()
        {
            List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                                new Asignatura(){Nombre = "Matematicas"},
                                new Asignatura(){Nombre = "Sociales"},
                                new Asignatura(){Nombre = "Naturales"},
                                new Asignatura(){Nombre = "Ingles"},
                                new Asignatura(){Nombre = "Español"},
                };

            return View(listaAsignaturas);
        }
    }
}