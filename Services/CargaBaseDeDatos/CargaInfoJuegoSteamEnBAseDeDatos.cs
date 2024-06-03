using FlaggGaming.Services.ServiciosAPISteam;
using FlaggGaming.Entity;

namespace FlaggGaming.Services.CargaBaseDeDatos
{
    public class CargaInfoJuegoSteamEnBAseDeDatos
    {
        private JuegoSteamService _juegoSteamService;
        private DatosContext _context;
        
        public CargaInfoJuegoSteamEnBAseDeDatos(DatosContext context, JuegoSteamService juegoSteamService) 
        {
            _context = context;
            _juegoSteamService = juegoSteamService;
        }

        public async void insertJuegosSteamEnBD() { 
        
            
        }
    }
}
