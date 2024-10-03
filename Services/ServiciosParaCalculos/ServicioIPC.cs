using FlaggGaming.Model.objetosCalculos;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using FlaggGaming.Model.objetosCalculos.IPC;

namespace FlaggGaming.Services.ServiciosParaCalculos;

public class ServicioIPC
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    string urlIPC = "https://apis.datos.gob.ar/series/api/series?ids=148.3_INIVELNAL_DICI_M_26&limit=5000&format=json";
    public ServicioIPC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<decimal> getValoresIPC()
    {
        Console.WriteLine("\t\t>>> ServicioIPC - getValoresIPC:\n\t\tSolicitando >> VALORES IPC");
        decimal inflacion = 0.0M;

        Task<decimal> tareaIPC = Task<decimal>.Factory.StartNew
            (
                () =>
                {
                    var _httpClient = _httpClientFactory.CreateClient("clienteValorIPC");
                    InfoIPC objetoIPC = new InfoIPC();
                    _httpClient.BaseAddress = new Uri(urlIPC);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var respuestaDeApi = async Task<HttpResponseMessage> () => { return await _httpClient.GetAsync(_httpClient.BaseAddress).ConfigureAwait(false); };

                    if (respuestaDeApi().Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"\t\tRespuesta de API positiva para >> Valor IPC");
                        var jsonDeApi = async Task<String> () => { return await respuestaDeApi().Result.Content.ReadAsStringAsync(); };
                        Console.WriteLine("RESPUESTA DE API POR >> Valor IPC: " + jsonDeApi().Result);

                        JObject objetoJson = JObject.Parse(jsonDeApi().Result);
                        objetoIPC = JsonConvert.DeserializeObject<InfoIPC>(jsonDeApi().Result);
                        if (jsonDeApi().Result == "null")
                        {
                            Console.WriteLine($"\t\tLa busqueda de >>VALOR IPC dio NULL");
                        }
                        else 
                        {
                            int largoDataIPC = objetoIPC.data.Count;
                            List<object> ipcUltimoDato = objetoIPC.data[largoDataIPC - 1];
                            List<object> ipcAnteUltimoDato = objetoIPC.data[largoDataIPC - 2];
                            decimal ultimoDato = Convert.ToDecimal(ipcUltimoDato[1]);
                            decimal anteultimoDato = Convert.ToDecimal(ipcAnteUltimoDato[1]);
                            inflacion = (((ultimoDato - anteultimoDato) / anteultimoDato) * 100) / 100;

                            Console.WriteLine("DATO INFLACIÓN: " + inflacion);
                        }
                    }
                    return inflacion;
                }
            );

        return tareaIPC.Result;
    }
}