using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Domain.Entities
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }  
        public string Placa { get; set; } = null!;
        public string TipoVehiculo { get; set; } = null!;
        public int ClienteId { get; set; }   
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}



