using Application.Abstractions.Messaging;
using Application.Profiles.Get;

namespace Application.Profiles.List;

public record ListProfileQuery() : ICommand<List<ProfileResponse>>;
