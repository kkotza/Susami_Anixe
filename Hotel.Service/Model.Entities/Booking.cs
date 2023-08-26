
using System.Reflection.Metadata;

namespace Susami_Anixe.Core.Model.Entities
{
    public class Booking
    {
        public int Id { get; set; }        
        public required string CustomerName { get; set; }
        public byte? Pax { get; set; }

        public int HotelId { get; set; }
        public required Hotel Hotel { get; set; } 

    }
}
