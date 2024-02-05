using AnkaraLab_BackEnd.WebAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ClientForShippingDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Discount { get; set; }
        public List<ShippingAdress?> DeliveryAdress { get; set; }
    }
}
