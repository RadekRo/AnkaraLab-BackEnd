using Microsoft.Identity.Client;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string DeliveryAddress { get; set; } = string.Empty;

        public string InvoiceAddress {  get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public string PaymentStatus {  get; set; } = string.Empty;
    }
}
