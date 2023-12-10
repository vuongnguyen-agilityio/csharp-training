using Application.Data;
using Application.Profiles.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Profiles.List;

internal sealed class ListProfileQueryHandler : IRequestHandler<ListProfileQuery, List<ProfileResponse>>
{
    private readonly IApplicationDbContext _context;

    public ListProfileQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProfileResponse>> Handle(ListProfileQuery request, CancellationToken cancellationToken)
    {
        var profiles = await _context
            .Profiles
            .Select(p => new ProfileResponse(
                p.Id.Value,
                p.UserId.Value,
                p.FirstName,
                p.LastName,
                p.Age))
            .ToListAsync(cancellationToken);

        return profiles;
    }
}
