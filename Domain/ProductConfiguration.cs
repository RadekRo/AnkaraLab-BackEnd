using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class ProductConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int SQMPrice { get; set; }
        [Required]
        public int OptionLevel { get; set; }
        public Category Category { get; set; } = default!;
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
    }
}
