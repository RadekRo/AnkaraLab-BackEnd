namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ProductConfigDto
    {
        int Id { get; set; }
        string Name {  get; set; } = string.Empty;
        int CategoryId { get; set; }
    }
}
