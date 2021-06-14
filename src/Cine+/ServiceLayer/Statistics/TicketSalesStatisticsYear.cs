using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;
using DomainLayer;

namespace ServiceLayer.Statistics
{
    public class TicketSalesStatisticsYear
    {
        private readonly ApplicationDbContext context;

        private int ticketsSold;
        private int[] months;
        private int[] ticketsSoldYear;
        public TicketSalesStatisticsYear(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }
        public int[] TicketsSoldYear { get { return ticketsSoldYear; } private set { ticketsSoldYear = value; } }
        public int[] Months { get { return months; } private set { months = value; } }

        public void Filter(DateTime month)
        {
            Dictionary<int, int> ticketsSoldDict = new Dictionary<int, int>();
            DateTime start = month;
            DateTime end = month.AddMonths(1);

            List<TicketPurchase> tickets = context.TicketPurchase.ToList();
            int count = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
            ticketsSoldDict.Add(start.Month, count);
            ticketsSold = count;


            for (int i = 1; i <= 11; i++)
            {
                end = end.AddMonths(1);
                start = start.AddMonths(1);
                int count_ = context.TicketPurchase.Count(x => x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) < 0);
                ticketsSoldDict.Add(start.Month, count_);
                ticketsSold += count_;

            }
            months = ticketsSoldDict.Keys.ToArray();
            ticketsSoldYear = ticketsSoldDict.Values.ToArray();


        }
    }
}
