namespace Parking.Main.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } = string.Empty;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Mensaje { get; set; } = "Ha ocurrido un error inesperado";

        // Excepción es opcional, para debug en desarrollo
        public string Excepcion { get; set; } = string.Empty;
    }
}
