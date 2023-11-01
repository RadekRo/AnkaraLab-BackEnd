using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Order
    {
        [Key]
        public int OrderId { get; }
        [Required]
        [StringLength(250)]
        public string? DeliveryAddress { get; set; }

        public string? InvoiceAddress { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }
        [Required]
        public string? PaymentStatus { get; set; }
    }
}
