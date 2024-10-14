using System;
using System.Collections.Generic;
using FlaggGaming.Model.tienda;

namespace FlaggGaming.Model.usuarios;

public partial class UsuariosTienda
{
    public int IdU { get; set; }

    public int IdT { get; set; }

    public bool Active { get; set; }

    public virtual Tienda IdTNavigation { get; set; } = null!;

    public virtual Usuario IdUNavigation { get; set; } = null!;
}
