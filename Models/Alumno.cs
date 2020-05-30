using System;
using System.Collections.Generic;

namespace HolaMundoMVC.Models
{
    public class Alumno : EscuelaBase
    {
        ///cada alumno tendra su propia lista de evaluaciones
        public List<Evaluacion> ListaEvaluacionesAlumno { get; set; } = new List<Evaluacion>();

    }
}