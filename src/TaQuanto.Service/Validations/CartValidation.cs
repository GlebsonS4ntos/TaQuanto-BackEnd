using FluentValidation;
using TaQuanto.Service.Dtos.Cart;

namespace TaQuanto.Service.Validations
{
    public class CartValidation : AbstractValidator<CreateOrUpdateCartDto>
    {
        public CartValidation() 
        {
            RuleFor(c => c.CartProducts)
                .NotNull().WithMessage("Deve ter 1 ou mais Itens para o Carrinho ser Salvo.")
                .NotEmpty().WithMessage("Deve ter 1 ou mais Itens para o Carrinho ser Salvo.");
        }
    }
}
