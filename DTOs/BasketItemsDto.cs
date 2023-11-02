using AnkaraLab_BackEnd.WebAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class BasketItemsDto
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } = 0;
        public int ClientId { get; set; }
    }
}
