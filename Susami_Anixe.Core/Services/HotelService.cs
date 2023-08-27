using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Services.Interfaces;
using Susami_Anixe.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Susami_Anixe.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;

        public HotelService(IHotelRepository hotelRepo)
        {
            _hotelRepo = hotelRepo;            
        }

        public Hotel Create(Hotel hotel)
        {
            return _hotelRepo.Create(hotel);
        }

        public IEnumerable<Hotel> GetByName(string term)
        {
            return _hotelRepo.GetByName(term);
        }
    }
}
