using TaQuanto.Service.Dtos.Product;

namespace TaQuanto.Service.Dtos.CartProduct
{
    public class ReadCartProductDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public ReadProductDto? Product { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
    }
}
