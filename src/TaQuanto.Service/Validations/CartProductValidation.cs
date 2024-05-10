using FluentValidation;
using TaQuanto.Service.Dtos.CartProduct;

namespace TaQuanto.Service.Validations
{
    public class CartProductValidation : AbstractValidator<CreateOrUpdateCartProductDto>
    {
        public CartProductValidation() 
        {
            RuleFor(cp => cp.ProductId)
                .NotNull().WithMessage("O Item deve ter um Produto.")
                .NotEmpty().WithMessage("O Item deve ter um Produto.");

            RuleFor(cp => cp.Quantity)
                .GreaterThanOrEqualTo(1).WithMessage("A quantidade de Produtos deve ser maior que 0.");
        }
    }
}
