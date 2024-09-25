using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class Tienda
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Dir { get; set; } = null!;

    public string Hr { get; set; } = null!;

    public string Days { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Insta { get; set; } = null!;

    public bool Premium { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<UsuariosTienda> UsuariosTienda { get; set; } = new List<UsuariosTienda>();
}
