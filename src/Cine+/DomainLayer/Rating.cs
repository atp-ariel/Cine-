using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Rating
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Clasificación")]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Rating()
        {
            Movies = new List<Movie>();
        }
    }
}
