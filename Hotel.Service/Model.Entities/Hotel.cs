﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}