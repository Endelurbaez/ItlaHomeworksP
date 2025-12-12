using System;
using System.Collections.Generic;

namespace Parking.Domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;

        // Relación con Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();

        // Relación: Un vehículo puede tener muchos tickets
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
