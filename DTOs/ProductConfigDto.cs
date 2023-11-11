namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ProductConfigDto
    {
        int Id { get; set; }
        string Name {  get; set; } = string.Empty;
        int SQMPrice { get; set; }
        int OptionLevel { get; set; }
        int CategoryId { get; set; }
    }
}
