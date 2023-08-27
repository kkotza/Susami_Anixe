using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Susami_Anixe.Core.Model.Dto;
using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.Core.Services.Interfaces;

namespace Susami_Anixe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {

        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet("{name}")]        
        public IEnumerable<Hotel> Get(string name)
        {         
            return _hotelService.GetByName(name);
        }

        [HttpPost]
        public IActionResult Create(HotelDto dto)
        {
            var newHotel = _mapper.Map<Hotel>(dto);

            var result = _hotelService.Create(newHotel);
            return Ok(result);
        }

    }
}
