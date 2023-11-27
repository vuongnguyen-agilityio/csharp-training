using Application.Data;
using Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Get;

internal sealed class ListUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IApplicationDbContext _context;

    public ListUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .Where(p => p.Id == request.UserId)
            .Select(p => new UserResponse(
                p.Id.Value,
                p.Email,
                p.Name,
                p.Role
               ))
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        return user;
    }
}
