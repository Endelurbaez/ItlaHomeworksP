using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Domain.Entities;

namespace Parking.Domain.Interfaces.Repository
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo?> GetByIdAsync(int id);
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(Vehiculo vehiculo);
    }
}

