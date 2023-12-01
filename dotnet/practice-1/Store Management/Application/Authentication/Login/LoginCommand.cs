using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Authentication.Login
{
    public record LoginCommand(
        string Email,
        string Password
        ) : IRequest<JwtSecurityToken>;

}
