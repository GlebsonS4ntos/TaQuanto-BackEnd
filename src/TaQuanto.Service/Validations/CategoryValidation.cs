using FluentValidation;
using TaQuanto.Service.Dtos.Category;

namespace TaQuanto.Service.Validations
{
    public class CategoryValidation : AbstractValidator<CreateOrUpdateCategoryDto>
    {
        public CategoryValidation() 
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("A Categoria deve possuir um Nome.");

            RuleFor(c => c.Name)
                .NotEmpty().When(c => c.Name != null).WithMessage("A Categoria deve possuir um Nome.")
                .MinimumLength(3).WithMessage("O Nome da Categoria deve possuir mais de 3 Caracteres.")
                .MaximumLength(100).WithMessage("O Nome da Categoria deve possuir menos de 100 Caracteres.");
        }
    }
}
