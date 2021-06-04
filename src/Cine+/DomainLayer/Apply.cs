using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Apply
    {
        public int DiscountListId { get; set; }
        public virtual DiscountList DiscountList { get; set; }
        [Key]
        public int TicketPurchaseId { get; set; }
        public virtual TicketPurchase TicketPurchase { get; set; }
        public float Price { get; set; }
    }
}
