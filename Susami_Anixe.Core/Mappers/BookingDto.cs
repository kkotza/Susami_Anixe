
using System.Reflection.Metadata;

namespace Susami_Anixe.Core.Model.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }        
        public required string CustomerName { get; set; }
        public byte? Pax { get; set; }

        public int HotelId { get; set; }     

    }
}
