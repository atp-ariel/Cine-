using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Batch
    {
        [Display(Name = "Inicio función")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime ScheduleStartTime { get; set; }

        [Display(Name = "Final función")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime ScheduleEndTime { get; set; }

        public virtual Schedule Schedule { get; set; }

        [Display(Name = "Sala")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get ; set;}

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Display(Name ="Precio de la entrada")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public float TicketPrice { get; set; }
    }
}
