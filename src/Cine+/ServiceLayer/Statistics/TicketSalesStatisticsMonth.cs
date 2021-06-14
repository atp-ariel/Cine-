using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer.Statistics
{
    public class TicketSalesStatisticsMonth
    {
        private readonly ApplicationDbContext context;

        private int ticketsSold;
        private int[] days;
        private int[] ticketsSoldMonth;
        public TicketSalesStatisticsMonth(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }
        public int[] TicketsSoldMonth { get { return ticketsSoldMonth; } private set { ticketsSoldMonth = value; } }
        public int[] Months { get { return days; } private set { days = value; } }

        public void Filter(DateTime month)
        {
            Dictionary<int, int> ticketsSoldDict = new Dictionary<int, int>();
            DateTime start = month;
            DateTime end = month.AddDays(1);

            List<TicketPurchase> tickets = context.TicketPurchase.ToList();
            int count = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
            ticketsSoldDict.Add(start.Day, count);
            ticketsSold = count;


            for (int i = 1; i <= DateTime.DaysInMonth(start.Year, start.Month) - 1; i++)
            {
                end = end.AddDays(1);
                start = start.AddDays(1);
                int count_ = context.TicketPurchase.Count(x => x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) < 0);
                ticketsSoldDict.Add(start.Day, count_);
                ticketsSold += count_;

            }
            days = ticketsSoldDict.Keys.ToArray();
            ticketsSoldMonth = ticketsSoldDict.Values.ToArray();


        }
    }
}
