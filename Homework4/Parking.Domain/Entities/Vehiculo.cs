using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public int ClienteId { get; set; } 
        public Cliente Cliente { get; set; } 
    }
}

