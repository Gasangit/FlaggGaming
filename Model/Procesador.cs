using Microsoft.AspNetCore.Routing.Constraints;

namespace FlaggGaming.Model
{
    public class Procesador
    {
        public int Id { get; set; } 
        public string urlImagen { get; set; }
        public string fechaLanzamiento { get; set; }
        public string nucleos { get; set; }
        public string frecuenciaTurbo { get; set; }
        public string cache {  get; set; }
        public string graficos {  get; set; }

        public Procesador () { }

        public Procesador(string url, string fecha, string nucleos, string frecuencia, string cache, string graficos) 
        {
            this.urlImagen = url;
            this.fechaLanzamiento = fecha;
            this.nucleos = nucleos;
            this.frecuenciaTurbo = frecuencia;
            this.cache = cache;
            this.graficos = graficos;
        }

    }
}
