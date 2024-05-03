using System.Text.Json.Serialization;

namespace TaQuanto.Domain.Entities
{
    public class State : Entity
    {
        public string? Name { get; set; }
        public string? UF { get; set; }
        [JsonIgnore]
        public IEnumerable<City>? Cities { get; set; }
    }
}
