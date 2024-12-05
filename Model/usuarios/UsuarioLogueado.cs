namespace FlaggGaming.Model.usuarios
{
    public class UsuarioLogueado
    {
        public int Id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public string apellido { get; set; } = "";
        public string mail { get; set; } = "";
        public string password { get; set; } = "";
        public bool rolTienda { get; set; } = false;
        
        public UsuarioLogueado(int Id, string nombre, string apellido, string mail, bool rolTienda) 
        {
            this.Id = Id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.rolTienda = rolTienda;
        }
    }
}