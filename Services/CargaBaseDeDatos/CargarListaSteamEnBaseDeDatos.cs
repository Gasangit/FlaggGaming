using FlaggGaming.Services.APISteam;
using FlaggGaming.Entity;
using FlaggGaming.Model.apiSteamListaJuegosTotal;

namespace FlaggGaming.Services.CargaBaseDeDatos
{
    public class CargarListaSteamEnBaseDeDatos
    {
        private readonly DatosContext _context;
        private readonly JuegosListaTotalService _listaTotal;

        public CargarListaSteamEnBaseDeDatos(DatosContext context, JuegosListaTotalService listaTotal)
        { 
            this._context = context;
            this._listaTotal = listaTotal;
        }

        //ver como hacer funcionar este método en la clase Program para que se ejecute periodicamente.La primera
        //idea es pasarlo estatico para ver si se puede llamar desde Program
        public static void insertListaSteamEnBD()
        {
            List<ItemListaJuegoSteam> lista = JuegosListaTotalService.getListaJuegosSteam().Result.applist.apps;

            if (lista != null)
            {
                int count = 0;
                foreach (ItemListaJuegoSteam juegoDeLista in lista)
                {
                    count++;
                    _context.listaJuegos.Add(juegoDeLista);
                    _context.SaveChanges();

                    if (count > 9) break;
                }
            }

        }
    }
}
