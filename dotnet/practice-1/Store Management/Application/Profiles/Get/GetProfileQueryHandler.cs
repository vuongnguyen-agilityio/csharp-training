using Application.Data;
using Domain.Profiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Profiles.Get;

internal sealed class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileResponse>
{
    private readonly IApplicationDbContext _context;

    public GetProfileQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var profile = await _context
            .Profiles
            .Where(p => p.Id == request.ProfileId)
            .Select(p => new ProfileResponse(
                p.Id.Value,
                p.UserId.Value,
                p.FirstName,
                p.LastName,
                p.Age
               ))
            .FirstOrDefaultAsync(cancellationToken);

        if (profile is null)
        {
            throw new ProfileNotFoundException(request.ProfileId);
        }

        return profile;
    }
}
