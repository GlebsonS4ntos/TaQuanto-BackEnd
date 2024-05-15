using TaQuanto.Service.Dtos.State;

namespace TaQuanto.Service.Dtos.City
{
    public class ReadCityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid StateId { get; set; }
    }
}
