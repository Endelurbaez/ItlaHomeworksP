using System;
using System.Collections.Generic;
using Parking.Application.Interfaces;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _repo;

        public TarifaService(ITarifaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Tarifa>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Tarifa> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(Tarifa tarifa) => await _repo.AddAsync(tarifa);
        public async Task UpdateAsync(Tarifa tarifa) => await _repo.UpdateAsync(tarifa);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}



