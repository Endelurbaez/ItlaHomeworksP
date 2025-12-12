using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;

namespace Parking.Infrastructure.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ParkingDbContext context) : base(context) { }

        public async Task<IEnumerable<Ticket>> GetByVehiculoIdAsync(int vehiculoId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(t => t.VehiculoId == vehiculoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByClienteIdAsync(int clienteId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(t => t.Vehiculo)
                .Where(t => t.Vehiculo.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByFechaAsync(DateTime fecha)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(t => t.HoraEntrada.Date == fecha.Date)
                .ToListAsync();
        }
    }
}
