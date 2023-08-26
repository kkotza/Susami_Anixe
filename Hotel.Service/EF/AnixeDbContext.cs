using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Entities;
using System.Reflection.Metadata;

namespace Susami_Anixe.Core.DataAccess
{

    public partial class AnixeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AnixeDatabase");
        }  

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Booking>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Booking>()                
                .HasOne(e => e.Hotel)
                .WithMany(e => e.Bookings)
                .HasForeignKey(e => e.HotelId);            

        }
    }
}