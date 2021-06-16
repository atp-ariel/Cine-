using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer.Statistics
{
    public class TicketSalesStatisticsMovie
    {
        private readonly ApplicationDbContext context;

        private int ticketsSold;
        public TicketSalesStatisticsMovie(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }
        public void Filter(Movie movie)
        {
            List<Batch> batches = context.Batch.ToList();
            int idMovie = movie.Id;
            int count = 0;

            foreach (var batch in batches)
            {
                int cinemaId = batch.CinemaId;
                DateTime startTime = batch.ScheduleStartTime;
                DateTime endTime = batch.ScheduleEndTime;


                count += context.TicketPurchase.Count(x => (x.SeatId == cinemaId && x.BatchScheduleStartTime.CompareTo(startTime) == 0 &&
                           x.BatchScheduleEndTime.CompareTo(endTime) == 0));
            }
            ticketsSold= count;
        }
    }
}
