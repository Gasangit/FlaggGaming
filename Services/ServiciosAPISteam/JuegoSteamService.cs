using FlaggGaming.Model.apiSteamJuego;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace FlaggGaming.Services.ServiciosAPISteam
{
    public class JuegoSteamService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        public JuegoSteamService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, JuegoSteam>> getJuegoSteam(string gameId)
        {
            Console.WriteLine("\t\t>>> JuegoSteamService - getJuegoSteam:\n\t\tSolicitando DATOS de juego a STEAM");
            Task<Dictionary<string, JuegoSteam>> tareaJuego = Task<Dictionary<string, JuegoSteam>>.Factory.StartNew
                (
                    () =>
                    {
                        var _httpClient = _httpClientFactory.CreateClient("clienteJuegoSteam");
                        string urlJuego = $"https://store.steampowered.com/api/appdetails?appids={gameId}&cc=ar";//gameId
                        Dictionary<string, JuegoSteam> diccionarioJson = new Dictionary<string, JuegoSteam>();
                        _httpClient.BaseAddress = new Uri(urlJuego);
                        _httpClient.DefaultRequestHeaders.Clear();
                        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var respuestaDeApi = async Task<HttpResponseMessage> () => { return await _httpClient.GetAsync(_httpClient.BaseAddress); };

                        if (respuestaDeApi().Result.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"\t\tRespuesta de API positiva para el juego con ID: {gameId}");
                            var jsonDeApi = async Task<String> () => { return await respuestaDeApi().Result.Content.ReadAsStringAsync(); };
                            Console.WriteLine("RESPUESTA DE API STEAM POR JUEGO: " + jsonDeApi().Result);
                            
                            JObject objetoJson = JObject.Parse(jsonDeApi().Result);
                            //Console.WriteLine("Prueba de atributo de objeto json : " + objetoJson[$"{gameId}"]["name"]);
                                //JObject jsonJuegoSteam = JObject.Parse(jsonDeApi().Result);
                                diccionarioJson = JsonConvert.DeserializeObject<Dictionary<string, JuegoSteam>>(jsonDeApi().Result);
                            if (jsonDeApi().Result == "null")
                            {
                                diccionarioJson = null;
                                Console.WriteLine($"\t\tLa busqueda del juego con ID: {gameId} dio NULL");
                            }
                        }
                        return diccionarioJson;
            }
        );

            return  tareaJuego.Result;
            
        }
    }
}
