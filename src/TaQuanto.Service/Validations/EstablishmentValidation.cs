using FluentValidation;
using Microsoft.AspNetCore.Http;
using TaQuanto.Service.Dtos.Establishment;

namespace TaQuanto.Service.Validations
{
    public class EstablishmentValidation : AbstractValidator<CreateOrUpdateEstablishmentDto>
    {
        public EstablishmentValidation()
        {
            RuleFor(e => e.Name)
                .NotNull().WithMessage("O Nome do Estabelecimento não pode ser nulo.")
                .NotEmpty().WithMessage("O Nome do Estabelecimento não pode ser em branco.")
                .MinimumLength(3).WithMessage("O Nome do Estabelecimento precisa de no minimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O Nome do Estabelecimento precisa ter no maximo 100 caracteres");

            RuleFor(e => e.Image)
                .NotNull().WithMessage("Um Estabelecimento deve Conter uma Imagem.")
                .NotEmpty().WithMessage("Um Estabelecimento deve Conter uma Imagem.")
                .Must(VerifyExtencion).WithMessage("O Arquivo da Imagem adicionada não tem uma extensão suportada.");

            RuleFor(e => e.Adress)
                .NotNull().WithMessage("O Endereço do Estabelecimento Precisa ser Preenchido.")
                .NotEmpty().WithMessage("O Endereço do Estabelecimento Precisa ser Preenchido.")
                .MinimumLength(3).WithMessage("O Endereço deve ter mais de 3 caracteres.")
                .MaximumLength(100).WithMessage("O Endereço deve ter menos de 100 caracteres.");

            RuleFor(e => e.CityId)
                .NotNull().WithMessage("Um Estabelecimento precisa pertencer a uma Cidade")
                .NotEmpty().WithMessage("Um Estabelecimento precisa pertencer a uma Cidade");

            RuleFor(e => e.IsDraft)
                .NotNull().WithMessage("Você deve especificar se o Estabelecimento é apenas um Rascunho.")
                .NotEmpty().WithMessage("Você deve especificar se o Estabelecimento é apenas um Rascunho.");
        }

        private bool VerifyExtencion(IFormFile? image)
        {
            var supportedExtencions = new[] { ".jpg", ".png", ".jpeg" };
            var extencionFile = Path.GetExtension(image.FileName).ToLowerInvariant();

            return supportedExtencions.Contains(extencionFile);
        }
    }
}