using FluentValidation;
using MinimalApi.Modules.User.Dtos;

namespace MinimalApi.Modules.User.Validators;

public class AddUserValidator : AbstractValidator<AddUserDto>
{
    public AddUserValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty or null");

        RuleFor(user => user.LastName)
            .NotEmpty()
            .WithMessage("Last name cannot be empty or null");

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty or null");

        RuleFor(user => user.Address)
            .NotEmpty()
            .WithMessage("Address cannot be empty or null");
    }
}