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
	public async Task<List<JuegoFlagg>> getListaJuegosEpic()
	{
		Console.WriteLine("<< getListaJuegosEpic >>");
		List<JuegoFlagg> flaggGamesList = new List<JuegoFlagg>();

		var _httpClient = _httpClientFactory.CreateClient("clienteEpic");
		_httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        int contar = 0;
        int contarJuegos = 0;
        bool esJuego;

        for (int i = 0; i < 9370 /*10225*/; i += 100)
		{
            var respuesta = await _httpClient.GetAsync(ConsultaApiEpic.armarConsultaEpic(" ", 100, "", "asc", i));
			ObjetoJsonEpicGraphql objetoJson = new ObjetoJsonEpicGraphql();      

            if (respuesta.IsSuccessStatusCode)
			{
				var jsonDeApi = respuesta.Content.ReadAsStringAsync();
				objetoJson = JsonConvert.DeserializeObject<ObjetoJsonEpicGraphql>(jsonDeApi.Result);

                foreach(Element juego in objetoJson.data.catalog.searchStore.elements)
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

                    if (esJuego)
                    {
                        JuegoFlagg flaggGame = new JuegoFlagg();
                        flaggGame.nombre = juego.title;
                        flaggGame.descripcionCorta = juego.description;
                        flaggGame.tienda = "Epic";
                        //flaggGame.precio = Decimal.Parse(juego.price.totalPrice.fmtPrice.discountPrice);
                        flaggGame.estudio = juego.seller.name;

                        if (juego.keyImages != null && juego.keyImages.Count > 0)
                        {
                            foreach (KeyImage image in juego.keyImages)
                            {
                                if (image.type == "Thumbnail") { flaggGame.imagenMini = image.url; }

                                if (image.type == "OfferImageWide") { flaggGame.imagen = image.url; }
                                else if (image.type == "OfferImageTall") { flaggGame.imagen = image.url; }
                            }
                        }
                        else { Console.WriteLine($"\tEl juego {juego.title} no contiene imagenes realacionadas"); }

                        
                        flaggGamesList.Add(flaggGame);
                    }

                }
			}
        }
        Console.WriteLine($"\n\n\tSe VERIFICAN {contar} Elements");
        Console.WriteLine($"\tSe encontraron {contarJuegos} juegos.\n\n");

        return flaggGamesList;
	}

    /*public async Task<List<Element>> getListaJuegosEpicPrueba()
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
    }*/
}