namespace Parking.Application.Dtos.Cliente 
{
    public class ClienteDto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
    }
}
