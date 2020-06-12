using System;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    // abstract --> esta clase es solo uno idea, no puede ser utilizada como instancia
    public abstract class EscuelaBase
    {
        // implementando esta clase ya no ce tendran que crear e inicializar atributos id y nombre en las demas clase del objeto
        // se produce una disminucion de condigo considerable
        public string Id { get; set; }
        public virtual string Nombre { get; set; }

        public EscuelaBase()
        {
            //this.Id  = Guid.NewGuid().ToString(); //Creamos Id automaticamente
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}