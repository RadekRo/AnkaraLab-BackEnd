using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class OrderForCreationDto
    {
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        public string InvoiceAddress { get; set;} = string.Empty;

        [Required]
        public string PaymentMethod { get; set;} = string.Empty;
        [Required]
        public string PaymentStatus { get; set; } = string.Empty;
    }
}
