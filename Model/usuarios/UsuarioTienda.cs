using FlaggGaming.Model.tienda;

namespace FlaggGaming.Model.Usuarios
{
    public class UsuarioTienda
    {
        public int idUsuario { get; set; }
        public int idTienda {  get; set; }
        public Usuario usuario {  get; set; }
        public Tienda tienda {  get; set; }
    }
}
