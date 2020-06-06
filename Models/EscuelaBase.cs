using System;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    // abstract --> esta clase es solo uno idea, no puede ser utilizada como instancia
    public abstract class EscuelaBase
    {
        // implementando esta clase ya no ce tendran que crear e inicializar atributos id y nombre en las demas clase del objeto
        // se produce una disminucion de condigo considerable
        [Key]
        public string Identificador { get; private set; }
        public string Nombre { get; set; }

        public EscuelaBase(){

            this.Identificador  = Guid.NewGuid().ToString(); //Creamos Id automaticamente
        }

        public override string ToString()
        {
            return $"{Nombre},{Identificador}";
        }
    }
}