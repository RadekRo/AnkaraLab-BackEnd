using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ProductForCreationDto
    {
        [Required]
        public string Size { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public int Deadline { get; set; }
        [Required]
        public bool IsAvaliable { get; set; }
        [Required]
        public int PhotoHeight { get; set; }
        [Required]
        public int PhotoWidth { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
