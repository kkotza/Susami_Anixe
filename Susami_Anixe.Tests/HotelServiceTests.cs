
using Microsoft.EntityFrameworkCore;
using Moq;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Repositories;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Services;
using Susami_Anixe.Core.Services.Interfaces;
using System.Reflection.Metadata;


namespace Susami_Anixe.Tests
{
    public class HotelServiceTests : IClassFixture<TestDatabaseFixture>
    {
        
        private TestDatabaseFixture Fixture { get; }
        private readonly Mock<IHotelRepository> repositoryMock = new Mock<IHotelRepository>();
        private readonly IHotelService _hotelService;

        public HotelServiceTests(TestDatabaseFixture fixture)
        {
            Fixture = fixture;
            _hotelService = new HotelService(repositoryMock.Object);
        }


        [Fact]
        public void Add_Hotel()
        {
            //test database

            var hotel = new Hotel("Test Hotel", "Test address", 1);

            using var context = Fixture.CreateContext();

            context.Database.BeginTransaction();

            var repo = new HotelRepository(context);
            repo.Create(hotel);

            context.ChangeTracker.Clear();

            var foundHotel = context.Hotels.Single(b => b.Name == "Test Hotel");           

            Assert.Equal("Test Hotel", foundHotel.Name);
        }

        [Fact]
        public void Get_By_Hotel_Name()
        {            
            var hotels = new List<Hotel>()
            {
                new Hotel("test", "", 1),
                new Hotel("test2","", 2),
            };
            
            repositoryMock.Setup(x => x.GetByName("test")).Returns(hotels);

            // Act
            IEnumerable<Hotel> result = _hotelService.GetByName("test");
            // Assert
            Assert.Equal(result, hotels);           
        }
              
    }
}
