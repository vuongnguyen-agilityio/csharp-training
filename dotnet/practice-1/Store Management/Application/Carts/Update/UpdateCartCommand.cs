using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.Users;

namespace Application.Carts.Update;

public record UpdateCartCommand(
    UserId UserId,
    ProductId ProductId,
    decimal Quantity) : ICommand;

public record UpdateCartRequest(
    ProductId ProductId,
    decimal Quantity);
