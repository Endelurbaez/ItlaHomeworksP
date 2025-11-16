using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ParkinDbContext _context;

        public VehiculoRepository(ParkinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos.Include(v => v.Cliente).ToListAsync();
        }

        public async Task<Vehiculo> GetByIdAsync(int id)
        {
            return await _context.Vehiculos.Include(v => v.Cliente)
                                          .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Vehiculo vehiculo)
        {
            await _context.Vehiculos.AddAsync(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}


