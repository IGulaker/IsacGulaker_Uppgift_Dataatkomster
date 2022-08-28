namespace IsacGulaker_Uppgift_Dataatkomster.Models.Order
{
    public class RequestOrderModel
    {
        public string ProductName { get; set; } = null!;
        public string ProductEAN_13 { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string? ResidenceNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public string OrderStatus { get; set; } = null!;
    }
}