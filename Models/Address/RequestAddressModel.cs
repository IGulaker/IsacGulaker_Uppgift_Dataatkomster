namespace IsacGulaker_Uppgift_Dataatkomster.Models.Address
{
    public class RequestAddressModel
    {
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string? ResidenceNumber { get; set; }
    }
}