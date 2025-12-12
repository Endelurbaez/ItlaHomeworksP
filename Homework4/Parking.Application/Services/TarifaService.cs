using Parking.Application.Contracts;
using Parking.Application.Dtos;
using Parking.Application.Dtos.Tarifa;

namespace Parking.Application.Services;

public class TarifaService : ITarifaService<TarifaDto>
{
    public Task<TarifaDto> CreateAsync(TarifaDto dto)
    {
        return Task.FromResult(dto);
    }

    public Task<TarifaDto> UpdateAsync(int id, TarifaDto dto)
    {
        return Task.FromResult(dto);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(true);
    }

    public Task<TarifaDto?> GetByIdAsync(int id)
    {
        return Task.FromResult<TarifaDto?>(null);
    }

    public Task<IEnumerable<TarifaDto>> GetAllAsync()
    {
        return Task.FromResult(Enumerable.Empty<TarifaDto>());
    }

    public Task<TarifaDto?> GetByNombreAsync(string nombre)
    {
        throw new NotImplementedException();
    }
}