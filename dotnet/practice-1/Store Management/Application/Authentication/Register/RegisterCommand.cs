using Application.Abstractions.Messaging;

namespace Application.Authentication.Register
{
    public record RegisterCommand(
        string Email,
        string Name,
        string Password) : ICommand;
}
