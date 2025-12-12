using System;

namespace Parking.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = new Vehiculo();
        public int TarifaId { get; set; }
        public Tarifa Tarifa { get; set; } = new Tarifa();

        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public decimal? Total { get; set; }
    }
}

