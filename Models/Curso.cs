using System;
using System.Collections.Generic;

namespace HolaMundoMVC.Models
{
    public class Curso : EscuelaBase
    {
        //podemos hacer que el guid solo se asigne (set) dentro de la clase (private)
        // su consulta (get) sera publica
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> listaAsignaturas {get; set;}
        public List<Alumno> listaAlumnos{get; set;}

        public Curso()
        {
        }

        //esta clase nos permite evidenciar los principios del encapsulamiento
        //hacer que la aplicacion utilice las funciones exclusivas que se le codificaron
        //no dar cabida a comportamientos extraños dentro de la apliacion 
        //ej. no crear un id cualquiera, solo la clase puede hacerlo.


        //sobreescritura de metodo toString
        public override string ToString()
        {
            return $" Nombre :{Nombre} \n Jornada: {Jornada} \n  Id: {Identificador} \n-------  ";
        }
    }
}