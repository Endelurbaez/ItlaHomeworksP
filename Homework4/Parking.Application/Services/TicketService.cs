using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Application.Contracts;
using Parking.Application.DTOs.Ticket;

namespace Parking.Application.Services;

public class TicketService : ITicketService<TicketDto>
{
    public Task<TicketDto> CreateAsync(TicketDto dto)
    {
        dto.Id = new Random().Next(100, 1000);
        dto.Estado = "Activo";
        return Task.FromResult(dto);
    }

    public Task<TicketDto> UpdateAsync(int id, TicketDto dto)
    {
        dto.Id = id;
        return Task.FromResult(dto);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(true);
    }

    public Task<TicketDto?> GetByIdAsync(int id)
    {
        return Task.FromResult<TicketDto?>(new TicketDto
        {
            Id = id,
            VehiculoId = 1,
            FechaEntrada = DateTime.Now.AddHours(-2),
            FechaSalida = null,
            TarifaId = 1,
            TotalPagar = 100.50m,
            Estado = "Activo"
        });
    }

    public Task<IEnumerable<TicketDto>> GetAllAsync()
    {
        var tickets = new List<TicketDto>
        {
            new() { Id = 1, VehiculoId = 1, FechaEntrada = DateTime.Now.AddHours(-3), FechaSalida = null, TarifaId = 1, TotalPagar = 150.75m, Estado = "Activo" },
            new() { Id = 2, VehiculoId = 2, FechaEntrada = DateTime.Now.AddHours(-1), FechaSalida = DateTime.Now, TarifaId = 2, TotalPagar = 75.25m, Estado = "Pagado" },
            new() { Id = 3, VehiculoId = 3, FechaEntrada = DateTime.Now.AddHours(-5), FechaSalida = null, TarifaId = 1, TotalPagar = 250.00m, Estado = "Activo" }
        };

        return Task.FromResult(tickets.AsEnumerable());
    }
}
