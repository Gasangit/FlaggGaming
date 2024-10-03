using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using FlaggGaming.Model.juegoFlagg;
using FlaggGaming.Model.apiEpic;namespace FlaggGaming.Services.ServiciosAPIEpic;

using System.Globalization;

public class JuegoEpicService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public JuegoEpicService(IHttpClientFactory httpClientFactory) 
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<decimal> getPrecioJuegoEpic(string nombreJuego)
    {
        Console.WriteLine("<< getListaJuegosEpic >>");
        List<JuegoFlagg> flaggGamesList = new List<JuegoFlagg>();
        decimal precioJuegoEpic = 0.0M;
        string precioConSimbolo;
        string precioSinSimbolo;

        var _httpClient = _httpClientFactory.CreateClient("clienteEpic");
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        int contar = 0;
        int contarJuegos = 0;
        bool esJuego;

        var respuesta = await _httpClient.GetAsync(ConsultaApiEpic.armarConsultaEpic(nombreJuego, 10, "title", "asc", 1)).ConfigureAwait(false);
        ObjetoJsonEpicGraphql objetoJson = new ObjetoJsonEpicGraphql();

        if (respuesta.IsSuccessStatusCode)
        {
            var jsonDeApi = respuesta.Content.ReadAsStringAsync();
            objetoJson = JsonConvert.DeserializeObject<ObjetoJsonEpicGraphql>(jsonDeApi.Result);

            foreach (Element juego in objetoJson.data.catalog.searchStore.elements)
            {
                contar++;
                esJuego = false;
                Console.WriteLine($"Se VERIFICA EL JUEGO EPIC: {juego.title}");

                foreach (Category categoria in juego.categories)
                {
                    Console.Write($"\t{categoria.path} - ");
                    Console.WriteLine("");
                    if (categoria.path == "games")
                    {
                        esJuego = true;
                        Console.WriteLine($"\tJuego EPIC CONFIRMADO -> CATEGORÍA: {categoria.path}");
                        contarJuegos++;
                        break;
                    }
                }

                if (esJuego && string.Equals(juego.title, nombreJuego, StringComparison.OrdinalIgnoreCase))
                {
                    
                    precioConSimbolo = juego.price.totalPrice.fmtPrice.discountPrice;
                    precioSinSimbolo = precioConSimbolo.Replace("$", "").Replace(",", "");
                    precioJuegoEpic = Convert.ToDecimal(precioSinSimbolo, CultureInfo.InvariantCulture);

                    Console.WriteLine("JUEGO: " + juego.title + "\nPRECIO ORIGINAL: " +juego.price.totalPrice.fmtPrice.discountPrice + "\nPRECIO FLAGG: " + precioJuegoEpic);
                    break;
                    //flaggGamesList.Add(flaggGame);
                }
            }
        }
        Console.WriteLine($"\n\n\tSe VERIFICAN {contar} Elements");
        Console.WriteLine($"\tSe encontraron {contarJuegos} juegos.\n\n");

        return precioJuegoEpic;
    }
}
