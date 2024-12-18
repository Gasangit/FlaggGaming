﻿namespace FlaggGaming.Model.tienda
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        public string DescCategoria { get; set; } = null!;

        public string? ImagenUrl { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
