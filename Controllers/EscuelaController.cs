using System;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.IdEscuela = Guid.NewGuid().ToString();
            escuela.Nombre = "Escuela de Juan";
            escuela.AñoFundacion = 2020;
            // Por convension ...
            // si no se le especifica una vista el metodo retornara la visrta que corresponda con su nombre en las views de Escuela
            return View(escuela);
        }
    }
}