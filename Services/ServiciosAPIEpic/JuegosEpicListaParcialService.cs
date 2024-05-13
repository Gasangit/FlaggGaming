using System;
using System.Net.Http.Headers;
using FlaggGaming.Model.apiEpic;
using Newtonsoft.Json;
namespace FlaggGaming.Services.APIEpic;

public class JuegosEpicListaParcialService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly HttpClient _httpClient;

	public JuegosEpicListaParcialService(IHttpClientFactory httpClientFactory)
	{
        _httpClientFactory = httpClientFactory;
	}

	public async Task<List<Element>> getListaJuegosEpic()
	{
		List<Element> elements = new List<Element>();

		var _httpClient = _httpClientFactory.CreateClient("clienteEpic");
		_httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        for (int i = 0; i < 4001; i += 1000)
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
                }
			}
        }
		
		return elements;
	}
}
