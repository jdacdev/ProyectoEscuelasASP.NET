using System;
using System.Collections.Generic;

namespace HolaMundoMVC.Models
{
    public class Curso : EscuelaBase
    {
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas {get; set;}
        public List<Alumno> Alumnos{get; set;}

        //referencia al padre - Escuela
        public string EscuelaId {get; set;}

        //esta propiedad adicional es para recuperar el objeto escuela completo
        public Escuela Escuela {get; set;}

        public Curso()
        {
        }

        public override string ToString()
        {
            return $" Nombre :{Nombre} \n Jornada: {Jornada} \n  Id: {Id} \n-------  ";
        }
    }
}