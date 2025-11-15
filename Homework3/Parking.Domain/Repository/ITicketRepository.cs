using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Domain.Entities;

namespace Parking.Domain.Interfaces.Repository
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<IEnumerable<Ticket>> GetTicketsAbiertosAsync();
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
    }
}




