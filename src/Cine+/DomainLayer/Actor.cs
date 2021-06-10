using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Actor 
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        [Display(Name = "Nombre y apellidos")]
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        public Actor()
        {
            Movies = new List<Movie>();
        }

    }
}
