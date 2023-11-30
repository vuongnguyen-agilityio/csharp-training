﻿using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Delete
{
    public record DeleteCartCommand(UserId UserId, ProductId ProductId) : IRequest;
}