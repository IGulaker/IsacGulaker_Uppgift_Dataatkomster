using IsacGulaker_Uppgift_Dataatkomster.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Subcategory
{
    public class CreateSubcategoryModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on subcategory name (Minimum one letter, maximum 50 letters)")]
        public string NewSubcategoryName { get; set; } = null!;

        public CreateCategoryModel NewSubcategoryCategory { get; set; } = null!;
    }
}