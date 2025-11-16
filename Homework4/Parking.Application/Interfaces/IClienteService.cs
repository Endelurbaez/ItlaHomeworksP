using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}




