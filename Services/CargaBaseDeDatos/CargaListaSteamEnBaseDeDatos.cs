﻿using FlaggGaming.Services.ServiciosAPISteam;
using FlaggGaming.Entity;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.EntityFrameworkCore;

namespace FlaggGaming.Services.CargaBaseDeDatos
{
    public class CargaListaSteamEnBaseDeDatos
    {
        private readonly DatosContext _context;
        private readonly JuegosListaTotalService _listaTotal;
        private readonly IServiceProvider _serviceProvider;
        public CargaListaSteamEnBaseDeDatos() { }
        public CargaListaSteamEnBaseDeDatos(DatosContext context, JuegosListaTotalService listaTotal)
        { 
            this._context = context;
            this._listaTotal = listaTotal;
        }
        
        public async Task insertListaSteamEnBD(object? state)
        {            
            List<ItemListaJuegoSteam> lista = _listaTotal.getListaJuegosSteam().Result.applist.apps;
            List<ItemListaJuegoSteam> listaContexto = _context.listaJuegos.AsNoTracking().ToList();

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
                    
                    if(actualizar) _context.listaJuegos.Update(juegoDeTienda);
                    else _context.listaJuegos.Add(juegoDeTienda);

                    if (count > 9) break;

                    _context.SaveChanges();
                }
            }
        }
    }
}