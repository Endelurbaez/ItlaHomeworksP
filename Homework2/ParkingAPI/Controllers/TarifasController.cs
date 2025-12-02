using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifasController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TarifasController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarifa>>> GetAll()
        {
            var list = await _db.Tarifas.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tarifa>> GetById(int id)
        {
            var entity = await _db.Tarifas.FindAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Tarifa>> Create([FromBody] Tarifa model)
        {
            _db.Tarifas.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tarifa model)
        {
            if (id != model.Id) return BadRequest();

            var entity = await _db.Tarifas.FindAsync(id);
            if (entity == null) return NotFound();

            entity.Nombre = model.Nombre;
            entity.PrecioHora = model.PrecioHora;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Tarifas.FindAsync(id);
            if (entity == null) return NotFound();

            _db.Tarifas.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
