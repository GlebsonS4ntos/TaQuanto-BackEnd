namespace TaQuanto.Domain.Pagination
{
    public class ProductParameters : PageParameters
    {
        public Guid? CategoryId { get; set; }
        public Guid? EstablishmentId { get; set; }
        public string? Name { get; set; }
        public bool? OnSale { get; set; }
    }
}
