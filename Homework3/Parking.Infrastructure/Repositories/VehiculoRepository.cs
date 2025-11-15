using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repository;
using Parking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AppDbContext _ctx;
        public VehiculoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Vehiculo vehiculo)
        {
            await _ctx.Vehiculos.AddAsync(vehiculo);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vehiculo vehiculo)
        {
            _ctx.Vehiculos.Remove(vehiculo);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _ctx.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo?> GetByIdAsync(int id)
        {
            return await _ctx.Vehiculos.FindAsync(id);
        }

        public async Task UpdateAsync(Vehiculo vehiculo)
        {
            _ctx.Vehiculos.Update(vehiculo);
            await _ctx.SaveChangesAsync();
        }
    }
}

