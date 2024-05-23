namespace TaQuanto.Domain.Pagination
{
    public class EstablishmentParameters : PageParameters
    {
        public Guid? CityId { get; set; }
        public string? Name { get; set; }
        public bool? IsDraft { get; set; }
    }
}
