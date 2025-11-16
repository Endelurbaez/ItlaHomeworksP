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
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _service;

        public VehiculoController(IVehiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAll()
        {
            var vehiculos = await _service.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetById(int id)
        {
            var vehiculo = await _service.GetByIdAsync(id);
            if (vehiculo == null)
                return NotFound();
            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Vehiculo vehiculo)
        {
            await _service.AddAsync(vehiculo);
            return CreatedAtAction(nameof(GetById), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
                return BadRequest();

            await _service.UpdateAsync(vehiculo);
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

