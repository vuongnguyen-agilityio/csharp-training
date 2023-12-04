using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Update;

public record UpdateCartCommand(
    UserId UserId,
    ProductId ProductId,
    decimal Quantity) : IRequest;

public record UpdateCartRequest(
    ProductId ProductId,
    decimal Quantity);
