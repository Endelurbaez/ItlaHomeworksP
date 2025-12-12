using System;
using System.ComponentModel.DataAnnotations;

namespace Parking.Main.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        // Vehículo
        [Required(ErrorMessage = "El vehículo es requerido")]
        [Display(Name = "Vehículo")]
        public int VehiculoId { get; set; }

        [Display(Name = "Placa del Vehículo")]
        public string PlacaVehiculo { get; set; } = string.Empty;

        [Display(Name = "Marca del Vehículo")]
        public string MarcaVehiculo { get; set; } = string.Empty;

        // Tarifa
        [Required(ErrorMessage = "La tarifa es requerida")]
        [Display(Name = "Tarifa")]
        public int TarifaId { get; set; }

        [Display(Name = "Nombre de Tarifa")]
        public string NombreTarifa { get; set; } = string.Empty;

        [Display(Name = "Precio por Hora")]
        [DataType(DataType.Currency)]
        public decimal PrecioPorHora { get; set; }

        // Fechas
        [Required(ErrorMessage = "La fecha de entrada es requerida")]
        [Display(Name = "Fecha de Entrada")]
        [DataType(DataType.DateTime)]
        public DateTime FechaEntrada { get; set; } = DateTime.Now;

        [Display(Name = "Fecha de Salida")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaSalida { get; set; }

        // Cálculos
        [Display(Name = "Horas Transcurridas")]
        public int? HorasTranscurridas
        {
            get
            {
                if (FechaSalida.HasValue)
                {
                    var diferencia = FechaSalida.Value - FechaEntrada;
                    return (int)Math.Ceiling(diferencia.TotalHours);
                }
                return null;
            }
        }

        [Display(Name = "Total a Pagar")]
        [DataType(DataType.Currency)]
        public decimal? TotalPagar
        {
            get
            {
                if (HorasTranscurridas.HasValue && PrecioPorHora > 0)
                {
                    return HorasTranscurridas.Value * PrecioPorHora;
                }
                return null;
            }
        }

        // Estado
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Activo"; // Activo, Pagado, Cerrado

        // Información del cliente
        [Display(Name = "Cliente")]
        public string ClienteNombre { get; set; } = string.Empty;

        public int ClienteId { get; set; }

        // Propiedades para vistas
        public string EstadoBadgeClass
        {
            get
            {
                return Estado switch
                {
                    "Activo" => "badge bg-warning",
                    "Pagado" => "badge bg-success",
                    "Cerrado" => "badge bg-secondary",
                    _ => "badge bg-info"
                };
            }
        }

        public bool EstaActivo => Estado == "Activo";
    }
}