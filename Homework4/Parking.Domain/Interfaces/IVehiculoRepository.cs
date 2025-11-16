using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<Vehiculo> GetByIdAsync(int id);
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(int id);
    }
}



