using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlaggGaming.Model.Usuarios
{
    public class Usuario: PageModel
    {
        public int Id { get; set; }
        public string nombre {  get; set; }
        public string apellido {  get; set; }
        public string mail {  get; set; }
        public string password {  get; set; }
        public bool rolTienda { get; set; }
    }
}
