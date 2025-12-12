using Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Domain.Interfaces
{
    public interface ITarifaRepository : IBaseRepository<Tarifa>
    {
        // Métodos específicos de Tarifa
        Task<Tarifa?> GetByNombreAsync(string nombre);
    }
}


