using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.EntityFrameworkCore;


namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }
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
                .HasKey(c => new { c.CinemaId,c.ScheduleStartTime,c.ScheduleEndTime});
            modelBuilder.Entity<TicketPurchase>()
                .HasKey(c => new { c.CinemaId,c.BatchScheduleStartTime,c.BatchScheduleEndTime, c.SeatId });
            modelBuilder.Entity<Seat>()
                .HasKey(c => new { c.CinemaId, c.Id});

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<TicketPurchase> TicketPurchase { get; set; }
        public DbSet<PhysicalTicketPurchase> PhysicalTicketPurchase { get; set; }
        public DbSet<OnlineTicketPurchase> OnlineTicketPurchase { get; set; }
        public DbSet<DiscountList> DiscountList { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Batch> Batch { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Rating> Rating { get; set; }
    }
}
