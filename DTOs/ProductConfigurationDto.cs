namespace AnkaraLab_BackEnd.WebAPI.DTOs
{
    public class ProductConfigurationDto
    {
        public int Id { get; set; }
        public string Name {  get; set; } = string.Empty;
        public int SQMPrice { get; set; }
        public int OptionLevel { get; set; }
        public int CategoryId { get; set; }
    }
}
