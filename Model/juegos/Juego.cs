using System.ComponentModel;

namespace FlaggGaming.Model.Juegos
{
    public class Juego
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        public string? nombre { get; set; }
        [DisplayName("Descripción")]
        public string? descripcion { get; set; }
        [DisplayName("Tienda")]
        public string store { get; set; }
        [DisplayName("Imagen")]
        public string? imagen { get; set; }
        public string? imagenMini { get; set; }
        public string url { get; set; }
        public double precio { get; set; }

        public Juego() { }

        //este constructor se utilizó para realizar las primeras pruebas
        public Juego(string? name, string? description, string? urlImagen)
        {
            nombre = name;
            descripcion = description;
            imagen = urlImagen;
        }
    }
}
