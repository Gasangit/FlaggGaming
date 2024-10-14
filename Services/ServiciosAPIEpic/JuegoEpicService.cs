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
        Console.WriteLine("<< JuegoEpicService - getPrecioJuegoEpic >>");
        List<JuegoFlagg> flaggGamesList = new List<JuegoFlagg>();
        decimal precioJuegoEpic = 0.0M;
        string precioConSimbolo;
        string precioSinSimbolo;
        string consulta;

        var _httpClient = _httpClientFactory.CreateClient("clienteEpic");
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        int contar = 0;
        int contarJuegos = 0;
        bool esJuego;

        consulta = ConsultaApiEpic.armarConsultaEpic(nombreJuego, 10, "title", "asc", 0);
        //Console.WriteLine($"\t\tConsulta enviada a EPIC: {consulta}");
        var respuesta = await _httpClient.GetAsync(consulta).ConfigureAwait(false);
        ObjetoJsonEpicGraphql objetoJson = new ObjetoJsonEpicGraphql();

        if (respuesta.IsSuccessStatusCode)
        {
            var jsonDeApi = respuesta.Content.ReadAsStringAsync();
            objetoJson = JsonConvert.DeserializeObject<ObjetoJsonEpicGraphql>(jsonDeApi.Result);

            foreach (Element juego in objetoJson.data.catalog.searchStore.elements)
            {
                contar++;
                esJuego = false;
                Console.WriteLine($"\t\tSe VERIFICA EL JUEGO EPIC: {juego.title}\n\t\tSe COMPARA con el nombre ingresado: {nombreJuego}");

                foreach (Category categoria in juego.categories)
                {
                    Console.Write($"\t\t{categoria.path} - ");
                    if (categoria.path == "games")
                    {
                        esJuego = true;
                        Console.WriteLine($"\t\tJuego EPIC CONFIRMADO -> CATEGORÍA: {categoria.path}");
                        contarJuegos++;
                        break;
                    }
                }

                if (esJuego && string.Equals(juego.title, nombreJuego, StringComparison.OrdinalIgnoreCase))
                {

                    precioConSimbolo = juego.price.totalPrice.fmtPrice.discountPrice;
                    precioSinSimbolo = precioConSimbolo.Replace("$", "").Replace(",", "");
                    precioJuegoEpic = Convert.ToDecimal(precioSinSimbolo, CultureInfo.InvariantCulture);

                    Console.WriteLine("\t\tJUEGO: " + juego.title + "\n\t\tPRECIO ORIGINAL: " + juego.price.totalPrice.fmtPrice.discountPrice + "\n\t\tPRECIO FLAGG: " + precioJuegoEpic);
                    break;
                    //flaggGamesList.Add(flaggGame);
                }
                else { Console.WriteLine($"\t\tLos nombres {juego.title} y {nombreJuego} se vefican como DISTINTOS."); }
            }
        }
        Console.WriteLine($"\n\n\t\tSe VERIFICAN {contar} Elements");
        Console.WriteLine($"\t\tSe encontraron {contarJuegos} juegos.\n\n");

        return precioJuegoEpic;
    }
}
