using Application.Data;
using Application.Users.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.List;

internal sealed class ListUserQueryHandler : IRequestHandler<ListUserQuery, List<UserResponse>>
{
    private readonly IApplicationDbContext _context;

    public ListUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserResponse>> Handle(ListUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _context
            .Users
            .Select(p => new UserResponse(
                p.Id.Value,
                p.Email,
                p.Name,
                p.Role))
            .ToListAsync(cancellationToken);

        return users;
    }
}
