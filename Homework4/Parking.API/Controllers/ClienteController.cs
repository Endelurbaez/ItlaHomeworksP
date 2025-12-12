using Microsoft.AspNetCore.Mvc;
using Parking.Application.Contracts;
using Parking.Application.Dtos.Cliente;

namespace Parking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService<ClienteDto> _clienteService;

    public ClienteController(IClienteService<ClienteDto> clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteService.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClienteDto createDto)
    {
        var clienteDto = new ClienteDto
        {
            Cedula = createDto.Cedula,
            Nombre = createDto.Nombre,
            Apellido = createDto.Apellido,
            Telefono = createDto.Telefono,
            Email = createDto.Email,
        };

        var result = await _clienteService.CreateAsync(clienteDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClienteDto updateDto)
    {
        var existingCliente = await _clienteService.GetByIdAsync(id);
        if (existingCliente == null)
            return NotFound();

        existingCliente.Cedula = updateDto.Cedula;
        existingCliente.Nombre = updateDto.Nombre;
        existingCliente.Apellido = updateDto.Apellido;
        existingCliente.Telefono = updateDto.Telefono;
        existingCliente.Email = updateDto.Email;

        var result = await _clienteService.UpdateAsync(id, existingCliente);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _clienteService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
} 