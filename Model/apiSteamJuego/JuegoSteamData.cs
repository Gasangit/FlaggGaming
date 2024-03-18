using Newtonsoft.Json;

namespace FlaggGaming.Model.apiSteamJuego
{
    public class JuegoSteamData
    {
        public string? type { get; set; }
        public string? name { get; set; }
        public int? steam_appid { get; set; }
        public int? required_age { get; set; }
        public bool? is_free { get; set; }
        public int[]? dlc { get; set; }
        public string? detailed_description { get; set; }
        public string? about_the_game { get; set; }
        public string? short_description { get; set; } 
        public string? supported_lenguages {  get; set; }
        public string? header_image { get; set; }
        public string? capsule_image { get; set; }
        public string? capsule_imagev5 { get; set; }
        public string? website { get; set; }
        [JsonProperty("pc_requirements")]
        [JsonConverter(typeof(SingleOrArrayConverter<PcRequirements>))]
        public List<PcRequirements>? pc_requirements { get; set; }
        [JsonProperty("mac_requirements")]
        [JsonConverter(typeof(SingleOrArrayConverter<MacRequirements>))]
        public List<MacRequirements>? mac_requirements { get; set; }
        [JsonProperty("linux_requirements")]
        [JsonConverter(typeof(SingleOrArrayConverter<LinuxRequirements>))]
        public List<LinuxRequirements>? linux_requirements { get; set; }
        public string[]? developers { get; set; }
        public string[]? publishers { get; set; }
        public int[]? packages { get; set; }
        public PackageGroups[]? package_groups { get; set; }
        public Platforms? platforms { get; set; }
        public Category[]? categories { get; set; }
        public Genre[]? genres { get; set; }
        public Screenshot[]? screenshots { get; set; }
        public Movie[]? movies { get; set; }
        public Recommendations? recommendations { get; set; }
        public Achievements? achievements { get; set; }
        public ReleaseDate? release_date { get; set; }
        public SupportInfo? support_info { get; set; }
        public string? background { get; set; }
        public string? background_raw { get; set; }
        public ContentDescriptors? content_descriptors { get; set; }
        public Ratings? ratings { get; set; }
    }
}
