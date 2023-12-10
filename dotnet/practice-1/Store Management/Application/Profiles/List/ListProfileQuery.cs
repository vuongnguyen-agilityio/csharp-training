using Application.Profiles.Get;
using MediatR;

namespace Application.Profiles.List;

public record ListProfileQuery() : IRequest<List<ProfileResponse>>;
