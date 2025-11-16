using Parking.Application.Interfaces;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Cliente> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(Cliente cliente) => await _repo.AddAsync(cliente);
        public async Task UpdateAsync(Cliente cliente) => await _repo.UpdateAsync(cliente);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}



