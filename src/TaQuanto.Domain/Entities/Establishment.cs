using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class Establishment : Entity
    {
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? ImageBannerUrl { get; set; }
        public string? ImageUrl {  get; set; }
        public Guid CityId { get; set; }
        [JsonIgnore]
        public City? City { get; set; }
        [JsonIgnore]
        public IEnumerable<Product>? Products { get; set; }
    }
}