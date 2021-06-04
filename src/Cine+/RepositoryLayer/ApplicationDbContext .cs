using System;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.EntityFrameworkCore;


namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Cine+.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
                .HasKey(c => new { c.StartTime, c.EndTime});
            modelBuilder.Entity<Batch>()
                .HasKey(c => new { c.MovieId, c.CinemaId,c.ScheduleId});
            modelBuilder.Entity<TicketPurchase>()
                .HasKey(c => new { c.CinemaId, c.SeatId ,c.ScheduleId});

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<TicketPurchase> TicketPurchase { get; set; }
        public DbSet<OnlineTickectPurchase> TickectPurchaseWeb { get; set; }
        public DbSet<DiscountList> DiscountList { get; set; }
        public DbSet<Apply> Apply { get; set; }


       


    }
}
