using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Domain.Entities;
using Parking.Infrastructure.Data;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly ParkingDbContext _context;

        public VehiculoController(ParkingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return NotFound();
            return vehiculo;
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> CreateVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.VehiculoId }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.VehiculoId) return BadRequest();
            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return NotFound();
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

