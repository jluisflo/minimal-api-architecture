using FluentValidation;
using MinimalApi.Modules.User.Dtos;

namespace MinimalApi.Modules.User.Validators;

public class SaveUserValidator : AbstractValidator<SaveUserDto>
{
    public SaveUserValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty or null");
    }
}