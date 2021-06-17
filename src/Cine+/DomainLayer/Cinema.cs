using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Cinema
    {
        [Display(Name = "Sala")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Capacidad")]
        public int Capacity { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }

    }
}
