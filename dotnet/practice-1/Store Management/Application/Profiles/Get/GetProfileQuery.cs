using Application.Abstractions.Messaging;
using Domain.Profiles;
using Domain.Users;

namespace Application.Profiles.Get;

public record GetProfileQuery(ProfileId ProfileId) : ICommand<ProfileResponse>;

public record GetProfileByUserIdQuery(UserId UserId) : ICommand<ProfileResponse>;

public record ProfileResponse(
    Guid Id,
    Guid UserId,
    string FirstName,
    string LastName,
    int Age);
