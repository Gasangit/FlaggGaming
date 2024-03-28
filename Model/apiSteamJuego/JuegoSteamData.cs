using Newtonsoft.Json;

namespace FlaggGaming.Model.apiSteamJuego
{
    public class JuegoSteamData
    {
        public string? type { get; }
        public string? name { get; }
        public int? steam_appid { get; }
        public int? required_age { get; }
        public bool? is_free { get; }
        public int[]? dlc { get; }
        public string? detailed_description { get; }
        public string? about_the_game { get; }
        public string? short_description { get; } 
        public string? supported_lenguages {  get; }
        public string? header_image { get; }
        public string? capsule_image { get; }
        public string? capsule_imagev5 { get; }
        public string? website { get; }
        [JsonProperty("pc_requirements")]
        [JsonConverter(typeof(SingleOrArrayConverter<PcRequirements>))]
        public List<PcRequirements>? pc_requirements { get; }
        [JsonProperty("mac_requirements")]
        [JsonConverter(typeof(SingleOrArrayConverter<MacRequirements>))]
        public List<MacRequirements>? mac_requirements { get; }
        [JsonProperty("linux_requirements")]
        [JsonConverter(typeof(SingleOrArrayConverter<LinuxRequirements>))]
        public List<LinuxRequirements>? linux_requirements { get; }
        public string[]? developers { get; }
        public string[]? publishers { get; }
        public int[]? packages { get; }
        public PackageGroups[]? package_groups { get; }
        public Platforms? platforms { get; }
        public Category[]? categories { get; }
        public Genre[]? genres { get; }
        public Screenshot[]? screenshots { get; }
        public Movie[]? movies { get; }
        public Recommendations? recommendations { get; }
        public Achievements? achievements { get; }
        public ReleaseDate? release_date { get; }
        public SupportInfo? support_info { get; }
        public string? background { get; }
        public string? background_raw { get; }
        public ContentDescriptors? content_descriptors { get; }
        public Ratings? ratings { get; }
   }
}
