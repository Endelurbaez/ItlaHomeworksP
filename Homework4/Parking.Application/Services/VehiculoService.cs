using Parking.Application.Interfaces;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _repo;

        public VehiculoService(IVehiculoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Vehiculo> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(Vehiculo vehiculo) => await _repo.AddAsync(vehiculo);
        public async Task UpdateAsync(Vehiculo vehiculo) => await _repo.UpdateAsync(vehiculo);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}







