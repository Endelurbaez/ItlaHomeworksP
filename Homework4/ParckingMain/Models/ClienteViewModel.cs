using System.ComponentModel.DataAnnotations;

namespace Parking.Main.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150, ErrorMessage = "El nombre no puede tener más de 150 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "La cédula no puede tener más de 20 caracteres")]
        public string Cedula { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Teléfono inválido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Correo inválido")]
        [StringLength(150, ErrorMessage = "El correo no puede tener más de 150 caracteres")]
        public string Correo { get; set; } = string.Empty;
    }
}






