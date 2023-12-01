using MediatR;
using Microsoft.AspNetCore.Identity;

using Domain.Authentications;

namespace Application.Authentication.Register
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly UserManager<BaseAuthentication> userManager;

        public RegisterCommandHandler(UserManager<BaseAuthentication> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
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
        }
    }
}
