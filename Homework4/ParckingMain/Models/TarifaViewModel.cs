using System.ComponentModel.DataAnnotations;

namespace Parking.Main.Models
{
    public class TarifaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio por hora es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "Precio inválido")]
        public decimal PrecioPorHora { get; set; }
    }
}

