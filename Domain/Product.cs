using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; }
        [Required]
        public string Subcategory { get; set; } = string.Empty;
        [Required]
        public string Size { get; set; } = string.Empty;
        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public int Deadline { get; set; }
        [Required]
        public bool IsAvaliable { get; set; }
        [Required]
        [MaxLength(4)]
        public int PhotoHeight { get; set; }
        [Required]
        [MaxLength(4)]
        public int PhotoWidth { get; set; }
    }
}
