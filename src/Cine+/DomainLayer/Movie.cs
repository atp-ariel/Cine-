using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DomainLayer
{
    public class Movie 
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Batch> Batches { get; set; }
    }
     
}
