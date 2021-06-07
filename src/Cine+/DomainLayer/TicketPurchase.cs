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
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

    }
}
