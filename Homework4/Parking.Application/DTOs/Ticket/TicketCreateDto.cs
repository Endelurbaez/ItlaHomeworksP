using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Application.DTOs.Ticket
{
    public class TicketCreateDto
    {
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int TarifaId { get; set; }
    }
}
