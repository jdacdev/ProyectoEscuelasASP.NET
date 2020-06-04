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
            escuela.Ciudad = "Bogóta";
            escuela.Pais = "Colombia";
            escuela.Direccion = "Calle false 123";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            #endregion Objeto escuela
            //en caso de que escuela no tenga datos insertar el objeto escuela (para efectos de demostracion)
            modelBuilder.Entity<Escuela>().HasData(escuela);
            //... lo mismo con las asignaturas.
            modelBuilder.Entity<Asignatura>().HasData(
                                                        new Asignatura(){Nombre = "Matematicas"},
                                                        new Asignatura(){Nombre = "Sociales"},
                                                        new Asignatura(){Nombre = "Naturales"},
                                                        new Asignatura(){Nombre = "Ingles"},
                                                        new Asignatura(){Nombre = "Español"}
                                                    );
            //... y con Alumnos
            //ojo HasData recibe solo objetos y arrays, no colecciones de otro tipo
            modelBuilder.Entity<Alumno>().HasData(AlumnosAlAzar().ToArray());                                   

        }

        public List<Alumno> AlumnosAlAzar()
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

            return listaAlumnosFiltrada;
            //return View(listaAlumnosFiltrada);
        }
    }
}