namespace FlaggGaming.Model.apiSteamJuego
{
    public class Movie
    {
        public int? id {  get; set; }
        public string? name {  get; set; }
        public string? thumbnail {  get; set; }
        public Dictionary<string, string> webm {  get; set; }
        public Dictionary<string, string> mp4 {  get; set; }
        public bool highlight {  get; set; }
    }
}
