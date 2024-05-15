namespace TaQuanto.Service.Dtos.CartProduct
{
    public class CreateOrUpdateCartProductDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
