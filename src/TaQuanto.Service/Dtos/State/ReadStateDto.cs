using TaQuanto.Service.Dtos.City;

namespace TaQuanto.Service.Dtos.State
{
    public class ReadStateDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? UF { get; set; }
        public IEnumerable<ReadCityDto>? Cities { get; set; }
    }
}
