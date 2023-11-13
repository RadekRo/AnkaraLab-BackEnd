using Microsoft.Identity.Client;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class FaqDto
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
