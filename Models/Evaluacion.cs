using System;

namespace HolaMundoMVC.Models
{
    public class Evaluacion : EscuelaBase
    {
        public Alumno AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public Asignatura AsignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }
        public float Nota {get; set;}
        public Evaluacion()
        {
            
        }
    }
}