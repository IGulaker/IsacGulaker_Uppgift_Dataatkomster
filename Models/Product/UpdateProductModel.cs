using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Product
{
    public class UpdateProductModel
    {
        [RegularExpression("^[A-ö0-9]+$", ErrorMessage = "Incorrect format on description (Product requires a name)")]
        public string NewProductName { get; set; } = null!;

        [RegularExpression("^[A-ö0-9]+$", ErrorMessage = "Incorrect format on description (Product requires a description)")]
        public string NewProductDescription { get; set; } = null!;
        public decimal NewProductPrice { get; set; }
    }
}