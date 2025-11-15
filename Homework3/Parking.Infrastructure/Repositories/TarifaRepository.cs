using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repository;
using Parking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly AppDbContext _ctx;
        public TarifaRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Tarifa tarifa)
        {
            await _ctx.Tarifas.AddAsync(tarifa);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tarifa tarifa)
        {
            _ctx.Tarifas.Remove(tarifa);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tarifa>> GetAllAsync()
        {
            return await _ctx.Tarifas.ToListAsync();
        }

        public async Task<Tarifa?> GetByIdAsync(int id)
        {
            return await _ctx.Tarifas.FindAsync(id);
        }

        public async Task UpdateAsync(Tarifa tarifa)
        {
            _ctx.Tarifas.Update(tarifa);
            await _ctx.SaveChangesAsync();
        }
    }
}
