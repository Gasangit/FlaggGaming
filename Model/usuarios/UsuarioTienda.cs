using FlaggGaming.Model.tienda;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlaggGaming.Model.Usuarios
{
    public class UsuarioTienda/*: PageModel*/
    {
        public int idUsuario { get; set; }
        public int idTienda {  get; set; }
        public Usuario usuario {  get; set; }
        public Tienda tienda {  get; set; }
    }
}
