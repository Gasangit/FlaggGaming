using System.ComponentModel.DataAnnotations;

namespace FlaggGaming.Model.apiSteamListaJuegosTotal
{
    public class ItemListaJuegoSteam
    {
        [Key]
        public int appid { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }

        public ItemListaJuegoSteam() { }

    }
}
