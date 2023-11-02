namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Basket
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<BasketItems> BasketItems { get; set; } = new List<BasketItems>();


    }
}
