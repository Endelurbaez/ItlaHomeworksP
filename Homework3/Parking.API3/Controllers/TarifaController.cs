using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Infrastructure.Data;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifaController : ControllerBase
    {
        private readonly ParkingDbContext _context;

        public TarifaController(ParkingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarifa>>> GetTarifas()
        {
            return await _context.Tarifas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarifa>> GetTarifa(int id)
        {
            var tarifa = await _context.Tarifas.FindAsync(id);
            if (tarifa == null) return NotFound();
            return tarifa;
        }

        [HttpPost]
        public async Task<ActionResult<Tarifa>> CreateTarifa(Tarifa tarifa)
        {
            _context.Tarifas.Add(tarifa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTarifa), new { id = tarifa.TarifaId }, tarifa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarifa(int id, Tarifa tarifa)
        {
            if (id != tarifa.TarifaId) return BadRequest();
            _context.Entry(tarifa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarifa(int id)
        {
            var tarifa = await _context.Tarifas.FindAsync(id);
            if (tarifa == null) return NotFound();
            _context.Tarifas.Remove(tarifa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


