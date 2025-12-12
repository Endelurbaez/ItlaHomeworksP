namespace Parking.Application.Dtos.Vehiculo 
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string TipoVehiculo { get; set; } = string.Empty;
        public string Matricula{ get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int ClienteId { get; set; } = int.MaxValue;
    }
}
