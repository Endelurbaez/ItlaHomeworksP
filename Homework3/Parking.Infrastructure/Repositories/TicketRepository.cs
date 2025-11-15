using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repository;
using Parking.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _ctx;
        public TicketRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Ticket ticket)
        {
            await _ctx.Tickets.AddAsync(ticket);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            _ctx.Tickets.Remove(ticket);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _ctx.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _ctx.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAbiertosAsync()
        {
            return await _ctx.Tickets
                .Where(t => t.FechaSalida == null)
                .ToListAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _ctx.Tickets.Update(ticket);
            await _ctx.SaveChangesAsync();
        }
    }
}



