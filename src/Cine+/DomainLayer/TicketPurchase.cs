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
        public int SeatCinemaId { get; set; }
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public DateTime ScheduleStartTime { get; set; }
        public DateTime ScheduleEndTime { get; set; }
        public virtual Schedule Schedule { get; set; }

    }
}
