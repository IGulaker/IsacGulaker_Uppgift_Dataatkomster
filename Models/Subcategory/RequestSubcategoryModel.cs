using IsacGulaker_Uppgift_Dataatkomster.Models.Category;

namespace IsacGulaker_Uppgift_Dataatkomster.Models.Subcategory
{
    public class RequestSubcategoryModel
    {
        public string Name { get; set; } = null!;
        public RequestCategoryModel Category { get; set; } = null!;
    }
}