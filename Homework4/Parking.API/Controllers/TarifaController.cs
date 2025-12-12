using Microsoft.AspNetCore.Mvc;
using Parking.Application.Contracts;
using Parking.Application.Dtos.Tarifa;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaService<TarifaDto> _tarifaService;

        public TarifaController(ITarifaService<TarifaDto> tarifaService)
        {
            _tarifaService = tarifaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarifas = await _tarifaService.GetAllAsync();
            return Ok(tarifas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarifa = await _tarifaService.GetByIdAsync(id);
            if (tarifa == null) return NotFound();
            return Ok(tarifa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarifaDto dto)  // ← Usa TarifaDto directamente
        {
            var result = await _tarifaService.CreateAsync(dto);
            if (result == null) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TarifaDto dto)  // ← Usa TarifaDto
        {
            var updated = await _tarifaService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tarifaService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}