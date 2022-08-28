using IsacGulaker_Uppgift_Dataatkomster.Models.Manufacturer;
using IsacGulaker_Uppgift_Dataatkomster.Models.Subcategory;
using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Product
{
    public class CreateProductModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on product name (Minimum one letter, maximum 50 letters)")]
        public string NewProductName { get; set; } = null!;

        [StringLength(600, MinimumLength = 1, ErrorMessage = "Incorrect length on product description (Minimum one letter, maximum 600 letters)")]
        public string NewProductDescription { get; set; } = null!;
        public CreateSubcategoryModel NewProductSubcategory { get; set; } = null!;
        public decimal NewProductPrice { get; set; }
        public CreateManufacturerModel NewProductManufacturer { get; set; } = null!;

        [RegularExpression("^[0-9]{13}$", ErrorMessage = "Incorrect format on EAN13 code (Accepted format: 13 digits)")]
        public string NewProductEAN_13 { get; set; } = null!;
    }
}