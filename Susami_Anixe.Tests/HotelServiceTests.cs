using Microsoft.Extensions.Logging;
using Moq;
using Susami_Anixe.Core.Model.Dto;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.Tests
{
    public  class HotelServiceTests
    {
        //private readonly Mock<Logger> _loggerMock;
        private readonly Mock<IHotelRepository> _hotelRepositoryMock;

        public HotelServiceTests()
        {
            //_loggerMock = new Mock<Logger>();
            _hotelRepositoryMock = new Mock<IHotelRepository>();
        }

        [Fact]
        public void AddMovie_Should_Add_Movie_To_Repository()
        {
            // Arrange
            var hotelDto = new HotelDto
            {
                Name = "Test Hotel",
                Address = "Test address",
                Star = 1
            };

            _hotelRepositoryMock.Setup(repo => repo.Create(It.IsAny<Hotel>())).Verifiable();
            //_hotelRepositoryMock.Setup(repo => repo.SaveChanges()).Verifiable();

            var hotelService = new HotelService(_hotelRepositoryMock.Object);

            //// Act
            //var result = hotelService.Create(movieDto);

            //// Assert
            //_movieRepositoryMock.Verify(); // Verifies that Add and SaveChanges were called
            //Assert.NotNull(result);
            //Assert.NotEqual(Guid.Empty, result.Id);
            //Assert.Equal(0, result.Rating); // Assuming the default rating is 0
        }
    }
}
