using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }  // PK
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}



