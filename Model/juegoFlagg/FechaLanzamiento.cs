﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlaggGaming.Model.juegoFlagg
{
    public class FechaLanzamiento
    {

        //public Guid idFecha;


        //public Guid idFlagg { get; set; }

        /*public bool proximamente {  get; set; }
        public string fecha {  get; set; }*/

        public Guid IdFlagg { get; set; }

        public DateTime Date { get; set; }

        public bool ComingSoon { get; set; }

        public virtual JuegoFlagg IdFlaggNavigation { get; set; } = null!;
    }
}
