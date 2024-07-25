using System;
using System.Net.Http.Headers;
using FlaggGaming.Model.apiEpic;
using FlaggGaming.Model.juegoFlagg;
using Newtonsoft.Json;
namespace FlaggGaming.Services.ServiciosAPIEpic;

public class JuegosEpicListaParcialService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly HttpClient _httpClient;

	public JuegosEpicListaParcialService(IHttpClientFactory httpClientFactory)
	{
        _httpClientFactory = httpClientFactory;
	}

	public JuegosEpicListaParcialService() { }

    //sobrecarga del método que recibe object para poder ser usado en servicio con timer
	public async Task<List<JuegoFlagg>> getListaJuegosEpic(object? state)
	{
		Console.WriteLine("<< getListaJuegosEpic >>");
		List<JuegoFlagg> flaggGamesList = new List<JuegoFlagg>();

		var _httpClient = _httpClientFactory.CreateClient("clienteEpic");
		_httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        for (int i = 0; i < 10225; i += 1000)
		{
            var respuesta = await _httpClient.GetAsync(ConsultaApiEpic.armarConsultaEpic(" ", 5, "", "asc", i));
			ObjetoJsonEpicGraphql objetoJson = new ObjetoJsonEpicGraphql();


            if (respuesta.IsSuccessStatusCode)
			{
				var jsonDeApi = respuesta.Content.ReadAsStringAsync();
				objetoJson = JsonConvert.DeserializeObject<ObjetoJsonEpicGraphql>(jsonDeApi.Result);

				int contar = 0;

                foreach(Element juego in objetoJson.data.catalog.searchStore.elements)
				{
                    JuegoFlagg flaggGame = new JuegoFlagg();
                    flaggGame.nombre = juego.title;
                    flaggGame.descripcionCorta = juego.description;
                    flaggGame.tienda = "Epic";
                    flaggGame.precio = Decimal.Parse(juego.price.totalPrice.fmtPrice.discountPrice);
                    flaggGame.estudio = juego.seller.name;

                    if (juego.keyImages != null)
                    {
                        foreach (KeyImage image in juego.keyImages)
                        {
                            if (image.type == "Thumbnail") { flaggGame.imagenMini = image.url; }

                            if (image.type == "OfferImageWide"){ flaggGame.imagen = image.url; } 
                            else if (image.type == "OfferImageTall") { flaggGame.imagen = image.url; }
                        }
                    }
                    else { Console.WriteLine($"El juego {juego.title} no contiene imagenes realacionadas"); }

					
					Console.WriteLine(juego.title);
                    flaggGamesList.Add(flaggGame);

                    contar++;
                    if (contar == 10) break;
                }
			}
        }
		
		return flaggGamesList;
	}


    public async Task<List<Element>> getListaJuegosEpic()
    {
        Console.WriteLine("<< getListaJuegosEpic >>");
        List<Element> elements = new List<Element>();

        var _httpClient = _httpClientFactory.CreateClient("clienteEpic");
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        for (int i = 0; i < 10225; i += 1000)
        {
            var respuesta = await _httpClient.GetAsync(ConsultaApiEpic.armarConsultaEpic(" ", 5, "", "asc", i));
            ObjetoJsonEpicGraphql objetoJson = new ObjetoJsonEpicGraphql();


            if (respuesta.IsSuccessStatusCode)
            {
                var jsonDeApi = respuesta.Content.ReadAsStringAsync();
                objetoJson = JsonConvert.DeserializeObject<ObjetoJsonEpicGraphql>(jsonDeApi.Result);

                int contar = 0;

                foreach (Element juego in objetoJson.data.catalog.searchStore.elements)
                {
                    contar++;
                    if (contar < 5) Console.WriteLine(juego.title);
                    elements.Add(juego);
                    if (contar == 10) break;
                }
            }
        }

        return elements;
    }
}
