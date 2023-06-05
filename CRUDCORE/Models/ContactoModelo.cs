using System.ComponentModel.DataAnnotations;
namespace CRUDCORE.Models
{
    public class ContactoModelo
    {
        // Referencia a cada columna de la tabla Contacto
        public int IdContacto { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }

    }
}
