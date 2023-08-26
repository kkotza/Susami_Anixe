using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Dto;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Services.Interfaces;

namespace Susami_Anixe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {        
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {            
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet("{hotelId}")]
        public IEnumerable<Booking> Get(int hotelId)
        {
            return _bookingService.GetByHotelId(hotelId);
        }

        [HttpPut]       
        public IActionResult Update(BookingDto dto)
        {                            

            if (dto == null || dto.Id <= 0 )
            {
                return BadRequest("Booking Id expected to have a proper value");
            }

            var updateBooking = _mapper.Map<Booking>(dto);            

            var existingBooking = _bookingService.Get(dto.Id).FirstOrDefault();
            if (existingBooking == null)
            {
                return NotFound();
            }

            existingBooking.CustomerName = updateBooking.CustomerName;
            existingBooking.Pax = updateBooking.Pax;
            existingBooking.HotelId = updateBooking.HotelId;

            var result = _bookingService.Update(existingBooking);

            return Ok(result);            
        }
    }
}
