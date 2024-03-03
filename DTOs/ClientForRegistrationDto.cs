using AnkaraLab_BackEnd.WebAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ClientForRegistrationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
