using MediatR;

namespace Application.Authentication.RegisterAdmin
{
    public record RegisterAdminCommand(
        string Email,
        string Name,
        string Password) : IRequest;
}
