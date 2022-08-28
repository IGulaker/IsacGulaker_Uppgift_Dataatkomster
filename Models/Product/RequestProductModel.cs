using IsacGulaker_Uppgift_Dataatkomster.Models.Manufacturer;
using IsacGulaker_Uppgift_Dataatkomster.Models.Subcategory;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Product
{
    public class RequestProductModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public RequestSubcategoryModel Subcategory { get; set; } = null!;
        public decimal Price { get; set; }
        public RequestManufacturerModel Manufacturer { get; set; } = null!;
        public string EAN_13 { get; set; } = null!;
    }
}