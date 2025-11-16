using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking.Application.Interfaces;
using Parking.Domain.Entities;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
        {
            var tickets = await _service.GetAllAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var ticket = await _service.GetByIdAsync(id);
            if (ticket == null)
                return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Ticket ticket)
        {
            await _service.AddAsync(ticket);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest();

            await _service.UpdateAsync(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

