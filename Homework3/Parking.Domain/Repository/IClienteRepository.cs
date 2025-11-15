using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Domain.Entities;

namespace Parking.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}



