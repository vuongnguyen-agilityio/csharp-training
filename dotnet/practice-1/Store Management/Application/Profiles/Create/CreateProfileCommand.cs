using Domain.Users;
using MediatR;

namespace Application.Profiles.Create
{
    public record CreateProfileCommand(
        UserId UserId,
        string FirstName,
        string LastName,
        int Age) : IRequest;
}
