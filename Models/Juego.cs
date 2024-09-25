using System;
using System.Collections.Generic;

namespace FlaggGaming.Models;

public partial class Juego
{
    public Guid IdFlagg { get; set; }

    public int IdJuegoTienda { get; set; }

    public string? Nombre { get; set; }

    public string? DescripcionCorta { get; set; }

    public string Tienda { get; set; } = null!;

    public string? Imagen { get; set; }

    public string? ImagenMini { get; set; }

    public string? UrlTienda { get; set; }

    public string? Requisitos { get; set; }

    public string Estudio { get; set; } = null!;

    public int ContadorVistas { get; set; }

    public string? UrlEpic { get; set; }

    public string? IdOferta { get; set; }

    public Guid? OfertaidOferta { get; set; }
}
