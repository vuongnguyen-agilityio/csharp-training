using Domain.Profiles;
using MediatR;

namespace Application.Profiles.Delete;

public record DeleteProfileCommand(ProfileId ProfileId) : IRequest;
