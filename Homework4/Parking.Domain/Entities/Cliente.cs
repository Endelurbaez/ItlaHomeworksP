using System;
using System.Collections.Generic;

namespace Parking.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relación: Un cliente puede tener muchos vehículos
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
        public string Telefono { get; set; }
        public string Cedula { get; set; }
    }
}



