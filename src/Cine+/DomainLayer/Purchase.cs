using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Purchase
    {
        [Key]
        public int PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public int PointsSpent { get; set; }
        public virtual ICollection<TicketPurchase> TicketsPurchase { get; set; }
    }
}
