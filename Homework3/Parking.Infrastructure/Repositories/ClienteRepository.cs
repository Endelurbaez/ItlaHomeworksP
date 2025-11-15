using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repository;
using Parking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _ctx;
        public ClienteRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Cliente cliente)
        {
            await _ctx.Clientes.AddAsync(cliente);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _ctx.Clientes.Remove(cliente);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _ctx.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _ctx.Clientes.FindAsync(id);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _ctx.Clientes.Update(cliente);
            await _ctx.SaveChangesAsync();
        }
    }
}


