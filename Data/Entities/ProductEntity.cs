using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsacGulaker_Uppgift_Dataatkomster.Data.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public SubcategoryEntity Subcategory { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public ManufacturerEntity Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(13)]
        public string EAN_13 { get; set; } = null!;

        [Required]
        public DateTime LastModified { get; set; }
    }
}
