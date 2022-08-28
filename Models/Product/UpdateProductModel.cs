using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Product
{
    public class UpdateProductModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on product name (Minimum one letter, maximum 50 letters)")]
        public string NewProductName { get; set; } = null!;

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on product description (Minimum one letter, maximum 50 letters)")]
        public string NewProductDescription { get; set; } = null!;
        public decimal NewProductPrice { get; set; }
    }
}