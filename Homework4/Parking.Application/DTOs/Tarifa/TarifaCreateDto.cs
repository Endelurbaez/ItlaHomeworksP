using System.ComponentModel.DataAnnotations;

namespace Parking.Application.Dtos.Tarifa 
{
    public class CreateTarifaDto 

    {
        [Required]
        public string TipoVehiculo { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 1000)]
        public decimal MontoHora { get; set; } = decimal.MinValue;
        public decimal MontoDia { get; set; }  = decimal.MaxValue;
    }
}