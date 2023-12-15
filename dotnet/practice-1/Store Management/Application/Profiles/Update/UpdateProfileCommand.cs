using Application.Abstractions.Messaging;
using Domain.Profiles;

namespace Application.Profiles.Update;

public record UpdateProfileCommand(
    ProfileId ProfileId,
    string FirstName,
    string LastName,
    int Age
    ) : ICommand;

public record UpdateProfileRequest(
    string FirstName,
    string LastName,
    int Age);
