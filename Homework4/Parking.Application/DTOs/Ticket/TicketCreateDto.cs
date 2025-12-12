using System;

namespace Parking.Application.DTOs.Ticket
{
    public class TicketCreateDto 
    {
        public int VehiculoId { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int TarifaId { get; set; }
        public decimal TotalPagar { get; set; }
        public string Estado { get; set; } = string.Empty; 
    }
}