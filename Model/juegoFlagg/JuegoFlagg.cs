using FlaggGaming.Model.apiSteamJuego;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FlaggGaming.Model.juegoFlagg;

namespace FlaggGaming.Model.juegoFlagg
{
    public class JuegoFlagg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idFlagg { get; set; }

        public int? idJuegoTienda { get; set; }
        [DisplayName("Nombre")]
        public string? nombre { get; set; }
        [DisplayName("Descripción")]
        public string? descripcionCorta { get; set; }
        [DisplayName("Tienda")]
        public string? tienda { get; set; }
        [DisplayName("Imagen")]
        public string? imagen { get; set; }
        public string? imagenMini { get; set; }
        public string? urlTienda { get; set; }
        public string? urlEpic { get; set; }
        //public decimal? precio { get; set; }
        public int? contadorVistas { get; set; }

        public string? estudio { get; set; }
        public string? requisitos { get; set; }

        public Guid? idOferta { get; set; }
        public Oferta? oferta { get; set; }
        //public FechaLanzamiento? fechaLanzamiento { get; set; }

        public JuegoFlagg() { }

        //este constructor se utilizó para realizar las primeras pruebas
        public JuegoFlagg(int _idJuegoTienda, string _nombre, string _descripcionCorta, string _tienda, string _imagen, string _imagenMini, string _urlTienda, string _estudio, string _requisitos/*, FechaLanzamiento _fechaLanzamiento*/)
        {
            this.idJuegoTienda = _idJuegoTienda;
            this.nombre = _nombre;
            this.descripcionCorta = _descripcionCorta;
            this.tienda = _tienda;
            this.imagen = _imagen;
            this.imagenMini = _imagenMini;
            this.urlTienda = _urlTienda;
            this.estudio = _estudio;
            this.requisitos = _requisitos;
            //this.fechaLanzamiento = _fechaLanzamiento;

        }

        public JuegoFlagg(string _descripcionCorta, string _imagen, string _imagenMini, string _urlTienda, string _requisitos)
        {
            this.descripcionCorta = _descripcionCorta;
            this.imagen = _imagen;
            this.imagenMini = _imagenMini;
            this.urlTienda = _urlTienda;
            this.requisitos = _requisitos;
        }
    }
}
