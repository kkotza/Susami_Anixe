using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.DataAccess;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Repositories.Interfaces;

namespace Susami_Anixe.Core.Repositories
{   
    public class BookingRepository : IBookingRepository
    {
        private readonly AnixeDbContext _context;

        public BookingRepository(AnixeDbContext context)
        => _context = context;

        public void Update(Booking booking)
        {            
            //var updateBooking = _context.Bookings.FirstOrDefault(x=> x.Id ==booking.Id);
            //if (updateBooking != null)
            //{
                _context.Bookings.Update(booking);
                _context.SaveChanges();                
            //}                                  
        }

        public List<Booking> GetByHotelId(int hotelId)
        {
            return _context.Bookings.Include(x=> x.Hotel).Where(x => x.HotelId == hotelId).ToList();
        }
    }
}
