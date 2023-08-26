using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Susami_Anixe.Core.Model.Dto;
using Susami_Anixe.Core.Model.Entities;
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
            var updateBooking = _mapper.Map<Booking>(dto);
            var result = _bookingService.Update(updateBooking);

            if (result != null) { return Ok(result); }

            return NotFound("Booking not found / error");
        }
    }
}
