using IsacGulaker_Uppgift_Dataatkomster.Models.Address;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.User
{
    public class RequestUserModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? AlternativePhoneNumber { get; set; }
        public RequestAddressModel Address { get; set; } = null!;
    }
}