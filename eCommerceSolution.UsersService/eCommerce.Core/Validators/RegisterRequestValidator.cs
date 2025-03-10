using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
{
  public RegisterRequestValidator()
  {
    RuleFor(temp => temp.Email)
      .NotEmpty().WithMessage("email is required")
      .EmailAddress().WithMessage("Invalid email address format");

    RuleFor(temp => temp.Password)
      .NotEmpty().WithMessage("password is required")
      .MinimumLength(8).WithMessage("The password must have more than 7 characters.");

    RuleFor(temp => temp.PersonName)
      .NotEmpty().WithMessage("personName is required")
      .Length(1, 50).WithMessage("personName should be 1 to 50 characters long");

    RuleFor(temp => temp.Gender)
      .IsInEnum().WithMessage("Invalid gender value");
  }
}
