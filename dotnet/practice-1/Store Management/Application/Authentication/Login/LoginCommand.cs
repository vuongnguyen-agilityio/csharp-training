using Application.Abstractions.Messaging;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Authentication.Login
{
    public record LoginCommand(
        string Email,
        string Password
        ) : ICommand<JwtSecurityToken>;

}
