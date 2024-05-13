using FlaggGaming.Model.tienda;

namespace FlaggGaming.Model.tienda
{
    public class Producto
    {
        public int idInternoProducto {  get; set; }
        public int idTienda { get; set; }
        public int idCategoria {  get; set; }
        public Tienda tienda {  get; set; }
        public Categoria categoria { get; set; }
        public string skuTienda { get; set; }
        public string descripcion {  get; set; }
        public string marca {  get; set; }
        public double precioVenta {  get; set; }
        public bool status {  get; set; }
    }
}
