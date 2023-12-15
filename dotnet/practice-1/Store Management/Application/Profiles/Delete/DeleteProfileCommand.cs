using Application.Abstractions.Messaging;
using Domain.Profiles;

namespace Application.Profiles.Delete;

public record DeleteProfileCommand(ProfileId ProfileId) : ICommand;
