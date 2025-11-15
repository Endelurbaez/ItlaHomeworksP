using Microsoft.AspNetCore.Mvc;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaRepository _repo;

        public TarifaController(ITarifaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarifas = await _repo.GetAllAsync();
            return Ok(tarifas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarifa = await _repo.GetByIdAsync(id);
            if (tarifa == null) return NotFound();
            return Ok(tarifa);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tarifa tarifa)
        {
            await _repo.AddAsync(tarifa);
            return Ok(tarifa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tarifa tarifa)
        {
            if (id != tarifa.Id) return BadRequest();

            await _repo.UpdateAsync(tarifa);
            return NoContent();
        }
    }
}
