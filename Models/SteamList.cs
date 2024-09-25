using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class SteamList
{
    public int Appid { get; set; }

    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; }
}
