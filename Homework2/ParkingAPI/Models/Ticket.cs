using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public DateTime Entrada { get; set; }
        public DateTime? Salida { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public int TarifaId { get; set; }
        public Tarifa Tarifa { get; set; }
        public decimal Total { get; internal set; }
    }
}
