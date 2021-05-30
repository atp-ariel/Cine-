using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Identity
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Ingrese su nombre de usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}