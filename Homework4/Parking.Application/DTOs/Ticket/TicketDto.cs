using System;

namespace Parking.Application.DTOs.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; } 
        public int VehiculoId { get; set; } = 0;
        public DateTime FechaEntrada { get; set; } = DateTime.Now;
        public DateTime? FechaSalida { get; set; }  
        public int TarifaId { get; set; } 
        public decimal TotalPagar { get; set; }  
        public string Estado { get; set; } = string.Empty;
    }
}