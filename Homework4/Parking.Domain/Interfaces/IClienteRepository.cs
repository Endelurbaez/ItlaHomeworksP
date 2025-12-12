using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {

        // Métodos específicos de Cliente
        Task<Cliente?> GetByEmailAsync(string email);
    }
}
