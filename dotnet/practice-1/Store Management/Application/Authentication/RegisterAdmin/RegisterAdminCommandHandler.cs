using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Domain.Authentications;
using Domain.Users;
using Application.Authentication.RegisterAdmin;

namespace Application.Authentication.Register
{
    internal sealed class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand>
    {
        private readonly UserManager<BaseAuthentication> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RegisterAdminCommandHandler(UserManager<BaseAuthentication> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task Handle(RegisterAdminCommand command, CancellationToken cancellationToken)
        {
            BaseAuthentication user = new BaseAuthentication()
            {
                Email = command.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = command.Email
            };
            var result = await userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User creation failed! Please check user details and try again.");
            }

            // Create Admin Role if not existed
            if (!await roleManager.RoleExistsAsync(nameof(UserRole.Admin)))
            {
                await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.Admin)));
            }
            // Create User Role if not existed
            if (!await roleManager.RoleExistsAsync(nameof(UserRole.User)))
            {
                await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.User)));
            }

            // Set Admin Role
            if (await roleManager.RoleExistsAsync(nameof(UserRole.Admin)))
            {
                await userManager.AddToRoleAsync(user, nameof(UserRole.Admin));
            }
        }
    }
}
