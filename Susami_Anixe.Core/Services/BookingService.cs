using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public Booking? Update(Booking booking)
        {
            
            _bookingRepo.Update(booking);
            return booking;
           
        }

        public IQueryable<Booking> Get(int id)
        {
            return _bookingRepo.Get(id);
        }

        public List<Booking> GetByHotelId(int hotelId)
        {
            return _bookingRepo.GetByHotelId(hotelId);
        }
    }
}
