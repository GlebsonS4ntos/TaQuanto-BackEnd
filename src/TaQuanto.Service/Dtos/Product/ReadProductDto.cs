using TaQuanto.Service.Dtos.Category;
using TaQuanto.Service.Dtos.Establishment;

namespace TaQuanto.Service.Dtos.Product
{
    public class ReadProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid EstablishmentId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
