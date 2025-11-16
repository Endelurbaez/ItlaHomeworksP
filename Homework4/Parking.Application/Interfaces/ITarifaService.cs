using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Interfaces
{
    public interface ITarifaService
    {
        Task<IEnumerable<Tarifa>> GetAllAsync();
        Task<Tarifa> GetByIdAsync(int id);
        Task AddAsync(Tarifa tarifa);
        Task UpdateAsync(Tarifa tarifa);
        Task DeleteAsync(int id);
    }
}


