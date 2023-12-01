﻿using MediatR;
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
        private readonly IConfiguration _configuration;

        public RegisterAdminCommandHandler(UserManager<BaseAuthentication> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task Handle(RegisterAdminCommand command, CancellationToken cancellationToken)
        {
            var userExists = await userManager.FindByNameAsync(command.Email);
            if (userExists != null)
            {
                throw new Exception("User already exists!");
            }


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

            if (!await roleManager.RoleExistsAsync(nameof(UserRole.Admin)))
                await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.Admin)));
            if (!await roleManager.RoleExistsAsync(nameof(UserRole.User)))
                await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.User)));

            if (await roleManager.RoleExistsAsync(nameof(UserRole.Admin)))
            {
                await userManager.AddToRoleAsync(user, nameof(UserRole.Admin));
            }
        }
    }
}
