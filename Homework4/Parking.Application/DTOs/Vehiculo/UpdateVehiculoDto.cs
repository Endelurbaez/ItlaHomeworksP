using System.ComponentModel.DataAnnotations;

namespace Parking.Application.DTOs.Vehiculo
{
    public class UpdateVehiculoDto
    {
        [Required]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        public string Marca { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        [Required]
        public string TipoVehiculo { get; set; } = string.Empty;

        [Required]
        public int ClienteId { get; set; }
    }
}