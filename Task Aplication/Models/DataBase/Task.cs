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
        [StringLength(100, ErrorMessage = "La {0} debe tener almenos {2}")]
        [Display(Name = "Tarea")]
        public string Infotask { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese una fecha")]
        [DataType(DataType.DateTime)]
        [Display(Name = "La tarea es para el")] 
        public DateTime? Date { get; set; }

        public virtual User IduserNavigation { get; set; }
    }
}
