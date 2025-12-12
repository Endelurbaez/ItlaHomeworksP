using System;

namespace Parking.Application.DTOs.Ticket
{
    public class UpdateTicketDto
    {
        public int VehiculoId { get; set; }
        public DateTime FechaEntrada { get; set; } = DateTime.Now;
        public DateTime? FechaSalida { get; set; } = null;
        public int TarifaId { get; set; }
        public decimal TotalPagar { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}