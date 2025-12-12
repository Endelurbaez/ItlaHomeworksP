using System;
using System.Collections.Generic;

namespace Parking.Domain.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioHora { get; set; }

        // Relación: Una tarifa puede aplicarse a muchos tickets
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
