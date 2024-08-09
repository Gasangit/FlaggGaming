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
            List<JuegoFlagg> listaJuegosEnBD;
            List<JuegoFlagg> listaDesdeEpic = _juegosEpicService.getListaJuegosEpic().Result;
            bool juegoEncontrado;

            foreach (JuegoFlagg juegoDesdeEpic in listaDesdeEpic)
            {
                juegoEncontrado = false;

                listaJuegosEnBD = _context.listaJuegosData.ToList();
                foreach (JuegoFlagg juegoFlaggEnBD in listaJuegosEnBD)
                {
                    if (juegoDesdeEpic.nombre == juegoFlaggEnBD.nombre && juegoFlaggEnBD.tienda == "Epic") 
                    { 
                        juegoEncontrado = true;
                        Console.WriteLine("\tEl JUEGO ya se ENCUENTRA en la BASE DE DATOS" +
                            $"\n\t\tNombre EPIC: {juegoDesdeEpic.nombre}  // Nombre BD: {juegoFlaggEnBD.nombre}");
                    }
                }
                /*  Juegos que se repitieron en la base de datos 2, 13 y 13 veces respectivamente.
                    CobblerDevAudience
                    Contingent®?
                    Cyber:Mind Dive
                 */

                if (!juegoEncontrado)
                {
                    juegoDesdeEpic.idFlagg = Guid.NewGuid();
                    juegoDesdeEpic.contadorVistas = 0; //quitar esto después
                    juegoDesdeEpic.idJuegoTienda = 0; //quitar esto después
                    Console.WriteLine("\tJuego AGREGADO EPIC: " + juegoDesdeEpic.nombre + " GUID: " + juegoDesdeEpic.idFlagg + " TIENDA: " + juegoDesdeEpic.tienda);

                    _context.listaJuegosData.Add(juegoDesdeEpic);
                }
            }
            _context.SaveChanges();
            Console.WriteLine("Juegos enviados a la BASE DE DATOS");
        }
    }
}