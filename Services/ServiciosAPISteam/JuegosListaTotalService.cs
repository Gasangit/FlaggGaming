using System;
//using FlaggGaming.Services.APISteam;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace FlaggGaming.Services.APISteam
{

    public class JuegosListaTotalService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public JuegosListaTotalService() { }
        public JuegosListaTotalService(IHttpClientFactory httpClientFactory)
        {
             _httpClientFactory = httpClientFactory;
        }
        
        public async Task<ObjetoJsonListaJuegos> getListaJuegosSteam()
        {
            Task<ObjetoJsonListaJuegos> tareaAppList = Task<ObjetoJsonListaJuegos>.Factory.StartNew
                (
                    () =>
                    {
                        var _httpClient = _httpClientFactory.CreateClient("apiListaJuegos");
                        ObjetoJsonListaJuegos objetoJson = new();

                        _httpClient.BaseAddress = new Uri("https://api.steampowered.com/ISteamApps/GetAppList/v2/");
                        _httpClient.DefaultRequestHeaders.Clear();
                        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var respuestaDeApi = async Task<HttpResponseMessage> () => { return await _httpClient.GetAsync(_httpClient.BaseAddress); };

                        Console.WriteLine(respuestaDeApi().Result.StatusCode.ToString());

                        if (respuestaDeApi().Result.IsSuccessStatusCode)
                        {
                            var jsonDeApi = async Task<String> () => { return await respuestaDeApi().Result.Content.ReadAsStringAsync(); };
                            objetoJson = JsonConvert.DeserializeObject<ObjetoJsonListaJuegos>(jsonDeApi().Result);

                        }

                        return objetoJson;
                    }
                );

            return await tareaAppList;
        }

        
    }
}
