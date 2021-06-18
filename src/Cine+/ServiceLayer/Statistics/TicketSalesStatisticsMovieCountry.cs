using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer.Statistics
{
    public class TicketSalesStatisticsMovieCountry
    {
        private readonly ApplicationDbContext context;
        private int ticketsSold;
        public TicketSalesStatisticsMovieCountry(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }

        public void Filter(string country)
        {
            Country country_ = context.Country.First(x => x.Name == country);
            List<Movie> movies = country_.Movies.ToList();
            int count = 0;
            foreach (var movie in movies)
            {
                List<Batch> batches = movie.Batches.ToList();
                foreach (var batch in batches)
                {
                    int cinemaId = batch.CinemaId;
                    DateTime startTime = batch.ScheduleStartTime;
                    DateTime endTime = batch.ScheduleEndTime;

                    count += context.TicketPurchase.Count(x => (x.CinemaId == cinemaId && x.BatchScheduleStartTime.CompareTo(startTime) == 0 &&
                   x.BatchScheduleEndTime.CompareTo(endTime) == 0));
                }
            }
            ticketsSold = count;

        }
    }
}
