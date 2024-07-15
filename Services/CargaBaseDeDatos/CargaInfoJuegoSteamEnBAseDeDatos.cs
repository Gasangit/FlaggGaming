using FlaggGaming.Services.ServiciosAPISteam;
using FlaggGaming.Entity;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.juegoFlagg;
using System.Diagnostics.Eventing.Reader;

namespace FlaggGaming.Services.CargaBaseDeDatos
{
    public class CargaInfoJuegoSteamEnBAseDeDatos
    {
        private JuegoSteamService _juegoSteamService;
        private JuegosListaTotalService _juegosListaTotalService;
        private DatosContext _context;

        public CargaInfoJuegoSteamEnBAseDeDatos(DatosContext context, JuegoSteamService juegoSteamService, JuegosListaTotalService juegosListaTotalService)
        {
            _context = context;
            _juegoSteamService = juegoSteamService;
            _juegosListaTotalService = juegosListaTotalService;
        }

        public async Task insertJuegosSteamEnBD(Object? state) {

            List<ItemListaJuegoSteam> listaJuegos = _context.listaJuegos.ToList();
            List<JuegoFlagg> listaJuegosData = _context.listaJuegosData.ToList();

            if (listaJuegos != null)
            {
                int conteo = 0;
                foreach (ItemListaJuegoSteam juegoDeLista in listaJuegos)
                {
                    conteo++;
                    if (conteo > 3) break;

                   foreach(JuegoFlagg  itemJuegoFlagg in listaJuegosData)
                   {
                        if (juegoDeLista.appid == itemJuegoFlagg.idJuegoTienda)
                        {
                            Dictionary<string, JuegoSteam> juegoSteamDictionary = await _juegoSteamService.getJuegoSteam(juegoDeLista.appid.ToString());

                            string idJuego = itemJuegoFlagg.idJuegoTienda.ToString();

                           JuegoFlagg juegoFlagg = new JuegoFlagg(
                                juegoSteamDictionary[idJuego].data.short_description,
                                juegoSteamDictionary[idJuego].data.header_image,
                                juegoSteamDictionary[idJuego].data.capsule_image,
                                juegoSteamDictionary[idJuego].data.website,
                                juegoSteamDictionary[idJuego].data.pc_requirements[0].minimum
                           );

                            listaJuegosData.Add(juegoFlagg);
                        }                        
                   }
                }

                _context.SaveChanges();
            }
            else
            {
                await _juegosListaTotalService.getListaJuegosSteam();   
            }
        }
    }
}
