using Moq;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Services;

namespace Susami_Anixe.Tests;

public class HotelTests
{
    [Fact]
    public void CreateHotel_ValidInput_ReturnsHotelObject()
    {
        // Arrange
        string name = "Sample Hotel";
        string address= "test address";
        byte star = 1;


        // Act
        var hotel = new Hotel(name, address, star);

        // Assert
        Assert.NotNull(hotel);
        Assert.Equal(name, hotel.Name);
        Assert.Equal(address, hotel.Address);
        Assert.Equal(star, hotel.Star);
    }

    [Theory]
    [InlineData(null, "Sample address", 1, "Value cannot be null. (Parameter 'name')")]    
    public void CreateHotel_InvalidInput_ThrowsArgumentException(string name, string address, byte star, string errorMessage)
    {                
        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => new Hotel(name, address, star));
        Assert.Equal(errorMessage, ex.Message);
    }

    [Theory]    
    [InlineData("Sample Hotel", null, 6, "Value cannot be outside range 1-5. (Parameter 'star')")]
    public void CreateHotel_InvalidInput_ThrowsArgumentOutOfRangeException(string name, string address, byte star, string errorMessage)
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Hotel(name, address, star));
        Assert.Equal(errorMessage, ex.Message);
    }
}