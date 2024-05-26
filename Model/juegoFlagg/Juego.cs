using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.juegoFlagg;
using System.ComponentModel;

namespace FlaggGaming.Model.Juegos
{
    public class Juego
    {
        public int idFlagg { get; set; }
        public int idJuegoTienda { get; set; }
        [DisplayName("Nombre")]
        public string? nombre { get; set; }
        [DisplayName("Descripción")]
        public string? descripcionCorta { get; set; }
        [DisplayName("Tienda")]
        public string tienda { get; set; }
        [DisplayName("Imagen")]
        public string? imagen { get; set; }
        public string? imagenMini { get; set; }
        public string urlTienda { get; set; }
        public double precio { get; set; }
        public int contadorVistas { get; set; }
        public int idOferta { get; set; }
        public string estudio { get; set; }
        public string requisitos { get; set; }
        public Oferta oferta { get; set; }
        FechaLanzamiento fechaLanzamiento { get; set; }

        public Juego() { }

        //este constructor se utilizó para realizar las primeras pruebas
        public Juego(string? name, string? description, string? urlImagen)
        {
            nombre = name;
            descripcionCorta = description;
            imagen = urlImagen;
        }
    }
}
