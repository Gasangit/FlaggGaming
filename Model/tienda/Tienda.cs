using Microsoft.AspNetCore.Mvc.RazorPages;
using FlaggGaming.Model.usuarios;

namespace FlaggGaming.Model.tienda
{
    public class Tienda/*:PageModel*/
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
        
        /*public int Id { get; set; }
        public string razonSocial {  get; set; }
        public string cuit {  get; set; }
        public string nombre {  get; set; }
        public string mail {  get; set; }
        public string password {  get; set; }
        public string direccion { get; set; }
        public string[] dias { get; set; } = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"};
        public string telefono {  get; set; }
        public string instagram {  get; set; }*/
    }
}
