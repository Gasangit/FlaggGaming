using FlaggGaming.Model;

namespace FlaggGaming.Services
{
    public class juegosIndexService
    {
        private Juego unJuego1 = new Juego();
        private Juego unJuego2 = new Juego();
        private Juego unJuego3 = new Juego();
        private Juego unJuego4 = new Juego();


        public async Task<Juego[]> obtenerJuegosDestacados()
        {
            unJuego1.nombre = "Counter Strike 2";
            unJuego1.descripcion = "Descripci�n de este juego para llenar un p�rrafo para contar algo";
            unJuego1.imagen = "/imagenes/cs2.webp";

            unJuego2.nombre = unJuego1.nombre; unJuego2.descripcion = unJuego1.descripcion;
            unJuego3.nombre = unJuego1.nombre; unJuego3.descripcion = unJuego1.descripcion;
            unJuego4.nombre = unJuego1.nombre; unJuego4.descripcion = unJuego1.descripcion;

            unJuego2.imagen = unJuego1.imagen;
            unJuego3.imagen = unJuego1.imagen;
            unJuego4.imagen = unJuego1.imagen;

            Task<Juego[]> taskJuegosIndex = Task<Juego[]>.Factory.StartNew
            (() =>
                {
                    Juego[] arrayJuegosDestacados = { unJuego1, unJuego2, unJuego3, unJuego4 };
                    return arrayJuegosDestacados;
                }
            );

            return await taskJuegosIndex;
        }

    }
}