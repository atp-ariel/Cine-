using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class OnlineTickectPurchase:TicketPurchase
    {
        [Display(Name ="Tarjeta de Crédito")]
        [Required]
        public string CreditCard { get; set; }
    }
}
