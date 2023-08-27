using Susami_Anixe.Core.Model.Entities;

namespace Susami_Anixe.Core.Services.Interfaces
{
    public interface IHotelService
    {
        Hotel Create(Hotel hotel);
        IEnumerable<Hotel> GetByName(string term);
    }
}
