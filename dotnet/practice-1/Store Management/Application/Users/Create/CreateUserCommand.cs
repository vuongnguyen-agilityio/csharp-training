﻿using MediatR;

namespace Application.Users.Create
{
    public record CreateUserCommand(
        string Email,
        string Name,
        string Password) : IRequest;
}
