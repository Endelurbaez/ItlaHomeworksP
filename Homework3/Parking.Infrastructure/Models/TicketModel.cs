using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Infrastructure.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public decimal? MontoPagar { get; set; }

        public string ClienteNombre { get; set; } = string.Empty;
        public string VehiculoPlaca { get; set; } = string.Empty;
        public string TarifaNombre { get; set; } = string.Empty;
    }
}
