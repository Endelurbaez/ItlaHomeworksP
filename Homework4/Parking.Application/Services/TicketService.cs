using System;
using Parking.Application.Interfaces;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;

        public TicketService(ITicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Ticket> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(Ticket ticket) => await _repo.AddAsync(ticket);
        public async Task UpdateAsync(Ticket ticket) => await _repo.UpdateAsync(ticket);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}




