using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(ParkingDbContext context) : base(context) { }

        public async Task<Tarifa?> GetByNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Nombre == nombre);
        }
    }
}
