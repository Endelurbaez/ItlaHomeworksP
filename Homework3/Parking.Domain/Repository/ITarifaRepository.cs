using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Domain.Entities;

namespace Parking.Domain.Interfaces.Repository
{
    public interface ITarifaRepository
    {
        Task<Tarifa?> GetByIdAsync(int id);
        Task<IEnumerable<Tarifa>> GetAllAsync();
        Task AddAsync(Tarifa tarifa);
        Task UpdateAsync(Tarifa tarifa);
        Task DeleteAsync(Tarifa tarifa);
    }
}

