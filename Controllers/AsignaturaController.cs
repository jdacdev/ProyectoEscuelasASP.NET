using System;
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
    }
}