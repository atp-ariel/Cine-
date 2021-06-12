using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Discount
    {
        public int Id { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage = "Esta campo es obligatorio")]
        public string Name { get; set; }

        [Display(Name="Dinero descontado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public float DiscountedMoney { get; set; }
        public ICollection<DiscountList> DiscountLists { get; set; }
    }
}
