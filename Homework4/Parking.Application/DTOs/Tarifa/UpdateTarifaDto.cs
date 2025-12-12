using System.ComponentModel.DataAnnotations;

namespace Parking.Application.Dtos.Tarifa 
{
    public class UpdateTarifaDto 
    {
        [Required] public string TipoVehiculo { get; set; } = string.Empty;
        [Required] public decimal MontoHora { get; set; }
        [Required] public decimal MontoDia { get; set; }
    }
}
