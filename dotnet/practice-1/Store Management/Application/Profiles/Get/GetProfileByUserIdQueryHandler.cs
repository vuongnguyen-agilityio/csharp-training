using Application.Data;
using Domain.Profiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Profiles.Get;

internal sealed class GetProfileByUserIdQueryHandler : IRequestHandler<GetProfileByUserIdQuery, ProfileResponse>
{
    private readonly IApplicationDbContext _context;

    public GetProfileByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProfileResponse> Handle(GetProfileByUserIdQuery request, CancellationToken cancellationToken)
    {
        var profile = await _context
            .Profiles
            .Where(p => p.UserId == request.UserId)
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
            throw new ProfileByUserIdNotFoundException(request.UserId);
        }

        return profile;
    }
}
