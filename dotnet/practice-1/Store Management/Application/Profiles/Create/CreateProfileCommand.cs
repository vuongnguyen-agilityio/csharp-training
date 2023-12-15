using Application.Abstractions.Messaging;
using Domain.Users;

namespace Application.Profiles.Create
{
    public record CreateProfileRequest(
        string FirstName,
        string LastName,
        int Age) : ICommand;

    public record CreateProfileCommand(
        UserId UserId,
        string FirstName,
        string LastName,
        int Age) : ICommand;
}
