using IsacGulaker_Uppgift_Dataatkomster.Models.Address;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Manufacturer
{
    public class RequestManufacturerModel
    {
        public string Name { get; set; } = null!;
        public RequestAddressModel Address { get; set; } = null!;
    }
}