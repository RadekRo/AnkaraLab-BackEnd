using AnkaraLab_BackEnd.WebAPI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; }
        public string Size { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Deadline { get; set; }
        public bool IsAvaliable { get; set; }
        public int PhotoHeight { get; set; }
        public int PhotoWidth { get; set; }
        public Category Category { get; set; } = default!;
    }
}
