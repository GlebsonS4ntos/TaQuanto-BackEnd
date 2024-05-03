using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string? ImageUrl { get; set; }
        public Guid EstablishmentId { get; set; }
        [JsonIgnore]
        public Establishment? Establishment { get; set; }
    }
}
