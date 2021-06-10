using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Batch
    {
        public DateTime ScheduleStartTime { get; set; }
        public DateTime ScheduleEndTime { get; set; }
        public virtual Schedule Schedule { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get ; set;}
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
