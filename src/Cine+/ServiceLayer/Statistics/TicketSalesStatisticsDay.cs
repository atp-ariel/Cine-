using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using RepositoryLayer;

namespace ServiceLayer.Statistics
{
    public class  TicketSalesStatisticsDay
    {
        private readonly ApplicationDbContext context;

        private int ticketsSold;
        private int[] days;
        private int[] ticketsSoldMonth;

        public TicketSalesStatisticsDay(ApplicationDbContext context)
        {
            this.context = context;
        }
       
        public Dictionary<string, int> Filter(DateTime day, int n)
        {
            Dictionary<string, int> ticketsSold = new Dictionary<string, int>();
            DateTime start = day;
            DateTime end = day.AddHours(n);
            
            List<TicketPurchase> tickets = context.TicketPurchase.ToList();
            int count = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
            ticketsSold.Add(start.Hour+"-"+end.Hour, count);

            for (int i = n; i <=24-n; i+=n)
            {
                end = end.AddHours(n);
                start=start.AddHours(n);
                int count_ = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) > 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
                ticketsSold.Add(start.Hour + "-" + end.Hour, count_);

            }
            return ticketsSold;
        }
    }
}
