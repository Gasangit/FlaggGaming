using System.ComponentModel;

namespace FlaggGaming.Model
{
    public class Juego: IProducto
    {
        [DisplayName("Nombre")]
        public string? Name { get; set; }
        [DisplayName("Descripción")]
        public string? Description { get; set; }
        [DisplayName("Imagen")]
        public string? urlImagen { get; set; }
        public double Price { get; set; }

        public Juego() { }
        public Juego(string? name, string? description, string? urlImagen)
        {
            Name = name;
            Description = description;
            this.urlImagen = urlImagen;
        }
    }
}
