using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class TicketPurchase
    {
        [Display(Name = "Sala")]
        [Required]
        public int SeatCinemaId { get; set; }

        [Display(Name = "Silla")]
        [Required]
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        [Display(Name ="Inicio función")]
        [Required]
        public DateTime ScheduleStartTime { get; set; }

        [Display(Name = "Final función")]
        [Required]
        public DateTime ScheduleEndTime { get; set; }
        public virtual Schedule Schedule { get; set; }

        public int DiscountListId { get; set; }
        public virtual DiscountList DiscountList { get; set; }

        public float Price { get; set; }

        public int PartnerCode { get; set; }
        public virtual Partner Partner { get; set; }
        public int PointsSpent { get; set; }
    }
}
