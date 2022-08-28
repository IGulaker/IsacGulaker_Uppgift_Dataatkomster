using IsacGulaker_Uppgift_Dataatkomster.Models.Manufacturer;
using IsacGulaker_Uppgift_Dataatkomster.Models.Subcategory;
using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Product
{
    public class CreateProductModel
    {
        [RegularExpression("^[A-ö0-9]+$", ErrorMessage = "Incorrect format on description (Product requires a name)")]
        public string NewProductName { get; set; } = null!;

        [RegularExpression("^[A-ö0-9]+$", ErrorMessage = "Incorrect format on description (Product requires a description)")]
        public string NewProductDescription { get; set; } = null!;
        public CreateSubcategoryModel NewProductSubcategory { get; set; } = null!;
        public decimal NewProductPrice { get; set; }
        public CreateManufacturerModel NewProductManufacturer { get; set; } = null!;

        [RegularExpression("^[0-9]{13}$", ErrorMessage = "Incorrect format on EAN13 code (Accepted format: 13 digits)")]
        public string NewProductEAN_13 { get; set; } = null!;
    }
}