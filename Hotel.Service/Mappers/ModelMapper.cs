using AutoMapper;
using Susami_Anixe.Core.Model.Dto;
using Susami_Anixe.Core.Model.Entities;

namespace Susami_Anixe.Core.Model.Dto
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<HotelDto, Hotel>();
            CreateMap<BookingDto, Booking>();
        }
    }
}