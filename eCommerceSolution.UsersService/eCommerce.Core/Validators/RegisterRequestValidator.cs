using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
{
  public RegisterRequestValidator()
  {
    RuleFor(temp => temp.Email)
      .NotEmpty().WithMessage("The field email is required")
      .EmailAddress().WithMessage("Invalid email address format");

    RuleFor(temp => temp.Password)
      .NotEmpty().WithMessage("The field password is required");

    RuleFor(temp => temp.PersonName)
      .NotEmpty().WithMessage("The field personName is required");

    RuleFor(temp => temp.Gender)
      .NotEmpty().WithMessage("The field gender is required")
      .IsInEnum().WithMessage("Invalid gender value");
  }
}
