using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Task_Aplication.Models.DataBase
{
    public partial class Task
    {
        public int Idtask { get; set; }
        public int? Iduser { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese una tarea")]
        [StringLength(300, ErrorMessage = "La {0} debe tener almenos {2}")]
        [Display(Name = "Descripción")]
        public string Infotask { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese una fecha")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha establecida")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese un titulo")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Título de la tarea")]
        public string Title { get; set; }

        public virtual User IduserNavigation { get; set; }
    }
}
