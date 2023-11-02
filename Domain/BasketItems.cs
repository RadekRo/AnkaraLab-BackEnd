using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class BasketItems
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Product? Product { get; set; }
        public int Quantity { get; set; } = 0;
        [Required]
        public int ClientId { get; set; }
    }
}
