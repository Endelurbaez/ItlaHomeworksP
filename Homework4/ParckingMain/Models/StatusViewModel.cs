using System.ComponentModel.DataAnnotations;

namespace Parking.Main.Models
{
    public class StatusViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del estatus es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}

