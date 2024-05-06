namespace TaQuanto.Service.Dtos.Product
{
    public class ReadProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}
