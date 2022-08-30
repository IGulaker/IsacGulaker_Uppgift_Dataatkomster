using IsacGulaker_Uppgift_Dataatkomster.Models.Address;

namespace IsacGulaker_Uppgift_Dataatkomster
{
    public class CustomerSessionProfile
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public RequestAddressModel Address { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
    }
}
