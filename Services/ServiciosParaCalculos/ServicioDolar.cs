using FlaggGaming.Model.objetosCalculos;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace FlaggGaming.Services.ServiciosParaCalculos;

public class ServicioDolar
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    string urlDolar = "https://dolarapi.com/v1/dolares/tarjeta";
    public ServicioDolar(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<decimal> getValorDolarTarjeta()
    {
        Console.WriteLine("\t\t>>> ServicioDolar - getValorDolarTarjeta:\n\t\tSolicitando >> VALOR Dolar Tarjeta");
        Task<decimal> tareaDolar = Task<decimal>.Factory.StartNew
            (
                () =>
                {
                    Console.WriteLine(">>1");
                    var _httpClient = _httpClientFactory.CreateClient("clienteDolarTarjeta");
                    DolarTarjeta objetoDolarTarjeta = new DolarTarjeta();
                    _httpClient.BaseAddress = new Uri(urlDolar);
                    _httpClient.DefaultRequestHeaders.Clear();
                    Console.WriteLine(">>2");
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Console.WriteLine(">>3");
                    var respuestaDeApi = async Task<HttpResponseMessage> () => { return await _httpClient.GetAsync(_httpClient.BaseAddress).ConfigureAwait(false); };
                    Console.WriteLine(">>4");
                    if (respuestaDeApi().Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine(">>5");
                        Console.WriteLine($"\t\tRespuesta de API positiva para >> VALOR Dolar Tarjeta");
                        var jsonDeApi = async Task<String> () => { return await respuestaDeApi().Result.Content.ReadAsStringAsync(); };
                        Console.WriteLine("RESPUESTA DE API POR >> Dolar Tarjeta: " + jsonDeApi().Result);

                        JObject objetoJson = JObject.Parse(jsonDeApi().Result);
                        objetoDolarTarjeta = JsonConvert.DeserializeObject<DolarTarjeta>(jsonDeApi().Result);
                        Console.WriteLine(">>6");
                        if (jsonDeApi().Result == "null")
                        {
                            Console.WriteLine(">>7A");
                            objetoDolarTarjeta = null;
                            Console.WriteLine($"\t\tLa busqueda de >>VALOR Dolar Tarjeta dio NULL");
                        }
                        Console.WriteLine(">>7B");
                    }
                    return objetoDolarTarjeta.venta;
                }
            );

        return tareaDolar.Result;

    }
}