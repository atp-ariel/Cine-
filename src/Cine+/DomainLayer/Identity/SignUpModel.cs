using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Identity
{
    public class SignUpModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo electrónico es incorrecto u omitido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username {get; set;}

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Contraseña inválida u omitida")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmedPassword {get; set;}

        [DataType(DataType.PhoneNumber)]
        public string Phone {get; set;}

        [DataType(DataType.Text)]
        public string Address {get; set;}
        
        public bool MatchPasswords(){
            return Password == ConfirmedPassword;
        }
    }
}