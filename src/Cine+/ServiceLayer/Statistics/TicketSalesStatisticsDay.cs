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
        private string[] hours;
        private int[] ticketsSoldMonth;

        public TicketSalesStatisticsDay(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }
        public int[] TicketsSoldMonth { get { return ticketsSoldMonth; } private set { ticketsSoldMonth = value; } }
        public string[] Hours { get { return hours; } private set { hours = value; } }

        public void Filter(DateTime day, int n)
        {
            Dictionary<string, int> ticketsSoldDict = new Dictionary<string, int>();
            DateTime start = day;
            DateTime end = day.AddHours(n);
            
            List<TicketPurchase> tickets = context.TicketPurchase.ToList();
            int count = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
            ticketsSoldDict.Add(start.Hour.ToString() + "-"+end.Hour.ToString(), count);

            for (int i = n; i <=24-n; i+=n)
            {
                end = end.AddHours(n);
                start=start.AddHours(n);
                int count_ = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) > 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
                ticketsSoldDict.Add(start.Hour.ToString() + "-" + end.Hour.ToString(), count_);

            }
            hours = ticketsSoldDict.Keys.ToArray();
            ticketsSoldMonth = ticketsSoldDict.Values.ToArray();
        }
    }
}
