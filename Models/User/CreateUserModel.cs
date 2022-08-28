using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.User
{
    public class CreateUserModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on first name (Minimum one letter, maximum 50 letters)")]
        public string NewUserFirstName { get; set; } = null!;

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on last name (Minimum one letter, maximum 50 letters)")]
        public string NewUserLastName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Incorrect format on email adress")]
        public string NewUserEmailAddress { get; set; } = null!;

        [StringLength(20, ErrorMessage = "Incorrect length on phone number (Maximum 20 digits)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Incorrect format on phone number (Only digits allowed)")]
        public string? NewUserPhoneNumber { get; set; }

        [StringLength(20, ErrorMessage = "Incorrect length on alternative phone number (Maximum 20 digits)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Incorrect format on alternitive phone number (Only digits allowed)")]
        public string? NewUserAlternativePhoneNumber { get; set; }
        public CreateAddressModel NewUserAddress { get; set; } = null!;
        public string NewUserPassword { get; set; } = null!;
    }
}