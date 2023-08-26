using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security;
using System.Threading;
using System.Xml.Linq;

using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Entities;

namespace Susami_Anixe.DataAccess
{
    
    public partial class AnixeDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "AnixeDatabase");
        //}

        public AnixeDbContext(DbContextOptions<AnixeDbContext> dbcontextoption)
            : base(dbcontextoption)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Books { get; set; }
    }
}