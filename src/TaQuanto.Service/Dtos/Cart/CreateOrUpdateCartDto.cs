using TaQuanto.Service.Dtos.CartProduct;

namespace TaQuanto.Service.Dtos.Cart
{
    public class CreateOrUpdateCartDto
    {
        public Guid? Id { get; set; }
        public IEnumerable<CreateOrUpdateCartProductDto>? CartProducts { get; set; }
    }
}
