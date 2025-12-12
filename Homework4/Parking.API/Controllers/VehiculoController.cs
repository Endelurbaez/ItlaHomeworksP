using Microsoft.AspNetCore.Mvc;
using Parking.Application.Contracts;
using Parking.Application.Dtos.Vehiculo;
using Parking.Application.DTOs.Vehiculo;  // ← DTOs MAYÚSCULA

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService<VehiculoDto> _vehiculoService;

        public VehiculoController(IVehiculoService<VehiculoDto> vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        // OPCIÓN A: Usa VehiculoDto directamente (para que compile rápido)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehiculoDto dto)  // ← VehiculoDto
        {
            var result = await _vehiculoService.CreateAsync(dto);
            if (result == null) return BadRequest("Error al crear el vehículo");
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // OPCIÓN A: Usa VehiculoDto directamente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehiculoDto dto)  // ← VehiculoDto
        {
            var updated = await _vehiculoService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _vehiculoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("matricula/{matricula}")]
        public async Task<IActionResult> GetByMatricula(string matricula)
        {
            var vehiculo = await _vehiculoService.GetByMatriculaAsync(matricula); 
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }
    }
}