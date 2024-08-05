using FlaggGaming.Services.ServiciosAPISteam;
using FlaggGaming.Entity;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.juegoFlagg;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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

        public async Task insertJuegosSteamEnBD(object? state)
        {
            Console.WriteLine(">>> CargaInfoJuegoSteamEnBAseDeDatos - insertJuegosSteamEnBD: \n \tCARGANDO LISTA Y JUEGOS STEAM");
            List<ItemListaJuegoSteam> listaJuegosTotalBD;
            List<JuegoFlagg> listaJuegosDataBD;
            bool verificarEnlistaTotalYDataBD;
            bool encontradoEnListaTotalBD;
            bool encontradoEnListaDataBD;
            int count = 0;
            int partialCount = 0;
            int countAddListaTotal = 0;
            int countAddListaData = 0;
            int countUpdateListaData = 0;

            ObjetoJsonListaJuegos listaJuegosSteam = _juegosListaTotalService.getListaJuegosSteam().Result;
            Console.WriteLine("\tLlamado a API STEAM para obtener lista.");
            string idJuegoString;

            Console.WriteLine("\tIteración lista API STEAM");
            foreach (ItemListaJuegoSteam juegoDeListaSteam in listaJuegosSteam.applist.apps)
            {
                Console.WriteLine($"\t-Se verificará el juego {juegoDeListaSteam.appid} - {juegoDeListaSteam.name}");

                idJuegoString = "";
                verificarEnlistaTotalYDataBD = false;
                encontradoEnListaTotalBD = false;
                encontradoEnListaDataBD = false;
                string minimumPcRequirements;

                idJuegoString = juegoDeListaSteam.appid.ToString();

                //el id 3132780 da null al buscar en la API al igual que el id 1349523
                Dictionary<string, JuegoSteam> dicccionarioJuegoSteam = null;
                dicccionarioJuegoSteam = /*await*/ _juegoSteamService.getJuegoSteam(idJuegoString);

                if (dicccionarioJuegoSteam[idJuegoString] != null)
                {
                    Console.WriteLine($"\t\t¿El JUEGO fue lanzado?: {dicccionarioJuegoSteam[idJuegoString].success}");
                    if (dicccionarioJuegoSteam[idJuegoString].success)
                    {
                        if (dicccionarioJuegoSteam[idJuegoString].data.type == "game")
                        {
                            verificarEnlistaTotalYDataBD = true;
                            Console.WriteLine("\t\tEl juego fue lanzado y es un JUEGO (no DLC)");
                        }
                    }
                }
                if (verificarEnlistaTotalYDataBD)
                {
                    Console.WriteLine("\t\tBusqueda de juego en lista existente");
                    listaJuegosTotalBD = _context.listaJuegos.ToList();
                    foreach (ItemListaJuegoSteam juegoDeListaBD in listaJuegosTotalBD)
                    {
                        if (juegoDeListaBD.appid.ToString() == idJuegoString)
                        {
                            encontradoEnListaTotalBD = true;
                            Console.WriteLine($"\t\t<SI> Se encontro el juego en la LISTA IDTIENDA BD: {juegoDeListaBD.appid.ToString(idJuegoString)} ID STEAM: {idJuegoString}");
                            break;
                        }
                        Console.Write(partialCount++ + " - ");
                    }
                    if (!encontradoEnListaTotalBD)
                    {
                        Console.WriteLine("\t\t<NO> Se encontro el juego en la LISTA. Se AGREGA a la misma");
                        juegoDeListaSteam.created_at = DateTime.Now;
                        _context.listaJuegos.Add(juegoDeListaSteam);
                        countAddListaTotal++;
                    }
                    Console.WriteLine($"\t\tSe COMPARÓ con {partialCount} JUEGOS de la lista.");
                    partialCount = 0;

                    listaJuegosDataBD = _context.listaJuegosData.ToList();
                    foreach (JuegoFlagg juegoFlaggDataBD in listaJuegosDataBD)
                    {
                        Console.WriteLine("\t\tSe recorre la lista de DATOS del JUEGO");
                        if (juegoFlaggDataBD.idJuegoTienda.ToString() == idJuegoString)
                        {
                            encontradoEnListaDataBD = true;
                            Console.WriteLine("\t\t<SI> Se encontró en lista de DATOS del JUEGO");
                        }
                        
                        if (encontradoEnListaDataBD)
                        {
                            Console.WriteLine("\t\tSe ACTUALIZAN los datos del juego en la lista.");
                            minimumPcRequirements = "";
                            if (dicccionarioJuegoSteam[idJuegoString].data.pc_requirements.Count > 0)
                            {
                                minimumPcRequirements = dicccionarioJuegoSteam[idJuegoString].data.pc_requirements[0].minimum;
                            }

                            juegoFlaggDataBD.descripcionCorta = dicccionarioJuegoSteam[idJuegoString].data.short_description;
                            juegoFlaggDataBD.imagen = dicccionarioJuegoSteam[idJuegoString].data.header_image;
                            juegoFlaggDataBD.imagenMini = dicccionarioJuegoSteam[idJuegoString].data.capsule_image;
                            juegoFlaggDataBD.requisitos = minimumPcRequirements;
                            juegoFlaggDataBD.nombre = dicccionarioJuegoSteam[idJuegoString].data.name;
                            juegoFlaggDataBD.idJuegoTienda = Convert.ToInt32(idJuegoString);
                            juegoFlaggDataBD.estudio = dicccionarioJuegoSteam[idJuegoString].data.publishers[0];
                            juegoFlaggDataBD.urlTienda = "https://store.steampowered.com/app/" + idJuegoString;

                            _context.listaJuegosData.Update(juegoFlaggDataBD);
                            countUpdateListaData++;
                            break;
                        }
                        Console.Write(partialCount++ + " - ");
                    }
                    Console.WriteLine($"\t\tSe COMPARÓ con {partialCount} JUEGOS de la lista de DATOS.");
                    partialCount = 0;

                    if (!encontradoEnListaDataBD)
                    {
                        Console.WriteLine("\t\t<NO> Se encontró en lista de DATOS del JUEGO. Se agregan los datos del JUEGO a la lista.");
                        minimumPcRequirements = "";
                        if (dicccionarioJuegoSteam[idJuegoString].data.pc_requirements.Count > 0)
                        {
                            minimumPcRequirements = dicccionarioJuegoSteam[idJuegoString].data.pc_requirements[0].minimum;
                        }

                        JuegoFlagg juegoFlaggParaAgregar = new JuegoFlagg();
                        juegoFlaggParaAgregar.idFlagg = Guid.NewGuid();
                        juegoFlaggParaAgregar.descripcionCorta = dicccionarioJuegoSteam[idJuegoString].data.short_description;
                        juegoFlaggParaAgregar.imagen = dicccionarioJuegoSteam[idJuegoString].data.header_image;
                        juegoFlaggParaAgregar.imagenMini = dicccionarioJuegoSteam[idJuegoString].data.capsule_image;
                        juegoFlaggParaAgregar.requisitos = minimumPcRequirements;
                        juegoFlaggParaAgregar.nombre = dicccionarioJuegoSteam[idJuegoString].data.name;
                        juegoFlaggParaAgregar.contadorVistas = 0;
                        juegoFlaggParaAgregar.idJuegoTienda = Convert.ToInt32(idJuegoString);
                        juegoFlaggParaAgregar.tienda = "Steam";
                        juegoFlaggParaAgregar.estudio = dicccionarioJuegoSteam[idJuegoString].data.publishers[0];
                        juegoFlaggParaAgregar.urlTienda = "https://store.steampowered.com/app/" + idJuegoString;
                        _context.listaJuegosData.Add(juegoFlaggParaAgregar);
                        countAddListaData++;
                    }
                }
                count++;
                /*if (count > 50) break;*/
                if(count == 100) _context.SaveChanges();
            }
            Console.WriteLine($"TOTAL JUEGOS EN LISTA DE STEAM: {listaJuegosSteam.applist.apps.Count}");
            Console.WriteLine($"TOTAL JUEGOS VERIFICADOS: {count}");
            Console.WriteLine($"TOTAL JUEGOS AGREGADOS EN <LISTA TOTAL>: {countAddListaTotal}");
            Console.WriteLine($"TOTAL JUEGOS AGREGADOS EN <LISTA DATA (ADD)>: {countAddListaData}");
            Console.WriteLine($"TOTAL JUEGOS AGREGADOS EN <LISTA DATOA (UPDATE)>: {countUpdateListaData}");
        }
    }
}
