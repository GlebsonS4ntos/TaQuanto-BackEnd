using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class Cart : Entity
    {
        [JsonIgnore]
        public IEnumerable<CartProduct>? CartProducts { get; set; }
    }
}
