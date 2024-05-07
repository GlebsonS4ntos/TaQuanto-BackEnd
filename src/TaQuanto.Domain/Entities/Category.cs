using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class Category : Entity
    {
        public string? Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Product>? Products { get; set; }
        public Guid ParentCategoriaId { get; set; }
        public Category? ParentCategory { get; set; }
    }
}