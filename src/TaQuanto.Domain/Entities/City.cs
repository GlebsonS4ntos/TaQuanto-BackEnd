using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class City : Entity
    {
        public string? Name {  get; set; }
        public Guid StateId { get; set; }
        [JsonIgnore]
        public State? State { get; set; }
        [JsonIgnore]
        public IEnumerable<Establishment>? Establishments { get; set; }
    }
}
