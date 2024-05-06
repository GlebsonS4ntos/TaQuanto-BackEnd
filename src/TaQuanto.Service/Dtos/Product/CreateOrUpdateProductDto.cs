using Microsoft.AspNetCore.Http;

namespace TaQuanto.Service.Dtos.Product
{
    public class CreateOrUpdateProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal NewPrice { get; set; }
        public IFormFile? Image { get; set; }
        public Guid EstablishmentId { get; set; }
    }
}
