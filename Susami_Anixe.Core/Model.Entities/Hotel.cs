using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Susami_Anixe.Core.Model.Entities
{
    public class Hotel
    {        
        public int Id { get; set; }

        public required string Name { get; init; }
        public string? Address { get; set; } = null;

        [Range(1, 5,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public byte Star { get; set; }

        public List<Booking>? Bookings { get; set; }

        [SetsRequiredMembers]
        public Hotel(string name, string address, byte star)
        {
            ArgumentNullException.ThrowIfNull(name);

            if (star<1 || star >5)
            {
                throw new ArgumentOutOfRangeException(nameof(star), "Value cannot be outside range 1-5.");
            }

            Name = name;
            Address = address;
            Star = star;
        }
    }
}