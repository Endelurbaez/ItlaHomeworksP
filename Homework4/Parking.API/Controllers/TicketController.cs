using Microsoft.AspNetCore.Mvc;
using Parking.Application.Contracts;
using Parking.Application.DTOs.Ticket;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService<TicketDto> _ticketService;

        public TicketController(ITicketService<TicketDto> ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketService.GetAllAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketDto dto)  // ← TicketDto
        {
            var result = await _ticketService.CreateAsync(dto);
            if (result == null) return BadRequest("Error al crear el ticket");
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketDto dto)  // ← TicketDto
        {
            var updated = await _ticketService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ticketService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}