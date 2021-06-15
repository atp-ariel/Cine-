using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer.Statistics
{
    public class TicketSalesStatisticsMovieRating
    {
        private readonly ApplicationDbContext context;
        private int ticketsSold;
        public TicketSalesStatisticsMovieRating(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }

        public void Filter(string rating)
        {
            Rating rating_ = context.Rating.First(x => x.Name == rating);
            List<Movie> movies = rating_.Movies.ToList();
            int count = 0;
            foreach (var movie in movies)
            {
                List<Batch> batches = movie.Batches.ToList();
                foreach (var batch in batches)
                {
                    int cinemaId = batch.CinemaId;
                    DateTime startTime = batch.ScheduleStartTime;
                    DateTime endTime = batch.ScheduleEndTime;

                    count += context.TicketPurchase.Count(x => (x.SeatId == cinemaId && x.BatchScheduleStartTime.CompareTo(startTime) == 0 &&
                   x.BatchScheduleEndTime.CompareTo(endTime) == 0));
                }
            }
            ticketsSold = count;

        }
    }
}
