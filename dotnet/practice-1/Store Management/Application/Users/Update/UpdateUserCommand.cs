using Domain.Users;
using MediatR;

namespace Application.Users.Update;

public record UpdateUserCommand(
    UserId UserId,
    string Name,
    string Password
    ) : IRequest;

public record UpdateUserRequest(
    string Name,
    string Password);
