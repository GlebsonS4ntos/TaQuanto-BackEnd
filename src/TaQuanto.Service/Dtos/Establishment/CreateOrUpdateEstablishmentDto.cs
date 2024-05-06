using Microsoft.AspNetCore.Http;
using TaQuanto.Service.Dtos.City;

namespace TaQuanto.Service.Dtos.Establishment
{
    public class CreateOrUpdateEstablishmentDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public IFormFile? ImageBanner { get; set; }
        public IFormFile? Image { get; set; }
        public Guid CityId { get; set; }
    }
}
