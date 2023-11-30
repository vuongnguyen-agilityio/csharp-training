using MediatR;

namespace Application.Authentication.Login
{
    public record LoginCommand(
        string Email,
        string Password
        ) : IRequest;
}
