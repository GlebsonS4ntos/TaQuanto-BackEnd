using TaQuanto.Service.Dtos.City;

namespace TaQuanto.Service.Dtos.Establishment
{
    public class ReadEstablishmentDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? ImageBannerUrl { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CityId { get; set; }
        public ReadCityDto? City { get; set; }
    }
}
