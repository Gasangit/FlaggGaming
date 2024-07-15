using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlaggGaming.Model.juegoFlagg
{
    public class FechaLanzamiento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idFecha;

        [ForeignKey("idFlagg")]
        public Guid idFlagg { get; set; }

        public bool proximamente {  get; set; }
        public string fecha {  get; set; }
    }
}
