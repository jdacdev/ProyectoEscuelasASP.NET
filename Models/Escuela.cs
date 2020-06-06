using System.Collections.Generic;

namespace HolaMundoMVC.Models
{
    // no existe la multiple herenciaen .net, sin embargo si se pueden implementar varias interces
    public class Escuela : EscuelaBase , ILugar
    {
        public int AñoFundacion{ get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        public string Direccion { get ; set ; }
        public Escuela()
        {
        
        }
        
        public Escuela(string pNombre, int pAño, TiposEscuela pTipoEscuela, string pPais = "", string pCiudad = "")
        {
            (Nombre, AñoFundacion) = (pNombre, pAño);
            this.Ciudad = pCiudad;
            this.TipoEscuela = pTipoEscuela;
            this.Pais = pPais;
            this.Cursos = new List<Curso>();
        }

        public Escuela(string pNombre, int pAño) => (Nombre, AñoFundacion, Cursos) = (pNombre, pAño, new List<Curso>());

        public override string ToString()
        {
            return $"Nombre :{Nombre} \n Año de creacion: {AñoFundacion} \n Pais: {Pais} \n Ciudad: {Ciudad} \n Tipo: {TipoEscuela}";
        }

        public void BorrarDireccion()
        {
            this.Direccion = "";
        }
    }
}