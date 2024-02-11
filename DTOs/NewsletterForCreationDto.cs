using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class NewsletterForCreationDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
