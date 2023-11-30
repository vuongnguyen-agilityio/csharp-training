﻿using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Create
{
    public record CreateCartCommand(
        UserId UserId,
        ProductId ProductId,
        decimal Quantity
        ) : IRequest;
}