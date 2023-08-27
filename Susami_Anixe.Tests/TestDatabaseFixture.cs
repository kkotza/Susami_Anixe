using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.DataAccess;
using Susami_Anixe.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.Tests
{
    public class TestDatabaseFixture
    {  
        private const string ConnectionString = @"Data Source=../AnixeTest.sqlite";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        //context.AddRange(
                        //        new List<Hotel> { new Hotel("Test Hotel", "Test address", 1), new Hotel("Test2 Hotel", "Test address", 2) });

                        //context.SaveChanges();                        
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public AnixeDbContext CreateContext()
            => new AnixeDbContext(
                new DbContextOptionsBuilder<AnixeDbContext>()
                    .UseSqlite(ConnectionString)
                    .Options);              
    }
}
