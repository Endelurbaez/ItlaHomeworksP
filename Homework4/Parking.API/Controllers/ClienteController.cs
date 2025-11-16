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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _service.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            await _service.AddAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            await _service.UpdateAsync(cliente);
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

