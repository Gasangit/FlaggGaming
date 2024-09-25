using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class Producto
{
    public int IdInternoProducto { get; set; }

    public int IdTienda { get; set; }

    public int IdCategoria { get; set; }

    public string SkuTienda { get; set; } = null!;

    public string DescTienda { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public decimal PrecioVta { get; set; }

    public bool Estatus { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;
}
