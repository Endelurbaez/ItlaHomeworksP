using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using Parking.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ParkinDbContext _context;

        public ClienteRepository(ParkinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.Include(c => c.Vehiculos).ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.Include(c => c.Vehiculos)
                                          .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}




