using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool RolTienda { get; set; }

    public virtual ICollection<UsuariosTienda> UsuariosTienda { get; set; } = new List<UsuariosTienda>();
}
