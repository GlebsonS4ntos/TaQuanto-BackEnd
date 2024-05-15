using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class CartProduct : Entity
    {
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        public Guid CartId { get; set; }
        [JsonIgnore]
        public virtual Cart? Cart { get; set; }
        public int Quantity { get; set; }
    }
}
