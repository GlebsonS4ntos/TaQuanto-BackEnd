﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using TaQuanto.Service.Dtos.Establishment;

namespace TaQuanto.Service.Validations
{
    public class EstablishmentValidation : AbstractValidator<CreateOrUpdateEstablishmentDto>
    {
        public EstablishmentValidation()
        {
            RuleFor(e => e.Name)
                .NotNull().WithMessage("O Estabelecimento deve possuir um nome.")
                .NotEmpty().WithMessage("O Estabelecimento deve possuir um nome.")
                .MinimumLength(3).WithMessage("O Nome do Estabelecimento precisa de no minimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O Nome do Estabelecimento precisa ter no maximo 100 caracteres");

            RuleFor(e => e.Image)
                .Must((e, image) => VerifyImageIsNullInAdd(image, e.Id)).WithMessage("Adicione o Arquivo de Imagem.")
                .Must(VerifyExtencion).WithMessage("O Arquivo da Imagem adicionada não tem uma extensão suportada.")
                .Must(VerifyImageSize).WithMessage("O Arquivo da Imagem adicionada é maior que 5MB");

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

        private bool VerifyImageSize(IFormFile? image)
        {
            var imageSizeInBytes = image.Length;
            double imageSizeInMb = imageSizeInBytes / 1048576.0;
            if (imageSizeInMb <= 5)
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