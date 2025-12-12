using System.ComponentModel.DataAnnotations;

namespace Parking.Application.Dtos.Cliente 
{
    public class CreateClienteDto 
    {
        [Required] public string Nombre { get; set; } = string.Empty;
        [Required] public string Apellido { get; set; } = string.Empty;
        [Required] public string Telefono{ get; set; } = string.Empty;
        [Required] public string Cedula { get; set; } = string.Empty;
        [EmailAddress] public string Email { get; set; } = string.Empty;
    }
}
