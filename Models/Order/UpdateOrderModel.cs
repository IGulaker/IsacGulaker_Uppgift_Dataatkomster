﻿using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Order
{
    public class UpdateOrderModel
    {
        [Range(1, int.MaxValue)]
        public int ProductQuantity { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on city name (Minimum one letter, maximum 50 letters)")]
        public string City { get; set; } = null!;

        [RegularExpression("^[0-9]{3} [0-9]{2}$", ErrorMessage = "Incorrect format on postal code (Accepted format: xxx xx)")]
        public string PostalCode { get; set; } = null!;

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on street name (Minimum one letter, maximum 50 letters)")]
        public string StreetName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Incorrect length on residence number (Maximum 50 letters)")]
        public string? ResidenceNumber { get; set; }
    }
}