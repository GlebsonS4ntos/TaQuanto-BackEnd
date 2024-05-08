using FluentValidation;
using Microsoft.AspNetCore.Http;
using TaQuanto.Service.Dtos.Product;

namespace TaQuanto.Service.Validations
{
    public class ProductValidation : AbstractValidator<CreateOrUpdateProductDto>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("O Nome do Produto não pode ser nulo.")
                .NotEmpty().WithMessage("O Nome do Produto não pode ser em branco.")
                .MinimumLength(3).WithMessage("O Nome do Produto precisa de no minimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O Nome do Produto precisa ter no maximo 100 caracteres");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("A Descrição não pode ser nula.")
                .NotEmpty().WithMessage("A Descrição não pode ser em branco.")
                .MinimumLength(5).WithMessage("A Descrição precisa de no minimo 5 caracteres.")
                .MaximumLength(200).WithMessage("A Descrição precisa ter no maximo 200 caracteres");

            RuleFor(p => p.Image)
                .NotNull().WithMessage("Um Produto deve Conter uma Imagem.")
                .NotEmpty().WithMessage("Um Produto deve Conter uma Imagem.")
                .Must(VerifyExtencion).WithMessage("O Arquivo da Imagem adicionada não tem uma extensão suportada.");

            RuleFor(p => p.EstablishmentId)
                .NotNull().WithMessage("O Produto deve pertencer a um Estabelecimento.")
                .NotEmpty().WithMessage("O Produto deve pertencer a um Estabelecimento.");

            RuleFor(p => p.OriginalPrice)
                .Must((p, originalPrice) => VerifyOriginalPrice(originalPrice, p.Price)).WithMessage("O Produto deve ter um Preço Original Válido.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("")
                .GreaterThan(0).WithMessage("");

            RuleFor(p => p.CategoryId)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("");

        }

        private bool VerifyExtencion(IFormFile? image)
        {
            var supportedExtencions = new[] { ".jpg", ".png", ".jpeg" };
            var extencionFile = Path.GetExtension(image.FileName).ToLowerInvariant();

            return supportedExtencions.Contains(extencionFile);
        }

        private bool VerifyOriginalPrice(decimal? originalPrice, decimal? price)
        {
            if(originalPrice == null) 
            {
                return true;
            }else if(originalPrice > price)
            {
                return true;
            }
            return false;
        }
    }
}
