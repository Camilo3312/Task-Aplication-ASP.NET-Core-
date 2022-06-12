using System.ComponentModel.DataAnnotations;

namespace Task_Aplication.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Porfavor ingrese un correo")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese una contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Correo")]
        public string Password { get; set; }
    }
}
