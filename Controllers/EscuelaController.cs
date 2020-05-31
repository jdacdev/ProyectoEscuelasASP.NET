using System;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            #region  set Escuela
            var escuela = new Escuela("Escuela de Juan",2020,TiposEscuela.Secundaria);
            escuela.Ciudad = "Bogotá";
            escuela.Pais = "Colombia";
            escuela.Direccion = "Calle falsa 123";
            #endregion  set Escuela

            ViewBag.FechaActual = System.DateTime.Today;
            // Por convension ...
            // si no se le especifica una vista el metodo retornara la vista que corresponda con su nombre en las views de Escuela
            return View(escuela);
        }
    }
}