namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}
