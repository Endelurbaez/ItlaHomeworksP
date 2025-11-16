using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }

        public int VehiculoId { get; set; } 
        public Vehiculo Vehiculo { get; set; } 

        public int TarifaId { get; set; } 
        public Tarifa Tarifa { get; set; } 

        public decimal? Total { get; set; }
    }
}

