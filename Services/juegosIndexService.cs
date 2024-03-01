namespace FlaggGaming.Services;
using FlaggGaming.Model;

public class juegosIndexService
{
    private Juego unJuego1 = new Juego();
    private Juego unJuego2 = new Juego();
    private Juego unJuego3 = new Juego();
    private Juego unJuego4 = new Juego();


    public async Task<Juego[]> obtenerJuegosDestacados()
    {
        unJuego1.Name = "Counter Strike 2";
        unJuego1.Description = "Descripci�n de este juego para llenar un p�rrafo para contar algo";
        unJuego1.urlImagen = "/imagenes/cs2.webp";

        unJuego2.Name = unJuego1.Name; unJuego2.Description = unJuego1.Description;
        unJuego3.Name = unJuego1.Name; unJuego3.Description = unJuego1.Description;
        unJuego4.Name = unJuego1.Name; unJuego4.Description = unJuego1.Description;

        unJuego2.urlImagen = unJuego1.urlImagen;
        unJuego3.urlImagen = unJuego1.urlImagen;
        unJuego4.urlImagen = unJuego1.urlImagen;


        Task<Juego[]> taskJuegosIndex = Task<Juego[]>.Factory.StartNew
        (() =>
            {
                Juego[] arrayJuegosDestacados = { unJuego1,unJuego2,unJuego3, unJuego4 };
                return arrayJuegosDestacados;
            }  
        );

        return await taskJuegosIndex;
    }


}