using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.DataAccess.Repositories
{   
    public class BookingRepository : IBookingRepository
    {
        public void Update(Booking booking)
        {

        }

        public List<Booking> GetByHotelId(int HotelId)
        {
            return new List<Booking>();
        }
    }
}
