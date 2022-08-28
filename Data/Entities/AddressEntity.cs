using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsacGulaker_Uppgift_Dataatkomster.Data.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;
        public string? ResidenceNumber { get; set; }
    }
}
