using Application.Users.Get;
using MediatR;

namespace Application.Users.List;

public record ListUserQuery() : IRequest<List<UserResponse>>;
