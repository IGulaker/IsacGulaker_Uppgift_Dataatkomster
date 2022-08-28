using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Address
{
    public class UpdateAddressModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on city name (Minimum one letter, maximum 50 letters)")]
        public string NewAddressCity { get; set; } = null!;

        [RegularExpression("^[0-9]{3} [0-9]{2}$", ErrorMessage = "Incorrect format on postal code (Accepted format: xxx xx)")]
        public string NewAddressPostalCode { get; set; } = null!;

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on street name (Minimum one letter, maximum 50 letters)")]
        public string NewAddressStreetName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Incorrect length on residence number (Maximum 50 letters)")]
        public string? NewAddressResidenceNumber { get; set; }
    }
}