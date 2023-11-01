using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
