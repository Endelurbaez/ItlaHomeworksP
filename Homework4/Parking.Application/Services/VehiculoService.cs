using Parking.Application.Contracts;
using Parking.Application.Dtos.Vehiculo;
using Parking.Application.DTOs.Vehiculo;

namespace Parking.Application.Services;

public class VehiculoService : IVehiculoService<VehiculoDto>
{
    public Task<VehiculoDto> CreateAsync(VehiculoDto dto)
    {
        dto.Id = new Random().Next(100, 1000);
        return Task.FromResult(dto);
    }

    public Task<VehiculoDto> UpdateAsync(int id, VehiculoDto dto)
    {
        dto.Id = id;
        return Task.FromResult(dto);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(true);
    }

    public Task<VehiculoDto?> GetByIdAsync(int id)
    {
        return Task.FromResult<VehiculoDto?>(new VehiculoDto
        {
            Id = id,
            Matricula = "ABC-123",
            Marca = "Toyota",
            Modelo = "Corolla",
            Color = "Blanco",
            TipoVehiculo = "Sedán",
            ClienteId = 1
        });
    }

    public Task<IEnumerable<VehiculoDto>> GetAllAsync()
    {
        var vehiculos = new List<VehiculoDto>
        {
            new() { Id = 1, Matricula = "ABC-123", Marca = "Toyota", Modelo = "Corolla", Color = "Blanco", TipoVehiculo = "Sedán", ClienteId = 1 },
            new() { Id = 2, Matricula = "XYZ-789", Marca = "Honda", Modelo = "Civic", Color = "Negro", TipoVehiculo = "Sedán", ClienteId = 2 },
            new() { Id = 3, Matricula = "DEF-456", Marca = "Ford", Modelo = "F-150", Color = "Rojo", TipoVehiculo = "Camioneta", ClienteId = 1 }
        };

        return Task.FromResult(vehiculos.AsEnumerable());
    }

    // ¡MÉTODO QUE FALTABA!
    public Task<VehiculoDto?> GetByMatriculaAsync(string matricula)
    {
        // Implementación simple para pruebas
        return Task.FromResult<VehiculoDto?>(new VehiculoDto
        {
            Id = 99,
            Matricula = matricula,
            Marca = "Marca Ejemplo",
            Modelo = "Modelo Ejemplo",
            Color = "Color Ejemplo",
            TipoVehiculo = "Tipo Ejemplo",
            ClienteId = 1
        });
    }
}