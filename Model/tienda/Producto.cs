using FlaggGaming.Model.tienda;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace FlaggGaming.Model.tienda
{
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


    /*public int idInternoProducto {  get; set; }
    public int idTienda { get; set; }
    public int idCategoria {  get; set; }
    public Tienda tienda {  get; set; }
    public Categoria categoria { get; set; }
    public string skuTienda { get; set; }
    public string descripcion {  get; set; }
    public string marca {  get; set; }
    public double precioVenta {  get; set; }
    public bool estatus {  get; set; }
    public int? descTienda { get; set; }*/
}

