using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class VehiculoRepository : BaseRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ParkingDbContext context) : base(context) { }

        public async Task<IEnumerable<Vehiculo>> GetByClienteIdAsync(int clienteId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(v => v.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Vehiculo?> GetByPlacaAsync(string placa)
        {
            return await _dbSet.FirstOrDefaultAsync(v => v.Placa == placa);
        }
    }
}
