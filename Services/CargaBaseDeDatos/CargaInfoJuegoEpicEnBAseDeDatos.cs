using EpicGamesStoreNET.Models;
using FlaggGaming.Entity;
using FlaggGaming.Model.juegoFlagg;
using FlaggGaming.Pages.PruebasComp;
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

        public async Task insertJuegosEpicEnBD(object? state)
        {
            List<JuegoFlagg> listaJuegosEnBD = _context.listaJuegosData.ToList();
            List<JuegoFlagg> listaDesdeEpic = _juegosEpicService.getListaJuegosEpic().Result;
            bool juegoEncontrado;

            foreach (JuegoFlagg juegoDesdeEpic in listaDesdeEpic)
            {
                juegoEncontrado = false;

                foreach (JuegoFlagg juegoFlaggEnBD in listaJuegosEnBD)
                {
                    if (juegoDesdeEpic.nombre == juegoFlaggEnBD.nombre) juegoEncontrado = true;
                }

                if (!juegoEncontrado)
                {
                    juegoDesdeEpic.idFlagg = Guid.NewGuid();
                    juegoDesdeEpic.contadorVistas = 0; //quitar esto después
                    juegoDesdeEpic.idJuegoTienda = 0; //quitar esto después
                    Console.WriteLine("\tJuego agregado EPIC: " + juegoDesdeEpic.nombre + " GUID: " + juegoDesdeEpic.idFlagg + " TIENDA: " + juegoDesdeEpic.tienda);

                    _context.listaJuegosData.Add(juegoDesdeEpic);
                }
            }
            _context.SaveChanges();
        }
    }
}