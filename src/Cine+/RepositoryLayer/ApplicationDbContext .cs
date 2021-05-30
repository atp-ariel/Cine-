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
                .HasNoKey();
            modelBuilder.Entity<TicketPurchase>()
                .HasKey(c => new { c.CinemaId, c.SeatId });
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<TicketPurchase> TicketPurchase { get; set; }
        public DbSet<TickectPurchaseWeb> TickectPurchaseWeb { get; set; }


       


    }
}
