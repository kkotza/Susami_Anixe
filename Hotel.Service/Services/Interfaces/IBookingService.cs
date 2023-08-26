using Susami_Anixe.Core.Model.Entities;

namespace Susami_Anixe.Core.Services.Interfaces
{
    public interface IBookingService
    {
        Booking? Update(Booking booking);
        IQueryable<Booking> Get(int id);
        List<Booking> GetByHotelId(int HotelId);
    }
}