using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        // Product ID nie powinien być listą, jako że koszyk przechowuje listę produktów???
        public int Quantity { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
      
    }
}
