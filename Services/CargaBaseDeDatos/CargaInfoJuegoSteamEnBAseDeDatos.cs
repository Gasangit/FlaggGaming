using FlaggGaming.Services.ServiciosAPISteam;
using FlaggGaming.Entity;
using FlaggGaming.Model.apiSteamListaJuegosTotal;
using FlaggGaming.Model.apiSteamJuego;
using FlaggGaming.Model.juegoFlagg;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;
using System.Collections.Specialized;

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
            Console.WriteLine(">>>> MÉTODO -> insertJuegosSteamEnBD" + " "  +  DateTime.Now);
            List<ItemListaJuegoSteam> listaJuegos = _context.listaJuegos.ToList();
            List<JuegoFlagg> listaJuegosData = _context.listaJuegosData.ToList();
            bool actualizado;

            if (listaJuegos.Count > 0)
            {
                
                foreach (ItemListaJuegoSteam juegoDeLista in listaJuegos)
                {
                    actualizado = false;//<= puede ser que por esto duplique
                    Console.WriteLine("FOREACH JUEGOS API STEAM BD");
                   JuegoFlagg juegoFlagg = new JuegoFlagg();
                    Dictionary<string, JuegoSteam> juegoSteamDictionary = await _juegoSteamService.getJuegoSteam(juegoDeLista.appid.ToString());

                    string idJuego = "";
                    foreach (string clave in juegoSteamDictionary.Keys) { idJuego = clave; }

                    if (juegoSteamDictionary[idJuego].success && juegoSteamDictionary[idJuego].data.type == "game") 
                    {
                        int conteo = 0;

                        string minimumPcRequirements = "";
                        if (juegoSteamDictionary[idJuego].data.pc_requirements.Count > 0)
                        {
                            minimumPcRequirements = juegoSteamDictionary[idJuego].data.pc_requirements[0].minimum;
                        }

                        conteo++;
                        if (conteo > 4) break;
                        
                        foreach (JuegoFlagg itemJuegoFlagg in listaJuegosData)
                        {
                            Console.WriteLine("FOREACH JUEGOSFLAGG");
                            

                            if (juegoDeLista.appid == itemJuegoFlagg.idJuegoTienda)
                            {
                                Console.WriteLine($"----> JUEGO PARA UPDATE\n ID OBJETO: {juegoFlagg.idJuegoTienda} \nID BBDD: {itemJuegoFlagg.idJuegoTienda}");
                                itemJuegoFlagg.descripcionCorta = juegoSteamDictionary[idJuego].data.short_description;
                                itemJuegoFlagg.imagen = juegoSteamDictionary[idJuego].data.header_image;
                                itemJuegoFlagg.imagenMini = juegoSteamDictionary[idJuego].data.capsule_image;
                                itemJuegoFlagg.requisitos = minimumPcRequirements;
                                itemJuegoFlagg.nombre = juegoSteamDictionary[idJuego].data.name;
                                itemJuegoFlagg.idJuegoTienda = Convert.ToInt32(idJuego);
                                itemJuegoFlagg.estudio = juegoSteamDictionary[idJuego].data.publishers[0];
                                itemJuegoFlagg.urlTienda = "https://store.steampowered.com/app/" + itemJuegoFlagg.idJuegoTienda;

                                Console.WriteLine("JUEGO FLAGG: " + itemJuegoFlagg.nombre);
                                actualizado = true;
                                _context.listaJuegosData.Update(itemJuegoFlagg);
                            }
                        }

                        if (!actualizado)
                        {
                            Console.WriteLine($"----> JUEGO PARA AGREGAR (lista en BD)\nID OBJETO: {juegoFlagg.idJuegoTienda}");
                            juegoFlagg.idFlagg = Guid.NewGuid();
                            juegoFlagg.descripcionCorta = juegoSteamDictionary[idJuego].data.short_description;
                            juegoFlagg.imagen = juegoSteamDictionary[idJuego].data.header_image;
                            juegoFlagg.imagenMini = juegoSteamDictionary[idJuego].data.capsule_image;
                            juegoFlagg.requisitos = minimumPcRequirements;
                            juegoFlagg.nombre = juegoSteamDictionary[idJuego].data.name;
                            juegoFlagg.contadorVistas = 0;
                            juegoFlagg.idJuegoTienda = Convert.ToInt32(idJuego);
                            juegoFlagg.tienda = "Steam";
                            juegoFlagg.estudio = juegoSteamDictionary[idJuego].data.publishers[0];
                            juegoFlagg.urlTienda = "https://store.steampowered.com/app/" + juegoFlagg.idJuegoTienda;

                            Console.WriteLine("JUEGO FLAGG: " + juegoFlagg.nombre);
                            _context.listaJuegosData.Add(juegoFlagg);
                        }
                    }
                    _context.SaveChanges();
                } 
                       
            }
            else
            {
                ObjetoJsonListaJuegos listaJuegosSteam =  _juegosListaTotalService.getListaJuegosSteam().Result;    
                int count = 0;
                bool encontrado;
                List<string> juegosGuardadoEnLista = new List<string>();

                foreach (ItemListaJuegoSteam juegoDeLista in listaJuegosSteam.applist.apps)
                {
                    Console.WriteLine("----> JUEGO PARA AGREGAR (sin lista en BD)");
                    encontrado = false;
                                     
                    foreach (string idJuegoDeLista in juegosGuardadoEnLista)
                    {
                        if (juegoDeLista.appid.ToString() == idJuegoDeLista)
                        {
                            encontrado = true;
                        }
                    }

                    if (juegosGuardadoEnLista.Count == 0 || !encontrado)
                    {
                        juegoDeLista.created_at = DateTime.Now;
                        _context.listaJuegos.Add(juegoDeLista);
                    }

                        Console.WriteLine("JUEGO STEAM DE LISTA: " + juegoDeLista.name + " ID: " + juegoDeLista.appid);

                    string idJuego = juegoDeLista.appid.ToString();                

                    Dictionary<string, JuegoSteam> juegoSteamDictionary = await _juegoSteamService.getJuegoSteam(idJuego);

                    if (juegoSteamDictionary[idJuego].success && juegoSteamDictionary[idJuego].data.type == "game")
                    {         
                        string minimumPcRequirements = "";
                        if (juegoSteamDictionary[idJuego].data.pc_requirements.Count > 0)
                        {
                            minimumPcRequirements = juegoSteamDictionary[idJuego].data.pc_requirements[0].minimum;
                        }
                        Console.WriteLine($"JUEGO LANZADO\n REQUERIMIENTOS\n{minimumPcRequirements}");
                        JuegoFlagg juegoFlagg = new JuegoFlagg(
                         juegoSteamDictionary[idJuego].data.short_description,
                         juegoSteamDictionary[idJuego].data.header_image,
                         juegoSteamDictionary[idJuego].data.capsule_image,
                         "https://store.steampowered.com/app/" + idJuego,
                         minimumPcRequirements
                        );

                        juegoFlagg.nombre = juegoSteamDictionary[idJuego].data.name;
                        juegoFlagg.idFlagg = Guid.NewGuid();
                        juegoFlagg.contadorVistas = 0; //quitar después
                        juegoFlagg.idJuegoTienda = Convert.ToInt32(idJuego);
                        juegoFlagg.tienda = "Steam";
                        juegoFlagg.estudio = juegoSteamDictionary[idJuego].data.publishers[0];

                        Console.WriteLine("JUEGO FLAGG: " + juegoFlagg.nombre);

                        _context.listaJuegosData.Add(juegoFlagg);

                        count++;
                        if (count > 4) break;
                    }
                    
                }
                    _context.SaveChanges();
            }
        }

    }
}
