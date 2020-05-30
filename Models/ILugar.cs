namespace HolaMundoMVC.Models
{
    //Una interfaz es la definición de la estructura de un objeto. 
    //Las interfaces las podemos tomar como contratos en las que obligamos a que los objetos cumplan determinadas características.
    public interface ILugar
    {
        // las propiedades de una interface no necesitan modificadores de acceso, todas son publicas
        string Direccion { get; set; }
        void BorrarDireccion();
    }
}