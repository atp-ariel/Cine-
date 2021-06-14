using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer.Statistics
{
     public class TicketSalesStatisticsMovieGenre
    {
        private readonly ApplicationDbContext context;
        private int ticketsSold;
        public TicketSalesStatisticsMovieGenre(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }

        public void Filter(DateTime month)
        {
            Dictionary<string, int> ticketsSoldDict = new Dictionary<string, int>();
            DateTime start = month;
            DateTime end = month.AddDays(1);
            ticketsSold = 0;

            List<TicketPurchase> tickets = context.TicketPurchase.ToList();
            int count = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
            ticketsSoldDict.Add(start.Day + "-" + end.Day, count);

            for (int i = 1; i <= DateTime.DaysInMonth(start.Year,start.Month) - 1; i ++)
            {
                end = end.AddDays(1);
                start = start.AddDays(1);
                int count_ = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) < 0));
                ticketsSoldDict.Add(start.Hour + "-" + end.Hour, count);

            }
            
        }
}
