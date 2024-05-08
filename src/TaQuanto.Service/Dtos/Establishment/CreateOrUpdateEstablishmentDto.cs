using Microsoft.AspNetCore.Http;

namespace TaQuanto.Service.Dtos.Establishment
{
    public class CreateOrUpdateEstablishmentDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public bool IsDraft { get; set; }
        public IFormFile? Image { get; set; }
        public Guid CityId { get; set; }
    }
}
