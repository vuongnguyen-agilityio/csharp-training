using MediatR;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Domain.Authentications;

namespace Application.Authentication.Login
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, JwtSecurityToken>
    {
        private readonly UserManager<BaseAuthentication> userManager;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<BaseAuthentication> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;
        }

        public async Task<JwtSecurityToken> Handle(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(loginCommand.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, loginCommand.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                return new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
            }
            throw new Exception("Unauthorized");
        }
    }
}
