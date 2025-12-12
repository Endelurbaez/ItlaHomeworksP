namespace Parking.Application.Dtos.Tarifa 
{
    public class TarifaDto
    {
        public int Id { get; set; }
        public string TipoVehiculo { get; set; } = string.Empty;
        public decimal MontoHora { get; set; }
        public decimal MontoDia { get; set; }
    }
}
