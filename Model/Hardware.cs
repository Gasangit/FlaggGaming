namespace FlaggGaming.Model
{
    public class Hardware: IProducto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string urlImagen {  get; set; }
        public string href { get; set; }
        public TipoHardware tipoHardware { get; set; }

        public Hardware() { }
        public Hardware(string nombre, string url) 
        {
            this.Name = nombre;   
            this.urlImagen = url;
        }
        public Hardware(string name, string url, double price)
        {
            this.Name = name;
            this.urlImagen = url;
            this.Price = price;
            this.href = href;
        }

        public Hardware(string name, string url, string href)
        {
            this.Name = name;
            this.urlImagen = url;
            this.href = href;
        }
        
    }
}
