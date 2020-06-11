using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoMVC.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas {get; set;}
        public DbSet<Asignatura> Asignaturas {get; set;}
        public DbSet<Alumno> Alumnos {get; set;}
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Evaluacion> Evaluaciones {get; set;}
        public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
        {
            
        }
        ///
        ///Metodo que se ejeucta cuando se esta creando la BD
        ///Se realiza Siembra de datos
        ///
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ejecute la instruccion original de OnModelCreating
            base.OnModelCreating(modelBuilder);

            #region Objeto escuela
            var escuela = new Escuela("San Juan", 1995);
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Ciudad = "Bogóta";
            escuela.Pais = "Colombia";
            escuela.Direccion = "Calle false 123";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            #endregion Objeto escuela

            //carga de cursos de la escuela
            var cursos = CargarCursos(escuela);

            //cargar asignaturas de curso
            var asignaturas = CargarAsignaturas(cursos);

            //cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            //agregamos al contexto los elementos...

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            List<Asignatura> listaAsignaturas = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> {
                                                        new Asignatura() { Id = Guid.NewGuid().ToString() , Nombre = "Matematicas",CursoId = curso.Id},
                                                        new Asignatura() { Id = Guid.NewGuid().ToString() , Nombre = "Sociales" ,CursoId = curso.Id},
                                                        new Asignatura() { Id = Guid.NewGuid().ToString() , Nombre = "Naturales" ,CursoId = curso.Id},
                                                        new Asignatura() { Id = Guid.NewGuid().ToString() , Nombre = "Ingles" ,CursoId = curso.Id},
                                                        new Asignatura() { Id = Guid.NewGuid().ToString() , Nombre = "Español" ,CursoId = curso.Id}
                                                    };
                listaAsignaturas.AddRange(tmpList);
            }

            return listaAsignaturas;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            var listaCursos = new List<Curso>()
            {
                new Curso(){ Id = Guid.NewGuid().ToString() , Nombre = "Curso 101", Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id},
                new Curso(){ Id = Guid.NewGuid().ToString() , Nombre = "Curso 102", Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id},
                new Curso(){ Id = Guid.NewGuid().ToString() , Nombre = "Curso 103", Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id}
            };
            return listaCursos;
        }
        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            foreach (var curso in cursos)
            {
                var alumnos = AlumnosAlAzar(curso,10);
                listaAlumnos.AddRange(alumnos);
            }

            return listaAlumnos;
        }

        public List<Alumno> AlumnosAlAzar(Curso curso,int cantidad)
        {
            //Generamos alumnos al azar a partir del algoritmo implementado en el curso anterior
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            //Producto cartesiano con LinQ
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Id = Guid.NewGuid().ToString() , Nombre = $"{n1} {n2} {a1}" , CursoId = curso.Id};

            List<Alumno> listaAlumnosFiltrada = listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();

            return listaAlumnosFiltrada;
            //return View(listaAlumnosFiltrada);
        }
    }
}