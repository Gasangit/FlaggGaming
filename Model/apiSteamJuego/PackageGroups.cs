namespace FlaggGaming.Model.apiSteamJuego
{
    public class PackageGroups
    {
        public string? name {  get; set; }
        public string? title {  get; set; }
        public string? description {  get; set; }
        public string? selection_text {  get; set; }
        public string? save_text {  get; set; }
        public int? display_type {  get; set; }
        public string is_recurring_subscription {  get; set; }
        public Package[]? subs { get; set; }
    }
}
