using System;
using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            #region  set Alumno
            var Alumno = new Alumno();
            Alumno.Nombre = "Juan David Amaya";
            #endregion  set Alumno

            ViewBag.FechaActual = System.DateTime.Today;
            // Por convension ...
            // si no se le especifica una vista el metodo retornara la vista que corresponda con su nombre en las views de Alumno
            return View(Alumno);
        }

        public IActionResult MultipleAlumnos()
        {
            //Generamos alumnos al azar a partir del algoritmo implementado en el curso anterior
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            //Producto cartesiano con LinQ
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            List<Alumno> listaAlumnosFiltrada = listaAlumnos.OrderBy((al) => al.Identificador).Take(10).ToList();

            return View(listaAlumnosFiltrada);
        }
    }
}