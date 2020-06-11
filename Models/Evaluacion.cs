using System;

namespace HolaMundoMVC.Models
{
    public class Evaluacion : EscuelaBase
    {
        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public string AsignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }
        public float Nota {get; set;}
        public Evaluacion()
        {
            
        }
    }
}