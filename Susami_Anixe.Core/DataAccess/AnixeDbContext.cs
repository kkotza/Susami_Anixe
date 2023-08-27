using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Entities;

namespace Susami_Anixe.Core.DataAccess
{

    public partial class AnixeDbContext : DbContext
    {                

        public AnixeDbContext(DbContextOptions<AnixeDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            //optionsBuilder.UseInMemoryDatabase(databaseName: "AnixeDatabase");                
            //optionsBuilder.UseSqlite("Data Source=InMemoryTest;Mode=Memory;Cache=Shared");                      
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

            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Booking>().ToTable("Booking");            
        }
    }
}