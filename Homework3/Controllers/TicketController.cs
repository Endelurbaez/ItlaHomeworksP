using Microsoft.AspNetCore.Mvc;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;
using System.Net.Sockets;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _repo;

        public TicketController(ITicketRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _repo.GetAllAsync();
            return Ok(tickets);
        }

        [HttpGet("abiertos")]
        public async Task<IActionResult> GetAbiertos()
        {
            var tickets = await _repo.GetTicketsAbiertosAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _repo.GetByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            ticket.HoraEntrada = DateTime.Now;

            await _repo.AddAsync(ticket);
            return Ok(ticket);
        }

        [HttpPut("cerrar/{id}")]
        public async Task<IActionResult> CerrarTicket(int id)
        {
            var ticket = await _repo.GetByIdAsync(id);
            if (ticket == null) return NotFound();

            ticket.HoraSalida = DateTime.Now;

            await _repo.UpdateAsync(ticket);
            return Ok(ticket);
        }
    }
}

