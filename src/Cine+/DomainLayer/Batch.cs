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
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]
        [Required]
        public string Title { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        [Required]
        [NotMapped]
        public Schedule Schedule { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Country> Countries { get; set; }

    }
}
