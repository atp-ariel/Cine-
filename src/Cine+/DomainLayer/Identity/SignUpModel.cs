using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Identity
{
    public class SignUpModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo electrónico es incorrecto u omitido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Contraseña inválida u omitida")]
        public string Password { get; set; }
    }
}