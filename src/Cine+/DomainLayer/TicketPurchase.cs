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
        public int CinemaId { get; set; }

        [Display(Name ="Inicio función")]
        public DateTime BatchScheduleStartTime { get; set; }

        [Display(Name = "Final función")]
        public DateTime BatchScheduleEndTime { get; set; }

        [ForeignKey("CinemaId, BatchScheduleStartTime, BatchScheduleEndTime")]
        public Batch Batch { get; set; }

        [Display(Name = "Silla")]
        public int SeatId { get; set; }

        [ForeignKey("CinemaId, SeatId")]
        public Seat Seat { get; set; }

        public int DiscountListId { get; set; }
        public virtual DiscountList DiscountList { get; set; }

        public float Price { get; set; }

        public int PartnerCode { get; set; }
        public virtual Partner Partner { get; set; }
        public int PointsSpent { get; set; }
    }
}
