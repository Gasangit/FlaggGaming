﻿using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class ReleaseDate
{
    public Guid IdFlagg { get; set; }

    public DateTime Date { get; set; }

    public bool ComingSoon { get; set; }

    public virtual Juego IdFlaggNavigation { get; set; } = null!;
}