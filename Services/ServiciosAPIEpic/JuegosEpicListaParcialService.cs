using System;
using System.Net.Http.Headers;
using FlaggGaming.Model.apiEpic;
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
	public async Task<List<Element>> getListaJuegosEpic(object? state)
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

                foreach(Element juego in objetoJson.data.catalog.searchStore.elements)
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
