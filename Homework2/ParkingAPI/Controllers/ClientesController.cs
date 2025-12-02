using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ClientesController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var list = await _db.Clientes.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var entity = await _db.Clientes.FindAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] Cliente model)
        {
            _db.Clientes.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente model)
        {
            if (id != model.Id) return BadRequest();

            var entity = await _db.Clientes.FindAsync(id);
            if (entity == null) return NotFound();

            // actualizar campos
            entity.Nombre = model.Nombre;
            entity.Telefono = model.Telefono;
            entity.Correo = model.Correo;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Clientes.FindAsync(id);
            if (entity == null) return NotFound();

            _db.Clientes.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
