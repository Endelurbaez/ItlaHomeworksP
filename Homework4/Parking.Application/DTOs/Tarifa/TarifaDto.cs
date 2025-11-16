using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Application.DTOs
{
    public class TarifaDto
    {
        public int Id { get; set; }
        public string TipoVehiculo { get; set; }
        public decimal PrecioHora { get; set; }
    }
}

