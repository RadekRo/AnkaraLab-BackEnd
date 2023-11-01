namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class BasketItem
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public double? Price { get;} //nie wiem czy potrzebne bo w produkcie jest jakas konkretna cena juz
    }
}
