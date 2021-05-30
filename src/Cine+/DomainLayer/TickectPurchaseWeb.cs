using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class TickectPurchaseWeb:TicketPurchase
    {

        [Required]
        public string CreditCard { get; set; }
    }
}
