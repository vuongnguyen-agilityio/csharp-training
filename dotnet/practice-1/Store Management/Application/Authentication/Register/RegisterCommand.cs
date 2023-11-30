using MediatR;

namespace Application.Authentication.Register
{
    public record RegisterCommand(
        string Email,
        string Name,
        string Password) : IRequest;
}
