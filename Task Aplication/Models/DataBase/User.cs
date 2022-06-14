using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web_API;

#nullable disable

namespace Task_Aplication.Models.DataBase
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Iduser { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese un nombre")]
        [StringLength(50, ErrorMessage = "El {0} debe tener almenos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Names { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese una imagen")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen de perfil")]
        public string ImageProfile { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese un correo")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese una contraseña")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } 

        public string Rol { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
