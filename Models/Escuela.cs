using System.Collections.Generic;

namespace HolaMundoMVC.Models
{
    // no existe la multiple herenciaen .net, sin embargo si se pueden implementar varias interces
    public class Escuela : EscuelaBase , ILugar
    {
        // cuando no se declara el metodo de acceso de una variable este queda como privado
        string nombre;
        //buena practica - acceder a los atributos de la clase mediante encapsulamiento
        //los metodos usados para encapsular variables son llamados propiedades.
        
        //public string Nombre /*Nos mostrara el nombre de una manera publica */
        //{
        //    get { return nombre; } //retorno del valor
        //    set { nombre = value; } //asignacion de un valor
        //}
        
        // el encapsulmiento de las variables puede contener ademas logica para tratar el llamado y la modificacion de la variable
        //ej...

        public string NombreExample
        {
            get { return "nombre: " + nombre; }
            set { nombre = value.ToLower(); }
        }

        // para definir estas propiedades de forma mas corta se puede emplear el siguiente shortcut  --> prop + tab
        public int AñoFundacion{ get; set; }
        //el compilador interpreta la misma logica para el uso de esta propiedad
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        // la forma correcta de manejar tipos en .Net es por medio de enumeraciones
        public TiposEscuela TipoEscuela { get; set; }

        public Curso[] Cursos { get; set; }

        public List<Curso> CursosList { get; set; }
        public string Direccion { get ; set ; }

        //las entidades tienes metodos 'constructor' el cual es usado cuando se instancia un clase para crear un objeto
        /*public Escuela (string pNombre, int pAño)
        {
            this.nombre = pNombre; // this --> referirse a la clase (llamado de metodos de la misma clase)
            this.AñoFundacion = pAño;
        }*/
        // es posible escribir de una forma mas corta por medio de asignacion usando igualacion por tuplas...
        public Escuela(string pNombre, int pAño) => (Nombre, AñoFundacion, CursosList) = (pNombre, pAño, new List<Curso>());

        public Escuela(){
        
        }
        //Es posible tener mas de un constructor desde que tengan una firma distinta
        //firma = nombre+acceso+ retorno +parametros(tipos)
        // es posible poner parametros como opcionales a la hora de llamar al constructor añadiendole un valor por defecto
        public Escuela(/*Lista de parametros*/string pNombre, int pAño, TiposEscuela pTipoEscuela, string pPais = "", string pCiudad = ""/*estos ultimos dos son opcionales*/)
        {
            // la asignacion por igualacion tambien se puede aplicar dentro del metodo
            (Nombre, AñoFundacion) = (pNombre, pAño);
            //this --> llamado  a elementos de la misma clase
            this.Ciudad = pCiudad;
            this.TipoEscuela = pTipoEscuela;
            this.Pais = pPais;
            this.CursosList = new List<Curso>();
        }
        //sobreescritura de metodo toString
        // este metodo es de la clase object - clase padre de todas las demas clases en c#
        public override string ToString()
        {
            return $"Nombre :{nombre} \n Año de creacion: {AñoFundacion} \n Pais: {Pais} \n Ciudad: {Ciudad} \n Tipo: {TipoEscuela}";
        }

        public void BorrarDireccion()
        {
            this.Direccion = "";
        }
    }
}