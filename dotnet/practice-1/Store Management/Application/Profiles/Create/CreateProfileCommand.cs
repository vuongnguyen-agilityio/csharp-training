using Domain.Users;
using MediatR;

namespace Application.Profiles.Create
{
    public record CreateProfileRequest(
        string FirstName,
        string LastName,
        int Age) : IRequest;

    public record CreateProfileCommand(
        UserId UserId,
        string FirstName,
        string LastName,
        int Age) : IRequest;
}
