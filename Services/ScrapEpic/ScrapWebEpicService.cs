using HtmlAgilityPack;
//using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Azure;
using static System.Net.WebRequestMethods;


namespace FlaggGaming.Services.ScrapEpic
{
    public class ScrapWebEpicService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private string _url = "https://store.epicgames.com/es-ES/browse?sortBy=releaseDate&sortDir=DESC&category=Game&count=40";

        public ScrapWebEpicService() { }

        public ScrapWebEpicService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> getHtmlEpicStore(string fullUrl)
        {
            var _httpClient = _httpClientFactory.CreateClient("scrapWebEpic");
            _httpClient.DefaultRequestHeaders.Add("User-Agent",RotadorDeUserAgentsForScrap.obtenerUserAgentParaScrap());
            _httpClient.DefaultRequestHeaders.Add("Sec - Ch - Ua - Mobile","?0");
            Console.WriteLine("\r\n>>>CLASE ScrapWebEpicService - Header HTTP enviada : \r\n" + _httpClient.DefaultRequestHeaders.ToString() + "\r\n");
            var htmlString = await _httpClient.GetStringAsync(fullUrl);
            return htmlString;
        }

        public List<string> getListaJuegosEpic()
        {
            string htmlString = getHtmlEpicStore(_url).Result;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            List<string> listaJuegos = new List<string>();

            var programmerLinks = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains("css-rgqwpc"))
                .ToList();

            foreach (var link in programmerLinks)
            {
                if (link.Attributes.Count > 0) listaJuegos.Add("https://store.epicgames.com/" + link.Attributes[0].Value); // despues de link iria FirstChild es decir link.FirstChild...
            }

            return listaJuegos;
        }

    }
}
