using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Manufacturer
{
    public class CreateManufacturerModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on manufacturer name (Minimum one letter, maximum 50 letters)")]
        public string NewManufacturerName { get; set; } = null!;
        public CreateAddressModel NewManufacturerAddress { get; set; } = null!;
    }
}