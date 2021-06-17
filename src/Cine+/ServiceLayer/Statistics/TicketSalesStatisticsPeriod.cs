using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryLayer;
using DomainLayer;


namespace ServiceLayer.Statistics
{
    public class TicketSalesStatisticsPeriod
    {
        private readonly ApplicationDbContext context;

        private int ticketsSold;
        public TicketSalesStatisticsPeriod(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int TicketsSold { get { return ticketsSold; } private set { ticketsSold = value; } }

        public void Filter(DateTime start,DateTime end)
        {
            List<TicketPurchase> tickets = context.TicketPurchase.ToList();
            int count = context.TicketPurchase.Count(x => (x.BatchScheduleStartTime.CompareTo(start) >= 0 && x.BatchScheduleEndTime.CompareTo(end) <= 0));
            ticketsSold = count;
        }
    }
}
