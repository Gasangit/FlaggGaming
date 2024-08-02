using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlaggGaming.Model.juegoFlagg;
public class Oferta{
    //public Guid idOferta { get; set; }

   /* [ForeignKey("idFlagg")]
    public Guid idFlagg { get; set; } */

    public ICollection<JuegoFlagg> juegos { get; set; }

    public int discount_percent { get; set; }

    public Oferta(){ }

}