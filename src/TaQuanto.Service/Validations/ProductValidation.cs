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
                .NotNull().WithMessage("O Produto deve possuir um Nome.")
                .NotEmpty().WithMessage("O Produto deve possuir um Nome.")
                .MinimumLength(3).WithMessage("O Nome do Produto precisa de no minimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O Nome do Produto precisa ter no maximo 100 caracteres");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("A Descrição não pode ser nula.")
                .NotEmpty().WithMessage("A Descrição não pode ser em branco.")
                .MinimumLength(5).WithMessage("A Descrição precisa de no minimo 5 caracteres.")
                .MaximumLength(200).WithMessage("A Descrição precisa ter no maximo 200 caracteres");

            RuleFor(p => p.Image)
                .Must((p, image) => VerifyImageIsNullInAdd(image, p.Id)).WithMessage("Adicione o Arquivo de Imagem.")
                .Must((p, image) => VerifyExtencion(image, p.Id)).WithMessage("O Arquivo da Imagem adicionada não tem uma extensão suportada.")
                .Must((p, image) => VerifyImageSize(image, p.Id)).WithMessage("O Arquivo da Imagem adicionada é maior que 5MB");

            RuleFor(p => p.EstablishmentId)
                .NotNull().WithMessage("O Produto deve pertencer a um Estabelecimento.")
                .NotEmpty().WithMessage("O Produto deve pertencer a um Estabelecimento.");

            RuleFor(p => p.OriginalPrice)
                .Must((p, originalPrice) => VerifyOriginalPrice(originalPrice, p.Price)).WithMessage("O Produto deve ter um Preço Original Válido.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("O Produto deve ter um Preco.")
                .NotEmpty().WithMessage("O Produto deve ter um Preco")
                .GreaterThan(0).WithMessage("O Preco do Produto deve ser maior que 0.");

            RuleFor(p => p.CategoryId)
                .NotNull().WithMessage("O Produto deve ter uma Categoria")
                .NotEmpty().WithMessage("O Produto deve ter uma Categoria");
        }

        private bool VerifyExtencion(IFormFile? image, Guid? id)
        {
            if (id != null && image == null)
            {
                return true;
            }

            var supportedExtencions = new[] { ".jpg", ".png", ".jpeg" };
            var extencionFile = Path.GetExtension(image.FileName).ToLowerInvariant();

            return supportedExtencions.Contains(extencionFile);
        }

        private bool VerifyOriginalPrice(decimal? originalPrice, decimal? price)
        {
            if(originalPrice == null || originalPrice == 0) 
            {
                return true;
            }else if(originalPrice > price)
            {
                return true;
            }
            return false;
        }

        private bool VerifyImageSize(IFormFile? image, Guid? id)
        {
            if (id != null && image == null)
            {
                return true;
            }

            var imageSizeInBytes = image.Length;
            double imageSizeInMb = imageSizeInBytes / 1048576.0;
            if(imageSizeInMb <= 5)
            {
                return true;
            }
            return false;
        }

        private bool VerifyImageIsNullInAdd(IFormFile? image, Guid? id)
        {
            if (id == null && image == null)
            {
                return false;
            }
            return true;
        }
    }
}
