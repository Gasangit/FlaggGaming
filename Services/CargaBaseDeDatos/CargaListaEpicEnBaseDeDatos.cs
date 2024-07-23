using FlaggGaming.Services.ServiciosAPIEpic;
using FlaggGaming.Entity;
using FlaggGaming.Model.apiEpic;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.EntityFrameworkCore;

namespace FlaggGaming.Services.CargaBaseDeDatos
{
    public class CargaListaEpicEnBaseDeDatos
    {
        private readonly DatosContext _context;
        private readonly JuegosEpicListaParcialService _listaTotalEpic;
        private readonly IServiceProvider _serviceProvider;
        public CargaListaEpicEnBaseDeDatos() { }
        public CargaListaEpicEnBaseDeDatos(DatosContext context, JuegosEpicListaParcialService listaTotal)
        {
            this._context = context;
            this._listaTotalEpic = listaTotal;
        }

       /* public async Task insertListaEpicEnBD(object? state)
        {
            List<Element> lista = _listaTotalEpic.getListaJuegosEpic().Result.applist.apps;
            List<Element> listaContexto = _context.listaJuegos.AsNoTracking().ToList();

            if (lista != null)
            {
                bool actualizar;
                int count = 0;
                foreach (ItemListaJuegoSteam juegoDeTienda in lista)
                {
                    juegoDeTienda.created_at = DateTime.Now;
                    actualizar = false;
                    count++;
                    foreach (ItemListaJuegoSteam unJuegoBd in listaContexto)
                    {
                        if (juegoDeTienda.appid == unJuegoBd.appid)
                        {
                            actualizar = true;
                        }
                    }

                    if (actualizar) _context.listaJuegos.Update(juegoDeTienda);
                    else _context.listaJuegos.Add(juegoDeTienda);

                    if (count > 9) break;

                    _context.SaveChanges();
                }
            }
        }*/
    }
}