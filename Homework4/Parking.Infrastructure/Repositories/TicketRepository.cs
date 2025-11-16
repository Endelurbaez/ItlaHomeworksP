using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ParkinDbContext _context;

        public TicketRepository(ParkinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.Include(t => t.Vehiculo)
                                         .Include(t => t.Tarifa)
                                         .ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.Include(t => t.Vehiculo)
                                         .Include(t => t.Tarifa)
                                         .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}



