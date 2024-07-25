using EpicGamesStoreNET.Models;
using FlaggGaming.Entity;
using FlaggGaming.Model.juegoFlagg;
using FlaggGaming.Services.ServiciosAPIEpic;

namespace FlaggGaming.Services.CargaBaseDeDatos
{
    public class CargaInfoJuegoEpicEnBAseDeDatos
    {
        private DatosContext _context;
        private JuegosEpicListaParcialService _juegosEpicService;

        public CargaInfoJuegoEpicEnBAseDeDatos(DatosContext context, JuegosEpicListaParcialService juegosEpic) 
        {
            _context = context;
            _juegosEpicService = juegosEpic;
        }

        public void insertJuegosEpicEnBD(object? state)
        {
            List<JuegoFlagg> listaJuegosInsertBD = _context.listaJuegosData.ToList();
            //List<Element> listaDesdeEpic = _juegosEpicService.getListaJuegosEpic().Result;

            /*foreach (Element juegoDesdeEpic in listaDesdeEpic)
            {
                JuegoFlagg juegoMapeado = new JuegoFlagg();

                //listaJuegosInsertBD.Add(juegoDesdeEpic);
            }

            _context.SaveChanges();*/
        }
    }
}