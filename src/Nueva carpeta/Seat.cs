using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Seat
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]
        [Required]
        public string Ubication { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
