using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Cinema
    {
        public int Id { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }

    }
}
