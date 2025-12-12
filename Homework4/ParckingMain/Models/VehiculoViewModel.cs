using System.ComponentModel.DataAnnotations;

namespace Parking.Main.Models
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(20)]
        public string Placa { get; set; } = string.Empty;

        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(100)]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [StringLength(100)]
        public string Modelo { get; set; } = string.Empty;  // ← AÑADIR

        [StringLength(50)]
        public string Color { get; set; } = string.Empty;   // ← AÑADIR

        [Range(1900, 2100, ErrorMessage = "Año inválido")]
        public int? Ano { get; set; }                       // ← AÑADIR (nullable)

        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        public int ClienteId { get; set; }

        public string ClienteNombre { get; set; } = string.Empty;
    }
}





