using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly AppDbContext _db;
        public VehiculosController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAll()
        {
            var list = await _db.Vehiculos
                .Include(v => v.Cliente) // opcional, si quieres datos del cliente
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Vehiculo>> GetById(int id)
        {
            var entity = await _db.Vehiculos
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> Create([FromBody] Vehiculo model)
        {
            // opcional: validar que Cliente exista
            var clienteExists = await _db.Clientes.AnyAsync(c => c.Id == model.ClienteId);
            if (!clienteExists) return BadRequest($"ClienteId {model.ClienteId} no existe.");

            _db.Vehiculos.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehiculo model)
        {
            if (id != model.Id) return BadRequest();

            var entity = await _db.Vehiculos.FindAsync(id);
            if (entity == null) return NotFound();

            entity.Marca = model.Marca;
            entity.Modelo = model.Modelo;
            entity.Placa = model.Placa;
            entity.ClienteId = model.ClienteId;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Vehiculos.FindAsync(id);
            if (entity == null) return NotFound();

            _db.Vehiculos.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

