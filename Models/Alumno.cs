using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    public class Alumno : EscuelaBase
    {
        [Required]
        public override string Nombre {get; set;}
         //referencia al padre - Curso
        public string CursoId {get; set;}

        //esta propiedad adicional es para recuperar el objeto Curso completo
        public Curso Curso {get; set;}
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}