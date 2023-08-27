
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
    public class BookingServiceTests : IClassFixture<TestDatabaseFixture>
    {

        private TestDatabaseFixture Fixture { get; }
        private readonly Mock<IBookingRepository> repositoryMock = new Mock<IBookingRepository>();
        private readonly IBookingService _bookingService;

        public BookingServiceTests(TestDatabaseFixture fixture)
        {
            Fixture = fixture;
            _bookingService = new BookingService(repositoryMock.Object);
        }


        [Fact]
        public void Update_Booking()
        {
            //test database

            var hotel = new Hotel("Test Hotel", "Test address", 1);
            var booking = new Booking { CustomerName = "customer 1", HotelId = 1, Hotel = hotel };

            using var context = Fixture.CreateContext();

            context.Database.BeginTransaction();

            var repo = new BookingRepository(context);            
            repo.Update(booking);

            context.ChangeTracker.Clear();

            var result = context.Bookings.Include(b=> b.Hotel).Single(b => b.HotelId == 1);          

            Assert.Equal(result.Hotel.Name, booking.Hotel.Name);
        }

        [Fact]
        public void Get_By_NotFound_Hotel_Id()
        {
            var hotel = new Hotel("Test Hotel", "Test address", 1);
            var bookings = new List<Booking>()
            {
                new Booking { CustomerName = "customer 1", HotelId = 1, Hotel = hotel },
                new Booking { CustomerName = "customer 2", HotelId = 1, Hotel = hotel },
                new Booking { CustomerName = "customer 3", HotelId = 1, Hotel = hotel }
            };

            repositoryMock.Setup(x => x.GetByHotelId(1)).Returns(bookings);

            // Act
            IEnumerable<Booking> result = _bookingService.GetByHotelId(2);
            // Assert
            Assert.NotEqual(result, bookings);
        }

    }
}
