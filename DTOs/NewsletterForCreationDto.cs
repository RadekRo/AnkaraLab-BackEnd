using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class NewsletterForCreationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
