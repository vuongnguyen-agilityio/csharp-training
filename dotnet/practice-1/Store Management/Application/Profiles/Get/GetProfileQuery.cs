using Domain.Profiles;
using Domain.Users;
using MediatR;

namespace Application.Profiles.Get;

public record GetProfileQuery(ProfileId ProfileId) : IRequest<ProfileResponse>;

public record GetProfileByUserIdQuery(UserId UserId) : IRequest<ProfileResponse>;

public record ProfileResponse(
    Guid Id,
    Guid UserId,
    string FirstName,
    string LastName,
    int Age);
