using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsacGulaker_Uppgift_Dataatkomster.Data.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(13)]
        public string ProductEAN_13 { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        [Required]
        public string CustomerFirstName { get; set; } = null!;

        [Required]
        public string CustomerLastName { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;
        public string? ResidenceNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string OrderStatus { get; set; } = null!;
    }
}
