using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using Susami_Anixe.Core.DataAccess;
using Susami_Anixe.Core.Model.Dto;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Repositories;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Services;
using Susami_Anixe.Core.Services.Interfaces;
using System.Reflection.Metadata;

namespace Susami_Anixe.Tests
{
    public  class HotelServiceTests
    {
        //private readonly Mock<Logger> _loggerMock;
        private readonly Mock<IHotelRepository> _hotelRepositoryMock;
        private readonly IHotelRepository _hotelRepository;
        private readonly DbContextOptions<AnixeDbContext> _contextOptions;
        //private readonly IMapper _mapper;

        public HotelServiceTests()
        {
            _hotelRepositoryMock = new Mock<IHotelRepository>();

            var directoryName = System.IO.Directory.GetCurrentDirectory();
            var dataSource = $"Data Source={directoryName}//Anixe.sqlite";

            _contextOptions = new DbContextOptionsBuilder<AnixeDbContext>()
                .UseSqlite(dataSource)                
                .Options;

            var context = new AnixeDbContext(_contextOptions);

            
            context.AddRange(
                new List<Hotel> { new Hotel("Test Hotel", "Test address", 1), new Hotel("Test2 Hotel", "Test address", 2) });

            context.SaveChanges();

            _hotelRepository = new HotelRepository(context);
        }

        [Fact]
        public void Create_Should_Add_Hotel_To_Repository()
        {
            _hotelRepositoryMock.Setup(repo => repo.Create(It.IsAny<Hotel>())).Verifiable();
            _hotelRepositoryMock.Setup(repo => repo.SaveChanges()).Verifiable();

            // Arrange
            var hotel = new Hotel("Test Hotel", "Test address", 1);                     
            var _hotelService = new HotelService(_hotelRepository);

            // Act
            var result = _hotelService.Create(hotel);

            // Assert            
            Assert.NotNull(result);                        
        }
    }
}
