using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TicketsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
        {
            var list = await _db.Tickets
                .Include(t => t.Vehiculo)
                .ThenInclude(v => v.Cliente)
                .Include(t => t.Tarifa)
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var entity = await _db.Tickets
                .Include(t => t.Vehiculo)
                .ThenInclude(v => v.Cliente)
                .Include(t => t.Tarifa)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Create([FromBody] Ticket model)
        {
            // Validaciones básicas: Vehiculo y Tarifa existen
            var vehExists = await _db.Vehiculos.AnyAsync(v => v.Id == model.VehiculoId);
            if (!vehExists) return BadRequest($"VehiculoId {model.VehiculoId} no existe.");

            var tarifaExists = await _db.Tarifas.AnyAsync(t => t.Id == model.TarifaId);
            if (!tarifaExists) return BadRequest($"TarifaId {model.TarifaId} no existe.");

            model.Entrada = DateTime.UtcNow;
            _db.Tickets.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        // PUT aquí lo usamos para cerrar el ticket (registrar salida y calcular total)
        [HttpPut("{id:int}/cerrar")]
        public async Task<IActionResult> CerrarTicket(int id)
        {
            var ticket = await _db.Tickets
                .Include(t => t.Tarifa)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return NotFound();
            if (ticket.Salida != null) return BadRequest("Ticket ya cerrado.");

            ticket.Salida = DateTime.UtcNow;

            // cálculo simple: horas redondeadas hacia arriba * precio por hora
            var horas = (ticket.Salida.Value - ticket.Entrada).TotalHours;
            var horasRedondeadas = Math.Ceiling(horas);
            ticket.Total = (decimal)horasRedondeadas * ticket.Tarifa.PrecioHora;

            await _db.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Tickets.FindAsync(id);
            if (entity == null) return NotFound();

            _db.Tickets.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

