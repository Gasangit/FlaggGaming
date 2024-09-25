using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class Oferta
{
    public Guid IdOferta { get; set; }

    public int DiscountPercent { get; set; }
}
