using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly ParkinDbContext _context;

        public TarifaRepository(ParkinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarifa>> GetAllAsync()
        {
            return await _context.Tarifas.ToListAsync();
        }

        public async Task<Tarifa> GetByIdAsync(int id)
        {
            return await _context.Tarifas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Tarifa tarifa)
        {
            await _context.Tarifas.AddAsync(tarifa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarifa tarifa)
        {
            _context.Tarifas.Update(tarifa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarifa = await _context.Tarifas.FindAsync(id);
            if (tarifa != null)
            {
                _context.Tarifas.Remove(tarifa);
                await _context.SaveChangesAsync();
            }
        }
    }
}


