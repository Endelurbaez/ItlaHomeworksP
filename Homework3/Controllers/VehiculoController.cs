using Microsoft.AspNetCore.Mvc;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoRepository _repo;

        public VehiculoController(IVehiculoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _repo.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _repo.GetByIdAsync(id);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            await _repo.AddAsync(vehiculo);
            return Ok(vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id) return BadRequest();

            await _repo.UpdateAsync(vehiculo);
            return NoContent();
        }
    }
}
