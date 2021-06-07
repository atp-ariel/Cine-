using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class DiscountList
    {
        public int Id { get; set; }
        public float TotalDiscounted { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
}
