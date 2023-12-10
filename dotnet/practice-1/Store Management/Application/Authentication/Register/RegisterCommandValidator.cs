using Domain.Authentications;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly UserManager<BaseAuthentication> userManager;

        public RegisterCommandValidator(UserManager<BaseAuthentication> userManager)
        {
            this.userManager = userManager;

            RuleFor(user => user.Email).EmailAddress().WithMessage("The email invalid format");

            RuleFor(user => user.Email).MustAsync(async (email, _) =>
            {
                return await this.userManager.FindByNameAsync(email) == null;
            }).WithMessage("User already existed");

            RuleFor(user => user.Password).MinimumLength(8).WithMessage("Password must be larger than 8 characters");
        }
    }
}
