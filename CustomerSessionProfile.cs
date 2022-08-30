using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;

namespace IsacGulaker_Uppgift_Dataatkomster
{
    public class CustomerSessionProfile
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public AddressEntity Address { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
    }
}
