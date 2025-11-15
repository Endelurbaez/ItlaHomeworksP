using Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }  // PK
        public int VehiculoId { get; set; } // FK simple
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal TotalPagar { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}




