using System;
using System.Collections.Generic;

namespace FlaggGaming.Model.juegoFlagg;

public partial class ReleaseDate
{
    public Guid IdFlagg { get; set; }

    public DateTime Date { get; set; }

    public bool ComingSoon { get; set; }

    public virtual JuegoFlagg IdFlaggNavigation { get; set; } = null!;
}
