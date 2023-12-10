using Domain.Authentications;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.RegisterAdmin
{
    public sealed class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        private readonly UserManager<BaseAuthentication> userManager;

        public RegisterAdminCommandValidator(UserManager<BaseAuthentication> userManager)
        {
            this.userManager = userManager;

            RuleFor(user => user.Email).EmailAddress().WithMessage("The email invalid format");

            RuleFor(user => user.Email).MustAsync(async (email, _) =>
            {
                return await this.userManager.FindByNameAsync(email) == null;
            }).WithMessage("Admin already existed");

            RuleFor(user => user.Password).MinimumLength(8).WithMessage("Password must be larger than 8 characters");
        }
    }
}
