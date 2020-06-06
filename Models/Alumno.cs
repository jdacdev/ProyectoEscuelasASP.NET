using System;
using System.Collections.Generic;

namespace HolaMundoMVC.Models
{
    public class Alumno : EscuelaBase
    {
         //referencia al padre - Curso
        public string CursoId {get; set;}

        //esta propiedad adicional es para recuperar el objeto Curso completo
        public Curso Curso {get; set;}
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}