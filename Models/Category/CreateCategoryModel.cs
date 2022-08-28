using System.ComponentModel.DataAnnotations;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Category
{
    public class CreateCategoryModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length on category name (Minimum one letter, maximum 50 letters)")]
        public string NewCategoryName { get; set; } = null!;
    }
}