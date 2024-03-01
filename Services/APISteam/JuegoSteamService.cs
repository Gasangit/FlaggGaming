using FlaggGaming.Model.apiSteamJuego;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace FlaggGaming.Services.APISteam
{
    public class JuegoSteamService
    {
        private readonly HttpClient _httpClient;
        public JuegoSteamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Dictionary<string, JuegoSteam>> getJuegoSteam(string gameId)
        {
            Task<Dictionary<string, JuegoSteam>> tareaJuego = Task<Dictionary<string, JuegoSteam>>.Factory.StartNew
                (
                    () =>
                    {
                    string urlJuego = $"https://store.steampowered.com/api/appdetails?appids={gameId}&cc=ar";
                    Dictionary<string, JuegoSteam> diccionarioJson = new Dictionary<string, JuegoSteam>();
                    _httpClient.BaseAddress = new Uri(urlJuego);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var respuestaDeApi = async Task<HttpResponseMessage> () => { return await _httpClient.GetAsync(_httpClient.BaseAddress); };

                    if (respuestaDeApi().Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine("respuesta de API positiva");
                        var jsonDeApi = async Task<String> () => { return await respuestaDeApi().Result.Content.ReadAsStringAsync(); };
                        Console.WriteLine(jsonDeApi().Result);

                        JSchemaGenerator generador = new JSchemaGenerator();
                        JSchema schema = generador.Generate(typeof(JuegoSteam));

                        Console.WriteLine($"Esquema : \r\n{schema.ToString()}");
                            JObject jsonJuegoSteam = JObject.Parse(jsonDeApi().Result);

                            Console.WriteLine($"El json coincide con el objeto  : {jsonJuegoSteam.IsValid(schema)}");

                            /*JsonTextReader lecturaPrevia = new JsonTextReader(new StringReader(jsonDeApi().Result));

                            while (lecturaPrevia.Read())
                            {
                                if (lecturaPrevia.Value != null)
                                {
                                    Console.WriteLine("Token: {0}, Value: {1}", lecturaPrevia.TokenType, lecturaPrevia.Value);
                                    if (lecturaPrevia.Value.ToString() == "mac_requirements")
                                    { 
                                        
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Token: {0}", lecturaPrevia.TokenType);
                                }
                            }*/

                            diccionarioJson = JsonConvert.DeserializeObject<Dictionary<string, JuegoSteam>>(jsonDeApi().Result);
                        }
                        return diccionarioJson;
                    }
                );

            return await tareaJuego;
        }
    }
}
