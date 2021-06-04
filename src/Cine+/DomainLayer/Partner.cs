using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Partner
    {      
        [Key]
        public int Code { get; set; }

        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Lastname Required")]
        [StringLength(50, ErrorMessage = "5 to 50 characters.", MinimumLength = 3)]
        public string Email { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public long Points { get; set; }
        
    }
}
