using Domain.Profiles;
using MediatR;

namespace Application.Profiles.Update;

public record UpdateProfileCommand(
    ProfileId ProfileId,
    string FirstName,
    string LastName,
    int Age
    ) : IRequest;

public record UpdateProfileRequest(
    string FirstName,
    string LastName,
    int Age);
