using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class NewsletterDto
    {
        public int Id { get; set; }
        public string? Email { get; set; } = string.Empty;
    }
}
