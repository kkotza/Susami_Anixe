using Susami_Anixe.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.Core.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        void Update(Booking booking);
        IQueryable<Booking> Get(int id);
        List<Booking> GetByHotelId(int hotelId);
    }
}
