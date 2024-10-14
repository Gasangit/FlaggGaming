//using EpicGamesStoreNET;
using EpicGamesStoreNET.Models;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FlaggGaming.Services.EpicGameStoreNet
{
    public class EpicGameStoreNetService
    {

        public async Task<Element[]> obtenerJuegosEpic(string consultaJuego)
        {
            var resp = await EpicGamesStoreNET.Query.SearchAsync(consultaJuego);
            var listings = resp.Data.Catalog.SearchStore.Elements;

            return listings;
        }
    }
}
