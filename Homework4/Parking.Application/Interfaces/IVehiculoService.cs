using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Interfaces
{
    public interface IVehiculoService
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<Vehiculo> GetByIdAsync(int id);
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(int id);
    }
}




