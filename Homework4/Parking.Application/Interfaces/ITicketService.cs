using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
    }
}



