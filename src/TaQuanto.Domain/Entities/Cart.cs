using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class Cart : Entity
    {
        [JsonIgnore]
        public virtual IEnumerable<CartProduct>? CartProducts { get; set; }
        public decimal? ValueCart { get; set; }
    }
}
