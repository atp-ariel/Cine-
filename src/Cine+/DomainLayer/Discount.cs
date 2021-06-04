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
        [Required]
        public string Name { get; set; }
        [Required]
        public float DiscountedMoney { get; set; }
        public ICollection<DiscountList> DiscountLists { get; set; }
    }
}
