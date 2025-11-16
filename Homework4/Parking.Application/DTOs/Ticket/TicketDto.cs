using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Application.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public int TarifaId { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public decimal Monto { get; set; }
    }
}

