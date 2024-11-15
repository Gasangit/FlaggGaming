using FlaggGaming.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlaggGaming.Model.tienda;
using FlaggGaming.Entity;

namespace FlaggGaming.Services
{
    public class TiendaService
    {
        private readonly DatosContext _context;

        public TiendaService(DatosContext context)
        {
            _context = context;
        }

        // Método para obtener la primera tienda (o puedes adaptarlo según sea necesario)
        public async Task<Tienda> ObtenerTiendaAsync()
        {
            return await _context.Tiendas.FirstOrDefaultAsync();
        }

        // Método para obtener una tienda por ID
        public async Task<Tienda> GetTiendaAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id);
        }

        // Método para actualizar la tienda
        public async Task ActualizarTiendaAsync(Tienda tienda)
        {
            _context.Tiendas.Update(tienda);
            await _context.SaveChangesAsync();
        }
    }
}