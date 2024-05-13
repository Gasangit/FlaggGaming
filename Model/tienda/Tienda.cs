namespace FlaggGaming.Model.tienda
{
    public class Tienda
    {
        public int Id { get; set; }
        public string razonSocial {  get; set; }
        public string cuit {  get; set; }
        public string nombre {  get; set; }
        public string mail {  get; set; }
        public string password {  get; set; }
        public string direccion { get; set; }
        public string[] dias { get; set; } = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"};
        public string telefono {  get; set; }
        public string instagram {  get; set; }
    }
}
