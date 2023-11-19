using FluentValidation;
using KatmanliBurger_UI.DTOs.BurgerViewDtos;
using KatmanliBurger_UI.Helpers;

namespace KatmanliBurger_UI.ValidationRules.BurgerDtosValidations
{
    public class BurgerUpdateDtoValidator : AbstractValidator<BurgerUpdateDto>
    {
        public BurgerUpdateDtoValidator()
        {
            RuleFor(s => s.Name).MinimumLength(5).WithMessage(ErrorMessageProvider.GetErrorMessage("Deneme"));
            RuleFor(s => s.Price).NotEqual(0).WithMessage(ErrorMessageProvider.GetErrorMessage("Deneme"));
        }
    }
}
