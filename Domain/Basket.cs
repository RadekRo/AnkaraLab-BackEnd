namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Basket
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public Product? Product { get; set; } //to mi chyba juz nie jest potrzebne, bo w BasketItem juz jest a tu tworze liste BasketItemow

        public Basket() 
        {
            new List<BasketItem>();
        }

    }
}
