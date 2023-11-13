using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class LoyaltyProgramDto
    {

        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public int Points { get; set; }
    }
}
