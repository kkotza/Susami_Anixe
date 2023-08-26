using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.DataAccess;
using Susami_Anixe.Core.Repositories.Interfaces;

namespace Susami_Anixe.Core.Repositories
{   
    public class HotelRepository : IHotelRepository
    {
        private readonly AnixeDbContext _context;

        public HotelRepository(AnixeDbContext context)
        => _context = context;

        public Hotel Create(Hotel hotel) {            

            var result = _context.Add<Hotel>(hotel);
            _context.SaveChanges();

            var h = _context.Hotels.Include(x=> x.Bookings).First(h => h.Id == result.Entity.Id);

            return new Hotel
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                Star = h.Star,
                Bookings = h.Bookings
            };
        }

        public List<Hotel> GetByName(string term) 
        {
            return _context.Hotels.Where(x=> x.Name.Contains(term)).ToList();           
        }
    }
}
