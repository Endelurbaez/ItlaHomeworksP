using Parking.Application.Contracts;
using Parking.Application.Dtos.Cliente;

namespace Parking.Application.Services;

public class ClienteService : IClienteService<ClienteDto>
{
    public Task<ClienteDto> CreateAsync(ClienteDto dto)
    {
        dto.Id = new Random().Next(100, 1000);
        return Task.FromResult(dto);
    }

    public Task<ClienteDto> UpdateAsync(int id, ClienteDto dto)
    {
        dto.Id = id;
        return Task.FromResult(dto);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(true);
    }

    // CORRECTO: Retorna Task<ClienteDto?> 
    public Task<ClienteDto?> GetByIdAsync(int id)
    {
        return Task.FromResult<ClienteDto?>(new ClienteDto
        {
            Id = id,
            Nombre = "Cliente",
            Apellido = "De Prueba",
            Email = "cliente@test.com",
            Cedula = "123456789",
            Telefono = "809-555-5555"
        });
    }

    public Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = new List<ClienteDto>
        {
            new() { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan@test.com", Cedula = "00112345678", Telefono = "809-111-1111" },
            new() { Id = 2, Nombre = "María", Apellido = "García", Email = "maria@test.com", Cedula = "00223456789", Telefono = "809-222-2222" },
            new() { Id = 3, Nombre = "Carlos", Apellido = "Rodríguez", Email = "carlos@test.com", Cedula = "00334567890", Telefono = "809-333-3333" }
        };

        return Task.FromResult(clientes.AsEnumerable());
    }

    // CORRECTO: Retorna Task<ClienteDto?>
    public Task<ClienteDto?> GetByCedulaAsync(string cedula)
    {
        return Task.FromResult<ClienteDto?>(new ClienteDto
        {
            Id = 99,
            Nombre = "Cliente",
            Apellido = "Con Cédula",
            Email = "cedula@test.com",
            Cedula = cedula,
            Telefono = "809-999-9999"
        });
    }
}