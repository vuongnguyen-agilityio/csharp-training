using Application.Abstractions.Messaging;

namespace Application.Authentication.RegisterAdmin
{
    public record RegisterAdminCommand(
        string Email,
        string Name,
        string Password) : ICommand;
}
