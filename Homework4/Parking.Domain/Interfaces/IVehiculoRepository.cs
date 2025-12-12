using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.Interfaces
{
    public interface IVehiculoRepository : IBaseRepository<Vehiculo>
    {
        // Métodos específicos de Vehiculo
        Task<IEnumerable<Vehiculo>> GetByClienteIdAsync(int clienteId);
        Task<Vehiculo?> GetByPlacaAsync(string placa);
    }
}
