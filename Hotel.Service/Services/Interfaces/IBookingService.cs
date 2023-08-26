using Susami_Anixe.Core.Model.Entities;

namespace Susami_Anixe.Core.Services.Interfaces
{
    public interface IBookingService
    {
        Booking? Update(Booking booking);
        List<Booking> GetByHotelId(int HotelId);
    }
}