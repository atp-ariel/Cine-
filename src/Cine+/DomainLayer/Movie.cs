using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DomainLayer
{
    public class Movie 
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Géneros")]
        public virtual ICollection<Genre> Genres { get; set; }

        [Display(Name = "Países")]
        public virtual ICollection<Country> Countries { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }

        [Display(Name = "Actores")]
        public virtual ICollection<Actor> Actors { get; set; }
    }
     
}
