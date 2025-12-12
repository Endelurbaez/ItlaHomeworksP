using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket>  // ← ¡AÑADE ESTO!
    {
        // Métodos específicos de Ticket
        Task<IEnumerable<Ticket>> GetByVehiculoIdAsync(int vehiculoId);
        Task<IEnumerable<Ticket>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Ticket>> GetByFechaAsync(DateTime fecha);
    }
}