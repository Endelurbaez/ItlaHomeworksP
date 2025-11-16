using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking.Application.Interfaces;
using Parking.Domain.Entities;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaService _service;

        public TarifaController(ITarifaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarifa>>> GetAll()
        {
            var tarifas = await _service.GetAllAsync();
            return Ok(tarifas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarifa>> GetById(int id)
        {
            var tarifa = await _service.GetByIdAsync(id);
            if (tarifa == null)
                return NotFound();
            return Ok(tarifa);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Tarifa tarifa)
        {
            await _service.AddAsync(tarifa);
            return CreatedAtAction(nameof(GetById), new { id = tarifa.Id }, tarifa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Tarifa tarifa)
        {
            if (id != tarifa.Id)
                return BadRequest();

            await _service.UpdateAsync(tarifa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

