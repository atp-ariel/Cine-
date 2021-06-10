using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DomainLayer
{
    public class Seat
    {
        public int CinemaId { get; set; }
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; } 
    }
}
